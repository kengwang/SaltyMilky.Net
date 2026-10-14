using System.Text.Json;
using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>Accepts standard and Lagrange CSRF token field names without changing the existing result property.</summary>
public sealed class MilkyCsrfTokenResultJsonConverter : JsonConverter<MilkyCsrfTokenResult>
{
    /// <inheritdoc />
    public override MilkyCsrfTokenResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        if (document.RootElement.TryGetProperty("token", out var token))
            return new(token.GetString()!) { UsesLagrangeName = true };
        return new(document.RootElement.GetProperty("csrf_token").GetString()!);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, MilkyCsrfTokenResult value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString(value.UsesLagrangeName ? "token" : "csrf_token", value.CsrfToken);
        writer.WriteEndObject();
    }
}
