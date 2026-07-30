namespace SaltyMilky.Net;

/// <summary>Provides the session, event envelope, and cancellation token for a dispatched Milky event.</summary>
public class MilkyEventContext
{
    /// <summary>Initializes a Milky event context.</summary>
    /// <param name="session">The action session associated with the event source.</param>
    /// <param name="milkyEvent">The event envelope.</param>
    /// <param name="cancellationToken">The event dispatch cancellation token.</param>
    public MilkyEventContext(IMilkyActionSession session, MilkyEvent milkyEvent, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(milkyEvent);
        Session = session;
        Event = milkyEvent;
        CancellationToken = cancellationToken;
    }

    /// <summary>Gets the action session associated with the event source.</summary>
    public IMilkyActionSession Session { get; }

    /// <summary>Gets the event envelope.</summary>
    public MilkyEvent Event { get; }

    /// <summary>Gets the event dispatch cancellation token.</summary>
    public CancellationToken CancellationToken { get; }

    /// <summary>Gets the bot QQ number.</summary>
    public long SelfId => Event.SelfId;
}

/// <summary>Provides strongly typed event data together with its session and event envelope.</summary>
/// <typeparam name="TData">The event data type.</typeparam>
public class MilkyEventContext<TData> : MilkyEventContext where TData : MilkyEventData
{
    /// <summary>Initializes a strongly typed Milky event context.</summary>
    /// <param name="session">The action session associated with the event source.</param>
    /// <param name="milkyEvent">The event envelope.</param>
    /// <param name="data">The strongly typed event data.</param>
    /// <param name="cancellationToken">The event dispatch cancellation token.</param>
    public MilkyEventContext(IMilkyActionSession session, MilkyEvent milkyEvent, TData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(data);
        Data = data;
    }

    /// <summary>Gets the strongly typed event data.</summary>
    public TData Data { get; }
}

/// <summary>Base context for an incoming message.</summary>
public abstract class MilkyMessageContext : MilkyEventContext<MilkyMessageReceiveEventData>
{
    /// <summary>Initializes an incoming message context.</summary>
    protected MilkyMessageContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyMessageReceiveEventData data, CancellationToken cancellationToken)
        : base(session, milkyEvent, data, cancellationToken)
    {
    }

    /// <summary>Gets the incoming message.</summary>
    public MilkyIncomingMessage Message => Data.Message;

    /// <summary>Gets the message sequence.</summary>
    public long MessageSeq => Message.MessageSeq;

    /// <summary>Gets the sender QQ number.</summary>
    public long SenderId => Message.SenderId;

    /// <summary>Gets all text segments concatenated in message order.</summary>
    public string Text => Message.Text();

    /// <summary>Gets the incoming message segments.</summary>
    public IReadOnlyList<MilkyIncomingSegment> Segments => Message.Segments;
}

/// <summary>Context for an incoming group message.</summary>
public sealed class MilkyGroupMessageContext : MilkyMessageContext
{
    /// <summary>Initializes a group message context.</summary>
    public MilkyGroupMessageContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyMessageReceiveEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken)
    {
    }

    /// <summary>Gets the group QQ number.</summary>
    public long GroupId => Message.PeerId;

    /// <summary>Gets information about the sending group member.</summary>
    public MilkyGroupMemberEntity? Sender => Message.GroupMember;

    /// <summary>Replies in the source group.</summary>
    /// <param name="segments">The outgoing message segments.</param>
    /// <returns>The send operation.</returns>
    public Task ReplyAsync(params MilkyOutgoingSegment[] segments) => SendAsync(segments);

    /// <summary>Sends a message to the source group.</summary>
    /// <param name="segments">The outgoing message segments.</param>
    /// <returns>The send operation.</returns>
    public Task SendAsync(IEnumerable<MilkyOutgoingSegment> segments) =>
        Session.SendGroupMessageAsync(GroupId, segments, CancellationToken);
}

