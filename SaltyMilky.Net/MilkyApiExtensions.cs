using System.Diagnostics.CodeAnalysis;

namespace SaltyMilky.Net;

/// <summary>Typed Milky API extension methods.</summary>
[RequiresUnreferencedCode("Milky typed API extension methods currently route through generic reflection-based System.Text.Json serialization.")]
[RequiresDynamicCode("Milky typed API extension methods currently route through generic reflection-based System.Text.Json serialization.")]
public static partial class MilkyActionSessionExtensions
{
    /// <summary>Gets login information.</summary>
    public static Task<MilkyActionResult<MilkyLoginInfoResult>?> GetLoginInfoAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyLoginInfoResult>("get_login_info", cancellationToken: cancellationToken);
    /// <summary>Gets implementation information.</summary>
    public static Task<MilkyActionResult<MilkyImplInfoResult>?> GetImplInfoAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyImplInfoResult>("get_impl_info", cancellationToken: cancellationToken);
    /// <summary>Gets a user profile.</summary>
    public static Task<MilkyActionResult<MilkyUserProfileResult>?> GetUserProfileAsync(this IMilkyActionSession session, long userId, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyUserProfileResult>("get_user_profile", new { user_id = userId }, cancellationToken);
    /// <summary>Gets friend list.</summary>
    public static Task<MilkyActionResult<MilkyFriendsResult>?> GetFriendListRawAsync(this IMilkyActionSession session, bool noCache = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyFriendsResult>("get_friend_list", new { no_cache = noCache }, cancellationToken);
    /// <summary>Gets friend list.</summary>
    public static Task<MilkyActionResult<MilkyFriendsResult>?> GetFriendListAsync(this IMilkyActionSession session, bool noCache = false, CancellationToken cancellationToken = default) => session.GetFriendListRawAsync(noCache, cancellationToken);
    /// <summary>Gets friend information.</summary>
    public static Task<MilkyActionResult<MilkyFriendResult>?> GetFriendInfoRawAsync(this IMilkyActionSession session, long userId, bool noCache = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyFriendResult>("get_friend_info", new { user_id = userId, no_cache = noCache }, cancellationToken);
    /// <summary>Gets friend information.</summary>
    public static Task<MilkyActionResult<MilkyFriendResult>?> GetFriendInfoAsync(this IMilkyActionSession session, long userId, bool noCache = false, CancellationToken cancellationToken = default) => session.GetFriendInfoRawAsync(userId, noCache, cancellationToken);
    /// <summary>Gets group list.</summary>
    public static Task<MilkyActionResult<MilkyGroupsResult>?> GetGroupListRawAsync(this IMilkyActionSession session, bool noCache = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyGroupsResult>("get_group_list", new { no_cache = noCache }, cancellationToken);
    /// <summary>Gets group list.</summary>
    public static Task<MilkyActionResult<MilkyGroupsResult>?> GetGroupListAsync(this IMilkyActionSession session, bool noCache = false, CancellationToken cancellationToken = default) => session.GetGroupListRawAsync(noCache, cancellationToken);
    /// <summary>Gets group information.</summary>
    public static Task<MilkyActionResult<MilkyGroupResult>?> GetGroupInfoRawAsync(this IMilkyActionSession session, long groupId, bool noCache = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyGroupResult>("get_group_info", new { group_id = groupId, no_cache = noCache }, cancellationToken);
    /// <summary>Gets group information.</summary>
    public static Task<MilkyActionResult<MilkyGroupResult>?> GetGroupInfoAsync(this IMilkyActionSession session, long groupId, bool noCache = false, CancellationToken cancellationToken = default) => session.GetGroupInfoRawAsync(groupId, noCache, cancellationToken);
    /// <summary>Gets group member list.</summary>
    public static Task<MilkyActionResult<MilkyMembersResult>?> GetGroupMemberListRawAsync(this IMilkyActionSession session, long groupId, bool noCache = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyMembersResult>("get_group_member_list", new { group_id = groupId, no_cache = noCache }, cancellationToken);
    /// <summary>Gets group member list.</summary>
    public static Task<MilkyActionResult<MilkyMembersResult>?> GetGroupMemberListAsync(this IMilkyActionSession session, long groupId, bool noCache = false, CancellationToken cancellationToken = default) => session.GetGroupMemberListRawAsync(groupId, noCache, cancellationToken);
    /// <summary>Gets group member information.</summary>
    public static Task<MilkyActionResult<MilkyMemberResult>?> GetGroupMemberInfoRawAsync(this IMilkyActionSession session, long groupId, long userId, bool noCache = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyMemberResult>("get_group_member_info", new { group_id = groupId, user_id = userId, no_cache = noCache }, cancellationToken);
    /// <summary>Gets group member information.</summary>
    public static Task<MilkyActionResult<MilkyMemberResult>?> GetGroupMemberInfoAsync(this IMilkyActionSession session, long groupId, long userId, bool noCache = false, CancellationToken cancellationToken = default) => session.GetGroupMemberInfoRawAsync(groupId, userId, noCache, cancellationToken);
    /// <summary>Gets pinned peers.</summary>
    public static Task<MilkyActionResult<MilkyPeerPinsResult>?> GetPeerPinsAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyPeerPinsResult>("get_peer_pins", cancellationToken: cancellationToken);
    /// <summary>Sets peer pin state.</summary>
    public static Task<MilkyActionResult?> SetPeerPinAsync(this IMilkyActionSession session, string messageScene, long peerId, bool isPinned = true, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_peer_pin", new { message_scene = messageScene, peer_id = peerId, is_pinned = isPinned }, cancellationToken);
    /// <summary>Sets account avatar.</summary>
    public static Task<MilkyActionResult?> SetAvatarAsync(this IMilkyActionSession session, string uri, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_avatar", new { uri }, cancellationToken);
    /// <summary>Sets nickname.</summary>
    public static Task<MilkyActionResult?> SetNicknameAsync(this IMilkyActionSession session, string newNickname, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_nickname", new { new_nickname = newNickname }, cancellationToken);
    /// <summary>Sets biography.</summary>
    public static Task<MilkyActionResult?> SetBioAsync(this IMilkyActionSession session, string newBio, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_bio", new { new_bio = newBio }, cancellationToken);
    /// <summary>Gets custom face URL list.</summary>
    public static Task<MilkyActionResult<MilkyStringListResult>?> GetCustomFaceUrlListRawAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyStringListResult>("get_custom_face_url_list", cancellationToken: cancellationToken);
    /// <summary>Gets custom face URL list.</summary>
    public static Task<MilkyActionResult<MilkyStringListResult>?> GetCustomFaceUrlListAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default) => session.GetCustomFaceUrlListRawAsync(cancellationToken);
    /// <summary>Gets cookies for a domain.</summary>
    public static Task<MilkyActionResult<MilkyCookiesResult>?> GetCookiesRawAsync(this IMilkyActionSession session, string domain, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyCookiesResult>("get_cookies", new { domain }, cancellationToken);
    /// <summary>Gets cookies for a domain.</summary>
    public static Task<MilkyActionResult<MilkyCookiesResult>?> GetCookiesAsync(this IMilkyActionSession session, string domain, CancellationToken cancellationToken = default) => session.GetCookiesRawAsync(domain, cancellationToken);
    /// <summary>Gets CSRF token.</summary>
    public static Task<MilkyActionResult<MilkyCsrfTokenResult>?> GetCsrfTokenRawAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyCsrfTokenResult>("get_csrf_token", cancellationToken: cancellationToken);
    /// <summary>Gets CSRF token.</summary>
    public static Task<MilkyActionResult<MilkyCsrfTokenResult>?> GetCsrfTokenAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default) => session.GetCsrfTokenRawAsync(cancellationToken);

    /// <summary>Sends a private message.</summary>
    public static Task<MilkyActionResult<MilkySendMessageResult>?> SendPrivateMessageAsync(this IMilkyActionSession session, long userId, IEnumerable<MilkyOutgoingSegment> message, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkySendMessageResult>("send_private_message", new { user_id = userId, message = message.ToList() }, cancellationToken);
    /// <summary>Sends a group message.</summary>
    public static Task<MilkyActionResult<MilkySendMessageResult>?> SendGroupMessageAsync(this IMilkyActionSession session, long groupId, IEnumerable<MilkyOutgoingSegment> message, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkySendMessageResult>("send_group_message", new { group_id = groupId, message = message.ToList() }, cancellationToken);
    /// <summary>Recalls a private message.</summary>
    public static Task<MilkyActionResult?> RecallPrivateMessageAsync(this IMilkyActionSession session, long userId, long messageSeq, CancellationToken cancellationToken = default) => session.InvokeApiAsync("recall_private_message", new { user_id = userId, message_seq = messageSeq }, cancellationToken);
    /// <summary>Recalls a group message.</summary>
    public static Task<MilkyActionResult?> RecallGroupMessageAsync(this IMilkyActionSession session, long groupId, long messageSeq, CancellationToken cancellationToken = default) => session.InvokeApiAsync("recall_group_message", new { group_id = groupId, message_seq = messageSeq }, cancellationToken);
    /// <summary>Gets a message.</summary>
    public static Task<MilkyActionResult<MilkyGetMessageResult>?> GetMessageAsync(this IMilkyActionSession session, string messageScene, long peerId, long messageSeq, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyGetMessageResult>("get_message", new { message_scene = messageScene, peer_id = peerId, message_seq = messageSeq }, cancellationToken);
    /// <summary>Gets history messages.</summary>
    public static Task<MilkyActionResult<MilkyHistoryMessagesResult>?> GetHistoryMessagesAsync(this IMilkyActionSession session, string messageScene, long peerId, long? startMessageSeq = null, int limit = 20, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyHistoryMessagesResult>("get_history_messages", new { message_scene = messageScene, peer_id = peerId, start_message_seq = startMessageSeq, limit }, cancellationToken);
    /// <summary>Gets a temporary resource URL.</summary>
    public static Task<MilkyActionResult<MilkyResourceTempUrlResult>?> GetResourceTempUrlAsync(this IMilkyActionSession session, string resourceId, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyResourceTempUrlResult>("get_resource_temp_url", new { resource_id = resourceId }, cancellationToken);
    /// <summary>Gets forwarded messages.</summary>
    public static Task<MilkyActionResult<MilkyForwardedMessagesResult>?> GetForwardedMessagesAsync(this IMilkyActionSession session, string forwardId, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyForwardedMessagesResult>("get_forwarded_messages", new { forward_id = forwardId }, cancellationToken);
    /// <summary>Marks messages as read.</summary>
    public static Task<MilkyActionResult?> MarkMessageAsReadAsync(this IMilkyActionSession session, string messageScene, long peerId, long messageSeq, CancellationToken cancellationToken = default) => session.InvokeApiAsync("mark_message_as_read", new { message_scene = messageScene, peer_id = peerId, message_seq = messageSeq }, cancellationToken);

    /// <summary>Sends friend nudge.</summary>
    public static Task<MilkyActionResult?> SendFriendNudgeAsync(this IMilkyActionSession session, long userId, bool isSelf = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync("send_friend_nudge", new { user_id = userId, is_self = isSelf }, cancellationToken);
    /// <summary>Sends profile likes.</summary>
    public static Task<MilkyActionResult?> SendProfileLikeAsync(this IMilkyActionSession session, long userId, int count = 1, CancellationToken cancellationToken = default) => session.InvokeApiAsync("send_profile_like", new { user_id = userId, count }, cancellationToken);
    /// <summary>Deletes a friend.</summary>
    public static Task<MilkyActionResult?> DeleteFriendAsync(this IMilkyActionSession session, long userId, CancellationToken cancellationToken = default) => session.InvokeApiAsync("delete_friend", new { user_id = userId }, cancellationToken);
    /// <summary>Gets friend requests.</summary>
    public static Task<MilkyActionResult<MilkyFriendRequestsResult>?> GetFriendRequestsRawAsync(this IMilkyActionSession session, int limit = 20, bool isFiltered = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyFriendRequestsResult>("get_friend_requests", new { limit, is_filtered = isFiltered }, cancellationToken);
    /// <summary>Gets friend requests.</summary>
    public static Task<MilkyActionResult<MilkyFriendRequestsResult>?> GetFriendRequestsAsync(this IMilkyActionSession session, int limit = 20, bool isFiltered = false, CancellationToken cancellationToken = default) => session.GetFriendRequestsRawAsync(limit, isFiltered, cancellationToken);
    /// <summary>Accepts a friend request.</summary>
    public static Task<MilkyActionResult?> AcceptFriendRequestAsync(this IMilkyActionSession session, string initiatorUid, bool isFiltered = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync("accept_friend_request", new { initiator_uid = initiatorUid, is_filtered = isFiltered }, cancellationToken);
    /// <summary>Rejects a friend request.</summary>
    public static Task<MilkyActionResult?> RejectFriendRequestAsync(this IMilkyActionSession session, string initiatorUid, bool isFiltered = false, string? reason = null, CancellationToken cancellationToken = default) => session.InvokeApiAsync("reject_friend_request", new { initiator_uid = initiatorUid, is_filtered = isFiltered, reason }, cancellationToken);

    /// <summary>Sets group name.</summary>
    public static Task<MilkyActionResult?> SetGroupNameAsync(this IMilkyActionSession session, long groupId, string newGroupName, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_group_name", new { group_id = groupId, new_group_name = newGroupName }, cancellationToken);
    /// <summary>Sets group avatar.</summary>
    public static Task<MilkyActionResult?> SetGroupAvatarAsync(this IMilkyActionSession session, long groupId, string imageUri, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_group_avatar", new { group_id = groupId, image_uri = imageUri }, cancellationToken);
    /// <summary>Sets group member card.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberCardAsync(this IMilkyActionSession session, long groupId, long userId, string card, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_group_member_card", new { group_id = groupId, user_id = userId, card }, cancellationToken);
    /// <summary>Sets group member special title.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberSpecialTitleAsync(this IMilkyActionSession session, long groupId, long userId, string specialTitle, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_group_member_special_title", new { group_id = groupId, user_id = userId, special_title = specialTitle }, cancellationToken);
    /// <summary>Sets group member administrator state.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberAdminAsync(this IMilkyActionSession session, long groupId, long userId, bool isSet = true, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_group_member_admin", new { group_id = groupId, user_id = userId, is_set = isSet }, cancellationToken);
    /// <summary>Sets group member mute duration.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberMuteAsync(this IMilkyActionSession session, long groupId, long userId, int duration = 0, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_group_member_mute", new { group_id = groupId, user_id = userId, duration }, cancellationToken);
    /// <summary>Sets whole group mute state.</summary>
    public static Task<MilkyActionResult?> SetGroupWholeMuteAsync(this IMilkyActionSession session, long groupId, bool isMute = true, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_group_whole_mute", new { group_id = groupId, is_mute = isMute }, cancellationToken);
    /// <summary>Kicks a group member.</summary>
    public static Task<MilkyActionResult?> KickGroupMemberAsync(this IMilkyActionSession session, long groupId, long userId, bool rejectAddRequest = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync("kick_group_member", new { group_id = groupId, user_id = userId, reject_add_request = rejectAddRequest }, cancellationToken);
    /// <summary>Gets group announcements.</summary>
    public static Task<MilkyActionResult<MilkyGroupAnnouncementsResult>?> GetGroupAnnouncementsRawAsync(this IMilkyActionSession session, long groupId, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyGroupAnnouncementsResult>("get_group_announcements", new { group_id = groupId }, cancellationToken);
    /// <summary>Gets group announcements.</summary>
    public static Task<MilkyActionResult<MilkyGroupAnnouncementsResult>?> GetGroupAnnouncementsAsync(this IMilkyActionSession session, long groupId, CancellationToken cancellationToken = default) => session.GetGroupAnnouncementsRawAsync(groupId, cancellationToken);
    /// <summary>Sends a group announcement.</summary>
    public static Task<MilkyActionResult?> SendGroupAnnouncementAsync(this IMilkyActionSession session, long groupId, string content, string? imageUri = null, CancellationToken cancellationToken = default) => session.InvokeApiAsync("send_group_announcement", new { group_id = groupId, content, image_uri = imageUri }, cancellationToken);
    /// <summary>Deletes a group announcement.</summary>
    public static Task<MilkyActionResult?> DeleteGroupAnnouncementAsync(this IMilkyActionSession session, long groupId, string announcementId, CancellationToken cancellationToken = default) => session.InvokeApiAsync("delete_group_announcement", new { group_id = groupId, announcement_id = announcementId }, cancellationToken);
    /// <summary>Gets group essence messages.</summary>
    public static Task<MilkyActionResult<MilkyGroupEssenceMessagesResult>?> GetGroupEssenceMessagesAsync(this IMilkyActionSession session, long groupId, int pageIndex, int pageSize, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyGroupEssenceMessagesResult>("get_group_essence_messages", new { group_id = groupId, page_index = pageIndex, page_size = pageSize }, cancellationToken);
    /// <summary>Sets group essence message state.</summary>
    public static Task<MilkyActionResult?> SetGroupEssenceMessageAsync(this IMilkyActionSession session, long groupId, long messageSeq, bool isSet = true, CancellationToken cancellationToken = default) => session.InvokeApiAsync("set_group_essence_message", new { group_id = groupId, message_seq = messageSeq, is_set = isSet }, cancellationToken);
    /// <summary>Quits a group.</summary>
    public static Task<MilkyActionResult?> QuitGroupAsync(this IMilkyActionSession session, long groupId, CancellationToken cancellationToken = default) => session.InvokeApiAsync("quit_group", new { group_id = groupId }, cancellationToken);
    /// <summary>Sends group message reaction.</summary>
    public static Task<MilkyActionResult?> SendGroupMessageReactionAsync(this IMilkyActionSession session, long groupId, long messageSeq, string reaction, string reactionType = "face", bool isAdd = true, CancellationToken cancellationToken = default) => session.InvokeApiAsync("send_group_message_reaction", new { group_id = groupId, message_seq = messageSeq, reaction, reaction_type = reactionType, is_add = isAdd }, cancellationToken);
    /// <summary>Sends group nudge.</summary>
    public static Task<MilkyActionResult?> SendGroupNudgeAsync(this IMilkyActionSession session, long groupId, long userId, CancellationToken cancellationToken = default) => session.InvokeApiAsync("send_group_nudge", new { group_id = groupId, user_id = userId }, cancellationToken);
    /// <summary>Gets group notifications.</summary>
    public static Task<MilkyActionResult<MilkyGroupNotificationsResult>?> GetGroupNotificationsAsync(this IMilkyActionSession session, long? startNotificationSeq = null, bool isFiltered = false, int limit = 20, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyGroupNotificationsResult>("get_group_notifications", new { start_notification_seq = startNotificationSeq, is_filtered = isFiltered, limit }, cancellationToken);
    /// <summary>Accepts a group request.</summary>
    public static Task<MilkyActionResult?> AcceptGroupRequestAsync(this IMilkyActionSession session, long notificationSeq, string notificationType, long groupId, bool isFiltered = false, CancellationToken cancellationToken = default) => session.InvokeApiAsync("accept_group_request", new { notification_seq = notificationSeq, notification_type = notificationType, group_id = groupId, is_filtered = isFiltered }, cancellationToken);
    /// <summary>Rejects a group request.</summary>
    public static Task<MilkyActionResult?> RejectGroupRequestAsync(this IMilkyActionSession session, long notificationSeq, string notificationType, long groupId, bool isFiltered = false, string? reason = null, CancellationToken cancellationToken = default) => session.InvokeApiAsync("reject_group_request", new { notification_seq = notificationSeq, notification_type = notificationType, group_id = groupId, is_filtered = isFiltered, reason }, cancellationToken);
    /// <summary>Accepts a group invitation.</summary>
    public static Task<MilkyActionResult?> AcceptGroupInvitationAsync(this IMilkyActionSession session, long groupId, long invitationSeq, CancellationToken cancellationToken = default) => session.InvokeApiAsync("accept_group_invitation", new { group_id = groupId, invitation_seq = invitationSeq }, cancellationToken);
    /// <summary>Rejects a group invitation.</summary>
    public static Task<MilkyActionResult?> RejectGroupInvitationAsync(this IMilkyActionSession session, long groupId, long invitationSeq, CancellationToken cancellationToken = default) => session.InvokeApiAsync("reject_group_invitation", new { group_id = groupId, invitation_seq = invitationSeq }, cancellationToken);

    /// <summary>Uploads a private file.</summary>
    public static Task<MilkyActionResult<MilkyFileUploadResult>?> UploadPrivateFileAsync(this IMilkyActionSession session, long userId, string fileUri, string fileName, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyFileUploadResult>("upload_private_file", new { user_id = userId, file_uri = fileUri, file_name = fileName }, cancellationToken);
    /// <summary>Uploads a group file.</summary>
    public static Task<MilkyActionResult<MilkyFileUploadResult>?> UploadGroupFileAsync(this IMilkyActionSession session, long groupId, string fileUri, string fileName, string parentFolderId = "/", CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyFileUploadResult>("upload_group_file", new { group_id = groupId, parent_folder_id = parentFolderId, file_uri = fileUri, file_name = fileName }, cancellationToken);
    /// <summary>Gets a private file download URL.</summary>
    public static Task<MilkyActionResult<MilkyFileDownloadUrlResult>?> GetPrivateFileDownloadUrlAsync(this IMilkyActionSession session, long userId, string fileId, string fileHash, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyFileDownloadUrlResult>("get_private_file_download_url", new { user_id = userId, file_id = fileId, file_hash = fileHash }, cancellationToken);
    /// <summary>Gets a group file download URL.</summary>
    public static Task<MilkyActionResult<MilkyFileDownloadUrlResult>?> GetGroupFileDownloadUrlAsync(this IMilkyActionSession session, long groupId, string fileId, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyFileDownloadUrlResult>("get_group_file_download_url", new { group_id = groupId, file_id = fileId }, cancellationToken);
    /// <summary>Gets group files.</summary>
    public static Task<MilkyActionResult<MilkyGroupFilesResult>?> GetGroupFilesAsync(this IMilkyActionSession session, long groupId, string parentFolderId = "/", CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyGroupFilesResult>("get_group_files", new { group_id = groupId, parent_folder_id = parentFolderId }, cancellationToken);
    /// <summary>Moves a group file.</summary>
    public static Task<MilkyActionResult?> MoveGroupFileAsync(this IMilkyActionSession session, long groupId, string fileId, string parentFolderId = "/", string targetFolderId = "/", CancellationToken cancellationToken = default) => session.InvokeApiAsync("move_group_file", new { group_id = groupId, file_id = fileId, parent_folder_id = parentFolderId, target_folder_id = targetFolderId }, cancellationToken);
    /// <summary>Renames a group file.</summary>
    public static Task<MilkyActionResult?> RenameGroupFileAsync(this IMilkyActionSession session, long groupId, string fileId, string newFileName, string parentFolderId = "/", CancellationToken cancellationToken = default) => session.InvokeApiAsync("rename_group_file", new { group_id = groupId, file_id = fileId, parent_folder_id = parentFolderId, new_file_name = newFileName }, cancellationToken);
    /// <summary>Deletes a group file.</summary>
    public static Task<MilkyActionResult?> DeleteGroupFileAsync(this IMilkyActionSession session, long groupId, string fileId, CancellationToken cancellationToken = default) => session.InvokeApiAsync("delete_group_file", new { group_id = groupId, file_id = fileId }, cancellationToken);
    /// <summary>Creates a group folder.</summary>
    public static Task<MilkyActionResult<MilkyCreateGroupFolderResult>?> CreateGroupFolderAsync(this IMilkyActionSession session, long groupId, string folderName, CancellationToken cancellationToken = default) => session.InvokeApiAsync<MilkyCreateGroupFolderResult>("create_group_folder", new { group_id = groupId, folder_name = folderName }, cancellationToken);
    /// <summary>Renames a group folder.</summary>
    public static Task<MilkyActionResult?> RenameGroupFolderAsync(this IMilkyActionSession session, long groupId, string folderId, string newFolderName, CancellationToken cancellationToken = default) => session.InvokeApiAsync("rename_group_folder", new { group_id = groupId, folder_id = folderId, new_folder_name = newFolderName }, cancellationToken);
    /// <summary>Deletes a group folder.</summary>
    public static Task<MilkyActionResult?> DeleteGroupFolderAsync(this IMilkyActionSession session, long groupId, string folderId, CancellationToken cancellationToken = default) => session.InvokeApiAsync("delete_group_folder", new { group_id = groupId, folder_id = folderId }, cancellationToken);
}
