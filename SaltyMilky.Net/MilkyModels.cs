using System.Text.Json;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>
/// A complete outgoing Milky message.
/// </summary>
public class MilkyMessage : List<MilkyOutgoingSegment>
{
    /// <summary>
    /// Initializes an empty message.
    /// </summary>
    public MilkyMessage()
    {
    }

    /// <summary>
    /// Initializes a message with segments.
    /// </summary>
    public MilkyMessage(IEnumerable<MilkyOutgoingSegment> collection) : base(collection)
    {
    }

    /// <summary>
    /// Initializes a text message.
    /// </summary>
    public MilkyMessage(string text) => Add(new MilkyTextSegment(text));

    /// <summary>
    /// Initializes a message with the supplied segments.
    /// </summary>
    public MilkyMessage(params MilkyOutgoingSegment[] segments) : base(segments)
    {
    }

    /// <summary>
    /// Gets concatenated text segment content.
    /// </summary>
    public string Text => string.Concat(this.OfType<MilkyTextSegment>().Select(segment => segment.Text));
}

/// <summary>
/// Base type for outgoing Milky message segments.
/// </summary>
[JsonConverter(typeof(MilkyOutgoingSegmentJsonConverter))]
public abstract record class MilkyOutgoingSegment
{
    /// <summary>
    /// Gets the Milky segment type.
    /// </summary>
    [JsonIgnore]
    public abstract string Type { get; }
}

/// <summary>
/// Base type for incoming Milky message segments.
/// </summary>
[JsonConverter(typeof(MilkyIncomingSegmentJsonConverter))]
public abstract record class MilkyIncomingSegment
{
    /// <summary>
    /// Gets the Milky segment type.
    /// </summary>
    [JsonIgnore]
    public abstract string Type { get; }
}

/// <summary>
/// Text segment.
/// </summary>
public record class MilkyTextSegment : MilkyOutgoingSegment
{
    /// <summary>
    /// Initializes a text segment.
    /// </summary>
    public MilkyTextSegment(string text) => Text = text;

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "text";

    /// <summary>
    /// Gets or sets the text content.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; }

    /// <summary>
    /// Converts text to a text segment.
    /// </summary>
    public static implicit operator MilkyTextSegment(string text) => new(text);
}

/// <summary>
/// Incoming text segment.
/// </summary>
public record class MilkyIncomingTextSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "text";

    /// <summary>
    /// Gets or sets the text content.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}

/// <summary>
/// Mention segment.
/// </summary>
public record class MilkyMentionSegment(long UserId) : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "mention";

    /// <summary>
    /// Gets the mentioned QQ number.
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; } = UserId;
}

/// <summary>
/// Incoming mention segment.
/// </summary>
public record class MilkyIncomingMentionSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "mention";

    /// <summary>
    /// Gets or sets the mentioned QQ number.
    /// </summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the mentioned display name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

/// <summary>
/// Mention-all segment.
/// </summary>
public record class MilkyMentionAllSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "mention_all";
}

/// <summary>
/// Incoming mention-all segment.
/// </summary>
public record class MilkyIncomingMentionAllSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "mention_all";
}

/// <summary>
/// Face segment.
/// </summary>
public record class MilkyFaceSegment(string FaceId, bool IsLarge = false) : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "face";

    /// <summary>
    /// Gets the face ID.
    /// </summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; init; } = FaceId;

    /// <summary>
    /// Gets whether the face is large.
    /// </summary>
    [JsonPropertyName("is_large")]
    public bool IsLarge { get; init; } = IsLarge;
}

/// <summary>
/// Incoming face segment.
/// </summary>
public record class MilkyIncomingFaceSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "face";

    /// <summary>Gets or sets the face ID.</summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; set; } = string.Empty;

    /// <summary>Gets or sets whether the face is large.</summary>
    [JsonPropertyName("is_large")]
    public bool IsLarge { get; set; }
}

/// <summary>
/// Reply segment.
/// </summary>
public record class MilkyReplySegment(long MessageSeq) : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "reply";

    /// <summary>
    /// Gets the replied message sequence.
    /// </summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; init; } = MessageSeq;
}

