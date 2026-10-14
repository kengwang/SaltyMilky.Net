using System.Net;
using System.Text;
using System.Text.Json.Nodes;

namespace SaltyMilky.Net.Tests;

internal sealed class ContractHttpHandler(string route, string requestJson, string responseJson) : HttpMessageHandler
{
    public bool Called { get; private set; }
    public int CallCount { get; private set; }
    public bool CancellationCanBeCanceled { get; private set; }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Called = true;
        CallCount++;
        CancellationCanBeCanceled = cancellationToken.CanBeCanceled;
        Check(request.Method == HttpMethod.Post, "API must use POST.");
        Check(request.RequestUri?.AbsolutePath == "/api/" + route, "API route mismatch.");
        string body = await request.Content!.ReadAsStringAsync(cancellationToken);
        Check(JsonNode.DeepEquals(JsonNode.Parse(body), JsonNode.Parse(requestJson)), "Request wire contract mismatch: " + body);
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
        };
    }

    internal static void Check(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    internal static void CheckContains(JsonNode? actual, JsonNode? expected, string path = "data")
    {
        if (expected is JsonObject obj)
        {
            Check(actual is JsonObject, "Expected object at " + path);
            foreach (var field in obj)
                CheckContains(actual![field.Key], field.Value, path + "." + field.Key);
        }
        else if (expected is JsonArray array)
        {
            Check(actual is JsonArray actualArray && actualArray.Count == array.Count, "Array mismatch at " + path);
            for (int i = 0; i < array.Count; i++) CheckContains(actual![i], array[i], path + "[" + i + "]");
        }
        else Check(JsonNode.DeepEquals(actual, expected), "Server field was lost or changed at " + path + ": " + actual);
    }
}
