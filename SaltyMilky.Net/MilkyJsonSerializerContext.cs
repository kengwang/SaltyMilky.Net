using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>
/// Source-generated JSON metadata for NativeAOT-sensitive Milky SDK internals.
/// </summary>
[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(MilkyApiResponseRaw))]
[JsonSerializable(typeof(MilkyEmptyObject))]
[JsonSerializable(typeof(MilkyTextSegment))]
[JsonSerializable(typeof(MilkyMentionSegment))]
[JsonSerializable(typeof(MilkyMentionAllSegment))]
[JsonSerializable(typeof(MilkyFaceSegment))]
[JsonSerializable(typeof(MilkyReplySegment))]
[JsonSerializable(typeof(MilkyImageSegment))]
[JsonSerializable(typeof(MilkyRecordSegment))]
[JsonSerializable(typeof(MilkyVideoSegment))]
[JsonSerializable(typeof(MilkyForwardSegment))]
[JsonSerializable(typeof(MilkyLightAppSegment))]
[JsonSerializable(typeof(MilkyIncomingTextSegment))]
[JsonSerializable(typeof(MilkyIncomingMentionSegment))]
[JsonSerializable(typeof(MilkyIncomingMentionAllSegment))]
[JsonSerializable(typeof(MilkyIncomingFaceSegment))]
[JsonSerializable(typeof(MilkyIncomingReplySegment))]
[JsonSerializable(typeof(MilkyIncomingImageSegment))]
[JsonSerializable(typeof(MilkyIncomingRecordSegment))]
[JsonSerializable(typeof(MilkyIncomingVideoSegment))]
[JsonSerializable(typeof(MilkyFileIncomingSegment))]
[JsonSerializable(typeof(MilkyIncomingForwardSegment))]
[JsonSerializable(typeof(MilkyMarketFaceIncomingSegment))]
[JsonSerializable(typeof(MilkyIncomingLightAppSegment))]
[JsonSerializable(typeof(MilkyXmlIncomingSegment))]
[JsonSerializable(typeof(MilkyIncomingMessage))]
[JsonSerializable(typeof(MilkyBotOfflineEventData))]
[JsonSerializable(typeof(MilkyMessageReceiveEventData))]
[JsonSerializable(typeof(MilkyMessageRecallEventData))]
[JsonSerializable(typeof(MilkyCommonEventData))]
[JsonSerializable(typeof(MilkyUnknownEventData))]
[JsonSerializable(typeof(MilkyEvent))]
internal partial class MilkyJsonSerializerContext : JsonSerializerContext
{
}
