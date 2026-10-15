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
    public override string Type => MilkyConstant.MessageSegmentType.Text;

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
    public override string Type => MilkyConstant.MessageSegmentType.Text;

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
    /// <summary>Gets the optional historical display name, used when forwarding mentions.</summary>
    [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; init; }

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Mention;

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
    public override string Type => MilkyConstant.MessageSegmentType.Mention;

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
    public override string Type => MilkyConstant.MessageSegmentType.MentionAll;
}

/// <summary>
/// Incoming mention-all segment.
/// </summary>
public record class MilkyIncomingMentionAllSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.MentionAll;
}

/// <summary>
/// Face segment.
/// </summary>
public record class MilkyFaceSegment(string FaceId, bool IsLarge = false) : MilkyOutgoingSegment
{
    /// <summary>Gets or sets result_id returned by Lagrange.</summary>
    [JsonPropertyName("result_id")]
    public string? ResultId { get; set; }
    /// <summary>Gets or sets raw returned by Lagrange.</summary>
    [JsonPropertyName("raw")]
    public string? Raw { get; set; }

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Face;

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
    /// <summary>Gets or sets result_id returned by Lagrange.</summary>
    [JsonPropertyName("result_id")]
    public string? ResultId { get; set; }
    /// <summary>Gets or sets raw returned by Lagrange.</summary>
    [JsonPropertyName("raw")]
    public string Raw { get; set; } = string.Empty;

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Face;

    /// <summary>Gets or sets the face ID.</summary>
    [JsonPropertyName("face_id")]
    [JsonConverter(typeof(MilkyIncomingFaceIdJsonConverter))]
    public string FaceId { get; set; } = string.Empty;

    /// <summary>Gets or sets whether the face is large.</summary>
    [JsonPropertyName("is_large")]
    public bool IsLarge { get; set; }
}

/// <summary>Accepts numeric face IDs from legacy implementations while writing protocol strings.</summary>
public sealed class MilkyIncomingFaceIdJsonConverter : JsonConverter<string>
{
    /// <inheritdoc />
    public override bool HandleNull => true;

    /// <inheritdoc />
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString()!;
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            string value = document.RootElement.GetRawText();
            if (value.All(char.IsAsciiDigit))
            {
                return value;
            }
        }

        throw new JsonException("face_id must be a string or a non-negative integer.");
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options) => writer.WriteStringValue(value);
}

/// <summary>
/// Reply segment.
/// </summary>
public record class MilkyReplySegment(long MessageSeq) : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Reply;

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
    public override string Type => MilkyConstant.MessageSegmentType.Reply;

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
public record class MilkyImageSegment(string Uri, string SubType = MilkyConstant.ImageSubType.Normal, string? Summary = null) : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Image;

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
    /// <summary>Gets or sets flash returned by Lagrange.</summary>
    [JsonPropertyName("flash")]
    public bool Flash { get; set; }
    /// <summary>Gets or sets file_md5 returned by Lagrange.</summary>
    [JsonPropertyName("file_md5")]
    public string? FileMd5 { get; set; }
    /// <summary>Gets or sets file_sha1 returned by Lagrange.</summary>
    [JsonPropertyName("file_sha1")]
    public string? FileSha1 { get; set; }
    /// <summary>Gets or sets file_size returned by Lagrange.</summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Image;

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
    public override string Type => MilkyConstant.MessageSegmentType.Record;

    /// <summary>Gets the record URI.</summary>
    [JsonPropertyName("uri")]
    public string Uri { get; init; } = Uri;
}

