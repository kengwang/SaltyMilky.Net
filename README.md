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
    AccessToken = "optional-token",
    EventHandlerConcurrency = 4,
    EventQueueCapacity = 100,
    EventHandlerExceptionHandler = (exception, milkyEvent) =>
        Console.Error.WriteLine($"Failed to handle {milkyEvent.EventType}: {exception}")
});

MilkyActionResult<MilkyLoginInfoResult>? login = await session.GetLoginInfoAsync();
if (login?.IsSuccess == true)
{
    Console.WriteLine($"Logged in as {login.Data?.Nickname} ({login.Data?.Uin})");
}
```

The built-in event loops process events concurrently with a bounded queue. An unhandled exception from one event is reported through `EventHandlerExceptionHandler` and does not stop the transport loop or later events. Queue backpressure prevents an event burst from creating an unbounded number of tasks.

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

By default, reconnecting loops keep an idle event connection open and reconnect only after a transport failure. If a deployment explicitly needs an idle watchdog, pass `idleTimeout`:

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

## LagrangeV2 compatibility

The SDK also covers all **175 HTTP routes and 29 event types** in the local
LagrangeV2 baseline `3a690b2919712b10cfcf77276decbb6e95e330a7`. These include
Lagrange extensions for raw packets, database keys, friend status, temporary
messages, history synchronization, flash transfers, group albums, Qzone,
interaction APIs, and message styles. See [the API coverage table](LagrangeApiCoverage.md)
for exact method names, request/response types, and server handler references.
The SDK remains a .NET 8, BCL-only client and does not reference Lagrange assemblies.

New parameterized APIs take typed request objects. Existing APIs also expose
request-object overloads to access their full Lagrange parameter surface:

```csharp
var status = await session.GetFriendsStatusAsync(cancellationToken);

var sent = await session.SendGroupMessageAsync(new MilkySendGroupMessageRequest
{
    GroupId = 987654321,
    Message = new MilkyMessage("styled message"),
    MessageStyle = new MilkyMessageStyle { BubbleId = 123, PendantId = 456 }
}, cancellationToken);

session.UsePacketReceived((data, envelope) =>
    Console.WriteLine($"{data.Command}: {data.Data}"));
```

Styles are optional on sends, incoming messages, history and individual forwarded
nodes. Omitted/null styles use the server's default; an explicit empty style
contains zero/false values. Nested forwarded nodes retain their own styles.
`MilkyTempMessageContext.ReplyAsync` sends through the original group to the
original conversation peer and forwards the dispatch cancellation token.

`packet_received` requires the server-side `Milky:Event:EnableRawPacketEvents`
setting to be enabled and the server restarted. Command blacklists and delivery
limits remain server controlled. Packet data is hexadecimal text, not an encrypted
TCP frame. `send_packet` does not retry: `rsp=false` accepts an empty response
object; `rsp=true` preserves packet-level `ret_code` even when the API envelope
reports success.

`request_decrypt_key` uses `Mode = "encrypt"` without setting `KeyMeta`, or
`Mode = "decrypt"` with the 128-character hexadecimal metadata. Explicitly setting
`KeyMeta = null` remains distinct from omitting it, so server validation is retained.
Returned passwords and metadata remain strings. Friend status preserves server
order, duplicates, self entries, nullable status and uninterpreted raw fields.

Existing methods and constructors remain available. The legacy
`AcceptFriendRequestAsync`/`RejectFriendRequestAsync` helpers call the standard
routes; this Lagrange baseline instead exposes `HandleFriendRequestAsync` with
`MilkyHandleFriendRequestRequest`. Its friend-request push currently lacks an
actionable flag, so the SDK does not invent one. For the parameterless Lagrange
friend-request list, call `GetFriendRequestsAsync(cancellationToken)`; the older
filter overload remains available for standard servers.

Cookie results support both standard strings and Lagrange dictionaries through
`Cookies` and `CookieValues`. CSRF results accept both `csrf_token` and `token`.
Group models expose full-width `MemberCount64`/`MaxMemberCount64` while retaining
the legacy `int` accessors; reading those legacy accessors outside the `int` range
throws an overflow exception. Additive Lagrange fields are available on existing
announcement, file, friend-request, essence-message and segment models.

Use `MilkyJson.GetTypeInfo<T>()` to serialize built-in wire models without
reflection. This includes all added request, result, event and message types.
API calls continue to use the existing envelope, cancellation and error handling
and introduce no automatic retry.

The contract tests use server-derived fixtures and mocked HTTP, without connecting
to QQ. Regenerate API models and fixtures with:

```powershell
python tools/generate_lagrange_tests.py E:/Clones/LagrangeV2
dotnet build SaltyMilky.Net.slnx -c Release
dotnet run --project SaltyMilky.Net.Tests -c Release
dotnet publish SaltyMilky.Net.NativeAotSmoke -c Release -r win-x64 -o artifacts/native-aot
./artifacts/native-aot/SaltyMilky.Net.NativeAotSmoke.exe --require-native
```

The native smoke executable exercises every route against mock HTTP responses,
request defaults, unsigned style boundaries, nested forwards, temporary replies,
key metadata presence, packet response variants and legacy JSON compatibility.

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