/// <summary>Context for an incoming private message.</summary>
public sealed class MilkyPrivateMessageContext : MilkyMessageContext
{
    /// <summary>Initializes a private message context.</summary>
    public MilkyPrivateMessageContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyMessageReceiveEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken)
    {
    }

    /// <summary>Gets the peer QQ number.</summary>
    public long UserId => Message.PeerId;

    /// <summary>Gets information about the sending friend.</summary>
    public MilkyFriendEntity? Sender => Message.Friend;

    /// <summary>Replies to the source user.</summary>
    /// <param name="segments">The outgoing message segments.</param>
    /// <returns>The send operation.</returns>
    public Task ReplyAsync(params MilkyOutgoingSegment[] segments) => SendAsync(segments);

    /// <summary>Sends a message to the source user.</summary>
    /// <param name="segments">The outgoing message segments.</param>
    /// <returns>The send operation.</returns>
    public Task SendAsync(IEnumerable<MilkyOutgoingSegment> segments) =>
        Session.SendPrivateMessageAsync(UserId, segments, CancellationToken);
}

/// <summary>Context shared by group join and invited-join requests.</summary>
public class MilkyGroupRequestContext : MilkyEventContext<MilkyCommonEventData>
{
    /// <summary>Initializes a group request context.</summary>
    public MilkyGroupRequestContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyCommonEventData data, string notificationType, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(notificationType);
        NotificationType = notificationType;
    }

    /// <summary>Gets the Milky group notification type.</summary>
    public string NotificationType { get; }

    /// <summary>Gets the target group QQ number.</summary>
    public long GroupId => Data.GroupId ?? 0;

    /// <summary>Gets the requesting user QQ number.</summary>
    public long UserId => Data.InitiatorId ?? Data.TargetUserId ?? 0;

    /// <summary>Gets the request comment.</summary>
    public string Comment => Data.Comment ?? string.Empty;

    /// <summary>Accepts the group request.</summary>
    /// <returns>The accept operation.</returns>
    public Task AcceptAsync() => Session.AcceptGroupRequestAsync(
        Data.NotificationSeq ?? 0, NotificationType, GroupId, Data.IsFiltered ?? false, CancellationToken);

    /// <summary>Rejects the group request.</summary>
    /// <param name="reason">An optional rejection reason.</param>
    /// <returns>The reject operation.</returns>
    public Task RejectAsync(string? reason = null) => Session.RejectGroupRequestAsync(
        Data.NotificationSeq ?? 0, NotificationType, GroupId, Data.IsFiltered ?? false, reason, CancellationToken);
}

/// <summary>Context for a recalled group message.</summary>
public sealed class MilkyGroupMessageRecallContext : MilkyEventContext<MilkyMessageRecallEventData>
{
    /// <summary>Initializes a group message recall context.</summary>
    public MilkyGroupMessageRecallContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyMessageRecallEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken)
    {
    }

    /// <summary>Gets the group QQ number.</summary>
    public long GroupId => Data.PeerId;

    /// <summary>Gets the original sender QQ number.</summary>
    public long UserId => Data.SenderId;

    /// <summary>Gets the operator QQ number.</summary>
    public long OperatorId => Data.OperatorId;

    /// <summary>Gets the recalled message sequence.</summary>
    public long MessageSeq => Data.MessageSeq;
}

/// <summary>Context for a recalled private message.</summary>
public sealed class MilkyPrivateMessageRecallContext : MilkyEventContext<MilkyMessageRecallEventData>
{
    /// <summary>Initializes a private message recall context.</summary>
    public MilkyPrivateMessageRecallContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyMessageRecallEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }

    /// <summary>Gets the peer QQ number.</summary>
    public long UserId => Data.PeerId;

    /// <summary>Gets the original sender QQ number.</summary>
    public long SenderId => Data.SenderId;

    /// <summary>Gets the recalled message sequence.</summary>
    public long MessageSeq => Data.MessageSeq;
}

