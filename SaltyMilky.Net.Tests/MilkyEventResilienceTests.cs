using System.Net.WebSockets;
using System.Text;
using SaltyMilky.Net;
using TUnit.Assertions;
using TUnit.Core;

namespace SaltyMilky.Net.Tests;

public sealed class MilkyEventResilienceTests
{
    private static string Message(string faceId) => $$$"""
        {"time":1,"self_id":10000,"event_type":"message_receive","data":{"message_scene":"friend","peer_id":123,"message_seq":42,"sender_id":123,"time":1,"segments":[{"type":"face","data":{"face_id":{{{faceId}}},"is_large":true}}]}}
        """;

    [Test]
    [Arguments("123")]
    [Arguments("\"123\"")]
    [Arguments("\"00123\"")]
    public async Task FaceId_ParsesAndSerializesAsProtocolString(string input)
    {
        var parsed = MilkyEventParser.ParseJson(Message(input))!;
        var face = (MilkyIncomingFaceSegment)((MilkyMessageReceiveEventData)parsed.Data).Message.Segments[0];
        await Assert.That(face.FaceId).IsEqualTo(input.Trim('"'));
        await Assert.That(face.IsLarge).IsTrue();
        string outgoing = System.Text.Json.JsonSerializer.Serialize<MilkyOutgoingSegment>(new MilkyFaceSegment(face.FaceId), MilkyJson.OutgoingSegmentTypeInfo);
        using var document = System.Text.Json.JsonDocument.Parse(outgoing);
        await Assert.That(document.RootElement.GetProperty("data").GetProperty("face_id").GetString()).IsEqualTo(face.FaceId);
    }

    [Test]
    [Arguments("{")]
    [Arguments("{}")]
    [Arguments("[]")]
    [Arguments("{\"event_type\":\"message_receive\",\"time\":true}")]
    [Arguments("face")]
    public async Task Sse_BadEventDoesNotPreventNextEvent(string invalid)
    {
        string badEvent = invalid == "face" ? Message("true") : invalid;
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes($"data: {badEvent}\n\ndata: {Message("\"123\"")}\n\n"));
        var events = await CollectAsync(MilkyCommunication.ReadSseEventsAsync(stream));
        await Assert.That(events.Count).IsEqualTo(1);
        await Assert.That(((MilkyMessageReceiveEventData)events[0].Data).Message.MessageSeq).IsEqualTo(42);
    }

    [Test]
    [Arguments("{")]
    [Arguments("{}")]
    [Arguments("[]")]
    [Arguments("{\"event_type\":\"message_receive\",\"time\":true}")]
    [Arguments("face")]
    public async Task WebSocket_BadEventDoesNotPreventNextEvent(string invalid)
    {
        using var socket = new ScriptedWebSocket(invalid == "face" ? Message("true") : invalid, Message("\"123\""));
        var events = await CollectAsync(MilkyCommunication.ReadWebSocketEventsAsync(socket));
        await Assert.That(events.Count).IsEqualTo(1);
        await Assert.That(((MilkyMessageReceiveEventData)events[0].Data).Message.MessageSeq).IsEqualTo(42);
    }

    [Test]
    [Arguments(false)]
    [Arguments(true)]
    public async Task Session_ReportsParseFailureAndSurvivesThrowingReporter(bool reporterThrows)
    {
        using var handler = new SseHandler($"data: {Message("null")}\n\ndata: {Message("\"123\"")}");
        using var client = new HttpClient(handler) { BaseAddress = new Uri("http://localhost/") };
        int failures = 0;
        using var session = new MilkyHttpSession(new MilkyHttpSessionOptions
        {
            HttpClient = client,
            EventParseExceptionHandler = _ =>
            {
                failures++;
                if (reporterThrows) throw new InvalidOperationException("reporter failed");
            }
        });
        var events = await CollectAsync(session.ReadSseEventsAsync());
        await Assert.That(failures).IsEqualTo(1);
        await Assert.That(events.Count).IsEqualTo(1);
    }

    [Test]
    public async Task WebSocket_CancellationIsNotSwallowed()
    {
        using var cts = new CancellationTokenSource();
        using var socket = new ScriptedWebSocket(Message("\"123\""), Message("\"123\""));
        await using var events = MilkyCommunication.ReadWebSocketEventsAsync(socket).GetAsyncEnumerator(cts.Token);
        await Assert.That(await events.MoveNextAsync()).IsTrue();
        cts.Cancel();
        await Assert.That(await events.MoveNextAsync()).IsFalse();
    }

    private sealed class SseHandler(string payload) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(payload, Encoding.UTF8, "text/event-stream") });
    }

    private static async Task<List<MilkyEvent>> CollectAsync(IAsyncEnumerable<MilkyEvent> source)
    {
        List<MilkyEvent> events = [];
        await foreach (var item in source) events.Add(item);
        return events;
    }

    private sealed class ScriptedWebSocket(params string[] messages) : WebSocket
    {
        private int _index;
        private WebSocketState _state = WebSocketState.Open;
        public override WebSocketState State => _state;
        public override WebSocketCloseStatus? CloseStatus => null;
        public override string? CloseStatusDescription => null;
        public override string? SubProtocol => null;
        public override void Abort() => _state = WebSocketState.Aborted;
        public override void Dispose() => _state = WebSocketState.Closed;
        public override Task CloseAsync(WebSocketCloseStatus closeStatus, string? statusDescription, CancellationToken cancellationToken) => Task.CompletedTask;
        public override Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string? statusDescription, CancellationToken cancellationToken) => Task.CompletedTask;
        public override Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken) => throw new NotSupportedException();
        public override Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (_index == messages.Length)
            {
                _state = WebSocketState.CloseReceived;
                return Task.FromResult(new WebSocketReceiveResult(0, WebSocketMessageType.Close, true));
            }
            byte[] payload = Encoding.UTF8.GetBytes(messages[_index++]);
            payload.AsSpan().CopyTo(buffer.AsSpan());
            return Task.FromResult(new WebSocketReceiveResult(payload.Length, WebSocketMessageType.Text, true));
        }
    }
}
