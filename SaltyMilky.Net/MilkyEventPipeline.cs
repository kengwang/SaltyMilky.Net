namespace SaltyMilky.Net;

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
    private readonly List<Func<MilkyEvent, Func<Task>, Task>> _middlewares = [];

    /// <summary>
    /// Adds middleware to the pipeline.
    /// </summary>
    /// <param name="middleware">The event middleware.</param>
    /// <returns>The current pipeline.</returns>
    public MilkyEventPipeline Use(Func<MilkyEvent, Func<Task>, Task> middleware)
    {
        ArgumentNullException.ThrowIfNull(middleware);
        _middlewares.Add(middleware);
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
        _middlewares.Remove(middleware);
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

        return () => _middlewares[index](milkyEvent, ExecuteAt(milkyEvent, index + 1, cancellationToken));
    }
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

    private async Task DispatchCommonAsync(MilkyCommonEventData data, MilkyEvent milkyEvent)
    {
        OnCommonEvent(data, milkyEvent);
        await OnCommonEventAsync(data, milkyEvent).ConfigureAwait(false);

        switch (data.EventType)
        {
            case "peer_pin_change":
                OnPeerPinChanged(data, milkyEvent);
                await OnPeerPinChangedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "friend_request":
                OnFriendRequest(data, milkyEvent);
                await OnFriendRequestAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_join_request":
                OnGroupJoinRequest(data, milkyEvent);
                await OnGroupJoinRequestAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_invited_join_request":
                OnGroupInvitedJoinRequest(data, milkyEvent);
                await OnGroupInvitedJoinRequestAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_invitation":
                OnGroupInvitation(data, milkyEvent);
                await OnGroupInvitationAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "friend_nudge":
                OnFriendNudge(data, milkyEvent);
                await OnFriendNudgeAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "friend_file_upload":
                OnFriendFileUpload(data, milkyEvent);
                await OnFriendFileUploadAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_admin_change":
                OnGroupAdminChanged(data, milkyEvent);
                await OnGroupAdminChangedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_essence_message_change":
                OnGroupEssenceMessageChanged(data, milkyEvent);
                await OnGroupEssenceMessageChangedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_member_increase":
                OnGroupMemberIncreased(data, milkyEvent);
                await OnGroupMemberIncreasedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_member_decrease":
                OnGroupMemberDecreased(data, milkyEvent);
                await OnGroupMemberDecreasedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_name_change":
                OnGroupNameChanged(data, milkyEvent);
                await OnGroupNameChangedAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_message_reaction":
                OnGroupMessageReaction(data, milkyEvent);
                await OnGroupMessageReactionAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_mute":
                OnGroupMute(data, milkyEvent);
                await OnGroupMuteAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_whole_mute":
                OnGroupWholeMute(data, milkyEvent);
                await OnGroupWholeMuteAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_nudge":
                OnGroupNudge(data, milkyEvent);
                await OnGroupNudgeAsync(data, milkyEvent).ConfigureAwait(false);
                break;
            case "group_file_upload":
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
    /// <summary>
    /// Adds plugin middleware to the event pipeline.
    /// </summary>
    public static IMilkyEventSession UsePlugin(this IMilkyEventSession session, MilkyEventPlugin plugin)
    {
        ArgumentNullException.ThrowIfNull(session);
        ArgumentNullException.ThrowIfNull(plugin);
        session.EventPipeline.Use(plugin.Execute);
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
