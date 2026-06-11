using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net;
using System.Text;
using SaltyMilky.Net;
using TUnit.Assertions;
using TUnit.Core;

namespace SaltyMilky.Net.Tests;

public sealed class MilkyNativeAotCompatibilityTests
{
    // Official documentation baseline: Milky v1.2.2 API/struct/compatibility pages.

    private const string MessageReceiveJson =
        """
        {
          "event_type": "message_receive",
          "time": 1710000000,
          "self_id": 10000,
          "data": {
            "message": {
              "message_scene": "friend",
              "peer_id": 123456789,
              "message_seq": 42,
              "sender_id": 123456789,
              "time": 1710000000,
              "segments": [{ "type": "text", "data": { "text": "ping" } }]
            }
          }
        }
        """;

    [Test]
    public async Task ParseJson_MessageReceive_ReturnsTypedMessageReceiveData()
    {
        MilkyEvent? parsed = MilkyEventParser.ParseJson(MessageReceiveJson);

        await Assert.That(parsed).IsNotNull();
        await Assert.That(parsed!.EventType).IsEqualTo("message_receive");
        await Assert.That(parsed.SelfId).IsEqualTo(10000);
        await Assert.That(parsed.Data).IsTypeOf<MilkyMessageReceiveEventData>();

        MilkyMessageReceiveEventData data = (MilkyMessageReceiveEventData)parsed.Data;
        await Assert.That(data.Message.MessageSeq).IsEqualTo(42);
        await Assert.That(data.Message.Segments.Count).IsEqualTo(1);
        await Assert.That(data.Message.Segments[0]).IsTypeOf<MilkyIncomingTextSegment>();
        await Assert.That(((MilkyIncomingTextSegment)data.Message.Segments[0]).Text).IsEqualTo("ping");
    }

    [Test]
    public async Task ParseJson_InlineMessageReceive_ReturnsTypedMessageReceiveData()
    {
        const string json =
            """
            {
              "event_type": "message_receive",
              "time": 1710000000,
              "self_id": 10000,
              "data": {
                "message_scene": "friend",
                "peer_id": 123456789,
                "message_seq": 42,
                "sender_id": 123456789,
                "time": 1710000000,
                "segments": [{ "type": "text", "data": { "text": "ping" } }]
              }
            }
            """;

        MilkyEvent? parsed = MilkyEventParser.ParseJson(json);

        await Assert.That(parsed).IsNotNull();
        await Assert.That(parsed!.Data).IsTypeOf<MilkyMessageReceiveEventData>();
        await Assert.That(((MilkyMessageReceiveEventData)parsed.Data).Message.MessageSeq).IsEqualTo(42);
    }

    [Test]
    public async Task ParseSseEvents_DataLines_ReturnsParsedEvents()
    {
        string sseText = string.Join('\n', MessageReceiveJson.Replace("\r\n", "\n").Split('\n').Select(line => $"data: {line}")) + "\n\n";

        MilkyEvent[] events = MilkyEventParser.ParseSseEvents(sseText).ToArray();

        await Assert.That(events.Length).IsEqualTo(1);
        await Assert.That(events[0].Data).IsTypeOf<MilkyMessageReceiveEventData>();
    }

    [Test]
    public async Task ReadSseEventsAsync_Stream_ReturnsParsedEvents()
    {
        string sseText = string.Join('\n', MessageReceiveJson.Replace("\r\n", "\n").Split('\n').Select(line => $"data: {line}")) + "\n\n";
        await using MemoryStream stream = new(Encoding.UTF8.GetBytes(sseText));

        MilkyEvent[] events = await CollectAsync(MilkyCommunication.ReadSseEventsAsync(stream));

        await Assert.That(events.Length).IsEqualTo(1);
        await Assert.That(events[0].Data).IsTypeOf<MilkyMessageReceiveEventData>();
    }

    [Test]
    public async Task ReadWebhookEventAsync_ValidBearerToken_ReturnsParsedEvent()
    {
        await using MemoryStream stream = new(Encoding.UTF8.GetBytes(MessageReceiveJson));

        MilkyEvent? milkyEvent = await MilkyCommunication.ReadWebhookEventAsync(stream, "Bearer secret", "secret");

        await Assert.That(milkyEvent).IsNotNull();
        await Assert.That(milkyEvent!.Data).IsTypeOf<MilkyMessageReceiveEventData>();
    }