/// <summary>
/// Incoming reply segment.
/// </summary>
public record class MilkyIncomingReplySegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "reply";

    /// <summary>
    /// Gets or sets the replied message sequence.
    /// </summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }

    /// <summary>
    /// Gets or sets the sender ID.
    /// </summary>
    [JsonPropertyName("sender_id")]
    public long SenderId { get; set; }

    /// <summary>
    /// Gets or sets the sender name.
    /// </summary>
    [JsonPropertyName("sender_name")]
    public string? SenderName { get; set; }

    /// <summary>
    /// Gets or sets the original message time.
    /// </summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }

    /// <summary>
    /// Gets or sets the original segments.
    /// </summary>
    [JsonPropertyName("segments")]
    public List<MilkyIncomingSegment> Segments { get; set; } = [];
}

/// <summary>
/// Image segment.
/// </summary>
public record class MilkyImageSegment(string Uri, string SubType = "normal", string? Summary = null) : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "image";

    /// <summary>
    /// Gets the image URI.
    /// </summary>
    [JsonPropertyName("uri")]
    public string Uri { get; init; } = Uri;

    /// <summary>
    /// Gets the image subtype.
    /// </summary>
    [JsonPropertyName("sub_type")]
    public string SubType { get; init; } = SubType;

    /// <summary>
    /// Gets the image summary.
    /// </summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; init; } = Summary;
}

/// <summary>
/// Incoming image segment.
/// </summary>
public record class MilkyIncomingImageSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "image";

    /// <summary>Gets or sets the resource ID.</summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; } = string.Empty;
    /// <summary>Gets or sets the temporary URL.</summary>
    [JsonPropertyName("temp_url")]
    public string TempUrl { get; set; } = string.Empty;
    /// <summary>Gets or sets the width.</summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }
    /// <summary>Gets or sets the height.</summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }
    /// <summary>Gets or sets the summary.</summary>
    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;
    /// <summary>Gets or sets the subtype.</summary>
    [JsonPropertyName("sub_type")]
    public string SubType { get; set; } = string.Empty;
}

/// <summary>
/// Record segment.
/// </summary>
public record class MilkyRecordSegment(string Uri) : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "record";

    /// <summary>Gets the record URI.</summary>
    [JsonPropertyName("uri")]
    public string Uri { get; init; } = Uri;
}

/// <summary>
/// Incoming record segment.
/// </summary>
public record class MilkyIncomingRecordSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "record";

    /// <summary>Gets or sets the resource ID.</summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; } = string.Empty;
    /// <summary>Gets or sets the temporary URL.</summary>
    [JsonPropertyName("temp_url")]
    public string TempUrl { get; set; } = string.Empty;
    /// <summary>Gets or sets the duration.</summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}

/// <summary>
/// Video segment.
/// </summary>
public record class MilkyVideoSegment(string Uri, string? ThumbUri = null) : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "video";

    /// <summary>Gets the video URI.</summary>
    [JsonPropertyName("uri")]
    public string Uri { get; init; } = Uri;
    /// <summary>Gets the thumbnail URI.</summary>
    [JsonPropertyName("thumb_uri")]
    public string? ThumbUri { get; init; } = ThumbUri;
}

/// <summary>
/// Incoming video segment.
/// </summary>
public record class MilkyIncomingVideoSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "video";
    /// <summary>Gets or sets the resource ID.</summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; } = string.Empty;
    /// <summary>Gets or sets the temporary URL.</summary>
    [JsonPropertyName("temp_url")]
    public string TempUrl { get; set; } = string.Empty;
    /// <summary>Gets or sets the width.</summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }
    /// <summary>Gets or sets the height.</summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }
    /// <summary>Gets or sets the duration.</summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}

/// <summary>
/// Outgoing forwarded message node.
/// </summary>
public record class MilkyOutgoingForwardedMessage(long UserId, string SenderName, MilkyMessage Segments)
{
    /// <summary>Gets the sender QQ number.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; init; } = UserId;
    /// <summary>Gets the sender name.</summary>
    [JsonPropertyName("sender_name")]
    public string SenderName { get; init; } = SenderName;
    /// <summary>Gets the message segments.</summary>
    [JsonPropertyName("segments")]
    public MilkyMessage Segments { get; init; } = Segments;
}

