using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>Wire contract for CommitFlashFileRequest.</summary>
public sealed record class MilkyCommitFlashFileRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets upload_key.</summary>
    [JsonPropertyName("upload_key")]
    public string UploadKey { get; set; } = string.Empty;
    /// <summary>Gets or sets file_uuid.</summary>
    [JsonPropertyName("file_uuid")]
    public string FileUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets file_size.</summary>
    [JsonPropertyName("file_size")]
    public ulong FileSize { get; set; }
    /// <summary>Gets or sets index.</summary>
    [JsonPropertyName("index")]
    public uint Index { get; set; } = 1;
    /// <summary>Gets or sets format_code.</summary>
    [JsonPropertyName("format_code")]
    public uint FormatCode { get; set; } = 26;
}

/// <summary>Wire contract for CompleteFlashTaskRequest.</summary>
public sealed record class MilkyCompleteFlashTaskRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
}

/// <summary>Wire contract for ConvertRecordRequest.</summary>
public sealed record class MilkyConvertRecordRequest
{
    /// <summary>Gets or sets file_uri.</summary>
    [JsonPropertyName("file_uri")]
    public string FileUri { get; set; } = string.Empty;
    /// <summary>Gets or sets format.</summary>
    [JsonPropertyName("format")]
    public string Format { get; set; } = string.Empty;
}

/// <summary>Wire contract for ConvertRecordResult.</summary>
public sealed record class MilkyConvertRecordResult
{
    /// <summary>Gets or sets base64.</summary>
    [JsonPropertyName("base64")]
    public string Base64 { get; set; } = string.Empty;
    /// <summary>Gets or sets size.</summary>
    [JsonPropertyName("size")]
    public int Size { get; set; }
    /// <summary>Gets or sets format.</summary>
    [JsonPropertyName("format")]
    public string Format { get; set; } = string.Empty;
}

/// <summary>Wire contract for CreateFlashTaskRequest.</summary>
public sealed record class MilkyCreateFlashTaskRequest
{
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets file_size.</summary>
    [JsonPropertyName("file_size")]
    public ulong FileSize { get; set; }
    /// <summary>Gets or sets file_type.</summary>
    [JsonPropertyName("file_type")]
    public uint FileType { get; set; } = 7;
}

/// <summary>Wire contract for CreateFlashTaskResult.</summary>
public sealed record class MilkyCreateFlashTaskResult
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets upload_key.</summary>
    [JsonPropertyName("upload_key")]
    public string UploadKey { get; set; } = string.Empty;
    /// <summary>Gets or sets upload_url.</summary>
    [JsonPropertyName("upload_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UploadUrl { get; set; }
    /// <summary>Gets or sets expire.</summary>
    [JsonPropertyName("expire")]
    public ulong Expire { get; set; }
    /// <summary>Gets or sets ttl.</summary>
    [JsonPropertyName("ttl")]
    public uint Ttl { get; set; }
}

/// <summary>Wire contract for CreateGroupFolderRequest.</summary>
public sealed record class MilkyCreateGroupFolderRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets folder_name.</summary>
    [JsonPropertyName("folder_name")]
    public string FolderName { get; set; } = string.Empty;
}

/// <summary>Wire contract for DeleteFlashFileRequest.</summary>
public sealed record class MilkyDeleteFlashFileRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
}

/// <summary>Wire contract for DeleteGroupFileRequest.</summary>
public sealed record class MilkyDeleteGroupFileRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
}

/// <summary>Wire contract for DeleteGroupFolderRequest.</summary>
public sealed record class MilkyDeleteGroupFolderRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets folder_id.</summary>
    [JsonPropertyName("folder_id")]
    public string FolderId { get; set; } = string.Empty;
}

