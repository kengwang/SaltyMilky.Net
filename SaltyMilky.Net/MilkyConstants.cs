namespace SaltyMilky.Net;

/// <summary>Centralized Milky protocol constants.</summary>
public static class MilkyConstant
{
    /// <summary>Milky event type values.</summary>
    public static class EventType
    {
        /// <summary>The bot offline event.</summary>
        public const string BotOffline = "bot_offline";
        /// <summary>The message receive event.</summary>
        public const string MessageReceive = "message_receive";
        /// <summary>The message recall event.</summary>
        public const string MessageRecall = "message_recall";
        /// <summary>The peer pin change event.</summary>
        public const string PeerPinChange = "peer_pin_change";
        /// <summary>The friend request event.</summary>
        public const string FriendRequest = "friend_request";
        /// <summary>The group join request event.</summary>
        public const string GroupJoinRequest = "group_join_request";
        /// <summary>The invited group join request event.</summary>
        public const string GroupInvitedJoinRequest = "group_invited_join_request";
        /// <summary>The group invitation event.</summary>
        public const string GroupInvitation = "group_invitation";
        /// <summary>The friend nudge event.</summary>
        public const string FriendNudge = "friend_nudge";
        /// <summary>The friend file upload event.</summary>
        public const string FriendFileUpload = "friend_file_upload";
        /// <summary>The group administrator change event.</summary>
        public const string GroupAdminChange = "group_admin_change";
        /// <summary>The group essence message change event.</summary>
        public const string GroupEssenceMessageChange = "group_essence_message_change";
        /// <summary>The group member increase event.</summary>
        public const string GroupMemberIncrease = "group_member_increase";
        /// <summary>The group member decrease event.</summary>
        public const string GroupMemberDecrease = "group_member_decrease";
        /// <summary>The group name change event.</summary>
        public const string GroupNameChange = "group_name_change";
        /// <summary>The group message reaction event.</summary>
        public const string GroupMessageReaction = "group_message_reaction";
        /// <summary>The group mute event.</summary>
        public const string GroupMute = "group_mute";
        /// <summary>The group whole mute event.</summary>
        public const string GroupWholeMute = "group_whole_mute";
        /// <summary>The group nudge event.</summary>
        public const string GroupNudge = "group_nudge";
        /// <summary>The group file upload event.</summary>
        public const string GroupFileUpload = "group_file_upload";
    }

    /// <summary>Milky group request notification type values.</summary>
    public static class GroupRequestNotificationType
    {
        /// <summary>A user requests to join a group.</summary>
        public const string JoinRequest = "join_request";
        /// <summary>A group member invites another user to join a group.</summary>
        public const string InvitedJoinRequest = "invited_join_request";
    }

    /// <summary>Milky group notification type values other than group requests.</summary>
    public static class GroupNotificationType
    {
        /// <summary>A group administrator change notification.</summary>
        public const string AdminChange = "admin_change";
        /// <summary>A group member kick notification.</summary>
        public const string Kick = "kick";
        /// <summary>A group member quit notification.</summary>
        public const string Quit = "quit";
    }

    /// <summary>Milky message scene values.</summary>
    public static class MessageScene
    {
        /// <summary>A friend conversation.</summary>
        public const string Friend = "friend";
        /// <summary>A group conversation.</summary>
        public const string Group = "group";
        /// <summary>A temporary conversation.</summary>
        public const string Temp = "temp";
    }

    /// <summary>Milky message segment type values.</summary>
    public static class MessageSegmentType
    {
        /// <summary>A text segment.</summary>
        public const string Text = "text";
        /// <summary>A mention segment.</summary>
        public const string Mention = "mention";
        /// <summary>A mention-all segment.</summary>
        public const string MentionAll = "mention_all";
        /// <summary>A face segment.</summary>
        public const string Face = "face";
        /// <summary>A reply segment.</summary>
        public const string Reply = "reply";
        /// <summary>An image segment.</summary>
        public const string Image = "image";
        /// <summary>A record segment.</summary>
        public const string Record = "record";
        /// <summary>A video segment.</summary>
        public const string Video = "video";
        /// <summary>A forward segment.</summary>
        public const string Forward = "forward";
        /// <summary>A light app segment.</summary>
        public const string LightApp = "light_app";
        /// <summary>A markdown segment.</summary>
        public const string Markdown = "markdown";
        /// <summary>A file segment.</summary>
        public const string File = "file";
        /// <summary>A market face segment.</summary>
        public const string MarketFace = "market_face";
        /// <summary>An XML segment.</summary>
        public const string Xml = "xml";
    }

    /// <summary>Milky image subtype values.</summary>
    public static class ImageSubType
    {
        /// <summary>A regular image.</summary>
        public const string Normal = "normal";
        /// <summary>A sticker image.</summary>
        public const string Sticker = "sticker";
    }

    /// <summary>Milky request state values.</summary>
    public static class RequestState
    {
        /// <summary>A pending request.</summary>
        public const string Pending = "pending";
        /// <summary>An accepted request.</summary>
        public const string Accepted = "accepted";
        /// <summary>A rejected request.</summary>
        public const string Rejected = "rejected";
        /// <summary>An ignored request.</summary>
        public const string Ignored = "ignored";
    }

    /// <summary>Milky group member role values.</summary>
    public static class GroupMemberRole
    {
        /// <summary>The group owner role.</summary>
        public const string Owner = "owner";
        /// <summary>The group administrator role.</summary>
        public const string Admin = "admin";
        /// <summary>The regular group member role.</summary>
        public const string Member = "member";
    }

    /// <summary>Milky message reaction type values.</summary>
    public static class ReactionType
    {
        /// <summary>A QQ system face reaction.</summary>
        public const string Face = "face";
        /// <summary>An Emoji reaction.</summary>
        public const string Emoji = "emoji";
    }

    /// <summary>Milky API response status values.</summary>
    public static class ResponseStatus
    {
        /// <summary>A successful API response.</summary>
        public const string Ok = "ok";
        /// <summary>A failed API response.</summary>
        public const string Failed = "failed";
    }

    /// <summary>URI schemes accepted by Milky event transport helpers.</summary>
    public static class CommunicationScheme
    {
        /// <summary>HTTP.</summary>
        public const string Http = "http";
        /// <summary>HTTPS.</summary>
        public const string Https = "https";
        /// <summary>WebSocket.</summary>
        public const string Ws = "ws";
        /// <summary>Secure WebSocket.</summary>
        public const string Wss = "wss";
    }

    /// <summary>Milky sex values.</summary>
    public static class Sex
    {
        /// <summary>Male.</summary>
        public const string Male = "male";
        /// <summary>Female.</summary>
        public const string Female = "female";
        /// <summary>An unknown sex value.</summary>
        public const string Unknown = "unknown";
    }
}