/// <summary>
/// Forward segment.
/// </summary>
public record class MilkyForwardSegment : MilkyOutgoingSegment
{
    /// <summary>Initializes a forward segment.</summary>
    public MilkyForwardSegment(IEnumerable<MilkyOutgoingForwardedMessage> messages) => Messages = messages.ToList();

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "forward";
    /// <summary>Gets forwarded messages.</summary>
    [JsonPropertyName("messages")]
    public List<MilkyOutgoingForwardedMessage> Messages { get; init; }
    /// <summary>Gets or sets the title.</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    /// <summary>Gets or sets the preview lines.</summary>
    [JsonPropertyName("preview")]
    public List<string>? Preview { get; set; }
    /// <summary>Gets or sets the summary.</summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }
    /// <summary>Gets or sets the prompt.</summary>
    [JsonPropertyName("prompt")]
    public string? Prompt { get; set; }
}

/// <summary>
/// Incoming forward segment.
/// </summary>
public record class MilkyIncomingForwardSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "forward";
    /// <summary>Gets or sets the forward ID.</summary>
    [JsonPropertyName("forward_id")]
    public string ForwardId { get; set; } = string.Empty;
    /// <summary>Gets or sets the title.</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    /// <summary>Gets or sets preview lines.</summary>
    [JsonPropertyName("preview")]
    public List<string>? Preview { get; set; }
    /// <summary>Gets or sets the summary.</summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }
}

/// <summary>
/// Light app segment.
/// </summary>
public record class MilkyLightAppSegment(string JsonPayload) : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "light_app";
    /// <summary>Gets the JSON payload.</summary>
    [JsonPropertyName("json_payload")]
    public string JsonPayload { get; init; } = JsonPayload;
}

/// <summary>
/// Markdown segment.
/// </summary>
public record class MilkyMarkdownSegment : MilkyOutgoingSegment
{
    /// <summary>Initializes an empty Markdown segment for JSON deserialization.</summary>
    [JsonConstructor]
    public MilkyMarkdownSegment()
    {
    }

    /// <summary>Initializes a Markdown segment.</summary>
    public MilkyMarkdownSegment(string content) => Content = content;

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "markdown";
    /// <summary>Gets the Markdown content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
    /// <summary>Gets additional fields for implementation-specific Markdown payload variants.</summary>
    [JsonIgnore]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Incoming light app segment.
/// </summary>
public record class MilkyIncomingLightAppSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "light_app";
    /// <summary>Gets or sets app name.</summary>
    [JsonPropertyName("app_name")]
    public string? AppName { get; set; }
    /// <summary>Gets or sets JSON payload.</summary>
    [JsonPropertyName("json_payload")]
    public string JsonPayload { get; set; } = string.Empty;
}

/// <summary>
/// Incoming Markdown segment.
/// </summary>
public record class MilkyIncomingMarkdownSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "markdown";
    /// <summary>Gets or sets the Markdown content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
    /// <summary>Gets or sets additional fields for implementation-specific Markdown payload variants.</summary>
    [JsonIgnore]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Incoming file segment.
/// </summary>
public record class MilkyFileIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "file";
    /// <summary>Gets or sets file ID.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
    /// <summary>Gets or sets file name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets file size.</summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }
    /// <summary>Gets or sets file hash.</summary>
    [JsonPropertyName("file_hash")]
    public string? FileHash { get; set; }
}

/// <summary>
/// Incoming market face segment.
/// </summary>
public record class MilkyMarketFaceIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "market_face";
    /// <summary>Gets or sets the package ID.</summary>
    [JsonPropertyName("emoji_package_id")]
    public int EmojiPackageId { get; set; }
    /// <summary>Gets or sets emoji ID.</summary>
    [JsonPropertyName("emoji_id")]
    public string EmojiId { get; set; } = string.Empty;
    /// <summary>Gets or sets key.</summary>
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
    /// <summary>Gets or sets summary.</summary>
    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;
    /// <summary>Gets or sets URL.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}

/// <summary>
/// Incoming XML segment.
/// </summary>
public record class MilkyXmlIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "xml";
    /// <summary>Gets or sets service ID.</summary>
    [JsonPropertyName("service_id")]
    public int ServiceId { get; set; }
    /// <summary>Gets or sets XML payload.</summary>
    [JsonPropertyName("xml_payload")]
    public string XmlPayload { get; set; } = string.Empty;
}

/// <summary>
/// Unknown incoming segment preserved as raw JSON.
/// </summary>
public record class MilkyUnknownIncomingSegment(string SegmentType, JsonElement Data) : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => SegmentType;
}

