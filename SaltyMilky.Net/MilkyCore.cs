using System.Net.Http.Headers;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace SaltyMilky.Net;

/// <summary>
/// Shared JSON options for the Milky wire format.
/// </summary>
public static class MilkyJson
{
    /// <summary>
    /// Gets JSON serializer options used by this SDK.
    /// </summary>
    public static JsonSerializerOptions Options { get; } = CreateOptions();

    /// <summary>
    /// Gets source-generated JSON metadata for Milky event envelopes.
    /// </summary>
    public static JsonTypeInfo<MilkyEvent> EventTypeInfo => MilkyJsonSerializerContext.Default.MilkyEvent;

    /// <summary>
    /// Gets source-generated JSON metadata for outgoing message segments.
    /// </summary>
    public static JsonTypeInfo<MilkyOutgoingSegment> OutgoingSegmentTypeInfo => MilkyJsonSerializerContext.Default.MilkyOutgoingSegment;

    /// <summary>
    /// Gets source-generated JSON metadata for incoming message segments.
    /// </summary>
    public static JsonTypeInfo<MilkyIncomingSegment> IncomingSegmentTypeInfo => MilkyJsonSerializerContext.Default.MilkyIncomingSegment;

    private static JsonSerializerOptions CreateOptions()
    {
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            TypeInfoResolver = MilkyJsonSerializerContext.Default,
        };

        options.Converters.Add(new MilkyOutgoingSegmentJsonConverter());
        options.Converters.Add(new MilkyIncomingSegmentJsonConverter());
        options.Converters.Add(new MilkyEventJsonConverter());
        return options;
    }
}

/// <summary>
/// Represents a Milky API action.
/// </summary>
public abstract class MilkyAction
{
    /// <summary>
    /// Gets the Milky API endpoint name.
    /// </summary>
    public abstract string ApiName { get; }

    internal abstract object GetParamsModel();
}

/// <summary>
/// Represents a generic Milky API action with typed response data.
/// </summary>
/// <typeparam name="TData">The response data type.</typeparam>
public sealed class MilkyApiAction<TData> : MilkyAction
{
    private readonly object? _parameters;

    /// <summary>
    /// Initializes a generic API action.
    /// </summary>
    /// <param name="apiName">The Milky API endpoint name.</param>
    /// <param name="parameters">The request parameters.</param>
    public MilkyApiAction(string apiName, object? parameters = null)
    {
        ApiName = apiName ?? throw new ArgumentNullException(nameof(apiName));
        _parameters = parameters;
    }

    /// <inheritdoc />
    public override string ApiName { get; }

    internal override object GetParamsModel() => _parameters ?? MilkyEmptyObject.Instance;
}

/// <summary>
/// Empty object sent for Milky APIs without input parameters.
/// </summary>
public sealed class MilkyEmptyObject
{
    /// <summary>
    /// Gets the singleton empty object.
    /// </summary>
    public static MilkyEmptyObject Instance { get; } = new();

    private MilkyEmptyObject()
    {
    }
}