    [Test]
    public async Task ReadWebhookEventAsync_InvalidBearerToken_Throws()
    {
        await using MemoryStream stream = new(Encoding.UTF8.GetBytes(MessageReceiveJson));

        await Assert.That(async () => await MilkyCommunication.ReadWebhookEventAsync(stream, "Bearer wrong", "secret")).Throws<UnauthorizedAccessException>();
    }

    [Test]
    public async Task ToWebSocketUri_HttpEventUri_UsesWebSocketScheme()
    {
        Uri uri = MilkyCommunication.ToWebSocketUri(new Uri("https://example.com/event?access_token=abc"));

        await Assert.That(uri.ToString()).IsEqualTo("wss://example.com/event?access_token=abc");
    }

    [Test]
    public async Task ParseJson_GroupMemberIncrease_ReturnsInvitorId()
    {
        const string json =
            """
            {
              "event_type": "group_member_increase",
              "time": 1710000000,
              "self_id": 10000,
              "data": {
                "group_id": 987654321,
                "user_id": 123456789,
                "invitor_id": 111222333
              }
            }
            """;

        MilkyEvent? parsed = MilkyEventParser.ParseJson(json);

        await Assert.That(parsed).IsNotNull();
        await Assert.That(parsed!.Data).IsTypeOf<MilkyGroupMemberIncreaseEventData>();
        MilkyCommonEventData data = (MilkyCommonEventData)parsed.Data;
        await Assert.That(data.EventType).IsEqualTo("group_member_increase");
        await Assert.That(data.InvitorId).IsEqualTo(111222333);
    }

    [Test]
    public async Task ParseJson_GroupMessageReaction_ReturnsIsAddAndReactionType()
    {
        const string json =
            """
            {
              "event_type": "group_message_reaction",
              "time": 1710000000,
              "self_id": 10000,
              "data": {
                "group_id": 987654321,
                "user_id": 123456789,
                "message_seq": 42,
                "face_id": "66",
                "reaction_type": "face",
                "is_add": true
              }
            }
            """;

        MilkyEvent? parsed = MilkyEventParser.ParseJson(json);

        await Assert.That(parsed).IsNotNull();
        await Assert.That(parsed!.Data).IsTypeOf<MilkyGroupMessageReactionEventData>();
        MilkyCommonEventData data = (MilkyCommonEventData)parsed.Data;
        await Assert.That(data.EventType).IsEqualTo("group_message_reaction");
        await Assert.That(data.IsAdd).IsTrue();
        await Assert.That(data.ReactionType).IsEqualTo("face");
    }

    [Test]
    public async Task ReadSseEventsWithReconnectAsync_CancelledToken_Completes()
    {
        using HttpClient client = new(new CaptureHandler("{}", "text/event-stream")) { BaseAddress = new Uri("http://localhost/") };
        using CancellationTokenSource cts = new();
        await cts.CancelAsync();

        MilkyEvent[] events = await CollectAsync(MilkyCommunication.ReadSseEventsWithReconnectAsync(client, TimeSpan.Zero, cts.Token));

        await Assert.That(events.Length).IsEqualTo(0);
    }

    [Test]
    public async Task RunWebhookListenerAsync_ValidRequest_DispatchesEvent()
    {
        string prefix = $"http://127.0.0.1:{Random.Shared.Next(20000, 50000)}/milky-webhook/";
        CountingPlugin plugin = new();
        MilkyEventPipeline pipeline = new();
        pipeline.Use(plugin.Execute);
        using CancellationTokenSource cts = new(TimeSpan.FromSeconds(10));
        Task listenerTask = MilkyCommunication.RunWebhookListenerAsync(prefix, pipeline, "secret", cts.Token);

        using HttpClient client = new();
        using HttpRequestMessage request = new(HttpMethod.Post, prefix)
        {
            Content = new StringContent(MessageReceiveJson, Encoding.UTF8, "application/json"),
        };
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "secret");

        using HttpResponseMessage response = await client.SendAsync(request, cts.Token);
        await cts.CancelAsync();
        await listenerTask;