/// <summary>
/// JSON converter for outgoing segments.
/// </summary>
public sealed class MilkyOutgoingSegmentJsonConverter : JsonConverter<MilkyOutgoingSegment>
{
    /// <inheritdoc />
    public override MilkyOutgoingSegment? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonDocument document = JsonDocument.ParseValue(ref reader);
        string type = document.RootElement.GetProperty("type").GetString() ?? string.Empty;
        JsonElement data = document.RootElement.TryGetProperty("data", out JsonElement nestedData) ? nestedData : document.RootElement;
        return type switch
        {
            "text" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyTextSegment),
            "mention" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyMentionSegment),
            "mention_all" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyMentionAllSegment),
            "face" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyFaceSegment),
            "reply" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyReplySegment),
            "image" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyImageSegment),
            "record" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyRecordSegment),
            "video" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyVideoSegment),
            "forward" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyForwardSegment),
            "light_app" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyLightAppSegment),
            "markdown" => ReadMarkdownSegment(data),
            _ => throw new JsonException($"Unknown outgoing segment type: {type}"),
        };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, MilkyOutgoingSegment value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("type", value.Type);
        writer.WritePropertyName("data");
        switch (value)
        {
            case MilkyTextSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyTextSegment);
                break;
            case MilkyMentionSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyMentionSegment);
                break;
            case MilkyMentionAllSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyMentionAllSegment);
                break;
            case MilkyFaceSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyFaceSegment);
                break;
            case MilkyReplySegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyReplySegment);
                break;
            case MilkyImageSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyImageSegment);
                break;
            case MilkyRecordSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyRecordSegment);
                break;
            case MilkyVideoSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyVideoSegment);
                break;
            case MilkyForwardSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyForwardSegment);
                break;
            case MilkyLightAppSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyLightAppSegment);
                break;
            case MilkyMarkdownSegment segment:
                WriteMarkdownData(writer, segment.Content, segment.ExtensionData);
                break;
            default:
                throw new JsonException($"Unknown outgoing segment type: {value.GetType().Name}");
        }

        writer.WriteEndObject();
    }

    private static MilkyMarkdownSegment ReadMarkdownSegment(JsonElement data)
    {
        MilkyMarkdownSegment segment = new(data.TryGetProperty("content", out JsonElement content) ? content.GetString() ?? string.Empty : string.Empty);
        Dictionary<string, JsonElement>? extensionData = null;
        foreach (JsonProperty property in data.EnumerateObject())
        {
            if (property.NameEquals("content"))
            {
                continue;
            }

            extensionData ??= [];
            extensionData[property.Name] = property.Value.Clone();
        }

        segment.ExtensionData = extensionData;
        return segment;
    }

    private static void WriteMarkdownData(Utf8JsonWriter writer, string content, Dictionary<string, JsonElement>? extensionData)
    {
        writer.WriteStartObject();
        writer.WriteString("content", content);
        if (extensionData is not null)
        {
            foreach (KeyValuePair<string, JsonElement> property in extensionData)
            {
                if (property.Key == "content")
                {
                    continue;
                }

                writer.WritePropertyName(property.Key);
                property.Value.WriteTo(writer);
            }
        }

        writer.WriteEndObject();
    }
}