/// <summary>
/// Sends Milky API actions.
/// </summary>
public abstract class MilkyActionSender
{
    /// <summary>
    /// Invokes a Milky action without typed response data.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The action result.</returns>
    [RequiresUnreferencedCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization. Use AOT-safe overloads when available.")]
    [RequiresDynamicCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization.")]
    public abstract Task<MilkyActionResult?> InvokeActionAsync(MilkyAction action, CancellationToken cancellationToken = default);

    /// <summary>
    /// Invokes a Milky action with typed response data.
    /// </summary>
    /// <typeparam name="TData">The response data type.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The action result.</returns>
    [RequiresUnreferencedCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization. Use AOT-safe overloads when available.")]
    [RequiresDynamicCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization.")]
    public abstract Task<MilkyActionResult<TData>?> InvokeActionAsync<TData>(MilkyAction action, CancellationToken cancellationToken = default);
}

/// <summary>
/// Represents a Milky session that can invoke actions.
/// </summary>
public interface IMilkyActionSession
{
    /// <summary>
    /// Gets the action sender used by this session.
    /// </summary>
    MilkyActionSender ActionSender { get; }
}

/// <summary>
/// Options for <see cref="MilkyHttpSession" />.
/// </summary>
public sealed class MilkyHttpSessionOptions
{
    /// <summary>
    /// Gets or sets the protocol-side HTTP base address, for example http://127.0.0.1:3000/.
    /// </summary>
    public Uri? BaseAddress { get; set; }

    /// <summary>
    /// Gets or sets the access token used as a Bearer token.
    /// </summary>
    public string? AccessToken { get; set; }

    /// <summary>
    /// Gets or sets an externally owned HTTP client.
    /// </summary>
    public HttpClient? HttpClient { get; set; }
}

/// <summary>
/// HTTP session for invoking Milky APIs.
/// </summary>
public sealed class MilkyHttpSession : IMilkyActionSession, IMilkyEventSession, IDisposable
{
    private readonly bool _ownsClient;

    /// <summary>
    /// Initializes a HTTP session.
    /// </summary>
    /// <param name="options">The session options.</param>
    public MilkyHttpSession(MilkyHttpSessionOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        HttpClient client = options.HttpClient ?? new HttpClient();
        _ownsClient = options.HttpClient is null;

        if (options.BaseAddress is not null)
        {
            client.BaseAddress = options.BaseAddress;
        }

        if (!string.IsNullOrWhiteSpace(options.AccessToken))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.AccessToken);
        }

        ActionSender = new MilkyHttpActionSender(client);
        EventPipeline = new MilkyEventPipeline();
    }

    /// <inheritdoc />
    public MilkyActionSender ActionSender { get; }

    /// <inheritdoc />
    public MilkyEventPipeline EventPipeline { get; }

    /// <summary>
    /// Releases the owned HTTP client, if any.
    /// </summary>
    public void Dispose()
    {
        if (_ownsClient && ActionSender is MilkyHttpActionSender sender)
        {
            sender.Client.Dispose();
        }
    }
}

/// <summary>
/// HTTP implementation of a Milky action sender.
/// </summary>
public sealed class MilkyHttpActionSender : MilkyActionSender
{
    /// <summary>
    /// Initializes a HTTP action sender.
    /// </summary>
    /// <param name="client">The HTTP client.</param>
    public MilkyHttpActionSender(HttpClient client)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
    }

    /// <summary>
    /// Gets the underlying HTTP client.
    /// </summary>
    public HttpClient Client { get; }

    /// <inheritdoc />
    [RequiresUnreferencedCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization. Use AOT-safe overloads when available.")]
    [RequiresDynamicCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization.")]
    public override async Task<MilkyActionResult?> InvokeActionAsync(MilkyAction action, CancellationToken cancellationToken = default)
    {
        return await InvokeActionAsync<MilkyEmptyObject>(action, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    [RequiresUnreferencedCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization. Use AOT-safe overloads when available.")]
    [RequiresDynamicCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization.")]
    public override async Task<MilkyActionResult<TData>?> InvokeActionAsync<TData>(MilkyAction action, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(action);

        string json = JsonSerializer.Serialize(action.GetParamsModel(), MilkyJson.Options);
        using StringContent content = new(json, Encoding.UTF8, "application/json");
        using HttpResponseMessage response = await Client.PostAsync($"api/{action.ApiName}", content, cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            return new MilkyActionResult<TData>
            {
                Status = "failed",
                RetCode = -(int)response.StatusCode,
                Message = response.ReasonPhrase,
            };
        }

        await using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        MilkyApiResponseRaw? raw = await JsonSerializer.DeserializeAsync(stream, MilkyJsonSerializerContext.Default.MilkyApiResponseRaw, cancellationToken).ConfigureAwait(false);
        if (raw is null)
        {
            return null;
        }

        TData? data = default;
        if (raw.Data.ValueKind is not JsonValueKind.Undefined and not JsonValueKind.Null)
        {
            data = raw.Data.Deserialize<TData>(MilkyJson.Options);
        }

        return new MilkyActionResult<TData>
        {
            Status = raw.Status,
            RetCode = raw.RetCode,
            Message = raw.Message,
            Data = data,
        };
    }
}

/// <summary>
/// Raw Milky API response.
/// </summary>
public sealed class MilkyApiResponseRaw
{
    /// <summary>
    /// Gets or sets the response status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the response return code.
    /// </summary>
    [JsonPropertyName("retcode")]
    public int RetCode { get; set; }

    /// <summary>
    /// Gets or sets the response data.
    /// </summary>
    [JsonPropertyName("data")]
    public JsonElement Data { get; set; }

    /// <summary>
    /// Gets or sets the response error message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

/// <summary>
/// Represents a Milky action result.
/// </summary>
public class MilkyActionResult
{
    /// <summary>
    /// Gets or sets the response status.
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the response return code.
    /// </summary>
    public int RetCode { get; set; }

    /// <summary>
    /// Gets or sets the response error message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Gets whether this action succeeded.
    /// </summary>
    public bool IsSuccess => Status == "ok" && RetCode == 0;
}

/// <summary>
/// Represents a Milky action result with typed data.
/// </summary>
/// <typeparam name="TData">The response data type.</typeparam>
public sealed class MilkyActionResult<TData> : MilkyActionResult
{
    /// <summary>
    /// Gets or sets the response data.
    /// </summary>
    public TData? Data { get; set; }
}

/// <summary>
/// Extension methods for invoking Milky APIs through a session.
/// </summary>
public static partial class MilkyActionSessionExtensions
{
    /// <summary>
    /// Invokes an arbitrary Milky API.
    /// </summary>
    [RequiresUnreferencedCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization. Use typed SDK methods for AOT-sensitive applications.")]
    [RequiresDynamicCode("Generic Milky API invocation uses reflection-based System.Text.Json serialization.")]
    public static Task<MilkyActionResult<TData>?> InvokeApiAsync<TData>(this IMilkyActionSession session, string apiName, object? parameters = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return session.ActionSender.InvokeActionAsync<TData>(new MilkyApiAction<TData>(apiName, parameters), cancellationToken);
    }

    /// <summary>
    /// Invokes an arbitrary Milky API without output data.
    /// </summary>
    public static Task<MilkyActionResult?> InvokeApiAsync(this IMilkyActionSession session, string apiName, object? parameters = null, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        return session.ActionSender.InvokeActionAsync(new MilkyApiAction<MilkyEmptyObject>(apiName, parameters), cancellationToken);
    }
}