/// <summary>Context for a bot offline event.</summary>
public sealed class MilkyBotOfflineContext : MilkyEventContext<MilkyBotOfflineEventData>
{
    /// <summary>Initializes a bot offline context.</summary>
    public MilkyBotOfflineContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyBotOfflineEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Base context for scalar Milky events.</summary>
/// <typeparam name="TData">The scalar event data type.</typeparam>
public abstract class MilkyCommonEventContext<TData> : MilkyEventContext<TData> where TData : MilkyCommonEventData
{
    /// <summary>Initializes a scalar event context.</summary>
    protected MilkyCommonEventContext(IMilkyActionSession session, MilkyEvent milkyEvent, TData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a peer pin change.</summary>
public sealed class MilkyPeerPinChangeContext : MilkyCommonEventContext<MilkyPeerPinChangeEventData>
{
    /// <summary>Initializes a peer pin change context.</summary>
    public MilkyPeerPinChangeContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyPeerPinChangeEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a friend request.</summary>
public sealed class MilkyFriendRequestContext : MilkyCommonEventContext<MilkyFriendRequestEventData>
{
    /// <summary>Initializes a friend request context.</summary>
    public MilkyFriendRequestContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyFriendRequestEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }

    /// <summary>Accepts the friend request.</summary>
    public Task AcceptAsync() => Session.AcceptFriendRequestAsync(Data.InitiatorUid ?? string.Empty, Data.IsFiltered ?? false, CancellationToken);

    /// <summary>Rejects the friend request.</summary>
    public Task RejectAsync(string? reason = null) => Session.RejectFriendRequestAsync(Data.InitiatorUid ?? string.Empty, Data.IsFiltered ?? false, reason, CancellationToken);
}

/// <summary>Context for a group join request.</summary>
public sealed class MilkyGroupJoinRequestContext : MilkyGroupRequestContext
{
    /// <summary>Initializes a group join request context.</summary>
    public MilkyGroupJoinRequestContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupJoinRequestEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, "join_request", cancellationToken) { }
}

/// <summary>Context for an invited group join request.</summary>
public sealed class MilkyGroupInvitedJoinRequestContext : MilkyGroupRequestContext
{
    /// <summary>Initializes an invited group join request context.</summary>
    public MilkyGroupInvitedJoinRequestContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupInvitedJoinRequestEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, "invited_join_request", cancellationToken) { }
}

/// <summary>Context for a group invitation.</summary>
public sealed class MilkyGroupInvitationContext : MilkyCommonEventContext<MilkyGroupInvitationEventData>
{
    /// <summary>Initializes a group invitation context.</summary>
    public MilkyGroupInvitationContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupInvitationEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }

    /// <summary>Accepts the group invitation.</summary>
    public Task AcceptAsync() => Session.AcceptGroupInvitationAsync(Data.GroupId ?? 0, Data.InvitationSeq ?? 0, CancellationToken);

    /// <summary>Rejects the group invitation.</summary>
    public Task RejectAsync() => Session.RejectGroupInvitationAsync(Data.GroupId ?? 0, Data.InvitationSeq ?? 0, CancellationToken);
}

