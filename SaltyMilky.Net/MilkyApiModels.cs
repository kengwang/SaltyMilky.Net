using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>Login account information.</summary>
public record class MilkyLoginInfoResult([property: JsonPropertyName("uin")] long Uin, [property: JsonPropertyName("nickname")] string Nickname);

/// <summary>Milky implementation information.</summary>
public record class MilkyImplInfoResult
{
    /// <summary>Gets or sets implementation name.</summary>
    [JsonPropertyName("impl_name")]
    public string ImplName { get; set; } = string.Empty;
    /// <summary>Gets or sets implementation version.</summary>
    [JsonPropertyName("impl_version")]
    public string ImplVersion { get; set; } = string.Empty;
    /// <summary>Gets or sets QQ protocol version.</summary>
    [JsonPropertyName("qq_protocol_version")]
    public string QqProtocolVersion { get; set; } = string.Empty;
    /// <summary>Gets or sets QQ protocol type.</summary>
    [JsonPropertyName("qq_protocol_type")]
    public string QqProtocolType { get; set; } = string.Empty;
    /// <summary>Gets or sets Milky protocol version.</summary>
    [JsonPropertyName("milky_version")]
    public string MilkyVersion { get; set; } = string.Empty;
}

/// <summary>User profile information.</summary>
public record class MilkyUserProfileResult
{
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets QID.</summary>
    [JsonPropertyName("qid")]
    public string Qid { get; set; } = string.Empty;
    /// <summary>Gets or sets age.</summary>
    [JsonPropertyName("age")]
    public int Age { get; set; }
    /// <summary>Gets or sets sex.</summary>
    [JsonPropertyName("sex")]
    public string Sex { get; set; } = "unknown";
    /// <summary>Gets or sets remark.</summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; } = string.Empty;
    /// <summary>Gets or sets biography.</summary>
    [JsonPropertyName("bio")]
    public string Bio { get; set; } = string.Empty;
    /// <summary>Gets or sets level.</summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }
    /// <summary>Gets or sets country.</summary>
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;
    /// <summary>Gets or sets city.</summary>
    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;
    /// <summary>Gets or sets school.</summary>
    [JsonPropertyName("school")]
    public string School { get; set; } = string.Empty;
}

/// <summary>Peer pin result.</summary>
public record class MilkyPeerPinsResult([property: JsonPropertyName("friends")] List<MilkyFriendEntity> Friends, [property: JsonPropertyName("groups")] List<MilkyGroupEntity> Groups);

/// <summary>Message sending result.</summary>
public record class MilkySendMessageResult([property: JsonPropertyName("message_seq")] long MessageSeq, [property: JsonPropertyName("time")] long Time);

/// <summary>Message query result.</summary>
public record class MilkyGetMessageResult([property: JsonPropertyName("message")] MilkyIncomingMessage Message);

/// <summary>History message query result.</summary>
public record class MilkyHistoryMessagesResult([property: JsonPropertyName("messages")] List<MilkyIncomingMessage> Messages, [property: JsonPropertyName("next_message_seq")] long? NextMessageSeq);

/// <summary>Temporary resource URL result.</summary>
public record class MilkyResourceTempUrlResult([property: JsonPropertyName("url")] string Url);

/// <summary>Forwarded messages result.</summary>
public record class MilkyForwardedMessagesResult([property: JsonPropertyName("messages")] List<MilkyIncomingForwardedMessage> Messages);

/// <summary>Group essence messages result.</summary>
public record class MilkyGroupEssenceMessagesResult([property: JsonPropertyName("messages")] List<MilkyGroupEssenceMessage> Messages, [property: JsonPropertyName("is_end")] bool IsEnd);

/// <summary>Group notifications result.</summary>
public record class MilkyGroupNotificationsResult([property: JsonPropertyName("notifications")] List<MilkyGroupNotification> Notifications, [property: JsonPropertyName("next_notification_seq")] long? NextNotificationSeq);

/// <summary>Group files result.</summary>
public record class MilkyGroupFilesResult([property: JsonPropertyName("files")] List<MilkyGroupFileEntity> Files, [property: JsonPropertyName("folders")] List<MilkyGroupFolderEntity> Folders);

/// <summary>File upload result.</summary>
public record class MilkyFileUploadResult([property: JsonPropertyName("file_id")] string FileId);

/// <summary>File download URL result.</summary>
public record class MilkyFileDownloadUrlResult([property: JsonPropertyName("download_url")] string DownloadUrl);

/// <summary>Folder creation result.</summary>
public record class MilkyCreateGroupFolderResult([property: JsonPropertyName("folder_id")] string FolderId);

/// <summary>Friend list result.</summary>
public record class MilkyFriendsResult([property: JsonPropertyName("friends")] List<MilkyFriendEntity> Friends);
/// <summary>Friend information result.</summary>
public record class MilkyFriendResult([property: JsonPropertyName("friend")] MilkyFriendEntity Friend);
/// <summary>Group list result.</summary>
public record class MilkyGroupsResult([property: JsonPropertyName("groups")] List<MilkyGroupEntity> Groups);
/// <summary>Group information result.</summary>
public record class MilkyGroupResult([property: JsonPropertyName("group")] MilkyGroupEntity Group);
/// <summary>Group member list result.</summary>
public record class MilkyMembersResult([property: JsonPropertyName("members")] List<MilkyGroupMemberEntity> Members);
/// <summary>Group member information result.</summary>
public record class MilkyMemberResult([property: JsonPropertyName("member")] MilkyGroupMemberEntity Member);
/// <summary>Custom face URL list result.</summary>
public record class MilkyStringListResult([property: JsonPropertyName("urls")] List<string> Urls);
/// <summary>Cookie string result.</summary>
public record class MilkyCookiesResult([property: JsonPropertyName("cookies")] string Cookies);
/// <summary>CSRF token result.</summary>
public record class MilkyCsrfTokenResult([property: JsonPropertyName("csrf_token")] string CsrfToken);
/// <summary>Friend requests result.</summary>
public record class MilkyFriendRequestsResult([property: JsonPropertyName("requests")] List<MilkyFriendRequest> Requests);
/// <summary>Group announcements result.</summary>
public record class MilkyGroupAnnouncementsResult([property: JsonPropertyName("announcements")] List<MilkyGroupAnnouncementEntity> Announcements);