/// <summary>
/// JSON converter for incoming segments.
/// </summary>
public sealed class MilkyIncomingSegmentJsonConverter : JsonConverter<MilkyIncomingSegment>
{
    /// <inheritdoc />
    public override MilkyIncomingSegment? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonDocument document = JsonDocument.ParseValue(ref reader);
        string type = document.RootElement.GetProperty("type").GetString() ?? string.Empty;
        JsonElement data = document.RootElement.TryGetProperty("data", out JsonElement nestedData) ? nestedData : document.RootElement;
        return type switch
        {
            "text" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingTextSegment),
            "mention" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingMentionSegment),
            "mention_all" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingMentionAllSegment),
            "face" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingFaceSegment),
            "reply" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingReplySegment),
            "image" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingImageSegment),
            "record" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingRecordSegment),
            "video" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingVideoSegment),
            "file" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyFileIncomingSegment),
            "forward" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingForwardSegment),
            "market_face" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyMarketFaceIncomingSegment),
            "light_app" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingLightAppSegment),
            "xml" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyXmlIncomingSegment),
            "markdown" => ReadMarkdownSegment(data),
            _ => new MilkyIncomingTextSegment { Text = $"[unsupported Milky segment: {type}]" },
        };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, MilkyIncomingSegment value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("type", value.Type);
        writer.WritePropertyName("data");
        switch (value)
        {
            case MilkyIncomingTextSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingTextSegment);
                break;
            case MilkyIncomingMentionSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingMentionSegment);
                break;
            case MilkyIncomingMentionAllSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingMentionAllSegment);
                break;
            case MilkyIncomingFaceSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingFaceSegment);
                break;
            case MilkyIncomingReplySegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingReplySegment);
                break;
            case MilkyIncomingImageSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingImageSegment);
                break;
            case MilkyIncomingRecordSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingRecordSegment);
                break;
            case MilkyIncomingVideoSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingVideoSegment);
                break;
            case MilkyFileIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyFileIncomingSegment);
                break;
            case MilkyIncomingForwardSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingForwardSegment);
                break;
            case MilkyMarketFaceIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyMarketFaceIncomingSegment);
                break;
            case MilkyIncomingLightAppSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyIncomingLightAppSegment);
                break;
            case MilkyXmlIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyXmlIncomingSegment);
                break;
            case MilkyIncomingMarkdownSegment segment:
                WriteMarkdownData(writer, segment.Content, segment.ExtensionData);
                break;
            case MilkyUnknownIncomingSegment segment:
                segment.Data.WriteTo(writer);
                break;
            default:
                throw new JsonException($"Unknown incoming segment type: {value.GetType().Name}");
        }

        writer.WriteEndObject();
    }

    private static MilkyIncomingMarkdownSegment ReadMarkdownSegment(JsonElement data)
    {
        MilkyIncomingMarkdownSegment segment = new()
        {
            Content = data.TryGetProperty("content", out JsonElement content) ? content.GetString() ?? string.Empty : string.Empty,
        };
        Dictionary<string, JsonElement>? extensionData = null;
        foreach (JsonProperty property in data.EnumerateObject())
        {
            if (property.NameEquals("content"))
            {
                continue;
            }

            extensionData ??= [];
            extensionData[property.Name] = property.Value.Clone();
        }

        segment.ExtensionData = extensionData;
        return segment;
    }

    private static void WriteMarkdownData(Utf8JsonWriter writer, string content, Dictionary<string, JsonElement>? extensionData)
    {
        writer.WriteStartObject();
        writer.WriteString("content", content);
        if (extensionData is not null)
        {
            foreach (KeyValuePair<string, JsonElement> property in extensionData)
            {
                if (property.Key == "content")
                {
                    continue;
                }

                writer.WritePropertyName(property.Key);
                property.Value.WriteTo(writer);
            }
        }

        writer.WriteEndObject();
    }
}
/// <summary>Friend category information.</summary>
public record class MilkyFriendCategoryEntity
{
    /// <summary>Gets or sets category ID.</summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }
    /// <summary>Gets or sets category name.</summary>
    [JsonPropertyName("category_name")]
    public string CategoryName { get; set; } = string.Empty;
}

/// <summary>Friend information.</summary>
public record class MilkyFriendEntity
{
    /// <summary>Gets or sets user QQ number.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets sex.</summary>
    [JsonPropertyName("sex")]
    public string Sex { get; set; } = "unknown";
    /// <summary>Gets or sets QID.</summary>
    [JsonPropertyName("qid")]
    public string Qid { get; set; } = string.Empty;
    /// <summary>Gets or sets remark.</summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; } = string.Empty;
    /// <summary>Gets or sets category.</summary>
    [JsonPropertyName("category")]
    public MilkyFriendCategoryEntity? Category { get; set; }
}

/// <summary>Group information.</summary>
public record class MilkyGroupEntity
{
    /// <summary>Gets or sets group QQ number.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets group name.</summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; } = string.Empty;
    /// <summary>Gets or sets member count.</summary>
    [JsonPropertyName("member_count")]
    public int MemberCount { get; set; }
    /// <summary>Gets or sets max member count.</summary>
    [JsonPropertyName("max_member_count")]
    public int MaxMemberCount { get; set; }
    /// <summary>Gets or sets remark.</summary>
    [JsonPropertyName("remark")]
    public string? Remark { get; set; }
    /// <summary>Gets or sets created time.</summary>
    [JsonPropertyName("created_time")]
    public long? CreatedTime { get; set; }
    /// <summary>Gets or sets description.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    /// <summary>Gets or sets question.</summary>
    [JsonPropertyName("question")]
    public string? Question { get; set; }
    /// <summary>Gets or sets announcement preview.</summary>
    [JsonPropertyName("announcement")]
    public string? Announcement { get; set; }
}

