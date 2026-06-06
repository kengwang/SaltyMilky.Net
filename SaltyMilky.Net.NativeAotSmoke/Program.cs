using System.Text.Json;
using SaltyMilky.Net;

const string messageReceiveJson =
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

MilkyEvent parsed = MilkyEventParser.ParseJson(messageReceiveJson) ?? throw new InvalidOperationException("Event JSON did not parse.");
Check(parsed.Data is MilkyMessageReceiveEventData, "message_receive data should be typed.");

MilkyMessageReceiveEventData messageData = (MilkyMessageReceiveEventData)parsed.Data;
Check(messageData.Message.Segments.Single() is MilkyIncomingTextSegment, "message segment should be typed as text.");
Check(((MilkyIncomingTextSegment)messageData.Message.Segments[0]).Text == "ping", "message text should round-trip.");

string sseText = string.Join('\n', messageReceiveJson.Replace("\r\n", "\n").Split('\n').Select(line => $"data: {line}")) + "\n\n";
Check(MilkyEventParser.ParseSseEvents(sseText).Single().Data is MilkyMessageReceiveEventData, "SSE payload should parse.");

string outgoingJson = JsonSerializer.Serialize(new MilkyTextSegment("hello"), MilkyJson.OutgoingSegmentTypeInfo);
Check(outgoingJson == "{\"type\":\"text\",\"data\":{\"text\":\"hello\"}}", "outgoing text segment should serialize.");

MilkyIncomingSegment? incomingSegment = JsonSerializer.Deserialize(outgoingJson, MilkyJson.IncomingSegmentTypeInfo);
Check(incomingSegment is MilkyIncomingTextSegment incomingText && incomingText.Text == "hello", "incoming text segment should deserialize.");

CountingPlugin plugin = new();
MilkyEventPipeline pipeline = new();
pipeline.Use(plugin.Execute);
await pipeline.ExecuteAsync(parsed);
Check(plugin.ReceivedMessages == 1, "event pipeline should invoke message plugin.");
Check(plugin.LastText == "ping", "plugin should receive typed message text.");

Console.WriteLine("NativeAOT smoke passed");

static void Check(bool condition, string message)
{
    if (!condition)
    {
        throw new InvalidOperationException(message);
    }
}

sealed class CountingPlugin : MilkyEventPlugin
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