/// <summary>Context for a friend nudge.</summary>
public sealed class MilkyFriendNudgeContext : MilkyCommonEventContext<MilkyFriendNudgeEventData>
{
    /// <summary>Initializes a friend nudge context.</summary>
    public MilkyFriendNudgeContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyFriendNudgeEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a friend file upload.</summary>
public sealed class MilkyFriendFileUploadContext : MilkyCommonEventContext<MilkyFriendFileUploadEventData>
{
    /// <summary>Initializes a friend file upload context.</summary>
    public MilkyFriendFileUploadContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyFriendFileUploadEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group administrator change.</summary>
public sealed class MilkyGroupAdminChangeContext : MilkyCommonEventContext<MilkyGroupAdminChangeEventData>
{
    /// <summary>Initializes a group administrator change context.</summary>
    public MilkyGroupAdminChangeContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupAdminChangeEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group essence message change.</summary>
public sealed class MilkyGroupEssenceMessageChangeContext : MilkyCommonEventContext<MilkyGroupEssenceMessageChangeEventData>
{
    /// <summary>Initializes a group essence message change context.</summary>
    public MilkyGroupEssenceMessageChangeContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupEssenceMessageChangeEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group member increase.</summary>
public sealed class MilkyGroupMemberIncreaseContext : MilkyCommonEventContext<MilkyGroupMemberIncreaseEventData>
{
    /// <summary>Initializes a group member increase context.</summary>
    public MilkyGroupMemberIncreaseContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupMemberIncreaseEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group member decrease.</summary>
public sealed class MilkyGroupMemberDecreaseContext : MilkyCommonEventContext<MilkyGroupMemberDecreaseEventData>
{
    /// <summary>Initializes a group member decrease context.</summary>
    public MilkyGroupMemberDecreaseContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupMemberDecreaseEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group name change.</summary>
public sealed class MilkyGroupNameChangeContext : MilkyCommonEventContext<MilkyGroupNameChangeEventData>
{
    /// <summary>Initializes a group name change context.</summary>
    public MilkyGroupNameChangeContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupNameChangeEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group message reaction.</summary>
public sealed class MilkyGroupMessageReactionContext : MilkyCommonEventContext<MilkyGroupMessageReactionEventData>
{
    /// <summary>Initializes a group message reaction context.</summary>
    public MilkyGroupMessageReactionContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupMessageReactionEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group member mute change.</summary>
public sealed class MilkyGroupMuteContext : MilkyCommonEventContext<MilkyGroupMuteEventData>
{
    /// <summary>Initializes a group member mute context.</summary>
    public MilkyGroupMuteContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupMuteEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group whole-mute change.</summary>
public sealed class MilkyGroupWholeMuteContext : MilkyCommonEventContext<MilkyGroupWholeMuteEventData>
{
    /// <summary>Initializes a group whole-mute context.</summary>
    public MilkyGroupWholeMuteContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupWholeMuteEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group nudge.</summary>
public sealed class MilkyGroupNudgeContext : MilkyCommonEventContext<MilkyGroupNudgeEventData>
{
    /// <summary>Initializes a group nudge context.</summary>
    public MilkyGroupNudgeContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupNudgeEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for a group file upload.</summary>
public sealed class MilkyGroupFileUploadContext : MilkyCommonEventContext<MilkyGroupFileUploadEventData>
{
    /// <summary>Initializes a group file upload context.</summary>
    public MilkyGroupFileUploadContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupFileUploadEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Context for an unknown future Milky event.</summary>
public sealed class MilkyUnknownEventContext : MilkyEventContext<MilkyUnknownEventData>
{
    /// <summary>Initializes an unknown event context.</summary>
    public MilkyUnknownEventContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyUnknownEventData data, CancellationToken cancellationToken = default)
        : base(session, milkyEvent, data, cancellationToken) { }
}

/// <summary>Creates the most specific context available for a Milky event.</summary>
public static class MilkyEventContextFactory
{
    /// <summary>Creates a strongly typed event context.</summary>
    /// <param name="session">The action session associated with the event source.</param>
    /// <param name="milkyEvent">The event envelope.</param>
    /// <param name="cancellationToken">The event dispatch cancellation token.</param>
    /// <returns>The most specific known context, or a base context for an unrecognized message scene.</returns>
    public static MilkyEventContext Create(IMilkyActionSession session, MilkyEvent milkyEvent, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(milkyEvent);

        return milkyEvent.Data switch
        {
            MilkyBotOfflineEventData data => new MilkyBotOfflineContext(session, milkyEvent, data, cancellationToken),
            MilkyMessageReceiveEventData data when data.Message.MessageScene == "group" => new MilkyGroupMessageContext(session, milkyEvent, data, cancellationToken),
            MilkyMessageReceiveEventData data when data.Message.MessageScene == "friend" => new MilkyPrivateMessageContext(session, milkyEvent, data, cancellationToken),
            MilkyMessageRecallEventData data when data.MessageScene == "group" => new MilkyGroupMessageRecallContext(session, milkyEvent, data, cancellationToken),
            MilkyMessageRecallEventData data when data.MessageScene == "friend" => new MilkyPrivateMessageRecallContext(session, milkyEvent, data, cancellationToken),
            MilkyPeerPinChangeEventData data => new MilkyPeerPinChangeContext(session, milkyEvent, data, cancellationToken),
            MilkyFriendRequestEventData data => new MilkyFriendRequestContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupJoinRequestEventData data => new MilkyGroupJoinRequestContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupInvitedJoinRequestEventData data => new MilkyGroupInvitedJoinRequestContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupInvitationEventData data => new MilkyGroupInvitationContext(session, milkyEvent, data, cancellationToken),
            MilkyFriendNudgeEventData data => new MilkyFriendNudgeContext(session, milkyEvent, data, cancellationToken),
            MilkyFriendFileUploadEventData data => new MilkyFriendFileUploadContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupAdminChangeEventData data => new MilkyGroupAdminChangeContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupEssenceMessageChangeEventData data => new MilkyGroupEssenceMessageChangeContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupMemberIncreaseEventData data => new MilkyGroupMemberIncreaseContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupMemberDecreaseEventData data => new MilkyGroupMemberDecreaseContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupNameChangeEventData data => new MilkyGroupNameChangeContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupMessageReactionEventData data => new MilkyGroupMessageReactionContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupMuteEventData data => new MilkyGroupMuteContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupWholeMuteEventData data => new MilkyGroupWholeMuteContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupNudgeEventData data => new MilkyGroupNudgeContext(session, milkyEvent, data, cancellationToken),
            MilkyGroupFileUploadEventData data => new MilkyGroupFileUploadContext(session, milkyEvent, data, cancellationToken),
            MilkyUnknownEventData data => new MilkyUnknownEventContext(session, milkyEvent, data, cancellationToken),
            _ => new MilkyEventContext(session, milkyEvent, cancellationToken),
        };
    }
}

/// <summary>Convenience helpers for constructing and converting Milky messages.</summary>
public static class MilkyMessageHelpers
{
    /// <summary>Concatenates all text segments in an incoming message.</summary>
    public static string Text(this MilkyIncomingMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);
        return string.Concat(message.Segments.OfType<MilkyIncomingTextSegment>().Select(segment => segment.Text));
    }

