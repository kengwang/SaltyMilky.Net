using System.Text.Json;
using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>Accepts both standard cookie strings and Lagrange cookie dictionaries.</summary>
public sealed class MilkyCookiesResultJsonConverter : JsonConverter<MilkyCookiesResult>
{
    /// <inheritdoc />
    public override MilkyCookiesResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        JsonElement cookies = document.RootElement.GetProperty("cookies");
        if (cookies.ValueKind == JsonValueKind.String) return new(cookies.GetString()!);
        if (cookies.ValueKind != JsonValueKind.Object) throw new JsonException("cookies must be a string or object.");
        Dictionary<string, string> values = new(StringComparer.Ordinal);
        foreach (JsonProperty cookie in cookies.EnumerateObject()) values.Add(cookie.Name, cookie.Value.GetString() ?? string.Empty);
        return new(string.Join("; ", values.Select(x => x.Key + "=" + x.Value))) { CookieValues = values };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, MilkyCookiesResult value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        if (value.CookieValues is { } values)
        {
            writer.WriteStartObject("cookies");
            foreach (var cookie in values) writer.WriteString(cookie.Key, cookie.Value);
            writer.WriteEndObject();
        }
        else writer.WriteString("cookies", value.Cookies);
        writer.WriteEndObject();
    }
}
