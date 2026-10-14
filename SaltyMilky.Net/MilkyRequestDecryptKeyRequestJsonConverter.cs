using System.Text.Json;
using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>Preserves the difference between omitted and explicitly null key metadata.</summary>
public sealed class MilkyRequestDecryptKeyRequestJsonConverter : JsonConverter<MilkyRequestDecryptKeyRequest>
{
    /// <inheritdoc />
    public override MilkyRequestDecryptKeyRequest Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;
        MilkyRequestDecryptKeyRequest request = new();
        if (root.TryGetProperty("mode", out var mode)) request.Mode = mode.GetString();
        if (root.TryGetProperty("key_meta", out var meta)) request.KeyMeta = meta.GetString();
        return request;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, MilkyRequestDecryptKeyRequest value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("mode", value.Mode);
        if (value.HasKeyMeta) writer.WriteString("key_meta", value.KeyMeta);
        writer.WriteEndObject();
    }
}
