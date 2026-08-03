namespace SaltyMilky.Net;

/// <summary>Represents middleware in the Milky event pipeline.</summary>
/// <param name="milkyEvent">The event to process.</param>
/// <param name="next">The next middleware in the pipeline.</param>
/// <param name="cancellationToken">The event dispatch cancellation token.</param>
/// <returns>An asynchronous task.</returns>
public delegate Task MilkyEventPipelineMiddleware(MilkyEvent milkyEvent, Func<Task> next, CancellationToken cancellationToken);

/// <summary>Base middleware for processing Milky event contexts.</summary>
public abstract class MilkyEventMiddleware
{
    /// <summary>Processes an event context.</summary>
    /// <param name="context">The strongly typed event context.</param>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <returns>An asynchronous task.</returns>
    public abstract Task ExecuteAsync(MilkyEventContext context, Func<Task> next);
}

/// <summary>
/// Represents a Milky session that can process incoming events.
/// </summary>
public interface IMilkyEventSession
{
    /// <summary>
    /// Gets the event processing pipeline.
    /// </summary>
    MilkyEventPipeline EventPipeline { get; }
}

/// <summary>
/// Middleware pipeline for Milky events.
/// </summary>
public sealed class MilkyEventPipeline
{
    private readonly List<MiddlewareRegistration> _middlewares = [];

    /// <summary>
    /// Adds middleware to the pipeline.
    /// </summary>
    /// <param name="middleware">The event middleware.</param>
    /// <returns>The current pipeline.</returns>
    public MilkyEventPipeline Use(Func<MilkyEvent, Func<Task>, Task> middleware)
    {
        ArgumentNullException.ThrowIfNull(middleware);
        _middlewares.Add(new(middleware, (milkyEvent, next, _) => middleware(milkyEvent, next)));
        return this;
    }

    /// <summary>Adds cancellation-aware middleware to the pipeline.</summary>
    /// <param name="middleware">The event middleware.</param>
    /// <returns>The current pipeline.</returns>
    public MilkyEventPipeline Use(MilkyEventPipelineMiddleware middleware)
    {
        ArgumentNullException.ThrowIfNull(middleware);
        _middlewares.Add(new(middleware, middleware));
        return this;
    }

    /// <summary>
    /// Removes middleware from the pipeline.
    /// </summary>
    /// <param name="middleware">The event middleware.</param>
    /// <returns>The current pipeline.</returns>
    public MilkyEventPipeline Remove(Func<MilkyEvent, Func<Task>, Task> middleware)
    {
        ArgumentNullException.ThrowIfNull(middleware);
        _middlewares.RemoveAll(registration => Equals(registration.Key, middleware));
        return this;
    }

    /// <summary>Removes cancellation-aware middleware from the pipeline.</summary>
    /// <param name="middleware">The event middleware.</param>
    /// <returns>The current pipeline.</returns>
    public MilkyEventPipeline Remove(MilkyEventPipelineMiddleware middleware)
    {
        ArgumentNullException.ThrowIfNull(middleware);
        _middlewares.RemoveAll(registration => Equals(registration.Key, middleware));
        return this;
    }

    /// <summary>
    /// Executes the pipeline for an event.
    /// </summary>
    /// <param name="milkyEvent">The event to process.</param>
    /// <returns>An asynchronous task.</returns>
    public Task ExecuteAsync(MilkyEvent milkyEvent) => ExecuteAsync(milkyEvent, CancellationToken.None);

    /// <summary>
    /// Executes the pipeline for an event.
    /// </summary>
    /// <param name="milkyEvent">The event to process.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>An asynchronous task.</returns>
    public Task ExecuteAsync(MilkyEvent milkyEvent, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(milkyEvent);
        return ExecuteAt(milkyEvent, 0, cancellationToken).Invoke();
    }

    private static Task EmptyAsync() => Task.CompletedTask;

    private Func<Task> ExecuteAt(MilkyEvent milkyEvent, int index, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested || index >= _middlewares.Count)
        {
            return EmptyAsync;
        }

