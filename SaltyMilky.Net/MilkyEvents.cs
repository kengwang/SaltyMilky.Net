using System.Text.Json;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>Milky event envelope for WebSocket, WebHook, and SSE payloads.</summary>
[JsonConverter(typeof(MilkyEventJsonConverter))]
public sealed record class MilkyEvent
{
    /// <summary>Gets or sets the event type.</summary>
    [JsonPropertyName("event_type")]
    public string EventType { get; set; } = string.Empty;
    /// <summary>Gets or sets the event Unix time in seconds.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
    /// <summary>Gets or sets the bot QQ number.</summary>
    [JsonPropertyName("self_id")]
    public long SelfId { get; set; }
    /// <summary>Gets or sets typed event data.</summary>
    [JsonPropertyName("data")]
    public MilkyEventData Data { get; set; } = new MilkyUnknownEventData(string.Empty, default);
}

/// <summary>Base type for Milky event data.</summary>
public abstract record class MilkyEventData
{
    /// <summary>Gets the event type.</summary>
    [JsonIgnore]
    public abstract string EventType { get; }
}

/// <summary>Bot offline event data.</summary>
public record class MilkyBotOfflineEventData([property: JsonPropertyName("reason")] string Reason) : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "bot_offline";
}

/// <summary>Message receive event data.</summary>
public record class MilkyMessageReceiveEventData([property: JsonPropertyName("message")] MilkyIncomingMessage Message) : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "message_receive";
}
/// <summary>Message recall event data.</summary>
public record class MilkyMessageRecallEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "message_recall";
    /// <summary>Gets or sets message scene.</summary>
    [JsonPropertyName("message_scene")]
    public string MessageScene { get; set; } = string.Empty;
    /// <summary>Gets or sets peer ID.</summary>
    [JsonPropertyName("peer_id")]
    public long PeerId { get; set; }
    /// <summary>Gets or sets message sequence.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
    /// <summary>Gets or sets sender ID.</summary>
    [JsonPropertyName("sender_id")]
    public long SenderId { get; set; }
    /// <summary>Gets or sets operator ID.</summary>
    [JsonPropertyName("operator_id")]
    public long OperatorId { get; set; }
    /// <summary>Gets or sets display suffix.</summary>
    [JsonPropertyName("display_suffix")]
    public string DisplaySuffix { get; set; } = string.Empty;
}

