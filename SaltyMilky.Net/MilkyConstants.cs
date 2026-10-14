namespace SaltyMilky.Net;

/// <summary>Centralized Milky protocol constants.</summary>
public static class MilkyConstant
{
    /// <summary>Milky API action names.</summary>
    #pragma warning disable CS1591
    public static class Api
    {
        /// <summary>The commit_flash_file endpoint.</summary>
        public const string CommitFlashFile = "commit_flash_file";
        /// <summary>The complete_flash_task endpoint.</summary>
        public const string CompleteFlashTask = "complete_flash_task";
        /// <summary>The convert_record endpoint.</summary>
        public const string ConvertRecord = "convert_record";
        /// <summary>The create_flash_task endpoint.</summary>
        public const string CreateFlashTask = "create_flash_task";
        /// <summary>The delete_flash_file endpoint.</summary>
        public const string DeleteFlashFile = "delete_flash_file";
        /// <summary>The upload_flash_files endpoint.</summary>
        public const string UploadFlashFiles = "upload_flash_files";
        /// <summary>The get_flash_download endpoint.</summary>
        public const string GetFlashDownload = "get_flash_download";
        /// <summary>The get_flash_share_link endpoint.</summary>
        public const string GetFlashShareLink = "get_flash_share_link";
        /// <summary>The resolve_flash_share_code endpoint.</summary>
        public const string ResolveFlashShareCode = "resolve_flash_share_code";
        /// <summary>The get_download_rkeys endpoint.</summary>
        public const string GetDownloadRkeys = "get_download_rkeys";
        /// <summary>The get_flash_fileset endpoint.</summary>
        public const string GetFlashFileset = "get_flash_fileset";
        /// <summary>The get_flash_file_url endpoint.</summary>
        public const string GetFlashFileUrl = "get_flash_file_url";
        /// <summary>The get_group_file_count endpoint.</summary>
        public const string GetGroupFileCount = "get_group_file_count";
        /// <summary>The get_group_file_space endpoint.</summary>
        public const string GetGroupFileSpace = "get_group_file_space";
        /// <summary>The get_group_file_url endpoint.</summary>
        public const string GetGroupFileUrl = "get_group_file_url";
        /// <summary>The get_group_ptt_url endpoint.</summary>
        public const string GetGroupPttUrl = "get_group_ptt_url";
        /// <summary>The get_group_video_url endpoint.</summary>
        public const string GetGroupVideoUrl = "get_group_video_url";
        /// <summary>The get_private_ptt_url endpoint.</summary>
        public const string GetPrivatePttUrl = "get_private_ptt_url";
        /// <summary>The get_private_video_url endpoint.</summary>
        public const string GetPrivateVideoUrl = "get_private_video_url";
        /// <summary>The list_flash_filesets endpoint.</summary>
        public const string ListFlashFilesets = "list_flash_filesets";
        /// <summary>The publish_group_file endpoint.</summary>
        public const string PublishGroupFile = "publish_group_file";
        /// <summary>The rename_flash_file endpoint.</summary>
        public const string RenameFlashFile = "rename_flash_file";
        /// <summary>The send_flash_message endpoint.</summary>
        public const string SendFlashMessage = "send_flash_message";
        /// <summary>The set_flash_task_status endpoint.</summary>
        public const string SetFlashTaskStatus = "set_flash_task_status";
        /// <summary>The trans_group_file endpoint.</summary>
        public const string TransGroupFile = "trans_group_file";
        /// <summary>The get_unidirectional_friend_list endpoint.</summary>
        public const string GetUnidirectionalFriendList = "get_unidirectional_friend_list";
        /// <summary>The handle_friend_request endpoint.</summary>
        public const string HandleFriendRequest = "handle_friend_request";
        /// <summary>The set_friend_category endpoint.</summary>
        public const string SetFriendCategory = "set_friend_category";
        /// <summary>The set_friend_remark endpoint.</summary>
        public const string SetFriendRemark = "set_friend_remark";
        /// <summary>The cancel_group_todo endpoint.</summary>
        public const string CancelGroupTodo = "cancel_group_todo";
        /// <summary>The comment_group_album_media endpoint.</summary>
        public const string CommentGroupAlbumMedia = "comment_group_album_media";
        /// <summary>The complete_group_todo endpoint.</summary>
        public const string CompleteGroupTodo = "complete_group_todo";
        /// <summary>The delete_group_album_media endpoint.</summary>
        public const string DeleteGroupAlbumMedia = "delete_group_album_media";
        /// <summary>The get_group_admin_settings endpoint.</summary>
        public const string GetGroupAdminSettings = "get_group_admin_settings";
        /// <summary>The get_group_album_media endpoint.</summary>
        public const string GetGroupAlbumMedia = "get_group_album_media";
        /// <summary>The get_group_album_list endpoint.</summary>
        public const string GetGroupAlbumList = "get_group_album_list";
        /// <summary>The get_group_at_all_remain endpoint.</summary>
        public const string GetGroupAtAllRemain = "get_group_at_all_remain";
        /// <summary>The get_group_essence endpoint.</summary>
        public const string GetGroupEssence = "get_group_essence";
        /// <summary>The get_group_honor endpoint.</summary>
        public const string GetGroupHonor = "get_group_honor";
        /// <summary>The get_group_sign_in endpoint.</summary>
        public const string GetGroupSignIn = "get_group_sign_in";
        /// <summary>The get_group_todo endpoint.</summary>
        public const string GetGroupTodo = "get_group_todo";
        /// <summary>The get_group_todo_list endpoint.</summary>
        public const string GetGroupTodoList = "get_group_todo_list";
        /// <summary>The send_group_sign endpoint.</summary>
        public const string SendGroupSign = "send_group_sign";
        /// <summary>The set_group_add_option endpoint.</summary>
        public const string SetGroupAddOption = "set_group_add_option";
        /// <summary>The set_group_album_like endpoint.</summary>
        public const string SetGroupAlbumLike = "set_group_album_like";
        /// <summary>The set_group_member_invite_policy endpoint.</summary>
        public const string SetGroupMemberInvitePolicy = "set_group_member_invite_policy";
        /// <summary>The set_group_member_permission endpoint.</summary>
        public const string SetGroupMemberPermission = "set_group_member_permission";
        /// <summary>The set_group_new_member_history_visibility endpoint.</summary>
        public const string SetGroupNewMemberHistoryVisibility = "set_group_new_member_history_visibility";
        /// <summary>The set_group_remark endpoint.</summary>
        public const string SetGroupRemark = "set_group_remark";
        /// <summary>The set_group_robot_add_option endpoint.</summary>
        public const string SetGroupRobotAddOption = "set_group_robot_add_option";
        /// <summary>The set_group_search endpoint.</summary>
        public const string SetGroupSearch = "set_group_search";
        /// <summary>The set_group_todo endpoint.</summary>
        public const string SetGroupTodo = "set_group_todo";
        /// <summary>The transfer_group endpoint.</summary>
        public const string TransferGroup = "transfer_group";
        /// <summary>The upload_group_album_image endpoint.</summary>
        public const string UploadGroupAlbumImage = "upload_group_album_image";
        /// <summary>The upload_group_album_video endpoint.</summary>
        public const string UploadGroupAlbumVideo = "upload_group_album_video";
        /// <summary>The upload_group_announcement_image endpoint.</summary>
        public const string UploadGroupAnnouncementImage = "upload_group_announcement_image";
        /// <summary>The click_inline_keyboard_button endpoint.</summary>
        public const string ClickInlineKeyboardButton = "click_inline_keyboard_button";
        /// <summary>The get_emoji_likes endpoint.</summary>
        public const string GetEmojiLikes = "get_emoji_likes";
        /// <summary>The get_group_reaction_summary endpoint.</summary>
        public const string GetGroupReactionSummary = "get_group_reaction_summary";
        /// <summary>The send_like endpoint.</summary>
        public const string SendLike = "send_like";
        /// <summary>The send_poke endpoint.</summary>
        public const string SendPoke = "send_poke";
        /// <summary>The set_group_reaction endpoint.</summary>
        public const string SetGroupReaction = "set_group_reaction";
        /// <summary>The set_input_status endpoint.</summary>
        public const string SetInputStatus = "set_input_status";
        /// <summary>The get_ai_voice_list endpoint.</summary>
        public const string GetAiVoiceList = "get_ai_voice_list";
        /// <summary>The get_collection endpoint.</summary>
        public const string GetCollection = "get_collection";
        /// <summary>The probe_history_sync_state endpoint.</summary>
        public const string ProbeHistorySyncState = "probe_history_sync_state";
        /// <summary>The get_history_sync_page endpoint.</summary>
        public const string GetHistorySyncPage = "get_history_sync_page";
        /// <summary>The get_private_history_roam_page endpoint.</summary>
        public const string GetPrivateHistoryRoamPage = "get_private_history_roam_page";
        /// <summary>The mark_all_read endpoint.</summary>
        public const string MarkAllRead = "mark_all_read";
        /// <summary>The send_ai_voice endpoint.</summary>
        public const string SendAiVoice = "send_ai_voice";
        /// <summary>The send_temp_message endpoint.</summary>
        public const string SendTempMessage = "send_temp_message";
        /// <summary>The synthesize_ai_voice endpoint.</summary>
        public const string SynthesizeAiVoice = "synthesize_ai_voice";
        /// <summary>The transcribe_voice endpoint.</summary>
        public const string TranscribeVoice = "transcribe_voice";
        /// <summary>The add_custom_face endpoint.</summary>
        public const string AddCustomFace = "add_custom_face";
        /// <summary>The comment_qzone_message endpoint.</summary>
        public const string CommentQzoneMessage = "comment_qzone_message";
        /// <summary>The delete_custom_face endpoint.</summary>
        public const string DeleteCustomFace = "delete_custom_face";
        /// <summary>The delete_qzone_message endpoint.</summary>
        public const string DeleteQzoneMessage = "delete_qzone_message";
        /// <summary>The get_group_system_msg endpoint.</summary>
        public const string GetGroupSystemMsg = "get_group_system_msg";
        /// <summary>The get_group_shut_list endpoint.</summary>
        public const string GetGroupShutList = "get_group_shut_list";
        /// <summary>The get_doubt_friends_add_request endpoint.</summary>
        public const string GetDoubtFriendsAddRequest = "get_doubt_friends_add_request";
        /// <summary>The set_doubt_friends_add_request endpoint.</summary>
        public const string SetDoubtFriendsAddRequest = "set_doubt_friends_add_request";
        /// <summary>The get_qidian_corp_info endpoint.</summary>
        public const string GetQidianCorpInfo = "get_qidian_corp_info";
        /// <summary>The send_ark_share endpoint.</summary>
        public const string SendArkShare = "send_ark_share";
        /// <summary>The send_tuwen_ark endpoint.</summary>
        public const string SendTuwenArk = "send_tuwen_ark";
        /// <summary>The get_custom_face_detail endpoint.</summary>
        public const string GetCustomFaceDetail = "get_custom_face_detail";
        /// <summary>The get_custom_face_list endpoint.</summary>
        public const string GetCustomFaceList = "get_custom_face_list";
        /// <summary>The get_friend_dress endpoint.</summary>
        public const string GetFriendDress = "get_friend_dress";
        /// <summary>The get_friends_status endpoint.</summary>
        public const string GetFriendsStatus = "get_friends_status";
        /// <summary>The get_group_ext_info endpoint.</summary>
        public const string GetGroupExtInfo = "get_group_ext_info";
        /// <summary>The get_mini_app_ark endpoint.</summary>
        public const string GetMiniAppArk = "get_mini_app_ark";
        /// <summary>The get_online_devices endpoint.</summary>
        public const string GetOnlineDevices = "get_online_devices";
        /// <summary>The get_like endpoint.</summary>
        public const string GetLike = "get_like";
        /// <summary>The get_qzone_feeds endpoint.</summary>
        public const string GetQzoneFeeds = "get_qzone_feeds";
        /// <summary>The get_qzone_msg_list endpoint.</summary>
        public const string GetQzoneMsgList = "get_qzone_msg_list";
        /// <summary>The get_system_faces endpoint.</summary>
        public const string GetSystemFaces = "get_system_faces";
        /// <summary>The get_user_status endpoint.</summary>
        public const string GetUserStatus = "get_user_status";
        /// <summary>The image_ocr endpoint.</summary>
        public const string ImageOcr = "image_ocr";
        /// <summary>The modify_custom_face endpoint.</summary>
        public const string ModifyCustomFace = "modify_custom_face";
        /// <summary>The move_custom_face endpoint.</summary>
        public const string MoveCustomFace = "move_custom_face";
        /// <summary>The publish_qzone_message endpoint.</summary>
        public const string PublishQzoneMessage = "publish_qzone_message";
        /// <summary>The request_database_key endpoint.</summary>
        public const string RequestDatabaseKey = "request_database_key";
        /// <summary>The request_decrypt_key endpoint.</summary>
        public const string RequestDecryptKey = "request_decrypt_key";
        /// <summary>The search_system_faces endpoint.</summary>
        public const string SearchSystemFaces = "search_system_faces";
        /// <summary>The send_packet endpoint.</summary>
        public const string SendPacket = "send_packet";
        /// <summary>The set_diy_online_status endpoint.</summary>
        public const string SetDiyOnlineStatus = "set_diy_online_status";
        /// <summary>The set_online_status endpoint.</summary>
        public const string SetOnlineStatus = "set_online_status";
        /// <summary>The set_profile endpoint.</summary>
        public const string SetProfile = "set_profile";
        /// <summary>The set_qzone_black endpoint.</summary>
        public const string SetQzoneBlack = "set_qzone_black";
        /// <summary>The set_qzone_like endpoint.</summary>
        public const string SetQzoneLike = "set_qzone_like";
        /// <summary>The set_qzone_message_visibility endpoint.</summary>
        public const string SetQzoneMessageVisibility = "set_qzone_message_visibility";
        /// <summary>The set_self_long_nick endpoint.</summary>
        public const string SetSelfLongNick = "set_self_long_nick";
        /// <summary>The translate_en_to_zh endpoint.</summary>
        public const string TranslateEnToZh = "translate_en_to_zh";
        /// <summary>The upload_qzone_image endpoint.</summary>
        public const string UploadQzoneImage = "upload_qzone_image";
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
        /// <summary>The packet_received event.</summary>
        public const string PacketReceived = "packet_received";
        /// <summary>The group_member_card_change event.</summary>
        public const string GroupMemberCardChange = "group_member_card_change";
        /// <summary>The group_self_joined event.</summary>
        public const string GroupSelfJoined = "group_self_joined";
        /// <summary>The friend_added event.</summary>
        public const string FriendAdded = "friend_added";
        /// <summary>The group_special_title_change event.</summary>
        public const string GroupSpecialTitleChange = "group_special_title_change";
        /// <summary>The friend_profile_like event.</summary>
        public const string FriendProfileLike = "friend_profile_like";
        /// <summary>The online_devices_changed event.</summary>
        public const string OnlineDevicesChanged = "online_devices_changed";
        /// <summary>The friend_input_status event.</summary>
        public const string FriendInputStatus = "friend_input_status";
        /// <summary>The friend_remark_changed event.</summary>
        public const string FriendRemarkChanged = "friend_remark_changed";
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
        /// <summary>The grey_tip segment.</summary>
        public const string GreyTip = "grey_tip";
        /// <summary>The group_reaction segment.</summary>
        public const string GroupReaction = "group_reaction";
        /// <summary>The bounce_face segment.</summary>
        public const string BounceFace = "bounce_face";
        /// <summary>The stream segment.</summary>
        public const string Stream = "stream";
        /// <summary>The long_msg segment.</summary>
        public const string LongMsg = "long_msg";
        /// <summary>The rps segment.</summary>
        public const string Rps = "rps";
        /// <summary>The dice segment.</summary>
        public const string Dice = "dice";
        /// <summary>The contact segment.</summary>
        public const string Contact = "contact";
        /// <summary>The share segment.</summary>
        public const string Share = "share";
        /// <summary>The music segment.</summary>
        public const string Music = "music";
        /// <summary>The location segment.</summary>
        public const string Location = "location";
        /// <summary>The json segment.</summary>
        public const string Json = "json";
        /// <summary>The special_poke segment.</summary>
        public const string SpecialPoke = "special_poke";
        /// <summary>The keyboard segment.</summary>
        public const string Keyboard = "keyboard";
        /// <summary>The poke segment.</summary>
        public const string Poke = "poke";
        /// <summary>The flash_file segment.</summary>
        public const string FlashFile = "flash_file";
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
