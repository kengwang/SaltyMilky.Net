namespace SaltyMilky.Net;

/// <summary>Centralized Milky protocol constants.</summary>
public static class MilkyConstant
{
    /// <summary>Milky API action names.</summary>
    #pragma warning disable CS1591
    public static class Api
    {
        public const string PathPrefix = "api/";
        public const string GetLoginInfo = "get_login_info";
        public const string GetImplInfo = "get_impl_info";
        public const string GetUserProfile = "get_user_profile";
        public const string GetFriendList = "get_friend_list";
        public const string GetFriendInfo = "get_friend_info";
        public const string GetGroupList = "get_group_list";
        public const string GetGroupInfo = "get_group_info";
        public const string GetGroupMemberList = "get_group_member_list";
        public const string GetGroupMemberInfo = "get_group_member_info";
        public const string GetPeerPins = "get_peer_pins";
        public const string SetPeerPin = "set_peer_pin";
        public const string SetAvatar = "set_avatar";
        public const string SetNickname = "set_nickname";
        public const string SetBio = "set_bio";
        public const string GetCustomFaceUrlList = "get_custom_face_url_list";
        public const string GetCookies = "get_cookies";
        public const string GetCsrfToken = "get_csrf_token";
        public const string SendPrivateMessage = "send_private_message";
        public const string SendGroupMessage = "send_group_message";
        public const string RecallPrivateMessage = "recall_private_message";
        public const string RecallGroupMessage = "recall_group_message";
        public const string GetMessage = "get_message";
        public const string GetHistoryMessages = "get_history_messages";
        public const string GetResourceTempUrl = "get_resource_temp_url";
        public const string GetForwardedMessages = "get_forwarded_messages";
        public const string MarkMessageAsRead = "mark_message_as_read";
        public const string SendFriendNudge = "send_friend_nudge";
        public const string SendProfileLike = "send_profile_like";
        public const string DeleteFriend = "delete_friend";
        public const string GetFriendRequests = "get_friend_requests";
        public const string AcceptFriendRequest = "accept_friend_request";
        public const string RejectFriendRequest = "reject_friend_request";
        public const string SetGroupName = "set_group_name";
        public const string SetGroupAvatar = "set_group_avatar";
        public const string SetGroupMemberCard = "set_group_member_card";
        public const string SetGroupMemberSpecialTitle = "set_group_member_special_title";
        public const string SetGroupMemberAdmin = "set_group_member_admin";
        public const string SetGroupMemberMute = "set_group_member_mute";
        public const string SetGroupWholeMute = "set_group_whole_mute";
        public const string KickGroupMember = "kick_group_member";
        public const string GetGroupAnnouncements = "get_group_announcements";
        public const string SendGroupAnnouncement = "send_group_announcement";
        public const string DeleteGroupAnnouncement = "delete_group_announcement";
        public const string GetGroupEssenceMessages = "get_group_essence_messages";
        public const string SetGroupEssenceMessage = "set_group_essence_message";
        public const string QuitGroup = "quit_group";
        public const string SendGroupMessageReaction = "send_group_message_reaction";
        public const string SendGroupNudge = "send_group_nudge";
        public const string GetGroupNotifications = "get_group_notifications";
        public const string AcceptGroupRequest = "accept_group_request";
        public const string RejectGroupRequest = "reject_group_request";
        public const string AcceptGroupInvitation = "accept_group_invitation";
        public const string RejectGroupInvitation = "reject_group_invitation";
        public const string UploadPrivateFile = "upload_private_file";
        public const string UploadGroupFile = "upload_group_file";
        public const string GetPrivateFileDownloadUrl = "get_private_file_download_url";
        public const string GetGroupFileDownloadUrl = "get_group_file_download_url";
        public const string GetGroupFiles = "get_group_files";
        public const string MoveGroupFile = "move_group_file";
        public const string RenameGroupFile = "rename_group_file";
        public const string DeleteGroupFile = "delete_group_file";
        public const string CreateGroupFolder = "create_group_folder";
        public const string RenameGroupFolder = "rename_group_folder";
        public const string DeleteGroupFolder = "delete_group_folder";
    }

    /// <summary>Milky group file constants.</summary>
    public static class GroupFile
    {
        public const string RootFolderId = "/";
    }

    /// <summary>Milky transport constants.</summary>
    public static class Communication
    {
        public const string EventEndpointPath = "event";
        public const string JsonMediaType = "application/json";
        public const string SseMediaType = "text/event-stream";
        public const string AuthorizationHeader = "Authorization";
        public const string BearerScheme = "Bearer";
        public const string PostMethod = "POST";
        public const string SseDataPrefix = "data:";
    }

    #pragma warning restore CS1591

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