/// <summary>Group member information.</summary>
public record class MilkyGroupMemberEntity
{
    /// <summary>Gets or sets user QQ number.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets sex.</summary>
    [JsonPropertyName("sex")]
    public string Sex { get; set; } = "unknown";
    /// <summary>Gets or sets group QQ number.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets card.</summary>
    [JsonPropertyName("card")]
    public string Card { get; set; } = string.Empty;
    /// <summary>Gets or sets title.</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    /// <summary>Gets or sets level.</summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }
    /// <summary>Gets or sets role.</summary>
    [JsonPropertyName("role")]
    public string Role { get; set; } = "member";
    /// <summary>Gets or sets join time.</summary>
    [JsonPropertyName("join_time")]
    public long JoinTime { get; set; }
    /// <summary>Gets or sets last sent time.</summary>
    [JsonPropertyName("last_sent_time")]
    public long LastSentTime { get; set; }
    /// <summary>Gets or sets mute end time.</summary>
    [JsonPropertyName("shut_up_end_time")]
    public long? ShutUpEndTime { get; set; }
}

/// <summary>Group announcement information.</summary>
public record class MilkyGroupAnnouncementEntity
{
    /// <summary>Gets or sets group QQ number.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets announcement ID.</summary>
    [JsonPropertyName("announcement_id")]
    public string AnnouncementId { get; set; } = string.Empty;
    /// <summary>Gets or sets user QQ number.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
    /// <summary>Gets or sets image URL.</summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }
}

/// <summary>Group file information.</summary>
public record class MilkyGroupFileEntity
{
    /// <summary>Gets or sets group QQ number.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets file ID.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
    /// <summary>Gets or sets file name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets parent folder ID.</summary>
    [JsonPropertyName("parent_folder_id")]
    public string ParentFolderId { get; set; } = string.Empty;
    /// <summary>Gets or sets file size.</summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }
    /// <summary>Gets or sets upload time.</summary>
    [JsonPropertyName("uploaded_time")]
    public long UploadedTime { get; set; }
    /// <summary>Gets or sets expire time.</summary>
    [JsonPropertyName("expire_time")]
    public long? ExpireTime { get; set; }
    /// <summary>Gets or sets uploader QQ number.</summary>
    [JsonPropertyName("uploader_id")]
    public long UploaderId { get; set; }
    /// <summary>Gets or sets downloaded times.</summary>
    [JsonPropertyName("downloaded_times")]
    public int DownloadedTimes { get; set; }
}

/// <summary>Group folder information.</summary>
public record class MilkyGroupFolderEntity
{
    /// <summary>Gets or sets group QQ number.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets folder ID.</summary>
    [JsonPropertyName("folder_id")]
    public string FolderId { get; set; } = string.Empty;
    /// <summary>Gets or sets parent folder ID.</summary>
    [JsonPropertyName("parent_folder_id")]
    public string ParentFolderId { get; set; } = string.Empty;
    /// <summary>Gets or sets folder name.</summary>
    [JsonPropertyName("folder_name")]
    public string FolderName { get; set; } = string.Empty;
    /// <summary>Gets or sets created time.</summary>
    [JsonPropertyName("created_time")]
    public long CreatedTime { get; set; }
    /// <summary>Gets or sets modified time.</summary>
    [JsonPropertyName("last_modified_time")]
    public long LastModifiedTime { get; set; }
    /// <summary>Gets or sets creator QQ number.</summary>
    [JsonPropertyName("creator_id")]
    public long CreatorId { get; set; }
    /// <summary>Gets or sets file count.</summary>
    [JsonPropertyName("file_count")]
    public int FileCount { get; set; }
}

/// <summary>Friend request information.</summary>
public record class MilkyFriendRequest
{
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
    /// <summary>Gets or sets initiator QQ number.</summary>
    [JsonPropertyName("initiator_id")]
    public long InitiatorId { get; set; }
    /// <summary>Gets or sets initiator UID.</summary>
    [JsonPropertyName("initiator_uid")]
    public string InitiatorUid { get; set; } = string.Empty;
    /// <summary>Gets or sets target QQ number.</summary>
    [JsonPropertyName("target_user_id")]
    public long TargetUserId { get; set; }
    /// <summary>Gets or sets target UID.</summary>
    [JsonPropertyName("target_user_uid")]
    public string TargetUserUid { get; set; } = string.Empty;
    /// <summary>Gets or sets state.</summary>
    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;
    /// <summary>Gets or sets comment.</summary>
    [JsonPropertyName("comment")]
    public string Comment { get; set; } = string.Empty;
    /// <summary>Gets or sets source.</summary>
    [JsonPropertyName("via")]
    public string Via { get; set; } = string.Empty;
    /// <summary>Gets or sets whether filtered.</summary>
    [JsonPropertyName("is_filtered")]
    public bool IsFiltered { get; set; }
}