        return () => _middlewares[index].Middleware(milkyEvent, ExecuteAt(milkyEvent, index + 1, cancellationToken), cancellationToken);
    }

    private sealed record MiddlewareRegistration(Delegate Key, MilkyEventPipelineMiddleware Middleware);
}

/// <summary>
/// Base plugin for handling Milky events.
/// </summary>
public class MilkyEventPlugin
{
    /// <summary>
    /// Executes this plugin as pipeline middleware.
    /// </summary>
    /// <param name="milkyEvent">The event to process.</param>
    /// <param name="next">The next middleware.</param>
    /// <returns>An asynchronous task.</returns>
    public async Task Execute(MilkyEvent milkyEvent, Func<Task> next)
    {
        ArgumentNullException.ThrowIfNull(milkyEvent);
        ArgumentNullException.ThrowIfNull(next);

        OnEvent(milkyEvent);
        await OnEventAsync(milkyEvent).ConfigureAwait(false);

        switch (milkyEvent.Data)
        {
            case MilkyBotOfflineEventData data:
                OnBotOffline(data, milkyEvent);
                await OnBotOfflineAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyMessageReceiveEventData data:
                OnMessageReceived(data, milkyEvent);
                await OnMessageReceivedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyMessageRecallEventData data:
                OnMessageRecalled(data, milkyEvent);
                await OnMessageRecalledAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyCommonEventData data:
                await DispatchCommonAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyUnknownEventData data:
                OnUnknownEvent(data, milkyEvent);
                await OnUnknownEventAsync(data, milkyEvent).ConfigureAwait(false);
                break;
        }

        await next().ConfigureAwait(false);
    }

    /// <summary>Executes this plugin with the action session that owns the event source.</summary>
    /// <param name="session">The action session associated with the event source.</param>
    /// <param name="milkyEvent">The event to process.</param>
    /// <param name="next">The next middleware.</param>
    /// <param name="cancellationToken">The event dispatch cancellation token.</param>
    /// <returns>An asynchronous task.</returns>
    public async Task Execute(
        IMilkyActionSession session,
        MilkyEvent milkyEvent,
        Func<Task> next,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(milkyEvent);
        ArgumentNullException.ThrowIfNull(next);

        await Execute(milkyEvent, static () => Task.CompletedTask).ConfigureAwait(false);

        MilkyEventContext context = MilkyEventContextFactory.Create(session, milkyEvent, cancellationToken);
        OnEvent(context);
        await OnEventAsync(context).ConfigureAwait(false);
        await DispatchContextAsync(session, milkyEvent, cancellationToken).ConfigureAwait(false);

        await next().ConfigureAwait(false);
    }

