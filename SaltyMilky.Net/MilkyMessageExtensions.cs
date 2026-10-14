namespace SaltyMilky.Net;

public static partial class MilkyActionSessionExtensions
{
    /// <summary>Sends a group message with optional presentation metadata.</summary>
    public static Task<MilkyActionResult<MilkySendMessageResult>?> SendGroupMessageAsync(
        this IMilkyActionSession session, long groupId, MilkyMessageStyle? messageStyle,
        IEnumerable<MilkyOutgoingSegment> message, CancellationToken cancellationToken = default) =>
        session.SendGroupMessageAsync(new MilkySendGroupMessageRequest
        {
            GroupId = groupId, Message = message.ToArray(), MessageStyle = messageStyle
        }, cancellationToken);

    /// <summary>Sends a private message with optional presentation metadata.</summary>
    public static Task<MilkyActionResult<MilkySendMessageResult>?> SendPrivateMessageAsync(
        this IMilkyActionSession session, long userId, MilkyMessageStyle? messageStyle,
        IEnumerable<MilkyOutgoingSegment> message, CancellationToken cancellationToken = default) =>
        session.SendPrivateMessageAsync(new MilkySendPrivateMessageRequest
        {
            UserId = userId, Message = message.ToArray(), MessageStyle = messageStyle
        }, cancellationToken);

    /// <summary>Sends a temporary message through the specified group.</summary>
    public static Task<MilkyActionResult<MilkySendTempMessageResult>?> SendTempMessageAsync(
        this IMilkyActionSession session, long groupId, long userId, IEnumerable<MilkyOutgoingSegment> message,
        CancellationToken cancellationToken = default) =>
        session.SendTempMessageAsync(new MilkySendTempMessageRequest
        {
            GroupId = groupId, UserId = userId, Message = message.ToArray()
        }, cancellationToken);

    /// <summary>Sends a temporary message with optional presentation metadata.</summary>
    public static Task<MilkyActionResult<MilkySendTempMessageResult>?> SendTempMessageAsync(
        this IMilkyActionSession session, long groupId, long userId, MilkyMessageStyle? messageStyle,
        IEnumerable<MilkyOutgoingSegment> message, CancellationToken cancellationToken = default) =>
        session.SendTempMessageAsync(new MilkySendTempMessageRequest
        {
            GroupId = groupId, UserId = userId, Message = message.ToArray(), MessageStyle = messageStyle
        }, cancellationToken);
}

/// <summary>Context for a temporary conversation associated with a group.</summary>
public sealed class MilkyTempMessageContext : MilkyMessageContext
{
    /// <summary>Initializes a temporary message context.</summary>
    public MilkyTempMessageContext(IMilkyActionSession session, MilkyEvent milkyEvent,
        MilkyMessageReceiveEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }

    /// <summary>Gets the group through which the conversation was opened.</summary>
    public long GroupId => Message.GroupId ?? throw new InvalidOperationException("A temporary message requires group_id.");

    /// <summary>Gets the conversation peer.</summary>
    public long UserId => Message.PeerId;

    /// <summary>Replies to the user through the source group.</summary>
    public Task ReplyAsync(params MilkyOutgoingSegment[] segments) => SendAsync(segments);

    /// <summary>Sends a message through the source group, forwarding the dispatch cancellation token.</summary>
    public Task SendAsync(IEnumerable<MilkyOutgoingSegment> segments) =>
        Session.SendTempMessageAsync(GroupId, UserId, segments, CancellationToken);
}

public partial class MilkyEventPlugin
{
    /// <summary>Called for an incoming temporary message.</summary>
    protected virtual void OnTempMessageReceived(MilkyTempMessageContext context) { }

    /// <summary>Called asynchronously for an incoming temporary message.</summary>
    protected virtual Task OnTempMessageReceivedAsync(MilkyTempMessageContext context) => Task.CompletedTask;
}