/// <summary>Group notification information.</summary>
[JsonConverter(typeof(MilkyGroupNotificationJsonConverter))]
public record class MilkyGroupNotification
{
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    /// <summary>Gets or sets group QQ number.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets notification sequence.</summary>
    [JsonPropertyName("notification_seq")]
    public long NotificationSeq { get; set; }
    /// <summary>Gets or sets whether filtered.</summary>
    [JsonPropertyName("is_filtered")]
    public bool? IsFiltered { get; set; }
    /// <summary>Gets or sets initiator QQ number.</summary>
    [JsonPropertyName("initiator_id")]
    public long? InitiatorId { get; set; }
    /// <summary>Gets or sets user QQ number.</summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }
    /// <summary>Gets or sets target QQ number.</summary>
    [JsonPropertyName("target_user_id")]
    public long? TargetUserId { get; set; }
    /// <summary>Gets or sets state.</summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }
    /// <summary>Gets or sets operator QQ number.</summary>
    [JsonPropertyName("operator_id")]
    public long? OperatorId { get; set; }
    /// <summary>Gets or sets comment.</summary>
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }
    /// <summary>Gets or sets whether set.</summary>
    [JsonPropertyName("is_set")]
    public bool? IsSet { get; set; }
}

/// <summary>Group join request notification.</summary>
public record class MilkyJoinRequestGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes a group join request notification.</summary>
    public MilkyJoinRequestGroupNotification() => Type = "join_request";
}

/// <summary>Group administrator change notification.</summary>
public record class MilkyAdminChangeGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes a group administrator change notification.</summary>
    public MilkyAdminChangeGroupNotification() => Type = "admin_change";
}

/// <summary>Group member kick notification.</summary>
public record class MilkyKickGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes a group member kick notification.</summary>
    public MilkyKickGroupNotification() => Type = "kick";
}

/// <summary>Group member quit notification.</summary>
public record class MilkyQuitGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes a group member quit notification.</summary>
    public MilkyQuitGroupNotification() => Type = "quit";
}

/// <summary>Group invited-join request notification.</summary>
public record class MilkyInvitedJoinRequestGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes a group invited-join request notification.</summary>
    public MilkyInvitedJoinRequestGroupNotification() => Type = "invited_join_request";
}

/// <summary>Unknown group notification preserved as raw JSON.</summary>
public record class MilkyUnknownGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes an unknown group notification.</summary>
    public MilkyUnknownGroupNotification(string notificationType, JsonElement rawData)
    {
        Type = notificationType;
        RawData = rawData;
    }

    /// <summary>Gets the raw notification JSON.</summary>
    public JsonElement RawData { get; }
}

/// <summary>JSON converter for group notification union variants.</summary>
public sealed class MilkyGroupNotificationJsonConverter : JsonConverter<MilkyGroupNotification>
{
    /// <inheritdoc />
    public override MilkyGroupNotification? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement root = document.RootElement;
        string type = root.TryGetProperty("type", out JsonElement typeElement) ? typeElement.GetString() ?? string.Empty : string.Empty;