    /// <summary>Called for every event with its owning action session.</summary>
    protected virtual void OnEvent(MilkyEventContext context) { }
    /// <summary>Called asynchronously for every event with its owning action session.</summary>
    protected virtual Task OnEventAsync(MilkyEventContext context) => Task.CompletedTask;
    /// <summary>Called for bot offline events.</summary>
    protected virtual void OnBotOffline(MilkyBotOfflineContext context) { }
    /// <summary>Called asynchronously for bot offline events.</summary>
    protected virtual Task OnBotOfflineAsync(MilkyBotOfflineContext context) => Task.CompletedTask;
    /// <summary>Called for incoming group messages.</summary>
    protected virtual void OnGroupMessageReceived(MilkyGroupMessageContext context) { }
    /// <summary>Called asynchronously for incoming group messages.</summary>
    protected virtual Task OnGroupMessageReceivedAsync(MilkyGroupMessageContext context) => Task.CompletedTask;
    /// <summary>Called for incoming private messages.</summary>
    protected virtual void OnPrivateMessageReceived(MilkyPrivateMessageContext context) { }
    /// <summary>Called asynchronously for incoming private messages.</summary>
    protected virtual Task OnPrivateMessageReceivedAsync(MilkyPrivateMessageContext context) => Task.CompletedTask;
    /// <summary>Called for group join and invited-join requests.</summary>
    protected virtual void OnGroupRequest(MilkyGroupRequestContext context) { }
    /// <summary>Called asynchronously for group join and invited-join requests.</summary>
    protected virtual Task OnGroupRequestAsync(MilkyGroupRequestContext context) => Task.CompletedTask;
    /// <summary>Called for recalled group messages.</summary>
    protected virtual void OnGroupMessageRecalled(MilkyGroupMessageRecallContext context) { }
    /// <summary>Called asynchronously for recalled group messages.</summary>
    protected virtual Task OnGroupMessageRecalledAsync(MilkyGroupMessageRecallContext context) => Task.CompletedTask;
    /// <summary>Called for recalled private messages.</summary>
    protected virtual void OnPrivateMessageRecalled(MilkyPrivateMessageRecallContext context) { }
    /// <summary>Called asynchronously for recalled private messages.</summary>
    protected virtual Task OnPrivateMessageRecalledAsync(MilkyPrivateMessageRecallContext context) => Task.CompletedTask;
    /// <summary>Called for peer pin changes.</summary>
    protected virtual void OnPeerPinChanged(MilkyPeerPinChangeContext context) { }
    /// <summary>Called asynchronously for peer pin changes.</summary>
    protected virtual Task OnPeerPinChangedAsync(MilkyPeerPinChangeContext context) => Task.CompletedTask;
    /// <summary>Called for friend requests.</summary>
    protected virtual void OnFriendRequest(MilkyFriendRequestContext context) { }
    /// <summary>Called asynchronously for friend requests.</summary>
    protected virtual Task OnFriendRequestAsync(MilkyFriendRequestContext context) => Task.CompletedTask;
    /// <summary>Called for group join requests.</summary>
    protected virtual void OnGroupJoinRequest(MilkyGroupJoinRequestContext context) { }
    /// <summary>Called asynchronously for group join requests.</summary>
    protected virtual Task OnGroupJoinRequestAsync(MilkyGroupJoinRequestContext context) => Task.CompletedTask;
    /// <summary>Called for invited group join requests.</summary>
    protected virtual void OnGroupInvitedJoinRequest(MilkyGroupInvitedJoinRequestContext context) { }
    /// <summary>Called asynchronously for invited group join requests.</summary>
    protected virtual Task OnGroupInvitedJoinRequestAsync(MilkyGroupInvitedJoinRequestContext context) => Task.CompletedTask;
    /// <summary>Called for group invitations.</summary>
    protected virtual void OnGroupInvitation(MilkyGroupInvitationContext context) { }
    /// <summary>Called asynchronously for group invitations.</summary>
    protected virtual Task OnGroupInvitationAsync(MilkyGroupInvitationContext context) => Task.CompletedTask;
    /// <summary>Called for friend nudges.</summary>
    protected virtual void OnFriendNudge(MilkyFriendNudgeContext context) { }
    /// <summary>Called asynchronously for friend nudges.</summary>
    protected virtual Task OnFriendNudgeAsync(MilkyFriendNudgeContext context) => Task.CompletedTask;
    /// <summary>Called for friend file uploads.</summary>
    protected virtual void OnFriendFileUpload(MilkyFriendFileUploadContext context) { }
    /// <summary>Called asynchronously for friend file uploads.</summary>
    protected virtual Task OnFriendFileUploadAsync(MilkyFriendFileUploadContext context) => Task.CompletedTask;
    /// <summary>Called for group administrator changes.</summary>
    protected virtual void OnGroupAdminChanged(MilkyGroupAdminChangeContext context) { }
    /// <summary>Called asynchronously for group administrator changes.</summary>
    protected virtual Task OnGroupAdminChangedAsync(MilkyGroupAdminChangeContext context) => Task.CompletedTask;
    /// <summary>Called for group essence message changes.</summary>
    protected virtual void OnGroupEssenceMessageChanged(MilkyGroupEssenceMessageChangeContext context) { }
    /// <summary>Called asynchronously for group essence message changes.</summary>
    protected virtual Task OnGroupEssenceMessageChangedAsync(MilkyGroupEssenceMessageChangeContext context) => Task.CompletedTask;
    /// <summary>Called for group member increases.</summary>
    protected virtual void OnGroupMemberIncreased(MilkyGroupMemberIncreaseContext context) { }
    /// <summary>Called asynchronously for group member increases.</summary>
    protected virtual Task OnGroupMemberIncreasedAsync(MilkyGroupMemberIncreaseContext context) => Task.CompletedTask;
    /// <summary>Called for group member decreases.</summary>
    protected virtual void OnGroupMemberDecreased(MilkyGroupMemberDecreaseContext context) { }
    /// <summary>Called asynchronously for group member decreases.</summary>
    protected virtual Task OnGroupMemberDecreasedAsync(MilkyGroupMemberDecreaseContext context) => Task.CompletedTask;
    /// <summary>Called for group name changes.</summary>
    protected virtual void OnGroupNameChanged(MilkyGroupNameChangeContext context) { }
    /// <summary>Called asynchronously for group name changes.</summary>
    protected virtual Task OnGroupNameChangedAsync(MilkyGroupNameChangeContext context) => Task.CompletedTask;
    /// <summary>Called for group message reactions.</summary>
    protected virtual void OnGroupMessageReaction(MilkyGroupMessageReactionContext context) { }
    /// <summary>Called asynchronously for group message reactions.</summary>
    protected virtual Task OnGroupMessageReactionAsync(MilkyGroupMessageReactionContext context) => Task.CompletedTask;
    /// <summary>Called for group member mute changes.</summary>
    protected virtual void OnGroupMute(MilkyGroupMuteContext context) { }
    /// <summary>Called asynchronously for group member mute changes.</summary>
    protected virtual Task OnGroupMuteAsync(MilkyGroupMuteContext context) => Task.CompletedTask;
    /// <summary>Called for group whole-mute changes.</summary>
    protected virtual void OnGroupWholeMute(MilkyGroupWholeMuteContext context) { }
    /// <summary>Called asynchronously for group whole-mute changes.</summary>
    protected virtual Task OnGroupWholeMuteAsync(MilkyGroupWholeMuteContext context) => Task.CompletedTask;
    /// <summary>Called for group nudges.</summary>
    protected virtual void OnGroupNudge(MilkyGroupNudgeContext context) { }
    /// <summary>Called asynchronously for group nudges.</summary>
    protected virtual Task OnGroupNudgeAsync(MilkyGroupNudgeContext context) => Task.CompletedTask;
    /// <summary>Called for group file uploads.</summary>
    protected virtual void OnGroupFileUpload(MilkyGroupFileUploadContext context) { }
    /// <summary>Called asynchronously for group file uploads.</summary>
    protected virtual Task OnGroupFileUploadAsync(MilkyGroupFileUploadContext context) => Task.CompletedTask;
    /// <summary>Called for unknown future events.</summary>
    protected virtual void OnUnknownEvent(MilkyUnknownEventContext context) { }
    /// <summary>Called asynchronously for unknown future events.</summary>
    protected virtual Task OnUnknownEventAsync(MilkyUnknownEventContext context) => Task.CompletedTask;

