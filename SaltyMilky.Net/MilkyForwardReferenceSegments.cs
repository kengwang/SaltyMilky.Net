using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>Wire contract for FileSegment.</summary>
public sealed record class MilkyFileSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "file";
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets file_size.</summary>
    [JsonPropertyName("file_size")]
    public long FileSize { get; set; }
    /// <summary>Gets or sets file_hash.</summary>
    [JsonPropertyName("file_hash"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FileHash { get; set; }
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
}

/// <summary>Wire contract for MarketFaceSegment.</summary>
public sealed record class MilkyMarketFaceSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "market_face";
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; }
    /// <summary>Gets or sets name.</summary>
    [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
    /// <summary>Gets or sets summary.</summary>
    [JsonPropertyName("summary"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Summary { get; set; }
}

/// <summary>Wire contract for XmlSegment.</summary>
public sealed record class MilkyXmlSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "xml";
    /// <summary>Gets or sets xml.</summary>
    [JsonPropertyName("xml")]
    public string Xml { get; set; } = string.Empty;
}