        return type switch
        {
            "join_request" => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyJoinRequestGroupNotification),
            "admin_change" => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyAdminChangeGroupNotification),
            "kick" => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyKickGroupNotification),
            "quit" => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyQuitGroupNotification),
            "invited_join_request" => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyInvitedJoinRequestGroupNotification),
            _ => new MilkyUnknownGroupNotification(type, root.Clone()),
        };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, MilkyGroupNotification value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case MilkyJoinRequestGroupNotification notification:
                JsonSerializer.Serialize(writer, notification, MilkyJsonSerializerContext.Default.MilkyJoinRequestGroupNotification);
                break;
            case MilkyAdminChangeGroupNotification notification:
                JsonSerializer.Serialize(writer, notification, MilkyJsonSerializerContext.Default.MilkyAdminChangeGroupNotification);
                break;
            case MilkyKickGroupNotification notification:
                JsonSerializer.Serialize(writer, notification, MilkyJsonSerializerContext.Default.MilkyKickGroupNotification);
                break;
            case MilkyQuitGroupNotification notification:
                JsonSerializer.Serialize(writer, notification, MilkyJsonSerializerContext.Default.MilkyQuitGroupNotification);
                break;
            case MilkyInvitedJoinRequestGroupNotification notification:
                JsonSerializer.Serialize(writer, notification, MilkyJsonSerializerContext.Default.MilkyInvitedJoinRequestGroupNotification);
                break;
            case MilkyUnknownGroupNotification notification:
                notification.RawData.WriteTo(writer);
                break;
            default:
                WriteBaseNotification(writer, value);
                break;
        }
    }

    private static void WriteBaseNotification(Utf8JsonWriter writer, MilkyGroupNotification notification)
    {
        writer.WriteStartObject();
        writer.WriteString("type", notification.Type);
        writer.WriteNumber("group_id", notification.GroupId);
        writer.WriteNumber("notification_seq", notification.NotificationSeq);
        if (notification.IsFiltered is { } isFiltered)
        {
            writer.WriteBoolean("is_filtered", isFiltered);
        }

        if (notification.InitiatorId is { } initiatorId)
        {
            writer.WriteNumber("initiator_id", initiatorId);
        }

        if (notification.UserId is { } userId)
        {
            writer.WriteNumber("user_id", userId);
        }

        if (notification.TargetUserId is { } targetUserId)
        {
            writer.WriteNumber("target_user_id", targetUserId);
        }

        if (notification.State is not null)
        {
            writer.WriteString("state", notification.State);
        }

        if (notification.OperatorId is { } operatorId)
        {
            writer.WriteNumber("operator_id", operatorId);
        }

        if (notification.Comment is not null)
        {
            writer.WriteString("comment", notification.Comment);
        }

        if (notification.IsSet is { } isSet)
        {
            writer.WriteBoolean("is_set", isSet);
        }

        writer.WriteEndObject();
    }
}

/// <summary>Incoming message.</summary>
public record class MilkyIncomingMessage
{
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
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
    /// <summary>Gets or sets segments.</summary>
    [JsonPropertyName("segments")]
    public List<MilkyIncomingSegment> Segments { get; set; } = [];
    /// <summary>Gets or sets friend info.</summary>
    [JsonPropertyName("friend")]
    public MilkyFriendEntity? Friend { get; set; }
    /// <summary>Gets or sets group info.</summary>
    [JsonPropertyName("group")]
    public MilkyGroupEntity? Group { get; set; }
    /// <summary>Gets or sets group member info.</summary>
    [JsonPropertyName("group_member")]
    public MilkyGroupMemberEntity? GroupMember { get; set; }
}

/// <summary>Incoming forwarded message.</summary>
public record class MilkyIncomingForwardedMessage
{
    /// <summary>Gets or sets message sequence.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
    /// <summary>Gets or sets sender name.</summary>
    [JsonPropertyName("sender_name")]
    public string SenderName { get; set; } = string.Empty;
    /// <summary>Gets or sets avatar URL.</summary>
    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; } = string.Empty;
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
    /// <summary>Gets or sets segments.</summary>
    [JsonPropertyName("segments")]
    public List<MilkyIncomingSegment> Segments { get; set; } = [];
}

/// <summary>Group essence message.</summary>
public record class MilkyGroupEssenceMessage
{
    /// <summary>Gets or sets group QQ number.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message sequence.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
    /// <summary>Gets or sets message time.</summary>
    [JsonPropertyName("message_time")]
    public long MessageTime { get; set; }
    /// <summary>Gets or sets sender QQ number.</summary>
    [JsonPropertyName("sender_id")]
    public long SenderId { get; set; }
    /// <summary>Gets or sets sender name.</summary>
    [JsonPropertyName("sender_name")]
    public string SenderName { get; set; } = string.Empty;
    /// <summary>Gets or sets operator QQ number.</summary>
    [JsonPropertyName("operator_id")]
    public long OperatorId { get; set; }
    /// <summary>Gets or sets operator name.</summary>
    [JsonPropertyName("operator_name")]
    public string OperatorName { get; set; } = string.Empty;
    /// <summary>Gets or sets operation time.</summary>
    [JsonPropertyName("operation_time")]
    public long OperationTime { get; set; }
    /// <summary>Gets or sets segments.</summary>
    [JsonPropertyName("segments")]
    public List<MilkyIncomingSegment> Segments { get; set; } = [];
}