/// <summary>Wire contract for UploadFlashFilesRequest.</summary>
public sealed record class MilkyUploadFlashFilesRequest
{
    /// <summary>Gets or sets files.</summary>
    [JsonPropertyName("files")]
    public List<MilkyUploadFlashFilesFileInput> Files { get; set; } = [];
    /// <summary>Gets or sets name.</summary>
    [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
}

/// <summary>Wire contract for UploadFlashFilesFileInput.</summary>
public sealed record class MilkyUploadFlashFilesFileInput
{
    /// <summary>Gets or sets file_uri.</summary>
    [JsonPropertyName("file_uri")]
    public string FileUri { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
}

/// <summary>Wire contract for UploadFlashFilesResult.</summary>
public sealed record class MilkyUploadFlashFilesResult
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets share_url.</summary>
    [JsonPropertyName("share_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ShareUrl { get; set; }
    /// <summary>Gets or sets files.</summary>
    [JsonPropertyName("files")]
    public List<MilkyUploadFlashFilesFileResult> Files { get; set; } = [];
}

/// <summary>Wire contract for UploadFlashFilesFileResult.</summary>
public sealed record class MilkyUploadFlashFilesFileResult
{
    /// <summary>Gets or sets file_uuid.</summary>
    [JsonPropertyName("file_uuid")]
    public string FileUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets file_index.</summary>
    [JsonPropertyName("file_index")]
    public uint FileIndex { get; set; }
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets file_size.</summary>
    [JsonPropertyName("file_size")]
    public ulong FileSize { get; set; }
}

/// <summary>Wire contract for GetFlashDownloadRequest.</summary>
public sealed record class MilkyGetFlashDownloadRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets file_index.</summary>
    [JsonPropertyName("file_index"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? FileIndex { get; set; }
}

/// <summary>Wire contract for GetFlashDownloadResult.</summary>
public sealed record class MilkyGetFlashDownloadResult
{
    /// <summary>Gets or sets download_url.</summary>
    [JsonPropertyName("download_url")]
    public string DownloadUrl { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets file_size.</summary>
    [JsonPropertyName("file_size")]
    public ulong FileSize { get; set; }
}

/// <summary>Wire contract for GetFlashShareLinkRequest.</summary>
public sealed record class MilkyGetFlashShareLinkRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetFlashShareLinkResult.</summary>
public sealed record class MilkyGetFlashShareLinkResult
{
    /// <summary>Gets or sets share_url.</summary>
    [JsonPropertyName("share_url")]
    public string ShareUrl { get; set; } = string.Empty;
}

/// <summary>Wire contract for ResolveFlashShareCodeRequest.</summary>
public sealed record class MilkyResolveFlashShareCodeRequest
{
    /// <summary>Gets or sets share_code.</summary>
    [JsonPropertyName("share_code")]
    public string ShareCode { get; set; } = string.Empty;
}

/// <summary>Wire contract for ResolveFlashShareCodeResult.</summary>
public sealed record class MilkyResolveFlashShareCodeResult
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetDownloadRkeysResult.</summary>
public sealed record class MilkyGetDownloadRkeysResult
{
    /// <summary>Gets or sets keys.</summary>
    [JsonPropertyName("keys")]
    public IReadOnlyList<MilkyGetDownloadRkeysKey> Keys { get; set; } = [];
}

/// <summary>Wire contract for GetDownloadRkeysKey.</summary>
public sealed record class MilkyGetDownloadRkeysKey
{
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? Type { get; set; }
    /// <summary>Gets or sets key.</summary>
    [JsonPropertyName("key")]
    public string Value { get; set; } = string.Empty;
    /// <summary>Gets or sets created_at.</summary>
    [JsonPropertyName("created_at"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? CreatedAt { get; set; }
    /// <summary>Gets or sets ttl_seconds.</summary>
    [JsonPropertyName("ttl_seconds")]
    public ulong TtlSeconds { get; set; }
}

/// <summary>Wire contract for GetFlashFilesetRequest.</summary>
public sealed record class MilkyGetFlashFilesetRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetFlashFilesetResult.</summary>
public sealed record class MilkyGetFlashFilesetResult
{
    /// <summary>Gets or sets files.</summary>
    [JsonPropertyName("files")]
    public MilkyGetFlashFilesetFlashFile[] Files { get; set; } = [];
}

/// <summary>Wire contract for GetFlashFilesetFlashFile.</summary>
public sealed record class MilkyGetFlashFilesetFlashFile
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets original_name.</summary>
    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; } = string.Empty;
    /// <summary>Gets or sets file_type.</summary>
    [JsonPropertyName("file_type")]
    public uint FileType { get; set; }
    /// <summary>Gets or sets file_size.</summary>
    [JsonPropertyName("file_size")]
    public ulong FileSize { get; set; }
    /// <summary>Gets or sets upload_url.</summary>
    [JsonPropertyName("upload_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UploadUrl { get; set; }
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FileId { get; set; }
    /// <summary>Gets or sets download_url.</summary>
    [JsonPropertyName("download_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DownloadUrl { get; set; }
}

/// <summary>Wire contract for GetFlashFileUrlRequest.</summary>
public sealed record class MilkyGetFlashFileUrlRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FileId { get; set; }
}

/// <summary>Wire contract for GetFlashFileUrlResult.</summary>
public sealed record class MilkyGetFlashFileUrlResult
{
    /// <summary>Gets or sets download_url.</summary>
    [JsonPropertyName("download_url")]
    public string DownloadUrl { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupFileCountRequest.</summary>
public sealed record class MilkyGetGroupFileCountRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for GetGroupFileCountResult.</summary>
public sealed record class MilkyGetGroupFileCountResult
{
    /// <summary>Gets or sets file_count.</summary>
    [JsonPropertyName("file_count")]
    public uint FileCount { get; set; }
}

/// <summary>Wire contract for GetGroupFileDownloadUrlRequest.</summary>
public sealed record class MilkyGetGroupFileDownloadUrlRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupFilesRequest.</summary>
public sealed record class MilkyGetGroupFilesRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets parent_folder_id.</summary>
    [JsonPropertyName("parent_folder_id")]
    public string ParentFolderId { get; set; } = "/";
}

/// <summary>Wire contract for GetGroupFileSpaceRequest.</summary>
public sealed record class MilkyGetGroupFileSpaceRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for GetGroupFileSpaceResult.</summary>
public sealed record class MilkyGetGroupFileSpaceResult
{
    /// <summary>Gets or sets used_space.</summary>
    [JsonPropertyName("used_space")]
    public ulong UsedSpace { get; set; }
    /// <summary>Gets or sets total_space.</summary>
    [JsonPropertyName("total_space")]
    public ulong TotalSpace { get; set; }
    /// <summary>Gets or sets free_space.</summary>
    [JsonPropertyName("free_space")]
    public ulong FreeSpace { get; set; }
}

/// <summary>Wire contract for GetGroupFileUrlRequest.</summary>
public sealed record class MilkyGetGroupFileUrlRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupFileUrlResult.</summary>
public sealed record class MilkyGetGroupFileUrlResult
{
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupPttUrlRequest.</summary>
public sealed record class MilkyGetGroupPttUrlRequest
{
    /// <summary>Gets or sets resource_id.</summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupPttUrlResult.</summary>
public sealed record class MilkyGetGroupPttUrlResult
{
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupVideoUrlRequest.</summary>
public sealed record class MilkyGetGroupVideoUrlRequest
{
    /// <summary>Gets or sets resource_id.</summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupVideoUrlResult.</summary>
public sealed record class MilkyGetGroupVideoUrlResult
{
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetPrivatePttUrlRequest.</summary>
public sealed record class MilkyGetPrivatePttUrlRequest
{
    /// <summary>Gets or sets resource_id.</summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetPrivatePttUrlResult.</summary>
public sealed record class MilkyGetPrivatePttUrlResult
{
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetPrivateVideoUrlRequest.</summary>
public sealed record class MilkyGetPrivateVideoUrlRequest
{
    /// <summary>Gets or sets resource_id.</summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetPrivateVideoUrlResult.</summary>
public sealed record class MilkyGetPrivateVideoUrlResult
{
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetPrivateFileDownloadUrlRequest.</summary>
public sealed record class MilkyGetPrivateFileDownloadUrlRequest
{
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
}

/// <summary>Wire contract for ListFlashFilesetsRequest.</summary>
public sealed record class MilkyListFlashFilesetsRequest
{
    /// <summary>Gets or sets limit.</summary>
    [JsonPropertyName("limit")]
    public uint Limit { get; set; } = 10;
}

/// <summary>Wire contract for ListFlashFilesetsResult.</summary>
public sealed record class MilkyListFlashFilesetsResult
{
    /// <summary>Gets or sets files.</summary>
    [JsonPropertyName("files")]
    public MilkyListFlashFilesetsFlashFile[] Files { get; set; } = [];
}

/// <summary>Wire contract for ListFlashFilesetsFlashFile.</summary>
public sealed record class MilkyListFlashFilesetsFlashFile
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets file_size.</summary>
    [JsonPropertyName("file_size")]
    public ulong FileSize { get; set; }
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FileId { get; set; }
    /// <summary>Gets or sets download_url.</summary>
    [JsonPropertyName("download_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DownloadUrl { get; set; }
}

/// <summary>Wire contract for MoveGroupFileRequest.</summary>
public sealed record class MilkyMoveGroupFileRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
    /// <summary>Gets or sets parent_folder_id.</summary>
    [JsonPropertyName("parent_folder_id")]
    public string ParentFolderId { get; set; } = "/";
    /// <summary>Gets or sets target_folder_id.</summary>
    [JsonPropertyName("target_folder_id")]
    public string TargetFolderId { get; set; } = "/";
}

/// <summary>Wire contract for PublishGroupFileRequest.</summary>
public sealed record class MilkyPublishGroupFileRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
}

/// <summary>Wire contract for RenameFlashFileRequest.</summary>
public sealed record class MilkyRenameFlashFileRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets new_name.</summary>
    [JsonPropertyName("new_name")]
    public string NewName { get; set; } = string.Empty;
}

/// <summary>Wire contract for RenameGroupFileRequest.</summary>
public sealed record class MilkyRenameGroupFileRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
    /// <summary>Gets or sets parent_directory.</summary>
    [JsonPropertyName("parent_directory")]
    public string ParentDirectory { get; set; } = string.Empty;
    /// <summary>Gets or sets new_file_name.</summary>
    [JsonPropertyName("new_file_name")]
    public string NewFileName { get; set; } = string.Empty;
}

/// <summary>Wire contract for RenameGroupFolderRequest.</summary>
public sealed record class MilkyRenameGroupFolderRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets folder_id.</summary>
    [JsonPropertyName("folder_id")]
    public string FolderId { get; set; } = string.Empty;
    /// <summary>Gets or sets new_folder_name.</summary>
    [JsonPropertyName("new_folder_name")]
    public string NewFolderName { get; set; } = string.Empty;
}

/// <summary>Wire contract for SendFlashMessageRequest.</summary>
public sealed record class MilkySendFlashMessageRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? UserId { get; set; }
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? GroupId { get; set; }
}

/// <summary>Wire contract for SetFlashTaskStatusRequest.</summary>
public sealed record class MilkySetFlashTaskStatusRequest
{
    /// <summary>Gets or sets fileset_uuid.</summary>
    [JsonPropertyName("fileset_uuid")]
    public string FilesetUuid { get; set; } = string.Empty;
    /// <summary>Gets or sets status.</summary>
    [JsonPropertyName("status")]
    public uint Status { get; set; } = 6;
}

/// <summary>Wire contract for TransGroupFileRequest.</summary>
public sealed record class MilkyTransGroupFileRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets file_id.</summary>
    [JsonPropertyName("file_id")]
    public string FileId { get; set; } = string.Empty;
}

/// <summary>Wire contract for TransGroupFileResult.</summary>
public sealed record class MilkyTransGroupFileResult
{
    /// <summary>Gets or sets save_bus_id.</summary>
    [JsonPropertyName("save_bus_id")]
    public int SaveBusId { get; set; }
    /// <summary>Gets or sets save_file_path.</summary>
    [JsonPropertyName("save_file_path")]
    public string SaveFilePath { get; set; } = string.Empty;
}

/// <summary>Wire contract for UploadGroupFileRequest.</summary>
public sealed record class MilkyUploadGroupFileRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets file_uri.</summary>
    [JsonPropertyName("file_uri")]
    public string FileUri { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets parent_folder_id.</summary>
    [JsonPropertyName("parent_folder_id")]
    public string ParentFolderId { get; set; } = "/";
}

/// <summary>Wire contract for UploadPrivateFileRequest.</summary>
public sealed record class MilkyUploadPrivateFileRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets file_uri.</summary>
    [JsonPropertyName("file_uri")]
    public string FileUri { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
}

/// <summary>Wire contract for DeleteFriendRequest.</summary>
public sealed record class MilkyDeleteFriendRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets block.</summary>
    [JsonPropertyName("block")]
    public bool Block { get; set; } = false;
}

/// <summary>Wire contract for GetUnidirectionalFriendListResult.</summary>
public sealed record class MilkyGetUnidirectionalFriendListResult
{
    /// <summary>Gets or sets entries.</summary>
    [JsonPropertyName("entries")]
    public IReadOnlyList<IReadOnlyDictionary<string, string>> Entries { get; set; } = [];
}

/// <summary>Wire contract for HandleFriendRequestRequest.</summary>
public sealed record class MilkyHandleFriendRequestRequest
{
    /// <summary>Gets or sets flag.</summary>
    [JsonPropertyName("flag")]
    public string Flag { get; set; } = string.Empty;
    /// <summary>Gets or sets approve.</summary>
    [JsonPropertyName("approve")]
    public bool Approve { get; set; }
}

/// <summary>Wire contract for SendFriendNudgeRequest.</summary>
public sealed record class MilkySendFriendNudgeRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets is_self.</summary>
    [JsonPropertyName("is_self")]
    public bool IsSelf { get; set; } = false;
}

/// <summary>Wire contract for SetFriendCategoryRequest.</summary>
public sealed record class MilkySetFriendCategoryRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets category_id.</summary>
    [JsonPropertyName("category_id")]
    public int CategoryId { get; set; }
}

/// <summary>Wire contract for SetFriendRemarkRequest.</summary>
public sealed record class MilkySetFriendRemarkRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets remark.</summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; } = string.Empty;
}

/// <summary>Wire contract for AcceptGroupInvitationRequest.</summary>
public sealed record class MilkyAcceptGroupInvitationRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets invitation_seq.</summary>
    [JsonPropertyName("invitation_seq")]
    public long InvitationSeq { get; set; }
}

/// <summary>Wire contract for AcceptGroupRequestRequest.</summary>
public sealed record class MilkyAcceptGroupRequestRequest
{
    /// <summary>Gets or sets notification_seq.</summary>
    [JsonPropertyName("notification_seq")]
    public long NotificationSeq { get; set; }
    /// <summary>Gets or sets notification_type.</summary>
    [JsonPropertyName("notification_type")]
    public string NotificationType { get; set; } = string.Empty;
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets is_filtered.</summary>
    [JsonPropertyName("is_filtered")]
    public bool IsFiltered { get; set; } = false;
}

/// <summary>Wire contract for CancelGroupTodoRequest.</summary>
public sealed record class MilkyCancelGroupTodoRequest
{
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ulong? MessageSeq { get; set; }
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for CommentGroupAlbumMediaRequest.</summary>
public sealed record class MilkyCommentGroupAlbumMediaRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets media_id.</summary>
    [JsonPropertyName("media_id")]
    public string MediaId { get; set; } = string.Empty;
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}

/// <summary>Wire contract for CommentGroupAlbumMediaResult.</summary>
public sealed record class MilkyCommentGroupAlbumMediaResult
{
    /// <summary>Gets or sets comment_id.</summary>
    [JsonPropertyName("comment_id")]
    public string CommentId { get; set; } = string.Empty;
}

/// <summary>Wire contract for CompleteGroupTodoRequest.</summary>
public sealed record class MilkyCompleteGroupTodoRequest
{
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ulong? MessageSeq { get; set; }
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for DeleteGroupAlbumMediaRequest.</summary>
public sealed record class MilkyDeleteGroupAlbumMediaRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets media_id.</summary>
    [JsonPropertyName("media_id")]
    public string MediaId { get; set; } = string.Empty;
    /// <summary>Gets or sets batch_id.</summary>
    [JsonPropertyName("batch_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BatchId { get; set; } = null;
}

/// <summary>Wire contract for DeleteGroupAnnouncementRequest.</summary>
public sealed record class MilkyDeleteGroupAnnouncementRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets announcement_id.</summary>
    [JsonPropertyName("announcement_id")]
    public string AnnouncementId { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupAdminSettingsRequest.</summary>
public sealed record class MilkyGetGroupAdminSettingsRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for GetGroupAdminSettingsResult.</summary>
public sealed record class MilkyGetGroupAdminSettingsResult
{
    /// <summary>Gets or sets add_type.</summary>
    [JsonPropertyName("add_type")]
    public uint AddType { get; set; }
    /// <summary>Gets or sets group_question.</summary>
    [JsonPropertyName("group_question")]
    public string GroupQuestion { get; set; } = string.Empty;
    /// <summary>Gets or sets group_answer.</summary>
    [JsonPropertyName("group_answer")]
    public string GroupAnswer { get; set; } = string.Empty;
    /// <summary>Gets or sets member_invite_policy.</summary>
    [JsonPropertyName("member_invite_policy")]
    public string MemberInvitePolicy { get; set; } = string.Empty;
    /// <summary>Gets or sets new_member_history_visible.</summary>
    [JsonPropertyName("new_member_history_visible")]
    public bool NewMemberHistoryVisible { get; set; }
    /// <summary>Gets or sets robot_member_switch.</summary>
    [JsonPropertyName("robot_member_switch")]
    public uint RobotMemberSwitch { get; set; }
    /// <summary>Gets or sets robot_member_examine.</summary>
    [JsonPropertyName("robot_member_examine")]
    public uint RobotMemberExamine { get; set; }
}

/// <summary>Wire contract for GetGroupAlbumMediaRequest.</summary>
public sealed record class MilkyGetGroupAlbumMediaRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets attach_info.</summary>
    [JsonPropertyName("attach_info"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AttachInfo { get; set; } = null;
}

/// <summary>Wire contract for GetGroupAlbumMediaResult.</summary>
public sealed record class MilkyGetGroupAlbumMediaResult
{
    /// <summary>Gets or sets media.</summary>
    [JsonPropertyName("media")]
    public MilkyGetGroupAlbumMediaMedia[] Media { get; set; } = [];
    /// <summary>Gets or sets previous_cursor.</summary>
    [JsonPropertyName("previous_cursor")]
    public string PreviousCursor { get; set; } = string.Empty;
    /// <summary>Gets or sets next_cursor.</summary>
    [JsonPropertyName("next_cursor")]
    public string NextCursor { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupAlbumMediaMedia.</summary>
public sealed record class MilkyGetGroupAlbumMediaMedia
{
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
    /// <summary>Gets or sets id.</summary>
    [JsonPropertyName("id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
    /// <summary>Gets or sets cover_url.</summary>
    [JsonPropertyName("cover_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CoverUrl { get; set; }
    /// <summary>Gets or sets width.</summary>
    [JsonPropertyName("width")]
    public uint Width { get; set; }
    /// <summary>Gets or sets height.</summary>
    [JsonPropertyName("height")]
    public uint Height { get; set; }
    /// <summary>Gets or sets upload_time.</summary>
    [JsonPropertyName("upload_time")]
    public ulong UploadTime { get; set; }
}

/// <summary>Wire contract for GetGroupAlbumListRequest.</summary>
public sealed record class MilkyGetGroupAlbumListRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets attach_info.</summary>
    [JsonPropertyName("attach_info"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AttachInfo { get; set; } = null;
}

/// <summary>Wire contract for GetGroupAlbumListResult.</summary>
public sealed record class MilkyGetGroupAlbumListResult
{
    /// <summary>Gets or sets albums.</summary>
    [JsonPropertyName("albums")]
    public MilkyGetGroupAlbumListAlbum[] Albums { get; set; } = [];
    /// <summary>Gets or sets has_more.</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
    /// <summary>Gets or sets attach_info.</summary>
    [JsonPropertyName("attach_info")]
    public string AttachInfo { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupAlbumListAlbum.</summary>
public sealed record class MilkyGetGroupAlbumListAlbum
{
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets owner.</summary>
    [JsonPropertyName("owner")]
    public string Owner { get; set; } = string.Empty;
    /// <summary>Gets or sets name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    /// <summary>Gets or sets description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    /// <summary>Gets or sets create_time.</summary>
    [JsonPropertyName("create_time")]
    public ulong CreateTime { get; set; }
    /// <summary>Gets or sets modify_time.</summary>
    [JsonPropertyName("modify_time")]
    public ulong ModifyTime { get; set; }
    /// <summary>Gets or sets last_upload_time.</summary>
    [JsonPropertyName("last_upload_time")]
    public ulong LastUploadTime { get; set; }
    /// <summary>Gets or sets upload_number.</summary>
    [JsonPropertyName("upload_number")]
    public ulong UploadNumber { get; set; }
    /// <summary>Gets or sets cover_url.</summary>
    [JsonPropertyName("cover_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CoverUrl { get; set; }
}

/// <summary>Wire contract for GetGroupAnnouncementsRequest.</summary>
public sealed record class MilkyGetGroupAnnouncementsRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets start.</summary>
    [JsonPropertyName("start")]
    public int Start { get; set; } = -1;
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public int Count { get; set; } = 20;
}

/// <summary>Wire contract for GetGroupAtAllRemainRequest.</summary>
public sealed record class MilkyGetGroupAtAllRemainRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for GetGroupAtAllRemainResult.</summary>
public sealed record class MilkyGetGroupAtAllRemainResult
{
    /// <summary>Gets or sets can_at_all.</summary>
    [JsonPropertyName("can_at_all")]
    public bool CanAtAll { get; set; }
    /// <summary>Gets or sets remain_for_uin.</summary>
    [JsonPropertyName("remain_for_uin")]
    public uint RemainForUin { get; set; }
    /// <summary>Gets or sets remain_for_group.</summary>
    [JsonPropertyName("remain_for_group")]
    public uint RemainForGroup { get; set; }
}

/// <summary>Wire contract for GetGroupEssenceRequest.</summary>
public sealed record class MilkyGetGroupEssenceRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets page_start.</summary>
    [JsonPropertyName("page_start")]
    public int PageStart { get; set; } = 0;
    /// <summary>Gets or sets page_limit.</summary>
    [JsonPropertyName("page_limit")]
    public int PageLimit { get; set; } = 50;
}

/// <summary>Wire contract for GetGroupEssenceResult.</summary>
public sealed record class MilkyGetGroupEssenceResult
{
    /// <summary>Gets or sets messages.</summary>
    [JsonPropertyName("messages")]
    public MilkyGetGroupEssenceMessage[] Messages { get; set; } = [];
    /// <summary>Gets or sets is_end.</summary>
    [JsonPropertyName("is_end")]
    public bool IsEnd { get; set; }
    /// <summary>Gets or sets group_role.</summary>
    [JsonPropertyName("group_role")]
    public int GroupRole { get; set; }
}

/// <summary>Wire contract for GetGroupEssenceMessage.</summary>
public sealed record class MilkyGetGroupEssenceMessage
{
    /// <summary>Gets or sets group_code.</summary>
    [JsonPropertyName("group_code")]
    public string GroupCode { get; set; } = string.Empty;
    /// <summary>Gets or sets message_sequence.</summary>
    [JsonPropertyName("message_sequence")]
    public ulong MessageSequence { get; set; }
    /// <summary>Gets or sets message_random.</summary>
    [JsonPropertyName("message_random")]
    public uint MessageRandom { get; set; }
    /// <summary>Gets or sets sender_uin.</summary>
    [JsonPropertyName("sender_uin")]
    public string SenderUin { get; set; } = string.Empty;
    /// <summary>Gets or sets sender_nick.</summary>
    [JsonPropertyName("sender_nick")]
    public string SenderNick { get; set; } = string.Empty;
    /// <summary>Gets or sets sender_time.</summary>
    [JsonPropertyName("sender_time")]
    public long SenderTime { get; set; }
    /// <summary>Gets or sets add_digest_uin.</summary>
    [JsonPropertyName("add_digest_uin")]
    public string AddDigestUin { get; set; } = string.Empty;
    /// <summary>Gets or sets add_digest_nick.</summary>
    [JsonPropertyName("add_digest_nick")]
    public string AddDigestNick { get; set; } = string.Empty;
    /// <summary>Gets or sets add_digest_time.</summary>
    [JsonPropertyName("add_digest_time")]
    public long AddDigestTime { get; set; }
    /// <summary>Gets or sets can_be_removed.</summary>
    [JsonPropertyName("can_be_removed")]
    public bool CanBeRemoved { get; set; }
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }
}

/// <summary>Wire contract for GetGroupEssenceMessagesRequest.</summary>
public sealed record class MilkyGetGroupEssenceMessagesRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets page_start.</summary>
    [JsonPropertyName("page_start")]
    public int PageStart { get; set; } = 0;
    /// <summary>Gets or sets page_limit.</summary>
    [JsonPropertyName("page_limit")]
    public int PageLimit { get; set; } = 50;
}

/// <summary>Wire contract for GetGroupHonorRequest.</summary>
public sealed record class MilkyGetGroupHonorRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets honor_type.</summary>
    [JsonPropertyName("honor_type")]
    public string HonorType { get; set; } = "all";
}

/// <summary>Wire contract for GetGroupHonorResult.</summary>
public sealed record class MilkyGetGroupHonorResult
{
    /// <summary>Gets or sets honor_type.</summary>
    [JsonPropertyName("honor_type")]
    public string HonorType { get; set; } = string.Empty;
    /// <summary>Gets or sets items.</summary>
    [JsonPropertyName("items")]
    public MilkyGetGroupHonorItem[] Items { get; set; } = [];
}

/// <summary>Wire contract for GetGroupHonorItem.</summary>
public sealed record class MilkyGetGroupHonorItem
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? UserId { get; set; }
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets avatar.</summary>
    [JsonPropertyName("avatar")]
    public string Avatar { get; set; } = string.Empty;
    /// <summary>Gets or sets description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupNotificationsRequest.</summary>
public sealed record class MilkyGetGroupNotificationsRequest
{
    /// <summary>Gets or sets start_notification_seq.</summary>
    [JsonPropertyName("start_notification_seq"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? StartNotificationSeq { get; set; } = null;
    /// <summary>Gets or sets is_filtered.</summary>
    [JsonPropertyName("is_filtered")]
    public bool IsFiltered { get; set; } = false;
    /// <summary>Gets or sets limit.</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 20;
}

/// <summary>Wire contract for GetGroupSignInRequest.</summary>
public sealed record class MilkyGetGroupSignInRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets day.</summary>
    [JsonPropertyName("day"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? Day { get; set; } = null;
}

/// <summary>Wire contract for GetGroupSignInResult.</summary>
public sealed record class MilkyGetGroupSignInResult
{
    /// <summary>Gets or sets members.</summary>
    [JsonPropertyName("members")]
    public MilkyGetGroupSignInItem[] Members { get; set; } = [];
}

/// <summary>Wire contract for GetGroupSignInItem.</summary>
public sealed record class MilkyGetGroupSignInItem
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
    /// <summary>Gets or sets rank.</summary>
    [JsonPropertyName("rank")]
    public int Rank { get; set; }
}

/// <summary>Wire contract for GetGroupTodoRequest.</summary>
public sealed record class MilkyGetGroupTodoRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for GetGroupTodoResult.</summary>
public sealed record class MilkyGetGroupTodoResult
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
    /// <summary>Gets or sets preview.</summary>
    [JsonPropertyName("preview")]
    public string Preview { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupTodoListRequest.</summary>
public sealed record class MilkyGetGroupTodoListRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for GetGroupTodoListResult.</summary>
public sealed record class MilkyGetGroupTodoListResult
{
    /// <summary>Gets or sets items.</summary>
    [JsonPropertyName("items")]
    public IReadOnlyList<MilkyGetGroupTodoListItem> Items { get; set; } = [];
}

/// <summary>Wire contract for GetGroupTodoListItem.</summary>
public sealed record class MilkyGetGroupTodoListItem
{
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public ulong MessageSeq { get; set; }
    /// <summary>Gets or sets random.</summary>
    [JsonPropertyName("random")]
    public long Random { get; set; }
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
    /// <summary>Gets or sets created_at.</summary>
    [JsonPropertyName("created_at")]
    public ulong CreatedAt { get; set; }
    /// <summary>Gets or sets updated_at.</summary>
    [JsonPropertyName("updated_at")]
    public ulong UpdatedAt { get; set; }
}

/// <summary>Wire contract for KickGroupMemberRequest.</summary>
public sealed record class MilkyKickGroupMemberRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets reject_add_request.</summary>
    [JsonPropertyName("reject_add_request")]
    public bool RejectAddRequest { get; set; } = false;
}

/// <summary>Wire contract for QuitGroupRequest.</summary>
public sealed record class MilkyQuitGroupRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for RejectGroupInvitationRequest.</summary>
public sealed record class MilkyRejectGroupInvitationRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets invitation_seq.</summary>
    [JsonPropertyName("invitation_seq")]
    public long InvitationSeq { get; set; }
}

/// <summary>Wire contract for RejectGroupRequestRequest.</summary>
public sealed record class MilkyRejectGroupRequestRequest
{
    /// <summary>Gets or sets notification_seq.</summary>
    [JsonPropertyName("notification_seq")]
    public long NotificationSeq { get; set; }
    /// <summary>Gets or sets notification_type.</summary>
    [JsonPropertyName("notification_type")]
    public string NotificationType { get; set; } = string.Empty;
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets reason.</summary>
    [JsonPropertyName("reason"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Reason { get; set; }
    /// <summary>Gets or sets is_filtered.</summary>
    [JsonPropertyName("is_filtered")]
    public bool IsFiltered { get; set; } = false;
}

/// <summary>Wire contract for SendGroupAnnouncementRequest.</summary>
public sealed record class MilkySendGroupAnnouncementRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
    /// <summary>Gets or sets pinned.</summary>
    [JsonPropertyName("pinned")]
    public bool Pinned { get; set; } = false;
    /// <summary>Gets or sets send_to_new_members.</summary>
    [JsonPropertyName("send_to_new_members")]
    public bool SendToNewMembers { get; set; }
    /// <summary>Gets or sets show_edit_card.</summary>
    [JsonPropertyName("show_edit_card")]
    public bool ShowEditCard { get; set; } = true;
    /// <summary>Gets or sets show_popup.</summary>
    [JsonPropertyName("show_popup")]
    public bool ShowPopup { get; set; }
    /// <summary>Gets or sets confirm_required.</summary>
    [JsonPropertyName("confirm_required")]
    public bool ConfirmRequired { get; set; } = true;
    /// <summary>Gets or sets picture_id.</summary>
    [JsonPropertyName("picture_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PictureId { get; set; }
    /// <summary>Gets or sets image_width.</summary>
    [JsonPropertyName("image_width")]
    public int ImageWidth { get; set; } = 540;
    /// <summary>Gets or sets image_height.</summary>
    [JsonPropertyName("image_height")]
    public int ImageHeight { get; set; } = 300;
}

/// <summary>Wire contract for SendGroupMessageReactionRequest.</summary>
public sealed record class MilkySendGroupMessageReactionRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
    /// <summary>Gets or sets reaction.</summary>
    [JsonPropertyName("reaction")]
    public string Reaction { get; set; } = string.Empty;
    /// <summary>Gets or sets reaction_type.</summary>
    [JsonPropertyName("reaction_type")]
    public string ReactionType { get; set; } = "face";
    /// <summary>Gets or sets is_add.</summary>
    [JsonPropertyName("is_add")]
    public bool IsAdd { get; set; } = true;
}

/// <summary>Wire contract for SendGroupNudgeRequest.</summary>
public sealed record class MilkySendGroupNudgeRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}

/// <summary>Wire contract for SendGroupSignRequest.</summary>
public sealed record class MilkySendGroupSignRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for SendGroupSignResult.</summary>
public sealed record class MilkySendGroupSignResult
{
    /// <summary>Gets or sets is_success.</summary>
    [JsonPropertyName("is_success")]
    public bool IsSuccess { get; set; }
    /// <summary>Gets or sets title.</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    /// <summary>Gets or sets keep_day_text.</summary>
    [JsonPropertyName("keep_day_text")]
    public string KeepDayText { get; set; } = string.Empty;
    /// <summary>Gets or sets group_rank_text.</summary>
    [JsonPropertyName("group_rank_text")]
    public string GroupRankText { get; set; } = string.Empty;
    /// <summary>Gets or sets clock_in_time.</summary>
    [JsonPropertyName("clock_in_time")]
    public long ClockInTime { get; set; }
    /// <summary>Gets or sets detail_url.</summary>
    [JsonPropertyName("detail_url")]
    public string DetailUrl { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetGroupAddOptionRequest.</summary>
public sealed record class MilkySetGroupAddOptionRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets add_type.</summary>
    [JsonPropertyName("add_type")]
    public uint AddType { get; set; }
    /// <summary>Gets or sets group_question.</summary>
    [JsonPropertyName("group_question"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GroupQuestion { get; set; }
    /// <summary>Gets or sets group_answer.</summary>
    [JsonPropertyName("group_answer"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GroupAnswer { get; set; }
}

/// <summary>Wire contract for SetGroupAlbumLikeRequest.</summary>
public sealed record class MilkySetGroupAlbumLikeRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets batch_id.</summary>
    [JsonPropertyName("batch_id")]
    public string BatchId { get; set; } = string.Empty;
    /// <summary>Gets or sets media_id.</summary>
    [JsonPropertyName("media_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MediaId { get; set; } = null;
    /// <summary>Gets or sets is_like.</summary>
    [JsonPropertyName("is_like")]
    public bool IsLike { get; set; } = true;
}

/// <summary>Wire contract for SetGroupAvatarRequest.</summary>
public sealed record class MilkySetGroupAvatarRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets image_uri.</summary>
    [JsonPropertyName("image_uri")]
    public string ImageUri { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetGroupEssenceMessageRequest.</summary>
public sealed record class MilkySetGroupEssenceMessageRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
    /// <summary>Gets or sets is_set.</summary>
    [JsonPropertyName("is_set")]
    public bool IsSet { get; set; } = true;
}

/// <summary>Wire contract for SetGroupMemberInvitePolicyRequest.</summary>
public sealed record class MilkySetGroupMemberInvitePolicyRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets current_privilege_flag.</summary>
    [JsonPropertyName("current_privilege_flag")]
    public uint CurrentPrivilegeFlag { get; set; }
    /// <summary>Gets or sets policy.</summary>
    [JsonPropertyName("policy")]
    public string Policy { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetGroupMemberAdminRequest.</summary>
public sealed record class MilkySetGroupMemberAdminRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets is_set.</summary>
    [JsonPropertyName("is_set")]
    public bool IsSet { get; set; }
}

/// <summary>Wire contract for SetGroupMemberCardRequest.</summary>
public sealed record class MilkySetGroupMemberCardRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets card.</summary>
    [JsonPropertyName("card")]
    public string Card { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetGroupMemberMuteRequest.</summary>
public sealed record class MilkySetGroupMemberMuteRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets duration.</summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; } = 0;
}

/// <summary>Wire contract for SetGroupMemberPermissionRequest.</summary>
public sealed record class MilkySetGroupMemberPermissionRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets permission.</summary>
    [JsonPropertyName("permission")]
    public string Permission { get; set; } = string.Empty;
    /// <summary>Gets or sets allow.</summary>
    [JsonPropertyName("allow")]
    public bool Allow { get; set; }
    /// <summary>Gets or sets current_privilege_flag.</summary>
    [JsonPropertyName("current_privilege_flag")]
    public uint CurrentPrivilegeFlag { get; set; }
}

/// <summary>Wire contract for SetGroupMemberSpecialTitleRequest.</summary>
public sealed record class MilkySetGroupMemberSpecialTitleRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets special_title.</summary>
    [JsonPropertyName("special_title")]
    public string SpecialTitle { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetGroupNameRequest.</summary>
public sealed record class MilkySetGroupNameRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets new_group_name.</summary>
    [JsonPropertyName("new_group_name")]
    public string NewGroupName { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetGroupNewMemberHistoryVisibilityRequest.</summary>
public sealed record class MilkySetGroupNewMemberHistoryVisibilityRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets visible.</summary>
    [JsonPropertyName("visible")]
    public bool Visible { get; set; }
}

/// <summary>Wire contract for SetGroupRemarkRequest.</summary>
public sealed record class MilkySetGroupRemarkRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets remark.</summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetGroupRobotAddOptionRequest.</summary>
public sealed record class MilkySetGroupRobotAddOptionRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets robot_member_switch.</summary>
    [JsonPropertyName("robot_member_switch"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? MemberSwitch { get; set; }
    /// <summary>Gets or sets robot_member_examine.</summary>
    [JsonPropertyName("robot_member_examine"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? MemberExamine { get; set; }
}

/// <summary>Wire contract for SetGroupSearchRequest.</summary>
public sealed record class MilkySetGroupSearchRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets no_finger_open.</summary>
    [JsonPropertyName("no_finger_open"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? NoFingerOpen { get; set; }
    /// <summary>Gets or sets no_code_finger_open.</summary>
    [JsonPropertyName("no_code_finger_open"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? NoCodeFingerOpen { get; set; }
}

/// <summary>Wire contract for SetGroupTodoRequest.</summary>
public sealed record class MilkySetGroupTodoRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
}

/// <summary>Wire contract for SetGroupWholeMuteRequest.</summary>
public sealed record class MilkySetGroupWholeMuteRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets is_mute.</summary>
    [JsonPropertyName("is_mute")]
    public bool IsMute { get; set; } = true;
}

/// <summary>Wire contract for TransferGroupRequest.</summary>
public sealed record class MilkyTransferGroupRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}

/// <summary>Wire contract for UploadGroupAlbumImageRequest.</summary>
public sealed record class MilkyUploadGroupAlbumImageRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets image_uri.</summary>
    [JsonPropertyName("image_uri")]
    public string ImageUri { get; set; } = string.Empty;
    /// <summary>Gets or sets album_name.</summary>
    [JsonPropertyName("album_name")]
    public string AlbumName { get; set; } = "";
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = "image.jpg";
}

/// <summary>Wire contract for UploadGroupAlbumImageResult.</summary>
public sealed record class MilkyUploadGroupAlbumImageResult
{
    /// <summary>Gets or sets media_id.</summary>
    [JsonPropertyName("media_id")]
    public string MediaId { get; set; } = string.Empty;
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}

/// <summary>Wire contract for UploadGroupAlbumVideoRequest.</summary>
public sealed record class MilkyUploadGroupAlbumVideoRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets album_name.</summary>
    [JsonPropertyName("album_name")]
    public string AlbumName { get; set; } = string.Empty;
    /// <summary>Gets or sets video_uri.</summary>
    [JsonPropertyName("video_uri")]
    public string VideoUri { get; set; } = string.Empty;
    /// <summary>Gets or sets cover_uri.</summary>
    [JsonPropertyName("cover_uri")]
    public string CoverUri { get; set; } = string.Empty;
    /// <summary>Gets or sets duration_ms.</summary>
    [JsonPropertyName("duration_ms"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? DurationMilliseconds { get; set; }
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
}

/// <summary>Wire contract for UploadGroupAlbumVideoResult.</summary>
public sealed record class MilkyUploadGroupAlbumVideoResult
{
    /// <summary>Gets or sets video_id.</summary>
    [JsonPropertyName("video_id")]
    public string VideoId { get; set; } = string.Empty;
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets cover_id.</summary>
    [JsonPropertyName("cover_id")]
    public string CoverId { get; set; } = string.Empty;
    /// <summary>Gets or sets cover_url.</summary>
    [JsonPropertyName("cover_url")]
    public string CoverUrl { get; set; } = string.Empty;
}

/// <summary>Wire contract for UploadGroupAnnouncementImageRequest.</summary>
public sealed record class MilkyUploadGroupAnnouncementImageRequest
{
    /// <summary>Gets or sets image_uri.</summary>
    [JsonPropertyName("image_uri")]
    public string ImageUri { get; set; } = string.Empty;
}

/// <summary>Wire contract for UploadGroupAnnouncementImageResult.</summary>
public sealed record class MilkyUploadGroupAnnouncementImageResult
{
    /// <summary>Gets or sets id.</summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    /// <summary>Gets or sets width.</summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }
    /// <summary>Gets or sets height.</summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }
}

/// <summary>Wire contract for ClickInlineKeyboardButtonRequest.</summary>
public sealed record class MilkyClickInlineKeyboardButtonRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets app_id.</summary>
    [JsonPropertyName("app_id")]
    public ulong AppId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public ulong MessageSeq { get; set; }
    /// <summary>Gets or sets button_id.</summary>
    [JsonPropertyName("button_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ButtonId { get; set; }
    /// <summary>Gets or sets callback_data.</summary>
    [JsonPropertyName("callback_data"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CallbackData { get; set; }
}

/// <summary>Wire contract for ClickInlineKeyboardButtonResult.</summary>
public sealed record class MilkyClickInlineKeyboardButtonResult
{
    /// <summary>Gets or sets prompt_text.</summary>
    [JsonPropertyName("prompt_text")]
    public string PromptText { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetEmojiLikesRequest.</summary>
public sealed record class MilkyGetEmojiLikesRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
    /// <summary>Gets or sets code.</summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;
    /// <summary>Gets or sets cookie.</summary>
    [JsonPropertyName("cookie")]
    public string Cookie { get; set; } = "";
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public int Count { get; set; } = 20;
}

/// <summary>Wire contract for GetEmojiLikesResult.</summary>
public sealed record class MilkyGetEmojiLikesResult
{
    /// <summary>Gets or sets users.</summary>
    [JsonPropertyName("users")]
    public IReadOnlyList<MilkyGetEmojiLikesLikeUser> Users { get; set; } = [];
    /// <summary>Gets or sets cookie.</summary>
    [JsonPropertyName("cookie")]
    public string Cookie { get; set; } = string.Empty;
    /// <summary>Gets or sets is_last.</summary>
    [JsonPropertyName("is_last")]
    public bool IsLast { get; set; }
}

/// <summary>Wire contract for GetEmojiLikesLikeUser.</summary>
public sealed record class MilkyGetEmojiLikesLikeUser
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets head_url.</summary>
    [JsonPropertyName("head_url")]
    public string HeadUrl { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupReactionSummaryRequest.</summary>
public sealed record class MilkyGetGroupReactionSummaryRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
}

/// <summary>Wire contract for GetGroupReactionSummaryResult.</summary>
public sealed record class MilkyGetGroupReactionSummaryResult
{
    /// <summary>Gets or sets entries.</summary>
    [JsonPropertyName("entries")]
    public IReadOnlyList<MilkyGetGroupReactionSummaryEntry> Entries { get; set; } = [];
}

/// <summary>Wire contract for GetGroupReactionSummaryEntry.</summary>
public sealed record class MilkyGetGroupReactionSummaryEntry
{
    /// <summary>Gets or sets emoji_id.</summary>
    [JsonPropertyName("emoji_id")]
    public string EmojiId { get; set; } = string.Empty;
    /// <summary>Gets or sets emoji_type.</summary>
    [JsonPropertyName("emoji_type")]
    public uint EmojiType { get; set; }
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; }
    /// <summary>Gets or sets last_reaction_time.</summary>
    [JsonPropertyName("last_reaction_time")]
    public ulong LastReactionTime { get; set; }
}

/// <summary>Wire contract for SendLikeRequest.</summary>
public sealed record class MilkySendLikeRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public int Count { get; set; } = 1;
}

/// <summary>Wire contract for SendPokeRequest.</summary>
public sealed record class MilkySendPokeRequest
{
    /// <summary>Gets or sets message_scene.</summary>
    [JsonPropertyName("message_scene")]
    public string MessageScene { get; set; } = string.Empty;
    /// <summary>Gets or sets peer_id.</summary>
    [JsonPropertyName("peer_id")]
    public long PeerId { get; set; }
    /// <summary>Gets or sets target_user_id.</summary>
    [JsonPropertyName("target_user_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? TargetUserId { get; set; } = null;
}

/// <summary>Wire contract for SetGroupReactionRequest.</summary>
public sealed record class MilkySetGroupReactionRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
    /// <summary>Gets or sets code.</summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;
    /// <summary>Gets or sets is_set.</summary>
    [JsonPropertyName("is_set")]
    public bool IsSet { get; set; } = true;
}

/// <summary>Wire contract for SetInputStatusRequest.</summary>
public sealed record class MilkySetInputStatusRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets event_type.</summary>
    [JsonPropertyName("event_type")]
    public int EventType { get; set; }
}

/// <summary>Wire contract for GetAiVoiceListRequest.</summary>
public sealed record class MilkyGetAiVoiceListRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets chat_type.</summary>
    [JsonPropertyName("chat_type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? ChatType { get; set; }
}

/// <summary>Wire contract for GetAiVoiceListResult.</summary>
public sealed record class MilkyGetAiVoiceListResult
{
    /// <summary>Gets or sets categories.</summary>
    [JsonPropertyName("categories")]
    public IReadOnlyList<MilkyGetAiVoiceListCategory> Categories { get; set; } = [];
}

/// <summary>Wire contract for GetAiVoiceListCategory.</summary>
public sealed record class MilkyGetAiVoiceListCategory
{
    /// <summary>Gets or sets name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    /// <summary>Gets or sets voices.</summary>
    [JsonPropertyName("voices")]
    public IReadOnlyList<MilkyGetAiVoiceListVoice> Voices { get; set; } = [];
}

/// <summary>Wire contract for GetAiVoiceListVoice.</summary>
public sealed record class MilkyGetAiVoiceListVoice
{
    /// <summary>Gets or sets id.</summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    /// <summary>Gets or sets name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    /// <summary>Gets or sets example_url.</summary>
    [JsonPropertyName("example_url")]
    public string ExampleUrl { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetCollectionRequest.</summary>
public sealed record class MilkyGetCollectionRequest
{
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; } = 50;
}

/// <summary>Wire contract for GetCollectionResult.</summary>
public sealed record class MilkyGetCollectionResult
{
    /// <summary>Gets or sets items.</summary>
    [JsonPropertyName("items")]
    public MilkyGetCollectionItem[] Items { get; set; } = [];
    /// <summary>Gets or sets total_count.</summary>
    [JsonPropertyName("total_count")]
    public uint TotalCount { get; set; }
    /// <summary>Gets or sets reached_bottom.</summary>
    [JsonPropertyName("reached_bottom")]
    public bool ReachedBottom { get; set; }
}

/// <summary>Wire contract for GetCollectionItem.</summary>
public sealed record class MilkyGetCollectionItem
{
    /// <summary>Gets or sets id.</summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type")]
    public uint Type { get; set; }
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }
    /// <summary>Gets or sets share_url.</summary>
    [JsonPropertyName("share_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ShareUrl { get; set; }
    /// <summary>Gets or sets create_time.</summary>
    [JsonPropertyName("create_time")]
    public ulong CreateTime { get; set; }
    /// <summary>Gets or sets collect_time.</summary>
    [JsonPropertyName("collect_time")]
    public ulong CollectTime { get; set; }
    /// <summary>Gets or sets modify_time.</summary>
    [JsonPropertyName("modify_time")]
    public ulong ModifyTime { get; set; }
    /// <summary>Gets or sets author_uid.</summary>
    [JsonPropertyName("author_uid"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AuthorUid { get; set; }
    /// <summary>Gets or sets author_uin.</summary>
    [JsonPropertyName("author_uin")]
    public long AuthorUin { get; set; }
}

/// <summary>Wire contract for GetForwardedMessagesRequest.</summary>
public sealed record class MilkyGetForwardedMessagesRequest
{
    /// <summary>Gets or sets forward_id.</summary>
    [JsonPropertyName("forward_id")]
    public string ForwardId { get; set; } = string.Empty;
    /// <summary>Gets or sets message_scene.</summary>
    [JsonPropertyName("message_scene")]
    public string MessageScene { get; set; } = "friend";
}

/// <summary>Wire contract for GetHistoryMessagesRequest.</summary>
public sealed record class MilkyGetHistoryMessagesRequest
{
    /// <summary>Gets or sets message_scene.</summary>
    [JsonPropertyName("message_scene")]
    public string MessageScene { get; set; } = string.Empty;
    /// <summary>Gets or sets peer_id.</summary>
    [JsonPropertyName("peer_id")]
    public long PeerId { get; set; }
    /// <summary>Gets or sets start_message_seq.</summary>
    [JsonPropertyName("start_message_seq"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? StartMessageSeq { get; set; } = null;
    /// <summary>Gets or sets limit.</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 20;
}

/// <summary>Wire contract for GetMessageRequest.</summary>
public sealed record class MilkyGetMessageRequest
{
    /// <summary>Gets or sets message_scene.</summary>
    [JsonPropertyName("message_scene")]
    public string MessageScene { get; set; } = string.Empty;
    /// <summary>Gets or sets peer_id.</summary>
    [JsonPropertyName("peer_id")]
    public long PeerId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
}

/// <summary>Wire contract for GetResourceTempUrlRequest.</summary>
public sealed record class MilkyGetResourceTempUrlRequest
{
    /// <summary>Gets or sets resource_id.</summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; } = string.Empty;
}

/// <summary>Wire contract for ProbeHistorySyncStateRequest.</summary>
public sealed record class MilkyProbeHistorySyncStateRequest
{
    /// <summary>Gets or sets group_ids.</summary>
    [JsonPropertyName("group_ids")]
    public IReadOnlyList<long> GroupIds { get; set; } = [];
    /// <summary>Gets or sets private_targets.</summary>
    [JsonPropertyName("private_targets")]
    public IReadOnlyList<MilkyProbeHistorySyncStatePrivateTarget> PrivateTargets { get; set; } = [];
}

/// <summary>Wire contract for ProbeHistorySyncStatePrivateTarget.</summary>
public sealed record class MilkyProbeHistorySyncStatePrivateTarget
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets uid.</summary>
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
}

/// <summary>Wire contract for ProbeHistorySyncStateResult.</summary>
public sealed record class MilkyProbeHistorySyncStateResult
{
    /// <summary>Gets or sets groups.</summary>
    [JsonPropertyName("groups")]
    public IReadOnlyList<MilkyProbeHistorySyncStateGroupState> Groups { get; set; } = [];
    /// <summary>Gets or sets private_users.</summary>
    [JsonPropertyName("private_users")]
    public IReadOnlyList<MilkyProbeHistorySyncStatePrivateState> PrivateUsers { get; set; } = [];
}

/// <summary>Wire contract for ProbeHistorySyncStateGroupState.</summary>
public sealed record class MilkyProbeHistorySyncStateGroupState
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets read_seq.</summary>
    [JsonPropertyName("read_seq")]
    public ulong ReadSequence { get; set; }
    /// <summary>Gets or sets latest_seq.</summary>
    [JsonPropertyName("latest_seq")]
    public ulong LatestSequence { get; set; }
}

/// <summary>Wire contract for ProbeHistorySyncStatePrivateState.</summary>
public sealed record class MilkyProbeHistorySyncStatePrivateState
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets uid.</summary>
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
    /// <summary>Gets or sets read_seq.</summary>
    [JsonPropertyName("read_seq")]
    public ulong ReadSequence { get; set; }
    /// <summary>Gets or sets latest_seq.</summary>
    [JsonPropertyName("latest_seq")]
    public ulong LatestSequence { get; set; }
    /// <summary>Gets or sets last_message_time.</summary>
    [JsonPropertyName("last_message_time")]
    public ulong LastMessageTime { get; set; }
}

/// <summary>Wire contract for GetHistorySyncPageRequest.</summary>
public sealed record class MilkyGetHistorySyncPageRequest
{
    /// <summary>Gets or sets message_scene.</summary>
    [JsonPropertyName("message_scene"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MessageScene { get; set; }
    /// <summary>Gets or sets peer_id.</summary>
    [JsonPropertyName("peer_id")]
    public long PeerId { get; set; }
    /// <summary>Gets or sets next_seq.</summary>
    [JsonPropertyName("next_seq")]
    public ulong NextSequence { get; set; }
    /// <summary>Gets or sets latest_seq.</summary>
    [JsonPropertyName("latest_seq")]
    public ulong LatestSequence { get; set; }
    /// <summary>Gets or sets limit.</summary>
    [JsonPropertyName("limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? Limit { get; set; }
}

/// <summary>Wire contract for GetHistorySyncPageResult.</summary>
public sealed record class MilkyGetHistorySyncPageResult
{
    /// <summary>Gets or sets messages.</summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<MilkyIncomingMessage> Messages { get; set; } = [];
    /// <summary>Gets or sets next_seq.</summary>
    [JsonPropertyName("next_seq"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ulong? NextSequence { get; set; }
    /// <summary>Gets or sets is_complete.</summary>
    [JsonPropertyName("is_complete")]
    public bool IsComplete { get; set; }
}

/// <summary>Wire contract for GetPrivateHistoryRoamPageRequest.</summary>
public sealed record class MilkyGetPrivateHistoryRoamPageRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public uint Time { get; set; }
    /// <summary>Gets or sets random.</summary>
    [JsonPropertyName("random")]
    public uint Random { get; set; }
    /// <summary>Gets or sets limit.</summary>
    [JsonPropertyName("limit"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? Limit { get; set; }
}

/// <summary>Wire contract for GetPrivateHistoryRoamPageResult.</summary>
public sealed record class MilkyGetPrivateHistoryRoamPageResult
{
    /// <summary>Gets or sets messages.</summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<MilkyIncomingMessage> Messages { get; set; } = [];
    /// <summary>Gets or sets next_cursor.</summary>
    [JsonPropertyName("next_cursor"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MilkyGetPrivateHistoryRoamPageCursor? NextCursor { get; set; }
    /// <summary>Gets or sets is_complete.</summary>
    [JsonPropertyName("is_complete")]
    public bool IsComplete { get; set; }
}

/// <summary>Wire contract for GetPrivateHistoryRoamPageCursor.</summary>
public sealed record class MilkyGetPrivateHistoryRoamPageCursor
{
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public uint Time { get; set; }
    /// <summary>Gets or sets random.</summary>
    [JsonPropertyName("random")]
    public uint Random { get; set; }
}

/// <summary>Wire contract for MarkAllReadRequest.</summary>
public sealed record class MilkyMarkAllReadRequest
{
    /// <summary>Gets or sets group_ids.</summary>
    [JsonPropertyName("group_ids"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<long>? GroupIds { get; set; }
    /// <summary>Gets or sets private_user_ids.</summary>
    [JsonPropertyName("private_user_ids"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<long>? PrivateUserIds { get; set; }
}

/// <summary>Wire contract for MarkMessageAsReadRequest.</summary>
public sealed record class MilkyMarkMessageAsReadRequest
{
    /// <summary>Gets or sets message_scene.</summary>
    [JsonPropertyName("message_scene")]
    public string MessageScene { get; set; } = string.Empty;
    /// <summary>Gets or sets peer_id.</summary>
    [JsonPropertyName("peer_id")]
    public long PeerId { get; set; }
    /// <summary>Gets or sets last_read_seq.</summary>
    [JsonPropertyName("last_read_seq")]
    public ulong LastReadSeq { get; set; }
}

/// <summary>Wire contract for RecallGroupMessageRequest.</summary>
public sealed record class MilkyRecallGroupMessageRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
}

/// <summary>Wire contract for RecallPrivateMessageRequest.</summary>
public sealed record class MilkyRecallPrivateMessageRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
}

/// <summary>Wire contract for SendAiVoiceRequest.</summary>
public sealed record class MilkySendAiVoiceRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets voice_id.</summary>
    [JsonPropertyName("voice_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? VoiceId { get; set; }
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }
    /// <summary>Gets or sets chat_type.</summary>
    [JsonPropertyName("chat_type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? ChatType { get; set; }
}

/// <summary>Wire contract for SendAiVoiceResult.</summary>
public sealed record class MilkySendAiVoiceResult
{
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public ulong MessageSeq { get; set; }
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
}

/// <summary>Wire contract for SendGroupMessageRequest.</summary>
public sealed record class MilkySendGroupMessageRequest
{
    /// <summary>Gets or sets message_style.</summary>
    [JsonPropertyName("message_style"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MilkyMessageStyle? MessageStyle { get; set; }
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message.</summary>
    [JsonPropertyName("message")]
    public IReadOnlyList<MilkyOutgoingSegment> Message { get; set; } = [];
}

/// <summary>Wire contract for MessageStyle.</summary>
public sealed record class MilkyMessageStyle
{
    /// <summary>Gets or sets bubble_id.</summary>
    [JsonPropertyName("bubble_id")]
    public ulong BubbleId { get; set; }
    /// <summary>Gets or sets pendant_id.</summary>
    [JsonPropertyName("pendant_id")]
    public ulong PendantId { get; set; }
    /// <summary>Gets or sets font_id.</summary>
    [JsonPropertyName("font_id")]
    public ushort FontId { get; set; }
    /// <summary>Gets or sets font_effect_id.</summary>
    [JsonPropertyName("font_effect_id")]
    public uint FontEffectId { get; set; }
    /// <summary>Gets or sets is_cs_font_effect_enabled.</summary>
    [JsonPropertyName("is_cs_font_effect_enabled")]
    public bool IsCsFontEffectEnabled { get; set; }
    /// <summary>Gets or sets bubble_diy_text_id.</summary>
    [JsonPropertyName("bubble_diy_text_id")]
    public uint BubbleDiyTextId { get; set; }
}

/// <summary>Wire contract for SendPrivateMessageRequest.</summary>
public sealed record class MilkySendPrivateMessageRequest
{
    /// <summary>Gets or sets message_style.</summary>
    [JsonPropertyName("message_style"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MilkyMessageStyle? MessageStyle { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets message.</summary>
    [JsonPropertyName("message")]
    public IReadOnlyList<MilkyOutgoingSegment> Message { get; set; } = [];
}

/// <summary>Wire contract for SendTempMessageRequest.</summary>
public sealed record class MilkySendTempMessageRequest
{
    /// <summary>Gets or sets message_style.</summary>
    [JsonPropertyName("message_style"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MilkyMessageStyle? MessageStyle { get; set; }
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets message.</summary>
    [JsonPropertyName("message")]
    public IReadOnlyList<MilkyOutgoingSegment> Message { get; set; } = [];
}

/// <summary>Wire contract for SendTempMessageResult.</summary>
public sealed record class MilkySendTempMessageResult
{
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
}

/// <summary>Wire contract for SynthesizeAiVoiceRequest.</summary>
public sealed record class MilkySynthesizeAiVoiceRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets voice_id.</summary>
    [JsonPropertyName("voice_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? VoiceId { get; set; }
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }
    /// <summary>Gets or sets chat_type.</summary>
    [JsonPropertyName("chat_type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? ChatType { get; set; }
}

/// <summary>Wire contract for SynthesizeAiVoiceResult.</summary>
public sealed record class MilkySynthesizeAiVoiceResult
{
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
    /// <summary>Gets or sets resource_id.</summary>
    [JsonPropertyName("resource_id")]
    public string ResourceId { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets file_size.</summary>
    [JsonPropertyName("file_size")]
    public uint Size { get; set; }
    /// <summary>Gets or sets duration.</summary>
    [JsonPropertyName("duration")]
    public uint Duration { get; set; }
    /// <summary>Gets or sets format.</summary>
    [JsonPropertyName("format")]
    public uint Format { get; set; }
}

/// <summary>Wire contract for TranscribeVoiceRequest.</summary>
public sealed record class MilkyTranscribeVoiceRequest
{
    /// <summary>Gets or sets message_scene.</summary>
    [JsonPropertyName("message_scene")]
    public string MessageScene { get; set; } = string.Empty;
    /// <summary>Gets or sets peer_id.</summary>
    [JsonPropertyName("peer_id")]
    public long PeerId { get; set; }
    /// <summary>Gets or sets message_seq.</summary>
    [JsonPropertyName("message_seq")]
    public long MessageSeq { get; set; }
}

/// <summary>Wire contract for TranscribeVoiceResult.</summary>
public sealed record class MilkyTranscribeVoiceResult
{
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}

/// <summary>Wire contract for AddCustomFaceRequest.</summary>
public sealed record class MilkyAddCustomFaceRequest
{
    /// <summary>Gets or sets image_uri.</summary>
    [JsonPropertyName("image_uri")]
    public string ImageUri { get; set; } = string.Empty;
}

/// <summary>Wire contract for AddCustomFaceResult.</summary>
public sealed record class MilkyAddCustomFaceResult
{
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; set; } = string.Empty;
}

/// <summary>Wire contract for CommentQzoneMessageRequest.</summary>
public sealed record class MilkyCommentQzoneMessageRequest
{
    /// <summary>Gets or sets target_uin.</summary>
    [JsonPropertyName("target_uin")]
    public long TargetUin { get; set; }
    /// <summary>Gets or sets message_id.</summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = string.Empty;
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}

/// <summary>Wire contract for CommentQzoneMessageResult.</summary>
public sealed record class MilkyCommentQzoneMessageResult
{
    /// <summary>Gets or sets comment_id.</summary>
    [JsonPropertyName("comment_id")]
    public string CommentId { get; set; } = string.Empty;
}

/// <summary>Wire contract for DeleteCustomFaceRequest.</summary>
public sealed record class MilkyDeleteCustomFaceRequest
{
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; set; } = string.Empty;
}

/// <summary>Wire contract for DeleteQzoneMessageRequest.</summary>
public sealed record class MilkyDeleteQzoneMessageRequest
{
    /// <summary>Gets or sets message_id.</summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupSystemMsgRequest.</summary>
public sealed record class MilkyGetGroupSystemMsgRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets message_type.</summary>
    [JsonPropertyName("message_type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MessageType { get; set; }
}

/// <summary>Wire contract for GetGroupSystemMsgResult.</summary>
public sealed record class MilkyGetGroupSystemMsgResult
{
    /// <summary>Gets or sets messages.</summary>
    [JsonPropertyName("messages")]
    public IReadOnlyList<MilkyGroupNotification> Messages { get; set; } = [];
}

/// <summary>Wire contract for GetGroupShutListRequest.</summary>
public sealed record class MilkyGetGroupShutListRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for GetGroupShutListResult.</summary>
public sealed record class MilkyGetGroupShutListResult
{
    /// <summary>Gets or sets members.</summary>
    [JsonPropertyName("members")]
    public IReadOnlyList<MilkyGetGroupShutListMember> Members { get; set; } = [];
}

/// <summary>Wire contract for GetGroupShutListMember.</summary>
public sealed record class MilkyGetGroupShutListMember
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets shut_up_timestamp.</summary>
    [JsonPropertyName("shut_up_timestamp")]
    public long ShutUpTimestamp { get; set; }
}

/// <summary>Wire contract for GetDoubtFriendsAddRequestResult.</summary>
public sealed record class MilkyGetDoubtFriendsAddRequestResult
{
    /// <summary>Gets or sets requests.</summary>
    [JsonPropertyName("requests")]
    public IReadOnlyList<MilkyGetDoubtFriendsAddRequestItem> Requests { get; set; } = [];
}

/// <summary>Wire contract for GetDoubtFriendsAddRequestItem.</summary>
public sealed record class MilkyGetDoubtFriendsAddRequestItem
{
    /// <summary>Gets or sets uid.</summary>
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets nick.</summary>
    [JsonPropertyName("nick")]
    public string Nick { get; set; } = string.Empty;
    /// <summary>Gets or sets source.</summary>
    [JsonPropertyName("source")]
    public string Source { get; set; } = string.Empty;
    /// <summary>Gets or sets reason.</summary>
    [JsonPropertyName("reason")]
    public string Reason { get; set; } = string.Empty;
    /// <summary>Gets or sets message.</summary>
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
    /// <summary>Gets or sets group_code.</summary>
    [JsonPropertyName("group_code")]
    public string GroupCode { get; set; } = string.Empty;
    /// <summary>Gets or sets request_time.</summary>
    [JsonPropertyName("request_time")]
    public long RequestTime { get; set; }
}

/// <summary>Wire contract for SetDoubtFriendsAddRequestRequest.</summary>
public sealed record class MilkySetDoubtFriendsAddRequestRequest
{
    /// <summary>Gets or sets request_id.</summary>
    [JsonPropertyName("request_id")]
    public string RequestId { get; set; } = string.Empty;
    /// <summary>Gets or sets approve.</summary>
    [JsonPropertyName("approve")]
    public bool Approve { get; set; }
}

/// <summary>Wire contract for GetQidianCorpInfoRequest.</summary>
public sealed record class MilkyGetQidianCorpInfoRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}

/// <summary>Wire contract for GetQidianCorpInfoResult.</summary>
public sealed record class MilkyGetQidianCorpInfoResult
{
    /// <summary>Gets or sets info.</summary>
    [JsonPropertyName("info")]
    public MilkyGetQidianCorpInfoCorp Info { get; set; } = null!;
}

/// <summary>Wire contract for GetQidianCorpInfoCorp.</summary>
public sealed record class MilkyGetQidianCorpInfoCorp
{
    /// <summary>Gets or sets name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    /// <summary>Gets or sets intro.</summary>
    [JsonPropertyName("intro")]
    public string Intro { get; set; } = string.Empty;
    /// <summary>Gets or sets website.</summary>
    [JsonPropertyName("website")]
    public string Website { get; set; } = string.Empty;
    /// <summary>Gets or sets slogan.</summary>
    [JsonPropertyName("slogan")]
    public string Slogan { get; set; } = string.Empty;
    /// <summary>Gets or sets address.</summary>
    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;
    /// <summary>Gets or sets phone.</summary>
    [JsonPropertyName("phone")]
    public string Phone { get; set; } = string.Empty;
    /// <summary>Gets or sets email.</summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
}

/// <summary>Wire contract for SendArkShareRequest.</summary>
public sealed record class MilkySendArkShareRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? GroupId { get; set; }
}

/// <summary>Wire contract for SendArkShareResult.</summary>
public sealed record class MilkySendArkShareResult
{
    /// <summary>Gets or sets ark.</summary>
    [JsonPropertyName("ark"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Ark { get; set; }
}

/// <summary>Wire contract for SendTuwenArkRequest.</summary>
public sealed record class MilkySendTuwenArkRequest
{
    /// <summary>Gets or sets peer_id.</summary>
    [JsonPropertyName("peer_id")]
    public long PeerId { get; set; }
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? GroupId { get; set; }
    /// <summary>Gets or sets title.</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    /// <summary>Gets or sets description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    /// <summary>Gets or sets summary.</summary>
    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
    /// <summary>Gets or sets preview_url.</summary>
    [JsonPropertyName("preview_url")]
    public string PreviewUrl { get; set; } = string.Empty;
}

/// <summary>Wire contract for SendTuwenArkResult.</summary>
public sealed record class MilkySendTuwenArkResult
{
    /// <summary>Gets or sets message_id.</summary>
    [JsonPropertyName("message_id")]
    public long MessageId { get; set; }
}

/// <summary>Wire contract for GetCookiesRequest.</summary>
public sealed record class MilkyGetCookiesRequest
{
    /// <summary>Gets or sets domains.</summary>
    [JsonPropertyName("domains")]
    public IReadOnlyList<string> Domains { get; set; } = [];
}

/// <summary>Wire contract for GetCustomFaceDetailRequest.</summary>
public sealed record class MilkyGetCustomFaceDetailRequest
{
    /// <summary>Gets or sets entries.</summary>
    [JsonPropertyName("entries")]
    public IReadOnlyList<MilkyGetCustomFaceDetailFaceEntry> Entries { get; set; } = [];
}

/// <summary>Wire contract for GetCustomFaceDetailFaceEntry.</summary>
public sealed record class MilkyGetCustomFaceDetailFaceEntry
{
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; set; } = string.Empty;
    /// <summary>Gets or sets md5.</summary>
    [JsonPropertyName("md5")]
    public string Md5 { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetCustomFaceDetailResult.</summary>
public sealed record class MilkyGetCustomFaceDetailResult
{
    /// <summary>Gets or sets entries.</summary>
    [JsonPropertyName("entries")]
    public IReadOnlyList<MilkyGetCustomFaceDetailDetail> Entries { get; set; } = [];
}

/// <summary>Wire contract for GetCustomFaceDetailDetail.</summary>
public sealed record class MilkyGetCustomFaceDetailDetail
{
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; set; } = string.Empty;
    /// <summary>Gets or sets description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetCustomFaceListResult.</summary>
public sealed record class MilkyGetCustomFaceListResult
{
    /// <summary>Gets or sets face_ids.</summary>
    [JsonPropertyName("face_ids")]
    public IReadOnlyList<string> FaceIds { get; set; } = [];
    /// <summary>Gets or sets total_count.</summary>
    [JsonPropertyName("total_count")]
    public uint TotalCount { get; set; }
}

/// <summary>Wire contract for GetFriendDressRequest.</summary>
public sealed record class MilkyGetFriendDressRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? UserId { get; set; } = null;
    /// <summary>Gets or sets target_uin.</summary>
    [JsonPropertyName("target_uin"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? TargetUin { get; set; } = null;
}

/// <summary>Wire contract for GetFriendDressResult.</summary>
public sealed record class MilkyGetFriendDressResult
{
    /// <summary>Gets or sets target_uin.</summary>
    [JsonPropertyName("target_uin")]
    public string TargetUin { get; set; } = string.Empty;
    /// <summary>Gets or sets is_svip.</summary>
    [JsonPropertyName("is_svip")]
    public bool IsSvip { get; set; }
    /// <summary>Gets or sets avatar_url.</summary>
    [JsonPropertyName("avatar_url")]
    public string AvatarUrl { get; set; } = string.Empty;
    /// <summary>Gets or sets items.</summary>
    [JsonPropertyName("items")]
    public MilkyGetFriendDressItem[] Items { get; set; } = [];
}

/// <summary>Wire contract for GetFriendDressItem.</summary>
public sealed record class MilkyGetFriendDressItem
{
    /// <summary>Gets or sets app_id.</summary>
    [JsonPropertyName("app_id")]
    public int AppId { get; set; }
    /// <summary>Gets or sets kind.</summary>
    [JsonPropertyName("kind")]
    public string Kind { get; set; } = string.Empty;
    /// <summary>Gets or sets item_id.</summary>
    [JsonPropertyName("item_id")]
    public int ItemId { get; set; }
    /// <summary>Gets or sets name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    /// <summary>Gets or sets preview_url.</summary>
    [JsonPropertyName("preview_url")]
    public string PreviewUrl { get; set; } = string.Empty;
    /// <summary>Gets or sets video_url.</summary>
    [JsonPropertyName("video_url")]
    public string VideoUrl { get; set; } = string.Empty;
    /// <summary>Gets or sets price.</summary>
    [JsonPropertyName("price")]
    public int Price { get; set; }
}

/// <summary>Wire contract for GetFriendInfoRequest.</summary>
public sealed record class MilkyGetFriendInfoRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets no_cache.</summary>
    [JsonPropertyName("no_cache")]
    public bool NoCache { get; set; } = false;
}

/// <summary>Wire contract for GetFriendListRequest.</summary>
public sealed record class MilkyGetFriendListRequest
{
    /// <summary>Gets or sets no_cache.</summary>
    [JsonPropertyName("no_cache")]
    public bool NoCache { get; set; } = false;
}

/// <summary>Wire contract for GetFriendsStatusResult.</summary>
public sealed record class MilkyGetFriendsStatusResult
{
    /// <summary>Gets or sets self_uid.</summary>
    [JsonPropertyName("self_uid")]
    public string SelfUid { get; set; } = string.Empty;
    /// <summary>Gets or sets friends.</summary>
    [JsonPropertyName("friends")]
    public IReadOnlyList<MilkyGetFriendsStatusFriendStatus> Friends { get; set; } = [];
}

/// <summary>Wire contract for GetFriendsStatusFriendStatus.</summary>
public sealed record class MilkyGetFriendsStatusFriendStatus
{
    /// <summary>Gets or sets uid.</summary>
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
    /// <summary>Gets or sets status.</summary>
    [JsonPropertyName("status"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? Status { get; set; }
    /// <summary>Gets or sets status_text.</summary>
    [JsonPropertyName("status_text")]
    public string StatusText { get; set; } = string.Empty;
    /// <summary>Gets or sets raw_fields.</summary>
    [JsonPropertyName("raw_fields")]
    public IReadOnlyList<MilkyGetFriendsStatusRawField> RawFields { get; set; } = [];
}

/// <summary>Wire contract for GetFriendsStatusRawField.</summary>
public sealed record class MilkyGetFriendsStatusRawField
{
    /// <summary>Gets or sets field.</summary>
    [JsonPropertyName("field")]
    public uint Field { get; set; }
    /// <summary>Gets or sets wire_type.</summary>
    [JsonPropertyName("wire_type")]
    public byte WireType { get; set; }
    /// <summary>Gets or sets value.</summary>
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetGroupExtInfoRequest.</summary>
public sealed record class MilkyGetGroupExtInfoRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
}

/// <summary>Wire contract for GetGroupExtInfoResult.</summary>
public sealed record class MilkyGetGroupExtInfoResult
{
    /// <summary>Gets or sets latest_message_sequence.</summary>
    [JsonPropertyName("latest_message_sequence")]
    public long LatestMessageSequence { get; set; }
}

/// <summary>Wire contract for GetGroupInfoRequest.</summary>
public sealed record class MilkyGetGroupInfoRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets no_cache.</summary>
    [JsonPropertyName("no_cache")]
    public bool NoCache { get; set; } = false;
}

/// <summary>Wire contract for GetGroupListRequest.</summary>
public sealed record class MilkyGetGroupListRequest
{
    /// <summary>Gets or sets no_cache.</summary>
    [JsonPropertyName("no_cache")]
    public bool NoCache { get; set; } = false;
}

/// <summary>Wire contract for GetGroupMemberInfoRequest.</summary>
public sealed record class MilkyGetGroupMemberInfoRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets no_cache.</summary>
    [JsonPropertyName("no_cache")]
    public bool NoCache { get; set; } = false;
}

/// <summary>Wire contract for GetGroupMemberListRequest.</summary>
public sealed record class MilkyGetGroupMemberListRequest
{
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets no_cache.</summary>
    [JsonPropertyName("no_cache")]
    public bool NoCache { get; set; } = false;
}

/// <summary>Wire contract for GetMiniAppArkRequest.</summary>
public sealed record class MilkyGetMiniAppArkRequest
{
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }
    /// <summary>Gets or sets title.</summary>
    [JsonPropertyName("title"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
    /// <summary>Gets or sets description.</summary>
    [JsonPropertyName("description"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }
    /// <summary>Gets or sets picture_url.</summary>
    [JsonPropertyName("picture_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PictureUrl { get; set; }
    /// <summary>Gets or sets jump_url.</summary>
    [JsonPropertyName("jump_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? JumpUrl { get; set; }
}

/// <summary>Wire contract for GetMiniAppArkResult.</summary>
public sealed record class MilkyGetMiniAppArkResult
{
    /// <summary>Gets or sets json_payload.</summary>
    [JsonPropertyName("json_payload")]
    public string JsonPayload { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetOnlineDevicesResult.</summary>
public sealed record class MilkyGetOnlineDevicesResult
{
    /// <summary>Gets or sets observed.</summary>
    [JsonPropertyName("observed")]
    public bool Observed { get; set; }
    /// <summary>Gets or sets devices.</summary>
    [JsonPropertyName("devices"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<MilkyGetOnlineDevicesDevice>? Devices { get; set; }
}

/// <summary>Wire contract for GetOnlineDevicesDevice.</summary>
public sealed record class MilkyGetOnlineDevicesDevice
{
    /// <summary>Gets or sets app_id.</summary>
    [JsonPropertyName("app_id")]
    public uint AppId { get; set; }
    /// <summary>Gets or sets instance_id.</summary>
    [JsonPropertyName("instance_id")]
    public uint InstanceId { get; set; }
    /// <summary>Gets or sets client_type.</summary>
    [JsonPropertyName("client_type")]
    public uint ClientType { get; set; }
    /// <summary>Gets or sets platform.</summary>
    [JsonPropertyName("platform")]
    public uint Platform { get; set; }
    /// <summary>Gets or sets device_name.</summary>
    [JsonPropertyName("device_name")]
    public string DeviceName { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetLikeRequest.</summary>
public sealed record class MilkyGetLikeRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? UserId { get; set; } = null;
    /// <summary>Gets or sets start.</summary>
    [JsonPropertyName("start")]
    public int Start { get; set; } = 0;
    /// <summary>Gets or sets limit.</summary>
    [JsonPropertyName("limit")]
    public int Limit { get; set; } = 10;
}

/// <summary>Wire contract for GetLikeResult.</summary>
public sealed record class MilkyGetLikeResult
{
    /// <summary>Gets or sets uid.</summary>
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
    /// <summary>Gets or sets total_count.</summary>
    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }
    /// <summary>Gets or sets new_count.</summary>
    [JsonPropertyName("new_count")]
    public int NewCount { get; set; }
    /// <summary>Gets or sets users.</summary>
    [JsonPropertyName("users")]
    public IReadOnlyList<MilkyGetLikeProfileLikeUser> Users { get; set; } = [];
}

/// <summary>Wire contract for GetLikeProfileLikeUser.</summary>
public sealed record class MilkyGetLikeProfileLikeUser
{
    /// <summary>Gets or sets uid.</summary>
    [JsonPropertyName("uid")]
    public string Uid { get; set; } = string.Empty;
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets latest_time.</summary>
    [JsonPropertyName("latest_time")]
    public long LatestTime { get; set; }
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
    /// <summary>Gets or sets is_friend.</summary>
    [JsonPropertyName("is_friend")]
    public bool IsFriend { get; set; }
}

/// <summary>Wire contract for GetQzoneFeedsRequest.</summary>
public sealed record class MilkyGetQzoneFeedsRequest
{
    /// <summary>Gets or sets page_num.</summary>
    [JsonPropertyName("page_num")]
    public int PageNum { get; set; } = 1;
    /// <summary>Gets or sets position.</summary>
    [JsonPropertyName("position"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Position { get; set; } = null;
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? UserId { get; set; } = null;
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public int Count { get; set; } = 10;
}

/// <summary>Wire contract for GetQzoneFeedsResult.</summary>
public sealed record class MilkyGetQzoneFeedsResult
{
    /// <summary>Gets or sets has_more.</summary>
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
    /// <summary>Gets or sets feeds.</summary>
    [JsonPropertyName("feeds")]
    public MilkyGetQzoneFeedsFeed[] Feeds { get; set; } = [];
}

/// <summary>Wire contract for GetQzoneFeedsFeed.</summary>
public sealed record class MilkyGetQzoneFeedsFeed
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
    /// <summary>Gets or sets app_id.</summary>
    [JsonPropertyName("app_id")]
    public int AppId { get; set; }
    /// <summary>Gets or sets key.</summary>
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
    /// <summary>Gets or sets html.</summary>
    [JsonPropertyName("html")]
    public string Html { get; set; } = string.Empty;
}

/// <summary>Wire contract for GetQzoneMsgListRequest.</summary>
public sealed record class MilkyGetQzoneMsgListRequest
{
    /// <summary>Gets or sets target_uin.</summary>
    [JsonPropertyName("target_uin"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public long? TargetUin { get; set; } = null;
    /// <summary>Gets or sets position.</summary>
    [JsonPropertyName("position")]
    public int Position { get; set; } = 0;
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public int Count { get; set; } = 20;
}

/// <summary>Wire contract for GetQzoneMsgListResult.</summary>
public sealed record class MilkyGetQzoneMsgListResult
{
    /// <summary>Gets or sets total.</summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
    /// <summary>Gets or sets messages.</summary>
    [JsonPropertyName("messages")]
    public MilkyGetQzoneMsgListMessage[] Messages { get; set; } = [];
}

/// <summary>Wire contract for GetQzoneMsgListMessage.</summary>
public sealed record class MilkyGetQzoneMsgListMessage
{
    /// <summary>Gets or sets id.</summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
    /// <summary>Gets or sets comment_count.</summary>
    [JsonPropertyName("comment_count")]
    public int CommentCount { get; set; }
    /// <summary>Gets or sets is_private.</summary>
    [JsonPropertyName("is_private")]
    public bool IsPrivate { get; set; }
    /// <summary>Gets or sets images.</summary>
    [JsonPropertyName("images")]
    public string[] Images { get; set; } = [];
}

/// <summary>Wire contract for GetSystemFacesRequest.</summary>
public sealed record class MilkyGetSystemFacesRequest
{
    /// <summary>Gets or sets refresh.</summary>
    [JsonPropertyName("refresh")]
    public bool Refresh { get; set; } = false;
}

/// <summary>Wire contract for GetSystemFacesResult.</summary>
public sealed record class MilkyGetSystemFacesResult
{
    /// <summary>Gets or sets packs.</summary>
    [JsonPropertyName("packs")]
    public IReadOnlyList<MilkyGetSystemFacesPack> Packs { get; set; } = [];
}

/// <summary>Wire contract for GetSystemFacesPack.</summary>
public sealed record class MilkyGetSystemFacesPack
{
    /// <summary>Gets or sets pack_name.</summary>
    [JsonPropertyName("pack_name")]
    public string PackName { get; set; } = string.Empty;
    /// <summary>Gets or sets faces.</summary>
    [JsonPropertyName("faces")]
    public IReadOnlyList<MilkyGetSystemFacesSystemFace> Faces { get; set; } = [];
}

/// <summary>Wire contract for GetSystemFacesSystemFace.</summary>
public sealed record class MilkyGetSystemFacesSystemFace
{
    /// <summary>Gets or sets sid.</summary>
    [JsonPropertyName("sid")]
    public string Sid { get; set; } = string.Empty;
    /// <summary>Gets or sets description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    /// <summary>Gets or sets em_code.</summary>
    [JsonPropertyName("em_code")]
    public string EmCode { get; set; } = string.Empty;
    /// <summary>Gets or sets category_id.</summary>
    [JsonPropertyName("category_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CategoryId { get; set; }
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
    /// <summary>Gets or sets aliases.</summary>
    [JsonPropertyName("aliases")]
    public IReadOnlyList<string> Aliases { get; set; } = [];
}

/// <summary>Wire contract for GetUserProfileRequest.</summary>
public sealed record class MilkyGetUserProfileRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}

/// <summary>Wire contract for GetUserStatusRequest.</summary>
public sealed record class MilkyGetUserStatusRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
}

/// <summary>Wire contract for GetUserStatusResult.</summary>
public sealed record class MilkyGetUserStatusResult
{
    /// <summary>Gets or sets status.</summary>
    [JsonPropertyName("status"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? Status { get; set; }
    /// <summary>Gets or sets extended_status.</summary>
    [JsonPropertyName("extended_status"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? ExtendedStatus { get; set; }
}

/// <summary>Wire contract for ImageOcrRequest.</summary>
public sealed record class MilkyImageOcrRequest
{
    /// <summary>Gets or sets image_url.</summary>
    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; } = string.Empty;
}

/// <summary>Wire contract for ImageOcrResult.</summary>
public sealed record class MilkyImageOcrResult
{
    /// <summary>Gets or sets language.</summary>
    [JsonPropertyName("language")]
    public string Language { get; set; } = string.Empty;
    /// <summary>Gets or sets texts.</summary>
    [JsonPropertyName("texts")]
    public IReadOnlyList<MilkyImageOcrText> Texts { get; set; } = [];
}

/// <summary>Wire contract for ImageOcrText.</summary>
public sealed record class MilkyImageOcrText
{
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text")]
    public string Value { get; set; } = string.Empty;
    /// <summary>Gets or sets confidence.</summary>
    [JsonPropertyName("confidence")]
    public uint Confidence { get; set; }
    /// <summary>Gets or sets coordinates.</summary>
    [JsonPropertyName("coordinates")]
    public IReadOnlyList<MilkyImageOcrCoordinate> Coordinates { get; set; } = [];
}

/// <summary>Wire contract for ImageOcrCoordinate.</summary>
public sealed record class MilkyImageOcrCoordinate
{
    /// <summary>Gets or sets x.</summary>
    [JsonPropertyName("x")]
    public int X { get; set; }
    /// <summary>Gets or sets y.</summary>
    [JsonPropertyName("y")]
    public int Y { get; set; }
}

/// <summary>Wire contract for ModifyCustomFaceRequest.</summary>
public sealed record class MilkyModifyCustomFaceRequest
{
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; set; } = string.Empty;
    /// <summary>Gets or sets md5.</summary>
    [JsonPropertyName("md5")]
    public string Md5 { get; set; } = string.Empty;
    /// <summary>Gets or sets description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

/// <summary>Wire contract for MoveCustomFaceRequest.</summary>
public sealed record class MilkyMoveCustomFaceRequest
{
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; set; } = string.Empty;
    /// <summary>Gets or sets position.</summary>
    [JsonPropertyName("position")]
    public int Position { get; set; }
    /// <summary>Gets or sets entries.</summary>
    [JsonPropertyName("entries")]
    public IReadOnlyList<MilkyMoveCustomFaceMoveFaceEntry> Entries { get; set; } = [];
}

/// <summary>Wire contract for MoveCustomFaceMoveFaceEntry.</summary>
public sealed record class MilkyMoveCustomFaceMoveFaceEntry
{
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; set; } = string.Empty;
    /// <summary>Gets or sets md5.</summary>
    [JsonPropertyName("md5")]
    public string Md5 { get; set; } = string.Empty;
}

/// <summary>Wire contract for PublishQzoneMessageRequest.</summary>
public sealed record class MilkyPublishQzoneMessageRequest
{
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
    /// <summary>Gets or sets rich_value.</summary>
    [JsonPropertyName("rich_value")]
    public string RichValue { get; set; } = "";
}

/// <summary>Wire contract for PublishQzoneMessageResult.</summary>
public sealed record class MilkyPublishQzoneMessageResult
{
    /// <summary>Gets or sets message_id.</summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = string.Empty;
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
}

/// <summary>Wire contract for RequestDatabaseKeyRequest.</summary>
public sealed record class MilkyRequestDatabaseKeyRequest
{
    /// <summary>Gets or sets db_salt.</summary>
    [JsonPropertyName("db_salt"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DbSalt { get; set; }
}

/// <summary>Wire contract for RequestDatabaseKeyResult.</summary>
public sealed record class MilkyRequestDatabaseKeyResult
{
    /// <summary>Gets or sets key.</summary>
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
}

/// <summary>Wire contract for RequestDecryptKeyRequest.</summary>
[JsonConverter(typeof(MilkyRequestDecryptKeyRequestJsonConverter))]
public sealed record class MilkyRequestDecryptKeyRequest
{
    /// <summary>Gets or sets mode.</summary>
    [JsonPropertyName("mode"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Mode { get; set; }
    /// <summary>Gets or sets key_meta.</summary>
    [JsonPropertyName("key_meta"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? KeyMeta { get => _keyMeta; set { _keyMeta = value; HasKeyMeta = true; } }
    private string? _keyMeta;
    [JsonIgnore]
    internal bool HasKeyMeta { get; private set; }
}

/// <summary>Wire contract for RequestDecryptKeyResult.</summary>
public sealed record class MilkyRequestDecryptKeyResult
{
    /// <summary>Gets or sets key.</summary>
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
    /// <summary>Gets or sets key_meta.</summary>
    [JsonPropertyName("key_meta")]
    public string KeyMeta { get; set; } = string.Empty;
}

/// <summary>Wire contract for SearchSystemFacesRequest.</summary>
public sealed record class MilkySearchSystemFacesRequest
{
    /// <summary>Gets or sets query.</summary>
    [JsonPropertyName("query")]
    public string Query { get; set; } = string.Empty;
    /// <summary>Gets or sets refresh.</summary>
    [JsonPropertyName("refresh")]
    public bool Refresh { get; set; } = false;
}

/// <summary>Wire contract for SearchSystemFacesResult.</summary>
public sealed record class MilkySearchSystemFacesResult
{
    /// <summary>Gets or sets faces.</summary>
    [JsonPropertyName("faces")]
    public IReadOnlyList<MilkySearchSystemFacesSearchFace> Faces { get; set; } = [];
}

/// <summary>Wire contract for SearchSystemFacesSearchFace.</summary>
public sealed record class MilkySearchSystemFacesSearchFace
{
    /// <summary>Gets or sets sid.</summary>
    [JsonPropertyName("sid")]
    public string Sid { get; set; } = string.Empty;
    /// <summary>Gets or sets description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    /// <summary>Gets or sets em_code.</summary>
    [JsonPropertyName("em_code")]
    public string EmCode { get; set; } = string.Empty;
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Url { get; set; }
}

/// <summary>Wire contract for SendPacketRequest.</summary>
public sealed record class MilkySendPacketRequest
{
    /// <summary>Gets or sets cmd.</summary>
    [JsonPropertyName("cmd"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string? Command { get; set; }
    /// <summary>Gets or sets data.</summary>
    [JsonPropertyName("data"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public string? Data { get; set; } = string.Empty;
    /// <summary>Gets or sets rsp.</summary>
    [JsonPropertyName("rsp"), JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public bool? WaitForResponse { get; set; } = true;
}

/// <summary>Wire contract for RawPacketData.</summary>
public sealed record class MilkyRawPacketData
{
    /// <summary>Gets or sets cmd.</summary>
    [JsonPropertyName("cmd")]
    public string Command { get; set; } = string.Empty;
    /// <summary>Gets or sets data.</summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;
    /// <summary>Gets or sets sequence.</summary>
    [JsonPropertyName("sequence")]
    public int Sequence { get; set; }
    /// <summary>Gets or sets ret_code.</summary>
    [JsonPropertyName("ret_code")]
    public int RetCode { get; set; }
    /// <summary>Gets or sets extra.</summary>
    [JsonPropertyName("extra")]
    public string Extra { get; set; } = string.Empty;
}

/// <summary>Wire contract for SendProfileLikeRequest.</summary>
public sealed record class MilkySendProfileLikeRequest
{
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; } = 1;
}

/// <summary>Wire contract for SetAvatarRequest.</summary>
public sealed record class MilkySetAvatarRequest
{
    /// <summary>Gets or sets uri.</summary>
    [JsonPropertyName("uri")]
    public string Uri { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetBioRequest.</summary>
public sealed record class MilkySetBioRequest
{
    /// <summary>Gets or sets bio.</summary>
    [JsonPropertyName("bio")]
    public string Bio { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetDiyOnlineStatusRequest.</summary>
public sealed record class MilkySetDiyOnlineStatusRequest
{
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public int FaceId { get; set; }
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetNicknameRequest.</summary>
public sealed record class MilkySetNicknameRequest
{
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
}

/// <summary>Wire contract for SetOnlineStatusRequest.</summary>
public sealed record class MilkySetOnlineStatusRequest
{
    /// <summary>Gets or sets status.</summary>
    [JsonPropertyName("status")]
    public uint Status { get; set; }
}

/// <summary>Wire contract for SetPeerPinRequest.</summary>
public sealed record class MilkySetPeerPinRequest
{
    /// <summary>Gets or sets message_scene.</summary>
    [JsonPropertyName("message_scene")]
    public string MessageScene { get; set; } = string.Empty;
    /// <summary>Gets or sets peer_id.</summary>
    [JsonPropertyName("peer_id")]
    public long PeerId { get; set; }
    /// <summary>Gets or sets is_pinned.</summary>
    [JsonPropertyName("is_pinned")]
    public bool IsPinned { get; set; } = true;
}

/// <summary>Wire contract for SetProfileRequest.</summary>
public sealed record class MilkySetProfileRequest
{
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Nickname { get; set; } = null;
    /// <summary>Gets or sets personal_note.</summary>
    [JsonPropertyName("personal_note"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PersonalNote { get; set; } = null;
    /// <summary>Gets or sets sex.</summary>
    [JsonPropertyName("sex"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Sex { get; set; } = null;
}

/// <summary>Wire contract for SetQzoneBlackRequest.</summary>
public sealed record class MilkySetQzoneBlackRequest
{
    /// <summary>Gets or sets target_uin.</summary>
    [JsonPropertyName("target_uin")]
    public long TargetUin { get; set; }
    /// <summary>Gets or sets ban.</summary>
    [JsonPropertyName("ban")]
    public bool Ban { get; set; } = true;
}

/// <summary>Wire contract for SetQzoneLikeRequest.</summary>
public sealed record class MilkySetQzoneLikeRequest
{
    /// <summary>Gets or sets target_uin.</summary>
    [JsonPropertyName("target_uin")]
    public long TargetUin { get; set; }
    /// <summary>Gets or sets message_id.</summary>
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = string.Empty;
    /// <summary>Gets or sets like.</summary>
    [JsonPropertyName("like")]
    public bool Like { get; set; } = true;
    /// <summary>Gets or sets abstime.</summary>
    [JsonPropertyName("abstime")]
    public long AbsTime { get; set; } = 0;
}

/// <summary>Wire contract for SetQzoneLikeResult.</summary>
public sealed record class MilkySetQzoneLikeResult
{
}

/// <summary>Wire contract for SetQzoneMessageVisibilityRequest.</summary>
public sealed record class MilkySetQzoneMessageVisibilityRequest
{
    /// <summary>Gets or sets message_id.</summary>
    [JsonPropertyName("message_id"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MessageId { get; set; }
    /// <summary>Gets or sets right.</summary>
    [JsonPropertyName("right")]
    public uint Right { get; set; }
    /// <summary>Gets or sets users.</summary>
    [JsonPropertyName("users")]
    public IReadOnlyList<long> Users { get; set; } = [];
}

/// <summary>Wire contract for SetSelfLongNickRequest.</summary>
public sealed record class MilkySetSelfLongNickRequest
{
    /// <summary>Gets or sets long_nick.</summary>
    [JsonPropertyName("long_nick")]
    public string LongNick { get; set; } = string.Empty;
}

/// <summary>Wire contract for TranslateEnToZhRequest.</summary>
public sealed record class MilkyTranslateEnToZhRequest
{
    /// <summary>Gets or sets words.</summary>
    [JsonPropertyName("words")]
    public IReadOnlyList<string> Words { get; set; } = [];
}

/// <summary>Wire contract for TranslateEnToZhResult.</summary>
public sealed record class MilkyTranslateEnToZhResult
{
    /// <summary>Gets or sets words.</summary>
    [JsonPropertyName("words")]
    public IReadOnlyList<string> Words { get; set; } = [];
}

/// <summary>Wire contract for UploadQzoneImageRequest.</summary>
public sealed record class MilkyUploadQzoneImageRequest
{
    /// <summary>Gets or sets image_uri.</summary>
    [JsonPropertyName("image_uri")]
    public string ImageUri { get; set; } = string.Empty;
}

/// <summary>Wire contract for UploadQzoneImageResult.</summary>
public sealed record class MilkyUploadQzoneImageResult
{
    /// <summary>Gets or sets rich_value.</summary>
    [JsonPropertyName("rich_value")]
    public string RichValue { get; set; } = string.Empty;
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
    /// <summary>Gets or sets album_id.</summary>
    [JsonPropertyName("album_id")]
    public string AlbumId { get; set; } = string.Empty;
    /// <summary>Gets or sets location.</summary>
    [JsonPropertyName("location")]
    public string Location { get; set; } = string.Empty;
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }
    /// <summary>Gets or sets width.</summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }
    /// <summary>Gets or sets height.</summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }
}
