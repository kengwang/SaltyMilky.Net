# SaltyMilky.Net

SaltyMilky.Net is a first buildable .NET 8 SDK for the Milky protocol. It provides a BCL-only library with HTTP API invocation, typed convenience methods, message segment models, and event parsing for WebSocket/WebHook JSON and SSE `data:` lines.

## Install

Reference the project or pack it locally:

```bash
dotnet add reference ./SaltyMilky.Net/SaltyMilky.Net.csproj
```

## HTTP API Session

```csharp
using SaltyMilky.Net;

using MilkyHttpSession session = new(new MilkyHttpSessionOptions
{
    BaseAddress = new Uri("http://127.0.0.1:3000/"),
    AccessToken = "optional-token"
});

MilkyActionResult<MilkyLoginInfoResult>? login = await session.GetLoginInfoAsync();
if (login?.IsSuccess == true)
{
    Console.WriteLine($"Logged in as {login.Data?.Nickname} ({login.Data?.Uin})");
}
```

## Send Messages

```csharp
MilkyMessage message = new(
    new MilkyTextSegment("hello "),
    new MilkyMentionSegment(123456789),
    new MilkyImageSegment("file:///tmp/cat.png", summary: "cat"));

MilkyActionResult<MilkySendMessageResult>? result = await session.SendGroupMessageAsync(987654321, message);
Console.WriteLine(result?.Data?.MessageSeq);
```

## Generic Future API Invocation

```csharp
MilkyActionResult<MilkyResourceTempUrlResult>? response = await session.InvokeApiAsync<MilkyResourceTempUrlResult>(
    "get_resource_temp_url",
    new { resource_id = "resource-id" });
```

## Parse Events

```csharp
string json = """
{
  "event_type": "message_receive",
  "time": 1710000000,
  "self_id": 10000,
  "data": {
    "message_scene": "friend",
    "peer_id": 123456789,
    "message_seq": 42,
    "sender_id": 123456789,
    "time": 1710000000,
    "segments": [{ "type": "text", "text": "ping" }]
  }
}
""";

MilkyEvent? parsed = MilkyEventParser.ParseJson(json);
if (parsed?.Data is MilkyMessageReceiveEventData received)
{
    Console.WriteLine(received.Message.Segments.OfType<MilkyIncomingTextSegment>().FirstOrDefault()?.Text);
}
```

For SSE streams, pass accumulated text blocks to `MilkyEventParser.ParseSseEvents`; only `data:` lines are parsed as Milky event JSON.

## Event Pipeline and Plugins

`MilkyHttpSession` also exposes an event pipeline. Feed parsed events into the pipeline from your WebSocket, SSE, or WebHook integration:

```csharp
public sealed class MyMilkyPlugin : MilkyEventPlugin
{
    public override Task OnMessageReceivedAsync(MilkyMessageReceiveEventData data, MilkyEvent milkyEvent)
    {
        Console.WriteLine(data.Message.Segments.OfType<MilkyIncomingTextSegment>().FirstOrDefault()?.Text);
        return Task.CompletedTask;
    }
}

session.UsePlugin(new MyMilkyPlugin());
session.UseMessageReceived((data, evt) =>
{
    Console.WriteLine($"message from {data.Message.SenderId}");
});

MilkyEvent? parsed = MilkyEventParser.ParseJson(json);
if (parsed is not null)
{
    await session.EventPipeline.ExecuteAsync(parsed);
}
```

## Scope

This first version intentionally does not include a hosted webhook server, CLI, UI, or WebSocket transport. It focuses on Milky's HTTP `/api/{apiName}` action contract and event JSON parsing surface.