/// <summary>Generic structured event data for scalar event variants.</summary>
public record class MilkyCommonEventData(string Kind) : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => Kind;
    /// <summary>Gets or sets message scene.</summary>
    [JsonPropertyName("message_scene")]
    public string? MessageScene { get; set; }
    /// <summary>Gets or sets peer ID.</summary>
    [JsonPropertyName("peer_id")]
    public long? PeerId { get; set; }
    /// <summary>Gets or sets group ID.</summary>
    [JsonPropertyName("group_id")]
    public long? GroupId { get; set; }
    /// <summary>Gets or sets user ID.</summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }
    /// <summary>Gets or sets sender ID.</summary>
    [JsonPropertyName("sender_id")]
    public long? SenderId { get; set; }
    /// <summary>Gets or sets receiver ID.</summary>
    [JsonPropertyName("receiver_id")]
    public long? ReceiverId { get; set; }
    /// <summary>Gets or sets operator ID.</summary>
    [JsonPropertyName("operator_id")]
    public long? OperatorId { get; set; }
    /// <summary>Gets or sets initiator ID.</summary>
    [JsonPropertyName("initiator_id")]
    public long? InitiatorId { get; set; }
    /// <summary>Gets or sets invitor ID.</summary>
    [JsonPropertyName("invitor_id")]
    public long? InvitorId { get; set; }
    /// <summary>Gets or sets target user ID.</summary>
    [JsonPropertyName("target_user_id")]
    public long? TargetUserId { get; set; }
    /// <summary>Gets or sets source group ID.</summary>
    [JsonPropertyName("source_group_id")]
    public long? SourceGroupId { get; set; }
    /// <summary>Gets or sets message sequence.</summary>
    [JsonPropertyName("message_seq")]
    public long? MessageSeq { get; set; }
    /// <summary>Gets or sets notification sequence.</summary>
    [JsonPropertyName("notification_seq")]
    public long? NotificationSeq { get; set; }
    /// <summary>Gets or sets invitation sequence.</summary>
    [JsonPropertyName("invitation_seq")]
    public long? InvitationSeq { get; set; }
    /// <summary>Gets or sets whether the event is filtered.</summary>
    [JsonPropertyName("is_filtered")]
    public bool? IsFiltered { get; set; }
    /// <summary>Gets or sets whether the flag is set.</summary>
    [JsonPropertyName("is_set")]
    public bool? IsSet { get; set; }
    /// <summary>Gets or sets whether muted.</summary>
    [JsonPropertyName("is_mute")]
    public bool? IsMute { get; set; }
    /// <summary>Gets or sets whether pinned.</summary>
    [JsonPropertyName("is_pinned")]
    public bool? IsPinned { get; set; }
    /// <summary>Gets or sets whether an item was added.</summary>
    [JsonPropertyName("is_add")]
    public bool? IsAdd { get; set; }
    /// <summary>Gets or sets whether self sent.</summary>
    [JsonPropertyName("is_self_send")]
    public bool? IsSelfSend { get; set; }
    /// <summary>Gets or sets whether self received.</summary>
    [JsonPropertyName("is_self_receive")]
    public bool? IsSelfReceive { get; set; }
    /// <summary>Gets or sets whether self.</summary>
    [JsonPropertyName("is_self")]
    public bool? IsSelf { get; set; }
    /// <summary>Gets or sets duration.</summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }
    /// <summary>Gets or sets reaction type.</summary>
    [JsonPropertyName("reaction_type")]
    public string? ReactionType { get; set; }
    /// <summary>Gets or sets face ID.</summary>
    [JsonPropertyName("face_id")]
    public string? FaceId { get; set; }
    /// <summary>Gets or sets file ID.</summary>
    [JsonPropertyName("file_id")]
    public string? FileId { get; set; }
    /// <summary>Gets or sets file name.</summary>
    [JsonPropertyName("file_name")]
    public string? FileName { get; set; }
    /// <summary>Gets or sets file size.</summary>
    [JsonPropertyName("file_size")]
    public long? FileSize { get; set; }
    /// <summary>Gets or sets file hash.</summary>
    [JsonPropertyName("file_hash")]
    public string? FileHash { get; set; }
    /// <summary>Gets or sets UID.</summary>
    [JsonPropertyName("initiator_uid")]
    public string? InitiatorUid { get; set; }
    /// <summary>Gets or sets comment.</summary>
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }
    /// <summary>Gets or sets source.</summary>
    [JsonPropertyName("via")]
    public string? Via { get; set; }
    /// <summary>Gets or sets display action.</summary>
    [JsonPropertyName("display_action")]
    public string? DisplayAction { get; set; }
    /// <summary>Gets or sets display suffix.</summary>
    [JsonPropertyName("display_suffix")]
    public string? DisplaySuffix { get; set; }
    /// <summary>Gets or sets display action image URL.</summary>
    [JsonPropertyName("display_action_img_url")]
    public string? DisplayActionImageUrl { get; set; }
    /// <summary>Gets or sets new group name.</summary>
    [JsonPropertyName("new_group_name")]
    public string? NewGroupName { get; set; }
}

/// <summary>Unknown event data preserved as raw JSON.</summary>
public record class MilkyUnknownEventData(string Kind, JsonElement RawData) : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => Kind;
}

/// <summary>Parses Milky event payloads.</summary>
public static class MilkyEventParser
{
    /// <summary>Parses a WebSocket or WebHook event JSON payload.</summary>
    public static MilkyEvent? ParseJson(string json) => JsonSerializer.Deserialize(json, MilkyJsonSerializerContext.Default.MilkyEvent);

    /// <summary>Parses events from Server-Sent Events text.</summary>
    public static IEnumerable<MilkyEvent> ParseSseEvents(string sseText)
    {
        ArgumentNullException.ThrowIfNull(sseText);
        List<string> dataLines = [];
        foreach (string line in sseText.Replace("\r\n", "\n").Split('\n'))
        {
            if (line.Length == 0)
            {
                foreach (MilkyEvent item in Flush(dataLines))
                {
                    yield return item;
                }

                continue;
            }

            if (line.StartsWith("data:", StringComparison.Ordinal))
            {
                dataLines.Add(line[5..].TrimStart());
            }
        }

        foreach (MilkyEvent item in Flush(dataLines))
        {
            yield return item;
        }
    }