    /// <summary>Called for every event before type-specific callbacks.</summary>
    public virtual void OnEvent(MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for every event before type-specific callbacks.</summary>
    public virtual Task OnEventAsync(MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called when the bot goes offline.</summary>
    public virtual void OnBotOffline(MilkyBotOfflineEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously when the bot goes offline.</summary>
    public virtual Task OnBotOfflineAsync(MilkyBotOfflineEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called when a message is received.</summary>
    public virtual void OnMessageReceived(MilkyMessageReceiveEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously when a message is received.</summary>
    public virtual Task OnMessageReceivedAsync(MilkyMessageReceiveEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called when a message is recalled.</summary>
    public virtual void OnMessageRecalled(MilkyMessageRecallEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously when a message is recalled.</summary>
    public virtual Task OnMessageRecalledAsync(MilkyMessageRecallEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for scalar event variants represented by <see cref="MilkyCommonEventData" />.</summary>
    public virtual void OnCommonEvent(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for scalar event variants represented by <see cref="MilkyCommonEventData" />.</summary>
    public virtual Task OnCommonEventAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for unknown event variants.</summary>
    public virtual void OnUnknownEvent(MilkyUnknownEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for unknown event variants.</summary>
    public virtual Task OnUnknownEventAsync(MilkyUnknownEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;

    /// <summary>Called for peer pin changes.</summary>
    public virtual void OnPeerPinChanged(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for peer pin changes.</summary>
    public virtual Task OnPeerPinChangedAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for friend requests.</summary>
    public virtual void OnFriendRequest(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for friend requests.</summary>
    public virtual Task OnFriendRequestAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group join requests.</summary>
    public virtual void OnGroupJoinRequest(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group join requests.</summary>
    public virtual Task OnGroupJoinRequestAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group invited-join requests.</summary>
    public virtual void OnGroupInvitedJoinRequest(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group invited-join requests.</summary>
    public virtual Task OnGroupInvitedJoinRequestAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group invitations.</summary>
    public virtual void OnGroupInvitation(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group invitations.</summary>
    public virtual Task OnGroupInvitationAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for friend nudges.</summary>
    public virtual void OnFriendNudge(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for friend nudges.</summary>
    public virtual Task OnFriendNudgeAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for friend file uploads.</summary>
    public virtual void OnFriendFileUpload(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for friend file uploads.</summary>
    public virtual Task OnFriendFileUploadAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group admin changes.</summary>
    public virtual void OnGroupAdminChanged(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group admin changes.</summary>
    public virtual Task OnGroupAdminChangedAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group essence message changes.</summary>
    public virtual void OnGroupEssenceMessageChanged(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group essence message changes.</summary>
    public virtual Task OnGroupEssenceMessageChangedAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group member increases.</summary>
    public virtual void OnGroupMemberIncreased(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group member increases.</summary>
    public virtual Task OnGroupMemberIncreasedAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group member decreases.</summary>
    public virtual void OnGroupMemberDecreased(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group member decreases.</summary>
    public virtual Task OnGroupMemberDecreasedAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group name changes.</summary>
    public virtual void OnGroupNameChanged(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group name changes.</summary>
    public virtual Task OnGroupNameChangedAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group message reactions.</summary>
    public virtual void OnGroupMessageReaction(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group message reactions.</summary>
    public virtual Task OnGroupMessageReactionAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group member mutes.</summary>
    public virtual void OnGroupMute(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group member mutes.</summary>
    public virtual Task OnGroupMuteAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group whole mute changes.</summary>
    public virtual void OnGroupWholeMute(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group whole mute changes.</summary>
    public virtual Task OnGroupWholeMuteAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group nudges.</summary>
    public virtual void OnGroupNudge(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group nudges.</summary>
    public virtual Task OnGroupNudgeAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group file uploads.</summary>
    public virtual void OnGroupFileUpload(MilkyCommonEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called asynchronously for group file uploads.</summary>
    public virtual Task OnGroupFileUploadAsync(MilkyCommonEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;

    private async Task DispatchContextAsync(IMilkyActionSession session, MilkyEvent milkyEvent, CancellationToken cancellationToken)
    {
        switch (milkyEvent.Data)
        {
            case MilkyBotOfflineEventData data:
            {
                MilkyBotOfflineContext context = new(session, milkyEvent, data, cancellationToken);
                OnBotOffline(context);
                await OnBotOfflineAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyMessageReceiveEventData data when data.Message.MessageScene == MilkyConstant.MessageScene.Group:
            {
                MilkyGroupMessageContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupMessageReceived(context);
                await OnGroupMessageReceivedAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyMessageReceiveEventData data when data.Message.MessageScene == MilkyConstant.MessageScene.Friend:
            {
                MilkyPrivateMessageContext context = new(session, milkyEvent, data, cancellationToken);
                OnPrivateMessageReceived(context);
                await OnPrivateMessageReceivedAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyMessageRecallEventData data when data.MessageScene == MilkyConstant.MessageScene.Group:
            {
                MilkyGroupMessageRecallContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupMessageRecalled(context);
                await OnGroupMessageRecalledAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyMessageRecallEventData data when data.MessageScene == MilkyConstant.MessageScene.Friend:
            {
                MilkyPrivateMessageRecallContext context = new(session, milkyEvent, data, cancellationToken);
                OnPrivateMessageRecalled(context);
                await OnPrivateMessageRecalledAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyPeerPinChangeEventData data:
            {
                MilkyPeerPinChangeContext context = new(session, milkyEvent, data, cancellationToken);
                OnPeerPinChanged(context);
                await OnPeerPinChangedAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyFriendRequestEventData data:
            {
                MilkyFriendRequestContext context = new(session, milkyEvent, data, cancellationToken);
                OnFriendRequest(context);
                await OnFriendRequestAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupJoinRequestEventData data:
            {
                MilkyGroupJoinRequestContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupRequest(context);
                await OnGroupRequestAsync(context).ConfigureAwait(false);
                OnGroupJoinRequest(context);
                await OnGroupJoinRequestAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupInvitedJoinRequestEventData data:
            {
                MilkyGroupInvitedJoinRequestContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupRequest(context);
                await OnGroupRequestAsync(context).ConfigureAwait(false);
                OnGroupInvitedJoinRequest(context);
                await OnGroupInvitedJoinRequestAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupInvitationEventData data:
            {
                MilkyGroupInvitationContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupInvitation(context);
                await OnGroupInvitationAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyFriendNudgeEventData data:
            {
                MilkyFriendNudgeContext context = new(session, milkyEvent, data, cancellationToken);
                OnFriendNudge(context);
                await OnFriendNudgeAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyFriendFileUploadEventData data:
            {
                MilkyFriendFileUploadContext context = new(session, milkyEvent, data, cancellationToken);
                OnFriendFileUpload(context);
                await OnFriendFileUploadAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupAdminChangeEventData data:
            {
                MilkyGroupAdminChangeContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupAdminChanged(context);
                await OnGroupAdminChangedAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupEssenceMessageChangeEventData data:
            {
                MilkyGroupEssenceMessageChangeContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupEssenceMessageChanged(context);
                await OnGroupEssenceMessageChangedAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupMemberIncreaseEventData data:
            {
                MilkyGroupMemberIncreaseContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupMemberIncreased(context);
                await OnGroupMemberIncreasedAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupMemberDecreaseEventData data:
            {
                MilkyGroupMemberDecreaseContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupMemberDecreased(context);
                await OnGroupMemberDecreasedAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupNameChangeEventData data:
            {
                MilkyGroupNameChangeContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupNameChanged(context);
                await OnGroupNameChangedAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupMessageReactionEventData data:
            {
                MilkyGroupMessageReactionContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupMessageReaction(context);
                await OnGroupMessageReactionAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupMuteEventData data:
            {
                MilkyGroupMuteContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupMute(context);
                await OnGroupMuteAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupWholeMuteEventData data:
            {
                MilkyGroupWholeMuteContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupWholeMute(context);
                await OnGroupWholeMuteAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupNudgeEventData data:
            {
                MilkyGroupNudgeContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupNudge(context);
                await OnGroupNudgeAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyGroupFileUploadEventData data:
            {
                MilkyGroupFileUploadContext context = new(session, milkyEvent, data, cancellationToken);
                OnGroupFileUpload(context);
                await OnGroupFileUploadAsync(context).ConfigureAwait(false);
                break;
            }
            case MilkyUnknownEventData data:
            {
                MilkyUnknownEventContext context = new(session, milkyEvent, data, cancellationToken);
                OnUnknownEvent(context);
                await OnUnknownEventAsync(context).ConfigureAwait(false);
                break;
            }
        }
    }

    private async Task DispatchCommonAsync(MilkyCommonEventData data, MilkyEvent milkyEvent)
    {
        OnCommonEvent(data, milkyEvent);
        await OnCommonEventAsync(data, milkyEvent).ConfigureAwait(false);

        switch (data.EventType)
        {
            case MilkyConstant.EventType.PeerPinChange:
                OnPeerPinChanged(data, milkyEvent);
                await OnPeerPinChangedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.FriendRequest:
                OnFriendRequest(data, milkyEvent);
                await OnFriendRequestAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupJoinRequest:
                OnGroupJoinRequest(data, milkyEvent);
                await OnGroupJoinRequestAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupInvitedJoinRequest:
                OnGroupInvitedJoinRequest(data, milkyEvent);
                await OnGroupInvitedJoinRequestAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupInvitation:
                OnGroupInvitation(data, milkyEvent);
                await OnGroupInvitationAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.FriendNudge:
                OnFriendNudge(data, milkyEvent);
                await OnFriendNudgeAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.FriendFileUpload:
                OnFriendFileUpload(data, milkyEvent);
                await OnFriendFileUploadAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupAdminChange:
                OnGroupAdminChanged(data, milkyEvent);
                await OnGroupAdminChangedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupEssenceMessageChange:
                OnGroupEssenceMessageChanged(data, milkyEvent);
                await OnGroupEssenceMessageChangedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupMemberIncrease:
                OnGroupMemberIncreased(data, milkyEvent);
                await OnGroupMemberIncreasedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupMemberDecrease:
                OnGroupMemberDecreased(data, milkyEvent);
                await OnGroupMemberDecreasedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupNameChange:
                OnGroupNameChanged(data, milkyEvent);
                await OnGroupNameChangedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupMessageReaction:
                OnGroupMessageReaction(data, milkyEvent);
                await OnGroupMessageReactionAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupMute:
                OnGroupMute(data, milkyEvent);
                await OnGroupMuteAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupWholeMute:
                OnGroupWholeMute(data, milkyEvent);
                await OnGroupWholeMuteAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupNudge:
                OnGroupNudge(data, milkyEvent);
                await OnGroupNudgeAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case MilkyConstant.EventType.GroupFileUpload:
                OnGroupFileUpload(data, milkyEvent);
                await OnGroupFileUploadAsync(data, milkyEvent).ConfigureAwait(false);
                break;
        }
    }
}

/// <summary>
/// Extension methods for Milky event sessions.
/// </summary>
public static class MilkyEventSessionExtensions
{
    /// <summary>Adds context middleware to the event pipeline.</summary>
    /// <param name="session">The event session, which must also support Milky actions.</param>
    /// <param name="middleware">The context middleware.</param>
    /// <returns>The current session.</returns>
    /// <exception cref="InvalidOperationException">The event session does not implement <see cref="IMilkyActionSession" />.</exception>
    public static IMilkyEventSession UseMiddleware(this IMilkyEventSession session, MilkyEventMiddleware middleware)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(middleware);
        if (session is not IMilkyActionSession actionSession)
        {
            throw new InvalidOperationException("Context middleware requires an event session that also implements IMilkyActionSession.");
        }

        session.EventPipeline.Use((milkyEvent, next, cancellationToken) =>
            middleware.ExecuteAsync(MilkyEventContextFactory.Create(actionSession, milkyEvent, cancellationToken), next));
        return session;
    }

    /// <summary>
    /// Adds plugin middleware to the event pipeline.
    /// </summary>
    public static IMilkyEventSession UsePlugin(this IMilkyEventSession session, MilkyEventPlugin plugin)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(plugin);
        if (session is IMilkyActionSession actionSession)
        {
            session.EventPipeline.Use((milkyEvent, next, cancellationToken) =>
                plugin.Execute(actionSession, milkyEvent, next, cancellationToken));
        }
        else
        {
            session.EventPipeline.Use(plugin.Execute);
        }

        return session;
    }

    /// <summary>
    /// Adds middleware for all events.
    /// </summary>
    public static IMilkyEventSession UseEvent(this IMilkyEventSession session, Func<MilkyEvent, Func<Task>, Task> middleware)
    {
        ArgumentNullException.ThrowIfNull(session);
        session.EventPipeline.Use(middleware);
        return session;
    }

    /// <summary>
    /// Adds asynchronous middleware for all events.
    /// </summary>
    public static IMilkyEventSession UseEvent(this IMilkyEventSession session, Func<MilkyEvent, Task> middleware)
    {
        ArgumentNullException.ThrowIfNull(middleware);
        return session.UseEvent(async (milkyEvent, next) =>
        {
            await middleware(milkyEvent).ConfigureAwait(false);
            await next().ConfigureAwait(false);
        });
    }

    /// <summary>
    /// Adds synchronous middleware for all events.
    /// </summary>
    public static IMilkyEventSession UseEvent(this IMilkyEventSession session, Action<MilkyEvent> middleware)
    {
        ArgumentNullException.ThrowIfNull(middleware);
        return session.UseEvent(milkyEvent =>
        {
            middleware(milkyEvent);
            return Task.CompletedTask;
        });
    }

    /// <summary>Adds middleware for message receive events.</summary>
    public static IMilkyEventSession UseMessageReceived(this IMilkyEventSession session, Func<MilkyMessageReceiveEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds asynchronous middleware for message receive events.</summary>
    public static IMilkyEventSession UseMessageReceived(this IMilkyEventSession session, Func<MilkyMessageReceiveEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds synchronous middleware for message receive events.</summary>
    public static IMilkyEventSession UseMessageReceived(this IMilkyEventSession session, Action<MilkyMessageReceiveEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Adds middleware for message recall events.</summary>
    public static IMilkyEventSession UseMessageRecalled(this IMilkyEventSession session, Func<MilkyMessageRecallEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds asynchronous middleware for message recall events.</summary>
    public static IMilkyEventSession UseMessageRecalled(this IMilkyEventSession session, Func<MilkyMessageRecallEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds synchronous middleware for message recall events.</summary>
    public static IMilkyEventSession UseMessageRecalled(this IMilkyEventSession session, Action<MilkyMessageRecallEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Adds middleware for bot offline events.</summary>
    public static IMilkyEventSession UseBotOffline(this IMilkyEventSession session, Func<MilkyBotOfflineEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds asynchronous middleware for bot offline events.</summary>
    public static IMilkyEventSession UseBotOffline(this IMilkyEventSession session, Func<MilkyBotOfflineEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds synchronous middleware for bot offline events.</summary>
    public static IMilkyEventSession UseBotOffline(this IMilkyEventSession session, Action<MilkyBotOfflineEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Adds middleware for scalar event variants.</summary>
    public static IMilkyEventSession UseCommonEvent(this IMilkyEventSession session, Func<MilkyCommonEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds asynchronous middleware for scalar event variants.</summary>
    public static IMilkyEventSession UseCommonEvent(this IMilkyEventSession session, Func<MilkyCommonEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds synchronous middleware for scalar event variants.</summary>
    public static IMilkyEventSession UseCommonEvent(this IMilkyEventSession session, Action<MilkyCommonEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Adds middleware for unknown events.</summary>
    public static IMilkyEventSession UseUnknownEvent(this IMilkyEventSession session, Func<MilkyUnknownEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds asynchronous middleware for unknown events.</summary>
    public static IMilkyEventSession UseUnknownEvent(this IMilkyEventSession session, Func<MilkyUnknownEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Adds synchronous middleware for unknown events.</summary>
    public static IMilkyEventSession UseUnknownEvent(this IMilkyEventSession session, Action<MilkyUnknownEventData, MilkyEvent> middleware) => UseData(session, middleware);

    private static IMilkyEventSession UseData<TData>(IMilkyEventSession session, Func<TData, MilkyEvent, Func<Task>, Task> middleware)
        where TData : MilkyEventData
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(middleware);
        session.EventPipeline.Use(async (milkyEvent, next) =>
        {
            if (milkyEvent.Data is TData data)
            {
                await middleware(data, milkyEvent, next).ConfigureAwait(false);
            }
            else
            {
                await next().ConfigureAwait(false);
            }
        });

        return session;
    }

    private static IMilkyEventSession UseData<TData>(IMilkyEventSession session, Func<TData, MilkyEvent, Task> middleware)
        where TData : MilkyEventData
    {
        ArgumentNullException.ThrowIfNull(middleware);
        return UseData<TData>(session, async (data, milkyEvent, next) =>
        {
            await middleware(data, milkyEvent).ConfigureAwait(false);
            await next().ConfigureAwait(false);
        });
    }

    private static IMilkyEventSession UseData<TData>(IMilkyEventSession session, Action<TData, MilkyEvent> middleware)
        where TData : MilkyEventData
    {
        ArgumentNullException.ThrowIfNull(middleware);
        return UseData<TData>(session, (data, milkyEvent) =>
        {
            middleware(data, milkyEvent);
            return Task.CompletedTask;
        });
    }
}
