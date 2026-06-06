using System.Text.Json;
using SaltyMilky.Net;
using TUnit.Assertions;
using TUnit.Core;

namespace SaltyMilky.Net.Tests;

public sealed class MilkyNativeAotCompatibilityTests
{
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
    public async Task ParseSseEvents_DataLines_ReturnsParsedEvents()
    {
        string sseText = string.Join('\n', MessageReceiveJson.Replace("\r\n", "\n").Split('\n').Select(line => $"data: {line}")) + "\n\n";

        MilkyEvent[] events = MilkyEventParser.ParseSseEvents(sseText).ToArray();

        await Assert.That(events.Length).IsEqualTo(1);
        await Assert.That(events[0].Data).IsTypeOf<MilkyMessageReceiveEventData>();
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
        await Assert.That(parsed!.Data).IsTypeOf<MilkyCommonEventData>();
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
        await Assert.That(parsed!.Data).IsTypeOf<MilkyCommonEventData>();
        MilkyCommonEventData data = (MilkyCommonEventData)parsed.Data;
        await Assert.That(data.EventType).IsEqualTo("group_message_reaction");
        await Assert.That(data.IsAdd).IsTrue();
        await Assert.That(data.ReactionType).IsEqualTo("face");
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