/// <summary>
/// Incoming record segment.
/// </summary>
public record class MilkyIncomingRecordSegment : MilkyIncomingSegment
{
    /// <summary>Gets or sets file_md5 returned by Lagrange.</summary>
    [JsonPropertyName("file_md5")]
    public string? FileMd5 { get; set; }
    /// <summary>Gets or sets file_sha1 returned by Lagrange.</summary>
    [JsonPropertyName("file_sha1")]
    public string? FileSha1 { get; set; }
    /// <summary>Gets or sets file_size returned by Lagrange.</summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Record;

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
    public override string Type => MilkyConstant.MessageSegmentType.Video;

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
    /// <summary>Gets or sets file_md5 returned by Lagrange.</summary>
    [JsonPropertyName("file_md5")]
    public string? FileMd5 { get; set; }
    /// <summary>Gets or sets file_sha1 returned by Lagrange.</summary>
    [JsonPropertyName("file_sha1")]
    public string? FileSha1 { get; set; }
    /// <summary>Gets or sets file_size returned by Lagrange.</summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Video;
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
    /// <summary>Gets or sets optional message presentation metadata.</summary>
    [JsonPropertyName("message_style"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MilkyMessageStyle? MessageStyle { get; set; }
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
    /// <summary>Initializes an empty forward segment for JSON deserialization.</summary>
    public MilkyForwardSegment() => Messages = [];
    /// <summary>Initializes a forward segment.</summary>
    public MilkyForwardSegment(IEnumerable<MilkyOutgoingForwardedMessage> messages) => Messages = messages.ToList();

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Forward;
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
    /// <summary>Gets or sets prompt returned by Lagrange.</summary>
    [JsonPropertyName("prompt")]
    public string? Prompt { get; set; }

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Forward;
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
    public override string Type => MilkyConstant.MessageSegmentType.LightApp;
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
    public override string Type => MilkyConstant.MessageSegmentType.Markdown;
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
    public override string Type => MilkyConstant.MessageSegmentType.LightApp;
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
    public override string Type => MilkyConstant.MessageSegmentType.Markdown;
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
    /// <summary>Gets or sets url returned by Lagrange.</summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }
    /// <summary>Gets or sets title returned by Lagrange.</summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    /// <summary>Gets or sets preview returned by Lagrange.</summary>
    [JsonPropertyName("preview")]
    public string? Preview { get; set; }
    /// <summary>Gets or sets summary returned by Lagrange.</summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.File;
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
    /// <summary>Gets or sets face_id returned by Lagrange.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; }
    /// <summary>Gets or sets name returned by Lagrange.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.MarketFace;
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
    /// <summary>Gets or sets xml returned by Lagrange.</summary>
    [JsonPropertyName("xml")]
    public string Xml { get; set; } = string.Empty;

    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => MilkyConstant.MessageSegmentType.Xml;
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
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        string type = document.RootElement.GetProperty("type").GetString() ?? string.Empty;
        JsonElement data = document.RootElement.TryGetProperty("data", out JsonElement nestedData) ? nestedData : document.RootElement;
        return type switch
        {
            MilkyConstant.MessageSegmentType.Text => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyTextSegment),
            MilkyConstant.MessageSegmentType.Mention => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyMentionSegment),
            MilkyConstant.MessageSegmentType.MentionAll => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyMentionAllSegment),
            MilkyConstant.MessageSegmentType.Face => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyFaceSegment),
            MilkyConstant.MessageSegmentType.Reply => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyReplySegment),
            MilkyConstant.MessageSegmentType.Image => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyImageSegment),
            MilkyConstant.MessageSegmentType.Record => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyRecordSegment),
            MilkyConstant.MessageSegmentType.Video => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyVideoSegment),
            MilkyConstant.MessageSegmentType.Forward => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyForwardSegment),
            MilkyConstant.MessageSegmentType.LightApp => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyLightAppSegment),
            MilkyConstant.MessageSegmentType.Markdown => ReadMarkdownSegment(data),
            "poke" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyPokeSegment),
            "keyboard" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyKeyboardSegment),
            "special_poke" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkySpecialPokeSegment),
            "json" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyJsonSegment),
            "location" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyLocationSegment),
            "music" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyMusicSegment),
            "share" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyShareSegment),
            "contact" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyContactSegment),
            "dice" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyDiceSegment),
            "rps" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyRpsSegment),
            "long_msg" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyLongMsgSegment),
            "stream" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyStreamSegment),
            "bounce_face" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyBounceFaceSegment),
            "group_reaction" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyGroupReactionSegment),
            "grey_tip" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyGreyTipSegment),
            "file" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyFileSegment),
            "market_face" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyMarketFaceSegment),
            "xml" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyXmlSegment),
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
            case MilkyPokeSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyPokeSegment);
                break;
            case MilkyKeyboardSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyKeyboardSegment);
                break;
            case MilkySpecialPokeSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkySpecialPokeSegment);
                break;
            case MilkyJsonSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyJsonSegment);
                break;
            case MilkyLocationSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyLocationSegment);
                break;
            case MilkyMusicSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyMusicSegment);
                break;
            case MilkyShareSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyShareSegment);
                break;
            case MilkyContactSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyContactSegment);
                break;
            case MilkyDiceSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyDiceSegment);
                break;
            case MilkyRpsSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyRpsSegment);
                break;
            case MilkyLongMsgSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyLongMsgSegment);
                break;
            case MilkyStreamSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyStreamSegment);
                break;
            case MilkyBounceFaceSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyBounceFaceSegment);
                break;
            case MilkyGroupReactionSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyGroupReactionSegment);
                break;
            case MilkyGreyTipSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyGreyTipSegment);
                break;
            case MilkyFileSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyFileSegment);
                break;
            case MilkyMarketFaceSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyMarketFaceSegment);
                break;
            case MilkyXmlSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyXmlSegment);
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
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        string type = document.RootElement.GetProperty("type").GetString() ?? string.Empty;
        JsonElement data = document.RootElement.TryGetProperty("data", out JsonElement nestedData) ? nestedData : document.RootElement;
        return type switch
        {
            MilkyConstant.MessageSegmentType.Text => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingTextSegment),
            MilkyConstant.MessageSegmentType.Mention => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingMentionSegment),
            MilkyConstant.MessageSegmentType.MentionAll => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingMentionAllSegment),
            MilkyConstant.MessageSegmentType.Face => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingFaceSegment),
            MilkyConstant.MessageSegmentType.Reply => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingReplySegment),
            MilkyConstant.MessageSegmentType.Image => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingImageSegment),
            MilkyConstant.MessageSegmentType.Record => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingRecordSegment),
            MilkyConstant.MessageSegmentType.Video => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingVideoSegment),
            MilkyConstant.MessageSegmentType.File => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyFileIncomingSegment),
            MilkyConstant.MessageSegmentType.Forward => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingForwardSegment),
            MilkyConstant.MessageSegmentType.MarketFace => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyMarketFaceIncomingSegment),
            MilkyConstant.MessageSegmentType.LightApp => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyIncomingLightAppSegment),
            MilkyConstant.MessageSegmentType.Xml => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyXmlIncomingSegment),
            MilkyConstant.MessageSegmentType.Markdown => ReadMarkdownSegment(data),
            "flash_file" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyFlashFileIncomingSegment),
            "poke" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyPokeIncomingSegment),
            "keyboard" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyKeyboardIncomingSegment),
            "special_poke" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkySpecialPokeIncomingSegment),
            "json" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyJsonIncomingSegment),
            "location" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyLocationIncomingSegment),
            "music" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyMusicIncomingSegment),
            "share" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyShareIncomingSegment),
            "contact" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyContactIncomingSegment),
            "dice" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyDiceIncomingSegment),
            "rps" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyRpsIncomingSegment),
            "long_msg" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyLongMsgIncomingSegment),
            "stream" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyStreamIncomingSegment),
            "bounce_face" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyBounceFaceIncomingSegment),
            "group_reaction" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyGroupReactionIncomingSegment),
            "grey_tip" => data.Deserialize(MilkyJsonSerializerContext.Default.MilkyGreyTipIncomingSegment),
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
            case MilkyFlashFileIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyFlashFileIncomingSegment);
                break;
            case MilkyPokeIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyPokeIncomingSegment);
                break;
            case MilkyKeyboardIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyKeyboardIncomingSegment);
                break;
            case MilkySpecialPokeIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkySpecialPokeIncomingSegment);
                break;
            case MilkyJsonIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyJsonIncomingSegment);
                break;
            case MilkyLocationIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyLocationIncomingSegment);
                break;
            case MilkyMusicIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyMusicIncomingSegment);
                break;
            case MilkyShareIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyShareIncomingSegment);
                break;
            case MilkyContactIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyContactIncomingSegment);
                break;
            case MilkyDiceIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyDiceIncomingSegment);
                break;
            case MilkyRpsIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyRpsIncomingSegment);
                break;
            case MilkyLongMsgIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyLongMsgIncomingSegment);
                break;
            case MilkyStreamIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyStreamIncomingSegment);
                break;
            case MilkyBounceFaceIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyBounceFaceIncomingSegment);
                break;
            case MilkyGroupReactionIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyGroupReactionIncomingSegment);
                break;
            case MilkyGreyTipIncomingSegment segment:
                JsonSerializer.Serialize(writer, segment, MilkyJsonSerializerContext.Default.MilkyGreyTipIncomingSegment);
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
    public string Sex { get; set; } = MilkyConstant.Sex.Unknown;
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
    [JsonIgnore]
    public int MemberCount { get => checked((int)MemberCount64); set => MemberCount64 = value; }
    /// <summary>Gets or sets the full-width member count returned by Lagrange.</summary>
    [JsonPropertyName("member_count")]
    public long MemberCount64 { get; set; }
    /// <summary>Gets or sets max member count.</summary>
    [JsonIgnore]
    public int MaxMemberCount { get => checked((int)MaxMemberCount64); set => MaxMemberCount64 = value; }
    /// <summary>Gets or sets the full-width maximum member count returned by Lagrange.</summary>
    [JsonPropertyName("max_member_count")]
    public long MaxMemberCount64 { get; set; }
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
    public string Sex { get; set; } = MilkyConstant.Sex.Unknown;
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
    public string Role { get; set; } = MilkyConstant.GroupMemberRole.Member;
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
    /// <summary>Gets or sets id returned by Lagrange.</summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    /// <summary>Gets or sets publisher_id returned by Lagrange.</summary>
    [JsonPropertyName("publisher_id")]
    public long PublisherId { get; set; }
    /// <summary>Gets or sets publish_time returned by Lagrange.</summary>
    [JsonPropertyName("publish_time")]
    public long PublishTime { get; set; }
    /// <summary>Gets or sets text returned by Lagrange.</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
    /// <summary>Gets or sets pinned returned by Lagrange.</summary>
    [JsonPropertyName("pinned")]
    public bool Pinned { get; set; }
    /// <summary>Gets or sets read_count returned by Lagrange.</summary>
    [JsonPropertyName("read_count")]
    public int ReadCount { get; set; }

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
    /// <summary>Gets or sets modify_time returned by Lagrange.</summary>
    [JsonPropertyName("modify_time")]
    public long ModifyTime { get; set; }
    /// <summary>Gets or sets uploader_name returned by Lagrange.</summary>
    [JsonPropertyName("uploader_name")]
    public string UploaderName { get; set; } = string.Empty;
    /// <summary>Gets or sets create_time returned by Lagrange.</summary>
    [JsonPropertyName("create_time")]
    public long CreateTime { get; set; }
    /// <summary>Gets or sets download_url returned by Lagrange.</summary>
    [JsonPropertyName("download_url")]
    public string DownloadUrl { get; set; } = string.Empty;

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
    /// <summary>Gets or sets the source account in a Lagrange friend request listing.</summary>
    [JsonPropertyName("source_user_id")]
    public long SourceUserId { get; set; }
    /// <summary>Gets or sets flag returned by Lagrange.</summary>
    [JsonPropertyName("flag")]
    public string Flag { get; set; } = string.Empty;
    /// <summary>Gets or sets user_id returned by Lagrange.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets uid returned by Lagrange.</summary>
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
    /// <summary>Gets or sets nickname returned by Lagrange.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets message returned by Lagrange.</summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
    /// <summary>Gets or sets source returned by Lagrange.</summary>
    [JsonPropertyName("source")]
    public string Source { get; set; } = string.Empty;

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
    public MilkyJoinRequestGroupNotification() => Type = MilkyConstant.GroupRequestNotificationType.JoinRequest;
}

