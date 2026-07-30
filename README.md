# SaltyMilky.Net

SaltyMilky.Net is a .NET 8 SDK for the Milky protocol. It provides a BCL-only library with HTTP API invocation, typed convenience methods, message segment models, event parsing, and event transport helpers for SSE, WebSocket, and WebHook communication.

## Install

Reference the project or pack it locally:

```bash
dotnet add reference ./SaltyMilky.Net/SaltyMilky.Net.csproj
```

## HTTP API Session

```csharp
using SaltyMilky.Net;
using System.Text.Json.Nodes;

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
    new JsonObject { ["resource_id"] = "resource-id" });
```

## Receive Events

Milky supports three event push models on top of HTTP API calls: SSE, WebSocket, and WebHook.

For SSE, connect to the protocol-side `/event` endpoint:

```csharp
await foreach (MilkyEvent milkyEvent in session.ReadSseEventsAsync(cancellationToken))
{
    await session.EventPipeline.ExecuteAsync(milkyEvent, cancellationToken);
}
```

For WebSocket, connect to the same `/event` endpoint using the WebSocket transport:

```csharp
await foreach (MilkyEvent milkyEvent in session.ReadWebSocketEventsAsync(cancellationToken))
{
    await session.EventPipeline.ExecuteAsync(milkyEvent, cancellationToken);
}
```

You can also run either event loop directly:

```csharp
await session.RunSseEventLoopAsync(cancellationToken);
await session.RunWebSocketEventLoopAsync(cancellationToken);
```

For long-running bots, use reconnecting loops:

```csharp
await session.RunReconnectingSseEventLoopAsync(cancellationToken: cancellationToken);
await session.RunReconnectingWebSocketEventLoopAsync(cancellationToken: cancellationToken);
```

The reconnecting loops also rebuild the event connection after an idle timeout, which helps recover from half-open long-running SSE or WebSocket connections. The default idle timeout is two minutes; pass `idleTimeout` when your deployment needs a shorter or longer watchdog:

```csharp
await session.RunReconnectingSseEventLoopAsync(
    reconnectDelay: TimeSpan.FromSeconds(3),
    idleTimeout: TimeSpan.FromMinutes(2),
    cancellationToken: cancellationToken);
```

For WebHook integrations, validate the incoming `Authorization` header and parse the request body:

```csharp
MilkyEvent? milkyEvent = await MilkyCommunication.ReadWebhookEventAsync(
    request.Body,
    request.Headers.Authorization.ToString(),
    accessToken,
    cancellationToken);

if (milkyEvent is not null)
{
    await session.EventPipeline.ExecuteAsync(milkyEvent, cancellationToken);
}
```

For a lightweight self-hosted WebHook endpoint:

```csharp
await MilkyCommunication.RunWebhookListenerAsync(
    "http://127.0.0.1:8080/milky-webhook/",
    session.EventPipeline,
    accessToken,
    cancellationToken);
```

## Parse Event Payloads

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

if (parsed?.Data is MilkyGroupMemberIncreaseEventData increased)
{
    Console.WriteLine($"{increased.UserId} joined {increased.GroupId}");
}
```

For existing transports, parse JSON payloads with `MilkyEventParser.ParseJson` or accumulated SSE text blocks with `MilkyEventParser.ParseSseEvents`; only `data:` lines are parsed as Milky event JSON.

The SDK tracks the public Milky v1.2.2 documentation surface for API helpers, event payloads, incoming/outgoing message segments, and group notification variants. Unknown event subtypes are preserved as `MilkyUnknownEventData`; unknown incoming message segments are converted to a text segment such as `[unsupported Milky segment: future_segment]` to match Milky compatibility guidance.

## Event Pipeline and Plugins

`MilkyHttpSession` also exposes an event pipeline. Feed parsed events into the pipeline from WebSocket, SSE, or WebHook integrations:

```csharp
public sealed class MyMilkyPlugin : MilkyEventPlugin
{
    protected override async Task OnGroupMessageReceivedAsync(MilkyGroupMessageContext context)
    {
        Console.WriteLine($"{context.SenderId}: {context.Text}");
        await context.ReplyAsync(MilkyMessageHelpers.Text("received"));
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

Context callbacks bind each event to the `IMilkyActionSession` that received it. The SDK provides a named context for every known Milky event, including group/private messages and recalls, friend and group requests, notices, bot-offline events, and unknown future events. Request contexts expose accept/reject operations; message contexts expose reply/send operations. `MilkyEventContextFactory.Create` is available when manually dispatching parsed events.

The original `(data, event)` callbacks and delegate middleware remain supported. Reusable context middleware can derive from `MilkyEventMiddleware` and register with `session.UseMiddleware(...)`. Cancellation-aware delegate middleware can use `MilkyEventPipelineMiddleware`; its token is also available through `MilkyEventContext.CancellationToken` and is forwarded by context operations.

## Scope

This package intentionally does not include a CLI or UI. It focuses on Milky's HTTP `/api/{apiName}` action contract, event transport clients, a lightweight WebHook listener, and event JSON parsing surface.
