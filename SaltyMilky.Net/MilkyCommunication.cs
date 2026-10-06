using System.Buffers;
using System.Net;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

namespace SaltyMilky.Net;

/// <summary>
/// Event transport helpers for Milky SSE, WebSocket, and WebHook communication.
/// </summary>
public static class MilkyCommunication
{
    /// <summary>
    /// Gets the protocol event endpoint path.
    /// </summary>
    public const string EventEndpointPath = MilkyConstant.Communication.EventEndpointPath;

    private static readonly TimeSpan DefaultReconnectDelay = TimeSpan.FromSeconds(3);
    private static readonly TimeSpan DefaultEventIdleTimeout = Timeout.InfiniteTimeSpan;

    /// <summary>
    /// Reads events from the protocol-side SSE /event endpoint.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadSseEventsAsync(
        HttpClient client,
        CancellationToken cancellationToken = default)
        => ReadSseEventsAsync(client, cancellationToken, null);

    internal static async IAsyncEnumerable<MilkyEvent> ReadSseEventsAsync(
        HttpClient client,
        [EnumeratorCancellation] CancellationToken cancellationToken,
        Action<Exception>? eventParseExceptionHandler)
    {
        ArgumentNullException.ThrowIfNull(client);

        using HttpRequestMessage request = new(HttpMethod.Get, EventEndpointPath);
        using HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        await using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        await foreach (MilkyEvent milkyEvent in ReadSseEventsAsync(stream, cancellationToken, eventParseExceptionHandler).ConfigureAwait(false))
        {
            yield return milkyEvent;
        }
    }

    /// <summary>
    /// Reads SSE events and reconnects after transport failures until cancellation is requested.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadSseEventsWithReconnectAsync(
        HttpClient client,
        TimeSpan? reconnectDelay = null,
        CancellationToken cancellationToken = default)
        => ReadSseEventsWithReconnectAsync(client, reconnectDelay, cancellationToken, null);

    internal static async IAsyncEnumerable<MilkyEvent> ReadSseEventsWithReconnectAsync(
        HttpClient client,
        TimeSpan? reconnectDelay,
        [EnumeratorCancellation] CancellationToken cancellationToken,
        Action<Exception>? eventParseExceptionHandler)
    {
        await foreach (MilkyEvent milkyEvent in ReadSseEventsWithReconnectAsync(client, reconnectDelay, DefaultEventIdleTimeout, cancellationToken, eventParseExceptionHandler).ConfigureAwait(false))
        {
            yield return milkyEvent;
        }
    }

    /// <summary>
    /// Reads SSE events and reconnects after transport failures or idle timeouts until cancellation is requested.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadSseEventsWithReconnectAsync(
        HttpClient client,
        TimeSpan? reconnectDelay,
        TimeSpan? idleTimeout,
        CancellationToken cancellationToken = default)
        => ReadSseEventsWithReconnectAsync(client, reconnectDelay, idleTimeout, cancellationToken, null);

    internal static async IAsyncEnumerable<MilkyEvent> ReadSseEventsWithReconnectAsync(
        HttpClient client,
        TimeSpan? reconnectDelay,
        TimeSpan? idleTimeout,
        [EnumeratorCancellation] CancellationToken cancellationToken,
        Action<Exception>? eventParseExceptionHandler)
    {
        ArgumentNullException.ThrowIfNull(client);
        TimeSpan delay = reconnectDelay ?? DefaultReconnectDelay;
        TimeSpan idle = idleTimeout ?? DefaultEventIdleTimeout;

        while (!cancellationToken.IsCancellationRequested)
        {
            using CancellationTokenSource attemptCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            IAsyncEnumerator<MilkyEvent> enumerator = ReadSseEventsAsync(client, attemptCts.Token, eventParseExceptionHandler).GetAsyncEnumerator(attemptCts.Token);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    MilkyEvent milkyEvent;
                    try
                    {
                        if (!await MoveNextWithIdleTimeoutAsync(enumerator, idle, attemptCts.Token).ConfigureAwait(false))
                        {
                            break;
                        }

                        milkyEvent = enumerator.Current;
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    catch (OperationCanceledException) when (attemptCts.IsCancellationRequested)
                    {
                        break;
                    }
                    catch (HttpRequestException)
                    {
                        break;
                    }
                    catch (IOException)
                    {
                        break;
                    }
                    catch (TimeoutException)
                    {
                        await attemptCts.CancelAsync().ConfigureAwait(false);
                        break;
                    }

                    yield return milkyEvent;
                }
            }
            finally
            {
                try
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
                catch (Exception ex) when (IsReconnectableDisposeException(ex) && !cancellationToken.IsCancellationRequested)
                {
                }
            }

            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Reads events from an SSE stream.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadSseEventsAsync(
        Stream stream,
        CancellationToken cancellationToken = default)
        => ReadSseEventsAsync(stream, cancellationToken, null);

    internal static async IAsyncEnumerable<MilkyEvent> ReadSseEventsAsync(
        Stream stream,
        [EnumeratorCancellation] CancellationToken cancellationToken,
        Action<Exception>? eventParseExceptionHandler)
    {
        ArgumentNullException.ThrowIfNull(stream);

        using StreamReader reader = new(stream, Encoding.UTF8, leaveOpen: true);
        List<string> dataLines = [];
        while (await reader.ReadLineAsync(cancellationToken).ConfigureAwait(false) is { } line)
        {
            if (line.Length == 0)
            {
                MilkyEvent? milkyEvent = ParseSseDataLines(dataLines, eventParseExceptionHandler);
                if (milkyEvent is not null)
                {
                    yield return milkyEvent;
                }

                dataLines.Clear();
                continue;
            }

            if (line.StartsWith(MilkyConstant.Communication.SseDataPrefix, StringComparison.Ordinal))
            {
                dataLines.Add(line[MilkyConstant.Communication.SseDataPrefix.Length..].TrimStart());
            }
        }

        MilkyEvent? finalEvent = ParseSseDataLines(dataLines, eventParseExceptionHandler);
        if (finalEvent is not null)
        {
            yield return finalEvent;
        }
    }

    /// <summary>
    /// Reads events from a protocol-side WebSocket /event endpoint.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsAsync(
        Uri eventUri,
        string? accessToken = null,
        CancellationToken cancellationToken = default)
        => ReadWebSocketEventsAsync(eventUri, accessToken, cancellationToken, null);

    internal static async IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsAsync(
        Uri eventUri,
        string? accessToken,
        [EnumeratorCancellation] CancellationToken cancellationToken,
        Action<Exception>? eventParseExceptionHandler)
    {
        ArgumentNullException.ThrowIfNull(eventUri);

        using ClientWebSocket webSocket = new();
        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            webSocket.Options.SetRequestHeader(MilkyConstant.Communication.AuthorizationHeader, $"{MilkyConstant.Communication.BearerScheme} {accessToken}");
        }

        await webSocket.ConnectAsync(ToWebSocketUri(eventUri), cancellationToken).ConfigureAwait(false);
        await foreach (MilkyEvent milkyEvent in ReadWebSocketEventsAsync(webSocket, cancellationToken, eventParseExceptionHandler).ConfigureAwait(false))
        {
            yield return milkyEvent;
        }
    }

    /// <summary>
    /// Reads WebSocket events and reconnects after transport failures until cancellation is requested.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsWithReconnectAsync(
        Uri eventUri,
        string? accessToken = null,
        TimeSpan? reconnectDelay = null,
        CancellationToken cancellationToken = default)
        => ReadWebSocketEventsWithReconnectAsync(eventUri, accessToken, reconnectDelay, cancellationToken, null);

    internal static async IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsWithReconnectAsync(
        Uri eventUri,
        string? accessToken,
        TimeSpan? reconnectDelay,
        [EnumeratorCancellation] CancellationToken cancellationToken,
        Action<Exception>? eventParseExceptionHandler)
    {
        await foreach (MilkyEvent milkyEvent in ReadWebSocketEventsWithReconnectAsync(eventUri, accessToken, reconnectDelay, DefaultEventIdleTimeout, cancellationToken, eventParseExceptionHandler).ConfigureAwait(false))
        {
            yield return milkyEvent;
        }
    }

    /// <summary>
    /// Reads WebSocket events and reconnects after transport failures or idle timeouts until cancellation is requested.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsWithReconnectAsync(
        Uri eventUri,
        string? accessToken,
        TimeSpan? reconnectDelay,
        TimeSpan? idleTimeout,
        CancellationToken cancellationToken = default)
        => ReadWebSocketEventsWithReconnectAsync(eventUri, accessToken, reconnectDelay, idleTimeout, cancellationToken, null);

    internal static async IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsWithReconnectAsync(
        Uri eventUri,
        string? accessToken,
        TimeSpan? reconnectDelay,
        TimeSpan? idleTimeout,
        [EnumeratorCancellation] CancellationToken cancellationToken,
        Action<Exception>? eventParseExceptionHandler)
    {
        ArgumentNullException.ThrowIfNull(eventUri);
        TimeSpan delay = reconnectDelay ?? DefaultReconnectDelay;
        TimeSpan idle = idleTimeout ?? DefaultEventIdleTimeout;

        while (!cancellationToken.IsCancellationRequested)
        {
            using CancellationTokenSource attemptCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            IAsyncEnumerator<MilkyEvent> enumerator = ReadWebSocketEventsAsync(eventUri, accessToken, attemptCts.Token, eventParseExceptionHandler).GetAsyncEnumerator(attemptCts.Token);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    MilkyEvent milkyEvent;
                    try
                    {
                        if (!await MoveNextWithIdleTimeoutAsync(enumerator, idle, attemptCts.Token).ConfigureAwait(false))
                        {
                            break;
                        }

                        milkyEvent = enumerator.Current;
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    catch (OperationCanceledException) when (attemptCts.IsCancellationRequested)
                    {
                        break;
                    }
                    catch (WebSocketException)
                    {
                        break;
                    }
                    catch (IOException)
                    {
                        break;
                    }
                    catch (TimeoutException)
                    {
                        await attemptCts.CancelAsync().ConfigureAwait(false);
                        break;
                    }

                    yield return milkyEvent;
                }
            }
            finally
            {
                try
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
                catch (Exception ex) when (IsReconnectableDisposeException(ex) && !cancellationToken.IsCancellationRequested)
                {
                }
            }

            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Reads events from an already connected WebSocket.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsAsync(
        WebSocket webSocket,
        CancellationToken cancellationToken = default)
        => ReadWebSocketEventsAsync(webSocket, cancellationToken, null);

    internal static async IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsAsync(
        WebSocket webSocket,
        [EnumeratorCancellation] CancellationToken cancellationToken,
        Action<Exception>? eventParseExceptionHandler)
    {
        ArgumentNullException.ThrowIfNull(webSocket);

        byte[] buffer = ArrayPool<byte>.Shared.Rent(16 * 1024);
        try
        {
            while (!cancellationToken.IsCancellationRequested && webSocket.State == WebSocketState.Open)
            {
                using MemoryStream message = new();
                WebSocketReceiveResult result;
                do
                {
                    result = await webSocket.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        yield break;
                    }

                    message.Write(buffer, 0, result.Count);
                }
                while (!result.EndOfMessage);

                if (result.MessageType != WebSocketMessageType.Text)
                {
                    continue;
                }

                MilkyEvent? milkyEvent = ParseEvent(message.ToArray(), eventParseExceptionHandler);
                if (milkyEvent is not null)
                {
                    yield return milkyEvent;
                }
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    /// <summary>
    /// Parses a WebHook request body after validating the optional Authorization header.
    /// </summary>
    public static async Task<MilkyEvent?> ReadWebhookEventAsync(
        Stream body,
        string? authorizationHeader = null,
        string? accessToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(body);

        if (!IsAuthorized(authorizationHeader, accessToken))
        {
            throw new UnauthorizedAccessException("Milky WebHook Authorization header is missing or invalid.");
        }

        return await JsonSerializer.DeserializeAsync(body, MilkyJsonSerializerContext.Default.MilkyEvent, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Runs a lightweight WebHook HTTP listener that validates, parses, and dispatches Milky events.
    /// </summary>
    public static async Task RunWebhookListenerAsync(
        string prefix,
        MilkyEventPipeline pipeline,
        string? accessToken = null,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(prefix);
        ArgumentNullException.ThrowIfNull(pipeline);

        using HttpListener listener = new();
        listener.Prefixes.Add(prefix);
        listener.Start();

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                HttpListenerContext context = await listener.GetContextAsync().WaitAsync(cancellationToken).ConfigureAwait(false);
                _ = Task.Run(() => HandleWebhookRequestAsync(context, pipeline, accessToken, cancellationToken), CancellationToken.None);
            }
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        finally
        {
            listener.Stop();
        }
    }

    /// <summary>
    /// Validates a Milky Authorization header using the Bearer token format.
    /// </summary>
    public static bool IsAuthorized(string? authorizationHeader, string? accessToken)
    {
        if (string.IsNullOrEmpty(accessToken))
        {
            return true;
        }

        if (!AuthenticationHeaderValue.TryParse(authorizationHeader, out AuthenticationHeaderValue? header))
        {
            return false;
        }

        return string.Equals(header.Scheme, MilkyConstant.Communication.BearerScheme, StringComparison.OrdinalIgnoreCase)
            && string.Equals(header.Parameter, accessToken, StringComparison.Ordinal);
    }

    /// <summary>
    /// Converts an HTTP event endpoint URI to a WebSocket URI.
    /// </summary>
    public static Uri ToWebSocketUri(Uri eventUri)
    {
        ArgumentNullException.ThrowIfNull(eventUri);

        UriBuilder builder = new(eventUri);
        builder.Scheme = builder.Scheme switch
        {
            MilkyConstant.CommunicationScheme.Http => MilkyConstant.CommunicationScheme.Ws,
            MilkyConstant.CommunicationScheme.Https => MilkyConstant.CommunicationScheme.Wss,
            MilkyConstant.CommunicationScheme.Ws or MilkyConstant.CommunicationScheme.Wss => builder.Scheme,
            _ => throw new ArgumentException("Event URI must use http, https, ws, or wss.", nameof(eventUri)),
        };

        return builder.Uri;
    }

    internal static Uri BuildEventUri(Uri? baseAddress)
    {
        if (baseAddress is null)
        {
            return new Uri(EventEndpointPath, UriKind.Relative);
        }

        return new Uri(baseAddress, EventEndpointPath);
    }

    private static MilkyEvent? ParseSseDataLines(List<string> dataLines, Action<Exception>? eventParseExceptionHandler)
    {
        if (dataLines.Count == 0)
        {
            return null;
        }

        string json = string.Join('\n', dataLines);
        return ParseEvent(Encoding.UTF8.GetBytes(json), eventParseExceptionHandler);
    }

    private static MilkyEvent? ParseEvent(byte[] json, Action<Exception>? exceptionHandler)
    {
        try
        {
            return JsonSerializer.Deserialize(json, MilkyJsonSerializerContext.Default.MilkyEvent);
        }
        catch (Exception ex) when (ex is JsonException or InvalidOperationException or KeyNotFoundException or FormatException or OverflowException)
        {
            try
            {
                exceptionHandler?.Invoke(ex);
            }
            catch
            {
                // A diagnostics callback must not terminate the event stream.
            }
            return null;
        }
    }

    private static async Task<bool> MoveNextWithIdleTimeoutAsync(
        IAsyncEnumerator<MilkyEvent> enumerator,
        TimeSpan idleTimeout,
        CancellationToken cancellationToken)
    {
        if (idleTimeout <= TimeSpan.Zero || idleTimeout == Timeout.InfiniteTimeSpan)
        {
            return await enumerator.MoveNextAsync().ConfigureAwait(false);
        }

        Task<bool> moveNextTask = enumerator.MoveNextAsync().AsTask();
        Task completedTask = await Task.WhenAny(moveNextTask, Task.Delay(idleTimeout, cancellationToken)).ConfigureAwait(false);
        if (completedTask == moveNextTask)
        {
            return await moveNextTask.ConfigureAwait(false);
        }

        cancellationToken.ThrowIfCancellationRequested();
        throw new TimeoutException("Milky event stream did not receive data before the idle timeout elapsed.");
    }

    private static bool IsReconnectableDisposeException(Exception exception)
    {
        return exception is IOException
            or ObjectDisposedException
            or NotSupportedException
            or OperationCanceledException;
    }

    private static async Task HandleWebhookRequestAsync(HttpListenerContext context, MilkyEventPipeline pipeline, string? accessToken, CancellationToken cancellationToken)
    {
        try
        {
            if (!string.Equals(context.Request.HttpMethod, MilkyConstant.Communication.PostMethod, StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                return;
            }

            MilkyEvent? milkyEvent = await ReadWebhookEventAsync(context.Request.InputStream, context.Request.Headers[MilkyConstant.Communication.AuthorizationHeader], accessToken, cancellationToken).ConfigureAwait(false);
            if (milkyEvent is not null)
            {
                await pipeline.ExecuteAsync(milkyEvent, cancellationToken).ConfigureAwait(false);
            }

            context.Response.StatusCode = (int)HttpStatusCode.NoContent;
        }
        catch (UnauthorizedAccessException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
        catch (JsonException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        finally
        {
            context.Response.Close();
        }
    }
}

/// <summary>
/// Event connection extensions for HTTP-backed Milky sessions.
/// </summary>
public static class MilkyHttpSessionEventExtensions
{
    /// <summary>
    /// Reads events from the protocol-side SSE /event endpoint.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadSseEventsAsync(this MilkyHttpSession session, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return MilkyCommunication.ReadSseEventsAsync(session.Client, cancellationToken, session.EventParseExceptionHandler);
    }

    /// <summary>
    /// Reads events from the protocol-side SSE /event endpoint and reconnects after transport failures.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadSseEventsWithReconnectAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return MilkyCommunication.ReadSseEventsWithReconnectAsync(session.Client, reconnectDelay, cancellationToken, session.EventParseExceptionHandler);
    }

    /// <summary>
    /// Reads events from the protocol-side SSE /event endpoint and reconnects after transport failures or idle timeouts.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadSseEventsWithReconnectAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay, TimeSpan? idleTimeout, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return MilkyCommunication.ReadSseEventsWithReconnectAsync(session.Client, reconnectDelay, idleTimeout, cancellationToken, session.EventParseExceptionHandler);
    }

    /// <summary>
    /// Reads events from the protocol-side WebSocket /event endpoint.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsAsync(this MilkyHttpSession session, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return MilkyCommunication.ReadWebSocketEventsAsync(session.EventUri, session.AccessToken, cancellationToken, session.EventParseExceptionHandler);
    }

    /// <summary>
    /// Reads events from the protocol-side WebSocket /event endpoint and reconnects after transport failures.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsWithReconnectAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return MilkyCommunication.ReadWebSocketEventsWithReconnectAsync(session.EventUri, session.AccessToken, reconnectDelay, cancellationToken, session.EventParseExceptionHandler);
    }

    /// <summary>
    /// Reads events from the protocol-side WebSocket /event endpoint and reconnects after transport failures or idle timeouts.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsWithReconnectAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay, TimeSpan? idleTimeout, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return MilkyCommunication.ReadWebSocketEventsWithReconnectAsync(session.EventUri, session.AccessToken, reconnectDelay, idleTimeout, cancellationToken, session.EventParseExceptionHandler);
    }

    /// <summary>
    /// Reads SSE events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunSseEventLoopAsync(this MilkyHttpSession session, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await RunEventLoopAsync(session, session.ReadSseEventsAsync(cancellationToken), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Reads reconnecting SSE events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunReconnectingSseEventLoopAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await RunEventLoopAsync(session, session.ReadSseEventsWithReconnectAsync(reconnectDelay, cancellationToken), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Reads reconnecting SSE events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunReconnectingSseEventLoopAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay, TimeSpan? idleTimeout, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await RunEventLoopAsync(session, session.ReadSseEventsWithReconnectAsync(reconnectDelay, idleTimeout, cancellationToken), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Reads WebSocket events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunWebSocketEventLoopAsync(this MilkyHttpSession session, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await RunEventLoopAsync(session, session.ReadWebSocketEventsAsync(cancellationToken), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Reads reconnecting WebSocket events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunReconnectingWebSocketEventLoopAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await RunEventLoopAsync(session, session.ReadWebSocketEventsWithReconnectAsync(reconnectDelay, cancellationToken), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Reads reconnecting WebSocket events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunReconnectingWebSocketEventLoopAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay, TimeSpan? idleTimeout, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await RunEventLoopAsync(session, session.ReadWebSocketEventsWithReconnectAsync(reconnectDelay, idleTimeout, cancellationToken), cancellationToken).ConfigureAwait(false);
    }

    private static async Task RunEventLoopAsync(
        MilkyHttpSession session,
        IAsyncEnumerable<MilkyEvent> events,
        CancellationToken cancellationToken)
    {
        Channel<MilkyEvent> channel = Channel.CreateBounded<MilkyEvent>(new BoundedChannelOptions(session.EventQueueCapacity)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleWriter = true,
            SingleReader = session.EventHandlerConcurrency == 1
        });

        Task[] workers = Enumerable.Range(0, session.EventHandlerConcurrency)
            .Select(_ => ConsumeEventsAsync(session, channel.Reader, cancellationToken))
            .ToArray();

        try
        {
            await foreach (MilkyEvent milkyEvent in events.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                await channel.Writer.WriteAsync(milkyEvent, cancellationToken).ConfigureAwait(false);
            }
        }
        finally
        {
            channel.Writer.TryComplete();
            await Task.WhenAll(workers).ConfigureAwait(false);
        }
    }

    private static async Task ConsumeEventsAsync(
        MilkyHttpSession session,
        ChannelReader<MilkyEvent> reader,
        CancellationToken cancellationToken)
    {
        try
        {
            await foreach (MilkyEvent milkyEvent in reader.ReadAllAsync(cancellationToken).ConfigureAwait(false))
            {
                try
                {
                    await session.EventPipeline.ExecuteAsync(milkyEvent, cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
                catch (Exception ex)
                {
                    try
                    {
                        session.EventHandlerExceptionHandler?.Invoke(ex, milkyEvent);
                    }
                    catch
                    {
                        // Exception reporting must not terminate event processing.
                    }
                }
            }
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
    }
}
