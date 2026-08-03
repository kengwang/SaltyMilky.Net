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
        await Assert.That(parsed!.EventType).IsEqualTo(MilkyConstant.EventType.MessageReceive);
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
        await Assert.That(data.EventType).IsEqualTo(MilkyConstant.EventType.GroupMemberIncrease);
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
        await Assert.That(data.EventType).IsEqualTo(MilkyConstant.EventType.GroupMessageReaction);
        await Assert.That(data.IsAdd).IsTrue();
        await Assert.That(data.ReactionType).IsEqualTo(MilkyConstant.ReactionType.Face);
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

    [Test, NotInParallel]
    public async Task RunWebhookListenerAsync_ValidRequest_DispatchesEvent()
    {
        string prefix = $"http://127.0.0.1:{Random.Shared.Next(20000, 50000)}/milky-webhook/";
        CountingPlugin plugin = new();
        MilkyEventPipeline pipeline = new();
        pipeline.Use(plugin.Execute);
        using CancellationTokenSource cts = new(TimeSpan.FromSeconds(10));
        Task listenerTask = MilkyCommunication.RunWebhookListenerAsync(prefix, pipeline, "secret", cts.Token);

        using HttpClient client = new();
        using HttpResponseMessage response = await SendWithListenerStartupRetryAsync(client, () =>
        {
            HttpRequestMessage request = new(HttpMethod.Post, prefix)
            {
                Content = new StringContent(MessageReceiveJson, Encoding.UTF8, "application/json"),
            };
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "secret");
            return request;
        }, cts.Token);
        await cts.CancelAsync();
        await listenerTask;

        await Assert.That(response.StatusCode).IsEqualTo(HttpStatusCode.NoContent);
        await Assert.That(plugin.ReceivedMessages).IsEqualTo(1);
    }

    [Test, NotInParallel]
    public async Task RunWebhookListenerAsync_InvalidBearerToken_ReturnsUnauthorized()
    {
        string prefix = $"http://127.0.0.1:{Random.Shared.Next(20000, 50000)}/milky-webhook/";
        MilkyEventPipeline pipeline = new();
        using CancellationTokenSource cts = new(TimeSpan.FromSeconds(10));
        Task listenerTask = MilkyCommunication.RunWebhookListenerAsync(prefix, pipeline, "secret", cts.Token);

        using HttpClient client = new();
        using HttpResponseMessage response = await SendWithListenerStartupRetryAsync(client, () =>
        {
            HttpRequestMessage request = new(HttpMethod.Post, prefix)
            {
                Content = new StringContent(MessageReceiveJson, Encoding.UTF8, "application/json"),
            };
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "wrong");
            return request;
        }, cts.Token);
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
    public async Task SerializeOutgoingSegment_MarkdownSegment_UsesReflectionDisabledOptions()
    {
        MilkyMarkdownSegment markdown = new("# Title")
        {
            ExtensionData = new Dictionary<string, JsonElement>
            {
                ["template_id"] = JsonDocument.Parse("\"tpl\"").RootElement.Clone(),
            },
        };

        string json = JsonSerializer.Serialize<MilkyOutgoingSegment>(markdown, MilkyJson.OutgoingSegmentTypeInfo);

        await Assert.That(json).IsEqualTo("{\"type\":\"markdown\",\"data\":{\"content\":\"# Title\",\"template_id\":\"tpl\"}}");
    }

    [Test]
    public async Task DeserializeIncomingSegment_MarkdownSegment_ReturnsTypedSegment()
    {
        const string json = "{\"type\":\"markdown\",\"data\":{\"content\":\"# Title\",\"template_id\":\"tpl\"}}";

        MilkyIncomingSegment? segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo);

        await Assert.That(segment).IsTypeOf<MilkyIncomingMarkdownSegment>();
        MilkyIncomingMarkdownSegment markdown = (MilkyIncomingMarkdownSegment)segment!;
        await Assert.That(markdown.Content).IsEqualTo("# Title");
        await Assert.That(markdown.ExtensionData!["template_id"].GetString()).IsEqualTo("tpl");
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
        await Assert.That(((MilkyIncomingImageSegment)image!).SubType).IsEqualTo(MilkyConstant.ImageSubType.Sticker);
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
        await Assert.That(result.Notifications[0].Type).IsEqualTo(MilkyConstant.GroupRequestNotificationType.JoinRequest);
        await Assert.That(result.Notifications[1].Type).IsEqualTo(MilkyConstant.GroupNotificationType.AdminChange);
        await Assert.That(result.Notifications[4].Type).IsEqualTo(MilkyConstant.GroupRequestNotificationType.InvitedJoinRequest);
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

    [Test]
    public async Task ReadSseEventsWithReconnectAsync_IdleStream_ReconnectsAndReceivesEvent()
    {
        string sseText = string.Join('\n', MessageReceiveJson.Replace("\r\n", "\n").Split('\n').Select(line => $"data: {line}")) + "\n\n";
        IdleThenEventHandler handler = new(sseText);
        using HttpClient client = new(handler) { BaseAddress = new Uri("http://localhost/") };

        MilkyEvent[] events = await CollectAtMostAsync(
            MilkyCommunication.ReadSseEventsWithReconnectAsync(client, TimeSpan.Zero, TimeSpan.FromMilliseconds(50)),
            count: 1,
            timeout: TimeSpan.FromSeconds(5));

        await Assert.That(events.Length).IsEqualTo(1);
        await Assert.That(events[0].Data).IsTypeOf<MilkyMessageReceiveEventData>();
        await Assert.That(handler.RequestCount).IsEqualTo(2);
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

    private static async Task<HttpResponseMessage> SendWithListenerStartupRetryAsync(HttpClient client, Func<HttpRequestMessage> requestFactory, CancellationToken cancellationToken)
    {
        for (int attempt = 0; ; attempt++)
        {
            HttpRequestMessage request = requestFactory();
            try
            {
                return await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }
            catch (HttpRequestException) when (attempt < 20)
            {
                request.Dispose();
                await Task.Delay(TimeSpan.FromMilliseconds(50), cancellationToken).ConfigureAwait(false);
            }
        }
    }

    private sealed class IdleThenEventHandler(string responseText) : HttpMessageHandler
    {
        public int RequestCount { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            RequestCount++;
            HttpContent content;
            if (RequestCount == 1)
            {
                content = new StreamContent(new IdleStream());
                content.Headers.ContentType = new("text/event-stream");
            }
            else
            {
                content = new StringContent(responseText, Encoding.UTF8, "text/event-stream");
            }

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = content,
            });
        }
    }

    private sealed class IdleStream : Stream
    {
        private readonly CancellationTokenSource _disposed = new();

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => 0;

        public override long Position
        {
            get => 0;
            set { }
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            _disposed.Token.WaitHandle.WaitOne();
            return 0;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            using CancellationTokenSource linked = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _disposed.Token);
            try
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, linked.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (_disposed.IsCancellationRequested)
            {
                return 0;
            }

            return 0;
        }

        public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            using CancellationTokenSource linked = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _disposed.Token);
            try
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, linked.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (_disposed.IsCancellationRequested)
            {
                return 0;
            }

            return 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _disposed.Cancel();
                _disposed.Dispose();
            }

            base.Dispose(disposing);
        }

        public override long Seek(long offset, SeekOrigin origin) => 0;

        public override void SetLength(long value)
        {
        }

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
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

    private static async Task<MilkyEvent[]> CollectAtMostAsync(IAsyncEnumerable<MilkyEvent> events, int count, TimeSpan timeout)
    {
        using CancellationTokenSource cts = new(timeout);
        List<MilkyEvent> result = [];
        await foreach (MilkyEvent milkyEvent in events.WithCancellation(cts.Token))
        {
            result.Add(milkyEvent);
            if (result.Count >= count)
            {
                break;
            }
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