/// <summary>Group administrator change notification.</summary>
public record class MilkyAdminChangeGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes a group administrator change notification.</summary>
    public MilkyAdminChangeGroupNotification() => Type = MilkyConstant.GroupNotificationType.AdminChange;
}

/// <summary>Group member kick notification.</summary>
public record class MilkyKickGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes a group member kick notification.</summary>
    public MilkyKickGroupNotification() => Type = MilkyConstant.GroupNotificationType.Kick;
}

/// <summary>Group member quit notification.</summary>
public record class MilkyQuitGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes a group member quit notification.</summary>
    public MilkyQuitGroupNotification() => Type = MilkyConstant.GroupNotificationType.Quit;
}

/// <summary>Group invited-join request notification.</summary>
public record class MilkyInvitedJoinRequestGroupNotification : MilkyGroupNotification
{
    /// <summary>Initializes a group invited-join request notification.</summary>
    public MilkyInvitedJoinRequestGroupNotification() => Type = MilkyConstant.GroupRequestNotificationType.InvitedJoinRequest;
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
            MilkyConstant.GroupRequestNotificationType.JoinRequest => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyJoinRequestGroupNotification),
            MilkyConstant.GroupNotificationType.AdminChange => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyAdminChangeGroupNotification),
            MilkyConstant.GroupNotificationType.Kick => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyKickGroupNotification),
            MilkyConstant.GroupNotificationType.Quit => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyQuitGroupNotification),
            MilkyConstant.GroupRequestNotificationType.InvitedJoinRequest => root.Deserialize(MilkyJsonSerializerContext.Default.MilkyInvitedJoinRequestGroupNotification),
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
    /// <summary>Gets or sets the source group for a temporary conversation.</summary>
    [JsonPropertyName("group_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? GroupId { get; set; }
    /// <summary>Gets or sets optional message presentation metadata.</summary>
    [JsonPropertyName("message_style"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MilkyMessageStyle? MessageStyle { get; set; }
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
    /// <summary>Gets or sets optional message presentation metadata.</summary>
    [JsonPropertyName("message_style"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MilkyMessageStyle? MessageStyle { get; set; }
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
    /// <summary>Gets or sets group_code returned by Lagrange.</summary>
    [JsonPropertyName("group_code")]
    public string GroupCode { get; set; } = string.Empty;
    /// <summary>Gets or sets message_sequence returned by Lagrange.</summary>
    [JsonPropertyName("message_sequence")]
    public ulong MessageSequence { get; set; }
    /// <summary>Gets or sets message_random returned by Lagrange.</summary>
    [JsonPropertyName("message_random")]
    public uint MessageRandom { get; set; }
    /// <summary>Gets or sets sender_uin returned by Lagrange.</summary>
    [JsonPropertyName("sender_uin")]
    public string SenderUin { get; set; } = string.Empty;
    /// <summary>Gets or sets sender_nick returned by Lagrange.</summary>
    [JsonPropertyName("sender_nick")]
    public string SenderNick { get; set; } = string.Empty;
    /// <summary>Gets or sets sender_time returned by Lagrange.</summary>
    [JsonPropertyName("sender_time")]
    public long SenderTime { get; set; }
    /// <summary>Gets or sets add_digest_uin returned by Lagrange.</summary>
    [JsonPropertyName("add_digest_uin")]
    public string AddDigestUin { get; set; } = string.Empty;
    /// <summary>Gets or sets add_digest_nick returned by Lagrange.</summary>
    [JsonPropertyName("add_digest_nick")]
    public string AddDigestNick { get; set; } = string.Empty;
    /// <summary>Gets or sets add_digest_time returned by Lagrange.</summary>
    [JsonPropertyName("add_digest_time")]
    public long AddDigestTime { get; set; }
    /// <summary>Gets or sets can_be_removed returned by Lagrange.</summary>
    [JsonPropertyName("can_be_removed")]
    public bool CanBeRemoved { get; set; }
    /// <summary>Gets or sets text returned by Lagrange.</summary>
    [JsonPropertyName("text")]
    public string? Text { get; set; }

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
