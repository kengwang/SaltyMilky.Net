using System.Buffers;
using System.Net;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace SaltyMilky.Net;

/// <summary>
/// Event transport helpers for Milky SSE, WebSocket, and WebHook communication.
/// </summary>
public static class MilkyCommunication
{
    /// <summary>
    /// Gets the protocol event endpoint path.
    /// </summary>
    public const string EventEndpointPath = "event";

    private static readonly TimeSpan DefaultReconnectDelay = TimeSpan.FromSeconds(3);

    /// <summary>
    /// Reads events from the protocol-side SSE /event endpoint.
    /// </summary>
    public static async IAsyncEnumerable<MilkyEvent> ReadSseEventsAsync(
        HttpClient client,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);

        using HttpRequestMessage request = new(HttpMethod.Get, EventEndpointPath);
        using HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        await using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        await foreach (MilkyEvent milkyEvent in ReadSseEventsAsync(stream, cancellationToken).ConfigureAwait(false))
        {
            yield return milkyEvent;
        }
    }

    /// <summary>
    /// Reads SSE events and reconnects after transport failures until cancellation is requested.
    /// </summary>
    public static async IAsyncEnumerable<MilkyEvent> ReadSseEventsWithReconnectAsync(
        HttpClient client,
        TimeSpan? reconnectDelay = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(client);
        TimeSpan delay = reconnectDelay ?? DefaultReconnectDelay;

        while (!cancellationToken.IsCancellationRequested)
        {
            IAsyncEnumerator<MilkyEvent> enumerator = ReadSseEventsAsync(client, cancellationToken).GetAsyncEnumerator(cancellationToken);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    MilkyEvent milkyEvent;
                    try
                    {
                        if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            break;
                        }

                        milkyEvent = enumerator.Current;
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    catch (HttpRequestException)
                    {
                        break;
                    }
                    catch (IOException)
                    {
                        break;
                    }

                    yield return milkyEvent;
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }

            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Reads events from an SSE stream.
    /// </summary>
    public static async IAsyncEnumerable<MilkyEvent> ReadSseEventsAsync(
        Stream stream,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(stream);

        using StreamReader reader = new(stream, Encoding.UTF8, leaveOpen: true);
        List<string> dataLines = [];
        while (await reader.ReadLineAsync(cancellationToken).ConfigureAwait(false) is { } line)
        {
            if (line.Length == 0)
            {
                MilkyEvent? milkyEvent = ParseSseDataLines(dataLines);
                if (milkyEvent is not null)
                {
                    yield return milkyEvent;
                }

                dataLines.Clear();
                continue;
            }

            if (line.StartsWith("data:", StringComparison.Ordinal))
            {
                dataLines.Add(line[5..].TrimStart());
            }
        }

        MilkyEvent? finalEvent = ParseSseDataLines(dataLines);
        if (finalEvent is not null)
        {
            yield return finalEvent;
        }
    }

    /// <summary>
    /// Reads events from a protocol-side WebSocket /event endpoint.
    /// </summary>
    public static async IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsAsync(
        Uri eventUri,
        string? accessToken = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(eventUri);

        using ClientWebSocket webSocket = new();
        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            webSocket.Options.SetRequestHeader("Authorization", $"Bearer {accessToken}");
        }

        await webSocket.ConnectAsync(ToWebSocketUri(eventUri), cancellationToken).ConfigureAwait(false);
        await foreach (MilkyEvent milkyEvent in ReadWebSocketEventsAsync(webSocket, cancellationToken).ConfigureAwait(false))
        {
            yield return milkyEvent;
        }
    }

    /// <summary>
    /// Reads WebSocket events and reconnects after transport failures until cancellation is requested.
    /// </summary>
    public static async IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsWithReconnectAsync(
        Uri eventUri,
        string? accessToken = null,
        TimeSpan? reconnectDelay = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(eventUri);
        TimeSpan delay = reconnectDelay ?? DefaultReconnectDelay;

        while (!cancellationToken.IsCancellationRequested)
        {
            IAsyncEnumerator<MilkyEvent> enumerator = ReadWebSocketEventsAsync(eventUri, accessToken, cancellationToken).GetAsyncEnumerator(cancellationToken);
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    MilkyEvent milkyEvent;
                    try
                    {
                        if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                        {
                            break;
                        }

                        milkyEvent = enumerator.Current;
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }
                    catch (WebSocketException)
                    {
                        break;
                    }
                    catch (IOException)
                    {
                        break;
                    }

                    yield return milkyEvent;
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }

            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Reads events from an already connected WebSocket.
    /// </summary>
    public static async IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsAsync(
        WebSocket webSocket,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
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

                MilkyEvent? milkyEvent = JsonSerializer.Deserialize(message.ToArray(), MilkyJsonSerializerContext.Default.MilkyEvent);
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

        return string.Equals(header.Scheme, "Bearer", StringComparison.OrdinalIgnoreCase)
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
            "http" => "ws",
            "https" => "wss",
            "ws" or "wss" => builder.Scheme,
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

    private static MilkyEvent? ParseSseDataLines(List<string> dataLines)
    {
        if (dataLines.Count == 0)
        {
            return null;
        }

        string json = string.Join('\n', dataLines);
        return MilkyEventParser.ParseJson(json);
    }

    private static async Task HandleWebhookRequestAsync(HttpListenerContext context, MilkyEventPipeline pipeline, string? accessToken, CancellationToken cancellationToken)
    {
        try
        {
            if (!string.Equals(context.Request.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                return;
            }

            MilkyEvent? milkyEvent = await ReadWebhookEventAsync(context.Request.InputStream, context.Request.Headers["Authorization"], accessToken, cancellationToken).ConfigureAwait(false);
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
        return MilkyCommunication.ReadSseEventsAsync(session.Client, cancellationToken);
    }

    /// <summary>
    /// Reads events from the protocol-side SSE /event endpoint and reconnects after transport failures.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadSseEventsWithReconnectAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return MilkyCommunication.ReadSseEventsWithReconnectAsync(session.Client, reconnectDelay, cancellationToken);
    }

    /// <summary>
    /// Reads events from the protocol-side WebSocket /event endpoint.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsAsync(this MilkyHttpSession session, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return MilkyCommunication.ReadWebSocketEventsAsync(session.EventUri, session.AccessToken, cancellationToken);
    }

    /// <summary>
    /// Reads events from the protocol-side WebSocket /event endpoint and reconnects after transport failures.
    /// </summary>
    public static IAsyncEnumerable<MilkyEvent> ReadWebSocketEventsWithReconnectAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return MilkyCommunication.ReadWebSocketEventsWithReconnectAsync(session.EventUri, session.AccessToken, reconnectDelay, cancellationToken);
    }

    /// <summary>
    /// Reads SSE events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunSseEventLoopAsync(this MilkyHttpSession session, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await foreach (MilkyEvent milkyEvent in session.ReadSseEventsAsync(cancellationToken).ConfigureAwait(false))
        {
            await session.EventPipeline.ExecuteAsync(milkyEvent, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Reads reconnecting SSE events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunReconnectingSseEventLoopAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await foreach (MilkyEvent milkyEvent in session.ReadSseEventsWithReconnectAsync(reconnectDelay, cancellationToken).ConfigureAwait(false))
        {
            await session.EventPipeline.ExecuteAsync(milkyEvent, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Reads WebSocket events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunWebSocketEventLoopAsync(this MilkyHttpSession session, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await foreach (MilkyEvent milkyEvent in session.ReadWebSocketEventsAsync(cancellationToken).ConfigureAwait(false))
        {
            await session.EventPipeline.ExecuteAsync(milkyEvent, cancellationToken).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Reads reconnecting WebSocket events and executes the session event pipeline for each event.
    /// </summary>
    public static async Task RunReconnectingWebSocketEventLoopAsync(this MilkyHttpSession session, TimeSpan? reconnectDelay = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        await foreach (MilkyEvent milkyEvent in session.ReadWebSocketEventsWithReconnectAsync(reconnectDelay, cancellationToken).ConfigureAwait(false))
        {
            await session.EventPipeline.ExecuteAsync(milkyEvent, cancellationToken).ConfigureAwait(false);
        }
    }
}