    /// <summary>Creates a text segment.</summary>
    public static MilkyTextSegment Text(string text) => new(text);

    /// <summary>Creates a user mention segment.</summary>
    public static MilkyMentionSegment At(long userId) => new(userId);

    /// <summary>Creates a reply segment.</summary>
    public static MilkyReplySegment Reply(long messageSeq) => new(messageSeq);

    /// <summary>Creates a base64 image segment.</summary>
    public static MilkyImageSegment ImageBase64(byte[] bytes) => new($"base64://{Convert.ToBase64String(bytes)}");

    /// <summary>Creates a base64 record segment.</summary>
    public static MilkyRecordSegment RecordBase64(byte[] bytes) => new($"base64://{Convert.ToBase64String(bytes)}");

    /// <summary>Creates a forwarded-message segment.</summary>
    public static MilkyForwardSegment Forward(IEnumerable<MilkyOutgoingForwardedMessage> messages) => new(messages);

    /// <summary>Creates a message from outgoing segments.</summary>
    public static MilkyMessage Message(params MilkyOutgoingSegment[] segments) => new(segments);

    /// <summary>Converts supported incoming segments into outgoing segments.</summary>
    public static IEnumerable<MilkyOutgoingSegment> ToOutgoingSegments(this IEnumerable<MilkyIncomingSegment> segments)
    {
        ArgumentNullException.ThrowIfNull(segments);
        foreach (MilkyIncomingSegment segment in segments)
        {
            switch (segment)
            {
                case MilkyIncomingTextSegment text:
                    yield return Text(text.Text);
                    break;
                case MilkyIncomingMentionSegment mention:
                    yield return At(mention.UserId);
                    break;
                case MilkyIncomingReplySegment reply:
                    yield return Reply(reply.MessageSeq);
                    break;
                case MilkyIncomingImageSegment image when !string.IsNullOrWhiteSpace(image.TempUrl):
                    yield return new MilkyImageSegment(image.TempUrl);
                    break;
                case MilkyIncomingRecordSegment record when !string.IsNullOrWhiteSpace(record.TempUrl):
                    yield return new MilkyRecordSegment(record.TempUrl);
                    break;
                case MilkyIncomingVideoSegment video when !string.IsNullOrWhiteSpace(video.TempUrl):
                    yield return new MilkyVideoSegment(video.TempUrl);
                    break;
            }
        }
    }
}