        await Assert.That(response.StatusCode).IsEqualTo(HttpStatusCode.NoContent);
        await Assert.That(plugin.ReceivedMessages).IsEqualTo(1);
    }

    [Test]
    public async Task RunWebhookListenerAsync_InvalidBearerToken_ReturnsUnauthorized()
    {
        string prefix = $"http://127.0.0.1:{Random.Shared.Next(20000, 50000)}/milky-webhook/";
        MilkyEventPipeline pipeline = new();
        using CancellationTokenSource cts = new(TimeSpan.FromSeconds(10));
        Task listenerTask = MilkyCommunication.RunWebhookListenerAsync(prefix, pipeline, "secret", cts.Token);

        using HttpClient client = new();
        using HttpRequestMessage request = new(HttpMethod.Post, prefix)
        {
            Content = new StringContent(MessageReceiveJson, Encoding.UTF8, "application/json"),
        };
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "wrong");

        using HttpResponseMessage response = await client.SendAsync(request, cts.Token);
        await cts.CancelAsync();
        await listenerTask;

        await Assert.That(response.StatusCode).IsEqualTo(HttpStatusCode.Unauthorized);
    }

    [Test]
    public async Task SerializeOutgoingSegment_TextSegment_UsesReflectionDisabledOptions()
    {
        string json = JsonSerializer.Serialize(new MilkyTextSegment("hello"), MilkyJson.OutgoingSegmentTypeInfo);

        await Assert.That(json).IsEqualTo("{\"type\":\"text\",\"data\":{\"text\":\"hello\"}}");
    }

    [Test]
    public async Task DeserializeIncomingSegment_TextSegment_UsesReflectionDisabledOptions()
    {
        const string json = "{\"type\":\"text\",\"data\":{\"text\":\"hello\"}}";

        MilkyIncomingSegment? segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo);

        await Assert.That(segment).IsTypeOf<MilkyIncomingTextSegment>();
        await Assert.That(((MilkyIncomingTextSegment)segment!).Text).IsEqualTo("hello");
    }

    [Test]
    public async Task DeserializeIncomingSegment_UnknownSegment_ReturnsUnsupportedTextSegment()
    {
        const string json = "{\"type\":\"new_segment\",\"data\":{\"value\":1}}";

        MilkyIncomingSegment? segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo);

        await Assert.That(segment).IsTypeOf<MilkyIncomingTextSegment>();
        await Assert.That(((MilkyIncomingTextSegment)segment!).Text).IsEqualTo("[unsupported Milky segment: new_segment]");
    }

    [Test]
    public async Task DeserializeIncomingSegments_DocumentedFields_DoNotRegress()
    {
        MilkyIncomingSegment? reply = JsonSerializer.Deserialize(
            """
            {"type":"reply","data":{"message_seq":42,"sender_id":123,"sender_name":"alice","time":1710000000,"segments":[{"type":"text","data":{"text":"quoted"}}]}}
            """,
            MilkyJson.IncomingSegmentTypeInfo);
        MilkyIncomingSegment? forward = JsonSerializer.Deserialize(
            """
            {"type":"forward","data":{"forward_id":"fwd","title":"title","preview":["a","b"],"summary":"summary"}}
            """,
            MilkyJson.IncomingSegmentTypeInfo);
        MilkyIncomingSegment? marketFace = JsonSerializer.Deserialize(
            """
            {"type":"market_face","data":{"emoji_package_id":1,"emoji_id":"e","key":"k","summary":"s","url":"https://example.com/e"}}
            """,
            MilkyJson.IncomingSegmentTypeInfo);
        MilkyIncomingSegment? lightApp = JsonSerializer.Deserialize(
            """
            {"type":"light_app","data":{"app_name":"app","json_payload":"{}"}}
            """,
            MilkyJson.IncomingSegmentTypeInfo);
        MilkyIncomingSegment? xml = JsonSerializer.Deserialize(
            """
            {"type":"xml","data":{"service_id":60,"xml_payload":"<x/>"}}
            """,
            MilkyJson.IncomingSegmentTypeInfo);
        MilkyIncomingSegment? image = JsonSerializer.Deserialize(
            """
            {"type":"image","data":{"resource_id":"r","temp_url":"https://example.com/i","width":1,"height":2,"summary":"summary","sub_type":"sticker"}}
            """,
            MilkyJson.IncomingSegmentTypeInfo);

        await Assert.That(((MilkyIncomingReplySegment)reply!).SenderName).IsEqualTo("alice");
        await Assert.That(((MilkyIncomingForwardSegment)forward!).Preview![1]).IsEqualTo("b");
        await Assert.That(((MilkyMarketFaceIncomingSegment)marketFace!).Key).IsEqualTo("k");
        await Assert.That(((MilkyIncomingLightAppSegment)lightApp!).AppName).IsEqualTo("app");
        await Assert.That(((MilkyXmlIncomingSegment)xml!).ServiceId).IsEqualTo(60);
        await Assert.That(((MilkyIncomingImageSegment)image!).SubType).IsEqualTo("sticker");
    }

    [Test]
    public async Task SerializeOutgoingSegments_DocumentedFields_DoNotRegress()
    {
        MilkyImageSegment image = new("file:///tmp/a.png", "sticker", "summary");
        MilkyForwardSegment forward = new([
            new MilkyOutgoingForwardedMessage(123, "alice", new MilkyMessage("hello")),
        ])
        {
            Title = "title",
            Preview = ["a"],
            Summary = "summary",
            Prompt = "prompt",
        };
        MilkyLightAppSegment lightApp = new("{}");

        string imageJson = JsonSerializer.Serialize<MilkyOutgoingSegment>(image, MilkyJson.OutgoingSegmentTypeInfo);
        string forwardJson = JsonSerializer.Serialize<MilkyOutgoingSegment>(forward, MilkyJson.OutgoingSegmentTypeInfo);
        string lightAppJson = JsonSerializer.Serialize<MilkyOutgoingSegment>(lightApp, MilkyJson.OutgoingSegmentTypeInfo);

        await Assert.That(imageJson).Contains("\"sub_type\":\"sticker\"");
        await Assert.That(imageJson).Contains("\"summary\":\"summary\"");
        await Assert.That(forwardJson).Contains("\"prompt\":\"prompt\"");
        await Assert.That(lightAppJson).Contains("\"json_payload\":\"{}\"");
    }

    [Test]
    public async Task DeserializeGroupNotifications_DocumentedTypes_ReturnTypedNotifications()
    {
        const string json =
            """
            {
              "notifications": [
                {"type":"join_request","group_id":100,"notification_seq":1,"is_filtered":true,"initiator_id":11,"state":"pending","comment":"hi"},
                {"type":"admin_change","group_id":100,"notification_seq":2,"user_id":22,"operator_id":33,"is_set":true},
                {"type":"kick","group_id":100,"notification_seq":3,"user_id":44,"operator_id":55},
                {"type":"quit","group_id":100,"notification_seq":4,"user_id":66},
                {"type":"invited_join_request","group_id":100,"notification_seq":5,"initiator_id":77,"target_user_id":88,"state":"pending"}
              ],
              "next_notification_seq": 6
            }
            """;

        MilkyGroupNotificationsResult? result = JsonSerializer.Deserialize<MilkyGroupNotificationsResult>(json, MilkyJson.Options);

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Notifications[0]).IsTypeOf<MilkyJoinRequestGroupNotification>();
        await Assert.That(result.Notifications[1]).IsTypeOf<MilkyAdminChangeGroupNotification>();
        await Assert.That(result.Notifications[2]).IsTypeOf<MilkyKickGroupNotification>();
        await Assert.That(result.Notifications[3]).IsTypeOf<MilkyQuitGroupNotification>();
        await Assert.That(result.Notifications[4]).IsTypeOf<MilkyInvitedJoinRequestGroupNotification>();
        await Assert.That(result.Notifications[0].InitiatorId).IsEqualTo(11);
        await Assert.That(result.Notifications[1].OperatorId).IsEqualTo(33);
        await Assert.That(result.Notifications[4].TargetUserId).IsEqualTo(88);
    }

    [Test]
    public async Task DeserializeGroupNotification_UnknownType_ReturnsUnknownNotification()
    {
        const string json =
            """
            {"notifications":[{"type":"future_notification","group_id":100,"notification_seq":1,"future":true}],"next_notification_seq":2}
            """;

        MilkyGroupNotificationsResult? result = JsonSerializer.Deserialize<MilkyGroupNotificationsResult>(json, MilkyJson.Options);

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Notifications[0]).IsTypeOf<MilkyUnknownGroupNotification>();
        MilkyUnknownGroupNotification notification = (MilkyUnknownGroupNotification)result.Notifications[0];
        await Assert.That(notification.Type).IsEqualTo("future_notification");
        await Assert.That(notification.RawData.GetProperty("future").GetBoolean()).IsTrue();
    }

    [Test]
    public async Task ExecuteAsync_MessageReceivePlugin_RunsHandler()
    {
        MilkyEvent parsed = MilkyEventParser.ParseJson(MessageReceiveJson)!;
        CountingPlugin plugin = new();
        MilkyEventPipeline pipeline = new();
        pipeline.Use(plugin.Execute);

        await pipeline.ExecuteAsync(parsed);

        await Assert.That(plugin.ReceivedMessages).IsEqualTo(1);
        await Assert.That(plugin.LastText).IsEqualTo("ping");
    }

    [Test]
    public async Task SendPrivateMessageAsync_UsesAotSafeJsonParams()
    {
        CaptureHandler handler = new("""{"status":"ok","retcode":0,"data":{"message_seq":99,"time":1710000001}}""");
        using HttpClient client = new(handler) { BaseAddress = new Uri("http://localhost/") };
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { HttpClient = client });

        MilkyActionResult<MilkySendMessageResult>? result = await session.SendPrivateMessageAsync(123456789, new MilkyMessage("hello"));

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Data!.MessageSeq).IsEqualTo(99);
        await Assert.That(handler.RequestPath).IsEqualTo("/api/send_private_message");
        await Assert.That(handler.RequestBody).IsEqualTo("""{"user_id":123456789,"message":[{"type":"text","data":{"text":"hello"}}]}""");
    }

    [Test]
    public async Task InvokeApiAsync_JsonObjectParameters_UsesAotSafeJsonParams()
    {
        CaptureHandler handler = new("""{"status":"ok","retcode":0,"data":{"url":"https://example.com/resource"}}""");
        using HttpClient client = new(handler) { BaseAddress = new Uri("http://localhost/") };
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { HttpClient = client });

        MilkyActionResult<MilkyResourceTempUrlResult>? result = await session.InvokeApiAsync<MilkyResourceTempUrlResult>(
            "get_resource_temp_url",
            new JsonObject { ["resource_id"] = "resource-id" });

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Data!.Url).IsEqualTo("https://example.com/resource");
        await Assert.That(handler.RequestBody).IsEqualTo("""{"resource_id":"resource-id"}""");
    }

    [Test]
    public async Task ReadSseEventsAsync_HttpSession_UsesEventEndpointAndBearerToken()
    {
        string sseText = string.Join('\n', MessageReceiveJson.Replace("\r\n", "\n").Split('\n').Select(line => $"data: {line}")) + "\n\n";
        CaptureHandler handler = new(sseText, "text/event-stream");
        using HttpClient client = new(handler) { BaseAddress = new Uri("http://localhost/") };
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { HttpClient = client, AccessToken = "secret" });

        MilkyEvent[] events = await CollectAsync(session.ReadSseEventsAsync());

        await Assert.That(events.Length).IsEqualTo(1);
        await Assert.That(handler.RequestPath).IsEqualTo("/event");
        await Assert.That(handler.Authorization).IsEqualTo("Bearer secret");
    }

    private sealed class CaptureHandler(string responseText, string mediaType = "application/json") : HttpMessageHandler
    {
        public string? RequestPath { get; private set; }

        public string? RequestBody { get; private set; }

        public string? Authorization { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestPath = request.RequestUri?.PathAndQuery;
            Authorization = request.Headers.Authorization?.ToString();
            RequestBody = request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseText, Encoding.UTF8, mediaType),
            };
        }
    }

    private static async Task<MilkyEvent[]> CollectAsync(IAsyncEnumerable<MilkyEvent> events)
    {
        List<MilkyEvent> result = [];
        await foreach (MilkyEvent milkyEvent in events)
        {
            result.Add(milkyEvent);
        }

        return result.ToArray();
    }

    private sealed class CountingPlugin : MilkyEventPlugin
    {
        public int ReceivedMessages { get; private set; }

        public string? LastText { get; private set; }

        public override Task OnMessageReceivedAsync(MilkyMessageReceiveEventData data, MilkyEvent milkyEvent)
        {
            ReceivedMessages++;
            LastText = data.Message.Segments.OfType<MilkyIncomingTextSegment>().Single().Text;
            return Task.CompletedTask;
        }
    }
}