    private static IEnumerable<MilkyEvent> Flush(List<string> dataLines)
    {
        if (dataLines.Count == 0)
        {
            yield break;
        }

        string json = string.Join('\n', dataLines);
        dataLines.Clear();
        MilkyEvent? parsed = ParseJson(json);
        if (parsed is not null)
        {
            yield return parsed;
        }
    }
}

/// <summary>JSON converter for Milky events.</summary>
public sealed class MilkyEventJsonConverter : JsonConverter<MilkyEvent>
{
    /// <inheritdoc />
    public override MilkyEvent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement root = document.RootElement;
        string eventType = root.GetProperty("event_type").GetString() ?? string.Empty;
        long time = root.TryGetProperty("time", out JsonElement timeElement) ? timeElement.GetInt64() : 0;
        long selfId = root.TryGetProperty("self_id", out JsonElement selfElement) ? selfElement.GetInt64() : 0;
        JsonElement dataElement = root.TryGetProperty("data", out JsonElement nestedData) ? nestedData : root;

        MilkyEventData? data = eventType switch
        {
            "bot_offline" => dataElement.Deserialize(MilkyJsonSerializerContext.Default.MilkyBotOfflineEventData),
            "message_receive" => ReadMessageReceive(dataElement, options),
            "message_recall" => dataElement.Deserialize(MilkyJsonSerializerContext.Default.MilkyMessageRecallEventData),
            "peer_pin_change" or "friend_request" or "group_join_request" or "group_invited_join_request" or "group_invitation" or "friend_nudge" or "friend_file_upload" or "group_admin_change" or "group_essence_message_change" or "group_member_increase" or "group_member_decrease" or "group_name_change" or "group_message_reaction" or "group_mute" or "group_whole_mute" or "group_nudge" or "group_file_upload" => ReadCommon(eventType, dataElement, options),
            _ => new MilkyUnknownEventData(eventType, dataElement.Clone()),
        };

        return new MilkyEvent { EventType = eventType, Time = time, SelfId = selfId, Data = data ?? new MilkyUnknownEventData(eventType, dataElement.Clone()) };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, MilkyEvent value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("event_type", value.EventType);
        writer.WriteNumber("time", value.Time);
        writer.WriteNumber("self_id", value.SelfId);
        writer.WritePropertyName("data");
        switch (value.Data)
        {
            case MilkyBotOfflineEventData data:
                JsonSerializer.Serialize(writer, data, MilkyJsonSerializerContext.Default.MilkyBotOfflineEventData);
                break;
            case MilkyMessageReceiveEventData data:
                JsonSerializer.Serialize(writer, data, MilkyJsonSerializerContext.Default.MilkyMessageReceiveEventData);
                break;
            case MilkyMessageRecallEventData data:
                JsonSerializer.Serialize(writer, data, MilkyJsonSerializerContext.Default.MilkyMessageRecallEventData);
                break;
            case MilkyCommonEventData data:
                JsonSerializer.Serialize(writer, data, MilkyJsonSerializerContext.Default.MilkyCommonEventData);
                break;
            case MilkyUnknownEventData data:
                data.RawData.WriteTo(writer);
                break;
            default:
                writer.WriteStartObject();
                writer.WriteEndObject();
                break;
        }
        writer.WriteEndObject();
    }

    private static MilkyEventData? ReadCommon(string eventType, JsonElement dataElement, JsonSerializerOptions options)
    {
        MilkyCommonEventData? data = dataElement.Deserialize(MilkyJsonSerializerContext.Default.MilkyCommonEventData);
        return data is null ? null : data with { Kind = eventType };
    }

    private static MilkyEventData? ReadMessageReceive(JsonElement dataElement, JsonSerializerOptions options)
    {
        if (dataElement.TryGetProperty("message", out JsonElement messageElement))
        {
            MilkyIncomingMessage? message = messageElement.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingMessage);
            return message is null ? null : new MilkyMessageReceiveEventData(message);
        }

        MilkyIncomingMessage? inlined = dataElement.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingMessage);
        return inlined is null ? null : new MilkyMessageReceiveEventData(inlined);
    }
}
