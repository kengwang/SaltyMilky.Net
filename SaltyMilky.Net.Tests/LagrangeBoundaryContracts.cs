using System.Text.Json;
using System.Text.Json.Nodes;
using SaltyMilky.Net;

namespace SaltyMilky.Net.Tests;

// This BCL-only probe also runs inside the published Native AOT smoke executable.
internal static class LagrangeBoundaryContracts
{
    internal static async Task RunAsync()
    {
        await MessageStylesAsync();
        await TempReplyAsync();
        await DatabaseKeysAsync();
        await PacketsAsync();
        await FriendStatusAsync();
        await FailureAndCancellationAsync();
        WideGroupCounts();
        CookieCompatibility();
    }

    private static MilkyHttpSession Session(ContractHttpHandler handler, HttpClient client) =>
        new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });

    private static async Task MessageStylesAsync()
    {
        const string styleJson = """{"bubble_id":18446744073709551615,"pendant_id":18446744073709551615,"font_id":65535,"font_effect_id":4294967295,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":4294967295}""";
        var style = JsonSerializer.Deserialize(styleJson, MilkyJson.GetTypeInfo<MilkyMessageStyle>())!;
        ContractHttpHandler.Check(style.BubbleId == ulong.MaxValue && style.PendantId == ulong.MaxValue && style.FontId == ushort.MaxValue && style.FontEffectId == uint.MaxValue, "Unsigned style metadata must not narrow.");
        var roundTrip = JsonSerializer.SerializeToNode(style, MilkyJson.GetTypeInfo<MilkyMessageStyle>());
        ContractHttpHandler.Check(JsonNode.DeepEquals(roundTrip, JsonNode.Parse(styleJson)), "Style boundaries should round-trip.");

        const string emptyStyle = """{"bubble_id":0,"pendant_id":0,"font_id":0,"font_effect_id":0,"is_cs_font_effect_enabled":false,"bubble_diy_text_id":0}""";
        var emptyRequest = new MilkySendGroupMessageRequest { GroupId = 1, MessageStyle = new() };
        var empty = JsonSerializer.SerializeToNode(emptyRequest, MilkyJson.GetTypeInfo<MilkySendGroupMessageRequest>())!;
        ContractHttpHandler.Check(JsonNode.DeepEquals(empty["message_style"], JsonNode.Parse(emptyStyle)), "Empty styles must retain zero and false values.");
        emptyRequest.MessageStyle = null;
        var omitted = JsonSerializer.SerializeToNode(emptyRequest, MilkyJson.GetTypeInfo<MilkySendGroupMessageRequest>())!.AsObject();
        ContractHttpHandler.Check(!omitted.ContainsKey("message_style"), "Null style should be omitted.");

        string requestJson = "{\"group_id\":1,\"message\":[],\"message_style\":" + styleJson + "}";
        using (ContractHttpHandler handler = new("send_group_message", requestJson, """{"status":"ok","retcode":0,"data":{"message_seq":2,"time":3}}"""))
        using (HttpClient client = new(handler))
        using (var session = Session(handler, client))
            ContractHttpHandler.Check((await session.SendGroupMessageAsync(1, style, []))?.Data?.MessageSeq == 2, "Styled send should use the existing result contract.");

        string incoming = "{\"event_type\":\"message_receive\",\"time\":1,\"self_id\":1,\"data\":{\"message_scene\":\"friend\",\"peer_id\":2,\"message_seq\":3,\"sender_id\":2,\"time\":1,\"segments\":[],\"message_style\":" + styleJson + "}}";
        var received = (MilkyMessageReceiveEventData)MilkyEventParser.ParseJson(incoming)!.Data;
        ContractHttpHandler.Check(received.Message.MessageStyle?.BubbleId == ulong.MaxValue, "Incoming styles should retain unsigned boundaries.");
        var wrapped = JsonNode.Parse(incoming)!;
        wrapped["data"] = new JsonObject { ["message"] = wrapped["data"]!.DeepClone() };
        var receivedWrapped = (MilkyMessageReceiveEventData)MilkyEventParser.ParseJson(wrapped.ToJsonString())!.Data;
        ContractHttpHandler.Check(receivedWrapped.Message.MessageStyle?.BubbleId == ulong.MaxValue, "Wrapped messages should retain style metadata.");

        MilkyForwardSegment forward = new([
            new MilkyOutgoingForwardedMessage(2, "outer", new MilkyMessage(
                new MilkyForwardSegment([new MilkyOutgoingForwardedMessage(3, "inner", new MilkyMessage("text")) { MessageStyle = new() }])
            )) { MessageStyle = style },
            new MilkyOutgoingForwardedMessage(4, "plain", new MilkyMessage("plain"))
        ]);
        var forwardJson = JsonSerializer.SerializeToNode<MilkyOutgoingSegment>(forward, MilkyJson.OutgoingSegmentTypeInfo)!;
        var nodes = forwardJson["data"]!["messages"]!;
        ContractHttpHandler.Check(JsonNode.DeepEquals(nodes[0]!["message_style"], JsonNode.Parse(styleJson)), "Outer forward node style should survive.");
        ContractHttpHandler.Check(JsonNode.DeepEquals(nodes[0]!["segments"]![0]!["data"]!["messages"]![0]!["message_style"], JsonNode.Parse(emptyStyle)), "Nested nodes retain their own style.");
        ContractHttpHandler.Check(!nodes[1]!.AsObject().ContainsKey("message_style"), "Unstyled sibling must not inherit a style.");
        var decoded = JsonSerializer.Deserialize(forwardJson.ToJsonString(), MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.Check(JsonNode.DeepEquals(forwardJson, JsonSerializer.SerializeToNode(decoded!, MilkyJson.OutgoingSegmentTypeInfo)), "Nested forward nodes should round-trip.");
    }

    private static async Task TempReplyAsync()
    {
        const string payload = """{"event_type":"message_receive","time":1,"self_id":1,"data":{"message_scene":"temp","peer_id":22,"group_id":33,"message_seq":4,"sender_id":22,"time":1,"segments":[]}}""";
        using ContractHttpHandler handler = new("send_temp_message", """{"group_id":33,"user_id":22,"message":[{"type":"text","data":{"text":"reply"}}]}""", """{"status":"ok","retcode":0,"data":{"message_seq":5,"time":1}}""");
        using HttpClient client = new(handler);
        using var session = Session(handler, client);
        using CancellationTokenSource cancellation = new();
        var evt = MilkyEventParser.ParseJson(payload)!;
        var context = (MilkyTempMessageContext)MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(context.GroupId == 33 && context.UserId == 22 && context.CancellationToken == cancellation.Token, "Temporary context must retain the group, user and cancellation.");
        TempPlugin plugin = new();
        session.UsePlugin(plugin);
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.Calls == 1, "Temporary messages should reach the dedicated plugin callback once.");
        await context.ReplyAsync(new MilkyTextSegment("reply"));
        ContractHttpHandler.Check(handler.Called, "Temporary replies should send through the source group.");
    }

    private static async Task DatabaseKeysAsync()
    {
        var encrypt = new MilkyRequestDecryptKeyRequest { Mode = "encrypt" };
        var omitted = JsonSerializer.SerializeToNode(encrypt, MilkyJson.GetTypeInfo<MilkyRequestDecryptKeyRequest>())!.AsObject();
        ContractHttpHandler.Check(!omitted.ContainsKey("key_meta"), "Encrypt mode must omit unset metadata.");
        encrypt.KeyMeta = null;
        var explicitNull = JsonSerializer.SerializeToNode(encrypt, MilkyJson.GetTypeInfo<MilkyRequestDecryptKeyRequest>())!.AsObject();
        ContractHttpHandler.Check(explicitNull.ContainsKey("key_meta") && explicitNull["key_meta"] is null, "Explicit null metadata must remain distinguishable.");
        var restored = JsonSerializer.Deserialize(explicitNull.ToJsonString(), MilkyJson.GetTypeInfo<MilkyRequestDecryptKeyRequest>())!;
        ContractHttpHandler.Check(JsonSerializer.SerializeToNode(restored, MilkyJson.GetTypeInfo<MilkyRequestDecryptKeyRequest>())!.AsObject().ContainsKey("key_meta"), "Metadata presence must survive decoding.");
        string meta = new('a', 128);
        using ContractHttpHandler handler = new("request_decrypt_key", "{\"mode\":\"decrypt\",\"key_meta\":\"" + meta + "\"}", """{"status":"ok","retcode":0,"data":{"key":"password","key_meta":""}}""");
        using HttpClient client = new(handler);
        using var session = Session(handler, client);
        var result = await session.RequestDecryptKeyAsync(new MilkyRequestDecryptKeyRequest { Mode = "decrypt", KeyMeta = meta });
        ContractHttpHandler.Check(result?.Data?.Key == "password" && result.Data.KeyMeta == "", "Keys must remain password strings and empty response metadata must survive.");
    }

    private static async Task PacketsAsync()
    {
        var invalid = new MilkySendPacketRequest { Command = "Example.Command", Data = null, WaitForResponse = null };
        var json = JsonSerializer.SerializeToNode(invalid, MilkyJson.GetTypeInfo<MilkySendPacketRequest>())!.AsObject();
        ContractHttpHandler.Check(json.ContainsKey("data") && json["data"] is null && json.ContainsKey("rsp") && json["rsp"] is null, "Explicit null packet fields must be sent to server validation.");
        using (ContractHttpHandler handler = new("send_packet", """{"cmd":"Example.Command","data":"","rsp":false}""", """{"status":"ok","retcode":0,"data":{}}"""))
        using (HttpClient client = new(handler))
        using (var session = Session(handler, client))
        {
            var result = await session.SendPacketAsync(new MilkySendPacketRequest { Command = "Example.Command", WaitForResponse = false });
            ContractHttpHandler.Check(result?.IsSuccess == true && result.Data?.Command == "" && result.Data.Data == "", "No-response packet sends must accept data={ }.");
        }
        using (ContractHttpHandler handler = new("send_packet", """{"cmd":"Example.Command","data":"aB00","rsp":true}""", """{"status":"ok","retcode":0,"data":{"cmd":"Example.Command","data":"AB00","sequence":-2147483648,"ret_code":1006,"extra":"detail"}}"""))
        using (HttpClient client = new(handler))
        using (var session = Session(handler, client))
        {
            var result = await session.SendPacketAsync(new MilkySendPacketRequest { Command = "Example.Command", Data = "aB00" });
            ContractHttpHandler.Check(result?.IsSuccess == true && result.Data?.RetCode == 1006 && result.Data.Sequence == int.MinValue && result.Data.Extra == "detail" && result.Data.Data == "AB00", "Packet-level errors must retain the successful response envelope and packet fields.");
        }
    }

    private static async Task FriendStatusAsync()
    {
        const string response = """{"status":"ok","retcode":0,"data":{"self_uid":"self","friends":[{"uid":"self","status":null,"status_text":"","raw_fields":[{"field":3,"wire_type":0,"value":"18446744073709551615"},{"field":3,"wire_type":2,"value":""}]},{"uid":"self","status":4294967295,"status_text":"online","raw_fields":[]}]}}""";
        using ContractHttpHandler handler = new("get_friends_status", "{}", response);
        using HttpClient client = new(handler);
        using var session = Session(handler, client);
        var result = (await session.GetFriendsStatusAsync())!.Data!;
        ContractHttpHandler.Check(result.Friends.Count == 2 && result.Friends[0].Uid == "self" && result.Friends[1].Uid == "self", "Friend status entries must preserve self and duplicates in server order.");
        ContractHttpHandler.Check(result.Friends[0].Status is null && result.Friends[1].Status == uint.MaxValue && result.Friends[0].RawFields[0].Value == "18446744073709551615" && result.Friends[0].RawFields[1].Value == "", "Raw fields must preserve precision, repeated fields and empty values.");
    }

    private static async Task FailureAndCancellationAsync()
    {
        using ContractHttpHandler handler = new("request_decrypt_key", """{"mode":"encrypt","key_meta":null}""", """{"status":"failed","retcode":-400,"message":"invalid metadata","data":null}""");
        using HttpClient client = new(handler);
        using var session = Session(handler, client);
        var result = await session.RequestDecryptKeyAsync(new MilkyRequestDecryptKeyRequest { Mode = "encrypt", KeyMeta = null });
        ContractHttpHandler.Check(result?.IsSuccess == false && result.RetCode == -400 && result.Message == "invalid metadata" && result.Data is null && handler.CallCount == 1, "Validation failures should preserve server details without retrying.");
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();
        try
        {
            await session.GetFriendsStatusAsync(cancellation.Token);
            throw new InvalidOperationException("Expected cancellation.");
        }
        catch (OperationCanceledException) { }
        ContractHttpHandler.Check(handler.CallCount == 1, "Canceled calls must not issue another request.");
    }

    private static void WideGroupCounts()
    {
        var group = JsonSerializer.Deserialize("""{"group_id":1,"group_name":"wide","member_count":2147483648,"max_member_count":9223372036854775807}""", MilkyJson.GetTypeInfo<MilkyGroupEntity>())!;
        ContractHttpHandler.Check(group.MemberCount64 == 2147483648 && group.MaxMemberCount64 == long.MaxValue, "Group counts must retain server long widths.");
        group.MemberCount = 20;
        ContractHttpHandler.Check(group.MemberCount64 == 20, "Legacy group count setter should update the full-width count.");
    }

    private static void CookieCompatibility()
    {
        var legacy = JsonSerializer.Deserialize("""{"cookies":"a=b"}""", MilkyJson.GetTypeInfo<MilkyCookiesResult>())!;
        ContractHttpHandler.Check(legacy.Cookies == "a=b" && legacy.CookieValues is null, "Legacy cookie strings remain supported.");
        var dictionary = JsonSerializer.Deserialize("""{"cookies":{"a":"b","empty":""}}""", MilkyJson.GetTypeInfo<MilkyCookiesResult>())!;
        ContractHttpHandler.Check(dictionary.CookieValues?["empty"] == "" && dictionary.Cookies == "a=b; empty=", "Cookie dictionaries should expose both individual values and the compatible string.");
        var oldToken = JsonSerializer.Deserialize("""{"csrf_token":"old"}""", MilkyJson.GetTypeInfo<MilkyCsrfTokenResult>())!;
        var newToken = JsonSerializer.Deserialize("""{"token":"new"}""", MilkyJson.GetTypeInfo<MilkyCsrfTokenResult>())!;
        ContractHttpHandler.Check(oldToken.CsrfToken == "old" && newToken.CsrfToken == "new", "Both token field names remain supported.");
    }

    private sealed class TempPlugin : MilkyEventPlugin
    {
        public int Calls;
        protected override Task OnTempMessageReceivedAsync(MilkyTempMessageContext context) { Calls++; return Task.CompletedTask; }
    }
}
