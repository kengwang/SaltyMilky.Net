using System.Text.Json;
using SaltyMilky.Net;
using TUnit.Assertions;
using TUnit.Core;

namespace SaltyMilky.Net.Tests;

public sealed class MilkyEventContextTests
{
    [Test]
    public async Task Create_AllKnownEvents_ReturnsMostSpecificContext()
    {
        TestSession session = new();
        (MilkyEventData Data, Type ContextType)[] cases =
        [
            (new MilkyBotOfflineEventData("network"), typeof(MilkyBotOfflineContext)),
            (MessageData("group"), typeof(MilkyGroupMessageContext)),
            (MessageData("friend"), typeof(MilkyPrivateMessageContext)),
            (RecallData("group"), typeof(MilkyGroupMessageRecallContext)),
            (RecallData("friend"), typeof(MilkyPrivateMessageRecallContext)),
            (new MilkyPeerPinChangeEventData(), typeof(MilkyPeerPinChangeContext)),
            (new MilkyFriendRequestEventData(), typeof(MilkyFriendRequestContext)),
            (new MilkyGroupJoinRequestEventData(), typeof(MilkyGroupJoinRequestContext)),
            (new MilkyGroupInvitedJoinRequestEventData(), typeof(MilkyGroupInvitedJoinRequestContext)),
            (new MilkyGroupInvitationEventData(), typeof(MilkyGroupInvitationContext)),
            (new MilkyFriendNudgeEventData(), typeof(MilkyFriendNudgeContext)),
            (new MilkyFriendFileUploadEventData(), typeof(MilkyFriendFileUploadContext)),
            (new MilkyGroupAdminChangeEventData(), typeof(MilkyGroupAdminChangeContext)),
            (new MilkyGroupEssenceMessageChangeEventData(), typeof(MilkyGroupEssenceMessageChangeContext)),
            (new MilkyGroupMemberIncreaseEventData(), typeof(MilkyGroupMemberIncreaseContext)),
            (new MilkyGroupMemberDecreaseEventData(), typeof(MilkyGroupMemberDecreaseContext)),
            (new MilkyGroupNameChangeEventData(), typeof(MilkyGroupNameChangeContext)),
            (new MilkyGroupMessageReactionEventData(), typeof(MilkyGroupMessageReactionContext)),
            (new MilkyGroupMuteEventData(), typeof(MilkyGroupMuteContext)),
            (new MilkyGroupWholeMuteEventData(), typeof(MilkyGroupWholeMuteContext)),
            (new MilkyGroupNudgeEventData(), typeof(MilkyGroupNudgeContext)),
            (new MilkyGroupFileUploadEventData(), typeof(MilkyGroupFileUploadContext)),
            (new MilkyUnknownEventData("future_event", default), typeof(MilkyUnknownEventContext)),
        ];

        foreach ((MilkyEventData data, Type contextType) in cases)
        {
            MilkyEvent milkyEvent = new() { Data = data };

            MilkyEventContext context = MilkyEventContextFactory.Create(session, milkyEvent);

            await Assert.That(context.GetType()).IsEqualTo(contextType);
            await Assert.That(context.Session).IsSameReferenceAs(session);
            await Assert.That(context.Event).IsSameReferenceAs(milkyEvent);
        }
    }

    [Test]
    public async Task UsePlugin_GroupMessage_BindsOwningSessionAndCancellationToken()
    {
        TestSession session = new();
        CapturingMiddleware middleware = new();
        CapturingPlugin plugin = new();
        using CancellationTokenSource cancellation = new();
        session.UseMiddleware(middleware);
        session.UsePlugin(plugin);
        MilkyEvent milkyEvent = new()
        {
            SelfId = 10000,
            Data = new MilkyMessageReceiveEventData(new MilkyIncomingMessage
            {
                MessageScene = "group",
                PeerId = 12345,
                SenderId = 67890,
                Segments = [new MilkyIncomingTextSegment { Text = "ping" }],
            }),
        };

        await session.EventPipeline.ExecuteAsync(milkyEvent, cancellation.Token);
        await plugin.Context!.ReplyAsync(MilkyMessageHelpers.Text("pong"));

        await Assert.That(plugin.Context.Session).IsSameReferenceAs(session);
        await Assert.That(middleware.Context).IsTypeOf<MilkyGroupMessageContext>();
        await Assert.That(plugin.Context.CancellationToken).IsEqualTo(cancellation.Token);
        await Assert.That(plugin.Context.GroupId).IsEqualTo(12345);
        await Assert.That(plugin.Context.Text).IsEqualTo("ping");
        await Assert.That(session.Sender.LastApiName).IsEqualTo("send_group_message");
        await Assert.That(session.Sender.LastCancellationToken).IsEqualTo(cancellation.Token);
    }

    private static MilkyMessageReceiveEventData MessageData(string scene) =>
        new(new MilkyIncomingMessage { MessageScene = scene });

    private static MilkyMessageRecallEventData RecallData(string scene) => new() { MessageScene = scene };

    private sealed class CapturingPlugin : MilkyEventPlugin
    {
        public MilkyGroupMessageContext? Context { get; private set; }

        protected override Task OnGroupMessageReceivedAsync(MilkyGroupMessageContext context)
        {
            Context = context;
            return Task.CompletedTask;
        }
    }

    private sealed class CapturingMiddleware : MilkyEventMiddleware
    {
        public MilkyEventContext? Context { get; private set; }

        public override async Task ExecuteAsync(MilkyEventContext context, Func<Task> next)
        {
            Context = context;
            await next();
        }
    }

    private sealed class TestSession : IMilkyActionSession, IMilkyEventSession
    {
        public CapturingActionSender Sender { get; } = new();

        public MilkyActionSender ActionSender => Sender;

        public MilkyEventPipeline EventPipeline { get; } = new();
    }

    private sealed class CapturingActionSender : MilkyActionSender
    {
        public string? LastApiName { get; private set; }

        public CancellationToken LastCancellationToken { get; private set; }

        public override Task<MilkyActionResult?> InvokeActionAsync(MilkyAction action, CancellationToken cancellationToken = default)
        {
            Capture(action, cancellationToken);
            return Task.FromResult<MilkyActionResult?>(null);
        }

        public override Task<MilkyActionResult<TData>?> InvokeActionAsync<TData>(MilkyAction action, CancellationToken cancellationToken = default)
        {
            Capture(action, cancellationToken);
            return Task.FromResult<MilkyActionResult<TData>?>(null);
        }

        private void Capture(MilkyAction action, CancellationToken cancellationToken)
        {
            LastApiName = action.ApiName;
            LastCancellationToken = cancellationToken;
        }
    }
}
