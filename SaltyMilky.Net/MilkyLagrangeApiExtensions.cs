using System.Text.Json;

namespace SaltyMilky.Net;

public static partial class MilkyActionSessionExtensions
{
    /// <summary>Invokes commit_flash_file.</summary>
    public static Task<MilkyActionResult?> CommitFlashFileAsync(this IMilkyActionSession session, MilkyCommitFlashFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.CommitFlashFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyCommitFlashFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes complete_flash_task.</summary>
    public static Task<MilkyActionResult?> CompleteFlashTaskAsync(this IMilkyActionSession session, MilkyCompleteFlashTaskRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.CompleteFlashTask, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyCompleteFlashTaskRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes convert_record.</summary>
    public static Task<MilkyActionResult<MilkyConvertRecordResult>?> ConvertRecordAsync(this IMilkyActionSession session, MilkyConvertRecordRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyConvertRecordResult>(MilkyConstant.Api.ConvertRecord, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyConvertRecordRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes create_flash_task.</summary>
    public static Task<MilkyActionResult<MilkyCreateFlashTaskResult>?> CreateFlashTaskAsync(this IMilkyActionSession session, MilkyCreateFlashTaskRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyCreateFlashTaskResult>(MilkyConstant.Api.CreateFlashTask, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyCreateFlashTaskRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes create_group_folder.</summary>
    public static Task<MilkyActionResult<MilkyCreateGroupFolderResult>?> CreateGroupFolderAsync(this IMilkyActionSession session, MilkyCreateGroupFolderRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyCreateGroupFolderResult>(MilkyConstant.Api.CreateGroupFolder, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyCreateGroupFolderRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes delete_flash_file.</summary>
    public static Task<MilkyActionResult?> DeleteFlashFileAsync(this IMilkyActionSession session, MilkyDeleteFlashFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.DeleteFlashFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyDeleteFlashFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes delete_group_file.</summary>
    public static Task<MilkyActionResult?> DeleteGroupFileAsync(this IMilkyActionSession session, MilkyDeleteGroupFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.DeleteGroupFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyDeleteGroupFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes delete_group_folder.</summary>
    public static Task<MilkyActionResult?> DeleteGroupFolderAsync(this IMilkyActionSession session, MilkyDeleteGroupFolderRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.DeleteGroupFolder, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyDeleteGroupFolderRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes upload_flash_files.</summary>
    public static Task<MilkyActionResult<MilkyUploadFlashFilesResult>?> UploadFlashFilesAsync(this IMilkyActionSession session, MilkyUploadFlashFilesRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyUploadFlashFilesResult>(MilkyConstant.Api.UploadFlashFiles, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyUploadFlashFilesRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_flash_download.</summary>
    public static Task<MilkyActionResult<MilkyGetFlashDownloadResult>?> GetFlashDownloadAsync(this IMilkyActionSession session, MilkyGetFlashDownloadRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetFlashDownloadResult>(MilkyConstant.Api.GetFlashDownload, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetFlashDownloadRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_flash_share_link.</summary>
    public static Task<MilkyActionResult<MilkyGetFlashShareLinkResult>?> GetFlashShareLinkAsync(this IMilkyActionSession session, MilkyGetFlashShareLinkRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetFlashShareLinkResult>(MilkyConstant.Api.GetFlashShareLink, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetFlashShareLinkRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes resolve_flash_share_code.</summary>
    public static Task<MilkyActionResult<MilkyResolveFlashShareCodeResult>?> ResolveFlashShareCodeAsync(this IMilkyActionSession session, MilkyResolveFlashShareCodeRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyResolveFlashShareCodeResult>(MilkyConstant.Api.ResolveFlashShareCode, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyResolveFlashShareCodeRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_download_rkeys.</summary>
    public static Task<MilkyActionResult<MilkyGetDownloadRkeysResult>?> GetDownloadRkeysAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetDownloadRkeysResult>(MilkyConstant.Api.GetDownloadRkeys, MilkyEmptyObject.Instance, cancellationToken);

    /// <summary>Invokes get_flash_fileset.</summary>
    public static Task<MilkyActionResult<MilkyGetFlashFilesetResult>?> GetFlashFilesetAsync(this IMilkyActionSession session, MilkyGetFlashFilesetRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetFlashFilesetResult>(MilkyConstant.Api.GetFlashFileset, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetFlashFilesetRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_flash_file_url.</summary>
    public static Task<MilkyActionResult<MilkyGetFlashFileUrlResult>?> GetFlashFileUrlAsync(this IMilkyActionSession session, MilkyGetFlashFileUrlRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetFlashFileUrlResult>(MilkyConstant.Api.GetFlashFileUrl, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetFlashFileUrlRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_file_count.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupFileCountResult>?> GetGroupFileCountAsync(this IMilkyActionSession session, MilkyGetGroupFileCountRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupFileCountResult>(MilkyConstant.Api.GetGroupFileCount, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupFileCountRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_file_download_url.</summary>
    public static Task<MilkyActionResult<MilkyFileDownloadUrlResult>?> GetGroupFileDownloadUrlAsync(this IMilkyActionSession session, MilkyGetGroupFileDownloadUrlRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyFileDownloadUrlResult>(MilkyConstant.Api.GetGroupFileDownloadUrl, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupFileDownloadUrlRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_files.</summary>
    public static Task<MilkyActionResult<MilkyGroupFilesResult>?> GetGroupFilesAsync(this IMilkyActionSession session, MilkyGetGroupFilesRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGroupFilesResult>(MilkyConstant.Api.GetGroupFiles, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupFilesRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_file_space.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupFileSpaceResult>?> GetGroupFileSpaceAsync(this IMilkyActionSession session, MilkyGetGroupFileSpaceRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupFileSpaceResult>(MilkyConstant.Api.GetGroupFileSpace, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupFileSpaceRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_file_url.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupFileUrlResult>?> GetGroupFileUrlAsync(this IMilkyActionSession session, MilkyGetGroupFileUrlRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupFileUrlResult>(MilkyConstant.Api.GetGroupFileUrl, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupFileUrlRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_ptt_url.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupPttUrlResult>?> GetGroupPttUrlAsync(this IMilkyActionSession session, MilkyGetGroupPttUrlRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupPttUrlResult>(MilkyConstant.Api.GetGroupPttUrl, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupPttUrlRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_video_url.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupVideoUrlResult>?> GetGroupVideoUrlAsync(this IMilkyActionSession session, MilkyGetGroupVideoUrlRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupVideoUrlResult>(MilkyConstant.Api.GetGroupVideoUrl, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupVideoUrlRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_private_ptt_url.</summary>
    public static Task<MilkyActionResult<MilkyGetPrivatePttUrlResult>?> GetPrivatePttUrlAsync(this IMilkyActionSession session, MilkyGetPrivatePttUrlRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetPrivatePttUrlResult>(MilkyConstant.Api.GetPrivatePttUrl, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetPrivatePttUrlRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_private_video_url.</summary>
    public static Task<MilkyActionResult<MilkyGetPrivateVideoUrlResult>?> GetPrivateVideoUrlAsync(this IMilkyActionSession session, MilkyGetPrivateVideoUrlRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetPrivateVideoUrlResult>(MilkyConstant.Api.GetPrivateVideoUrl, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetPrivateVideoUrlRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_private_file_download_url.</summary>
    public static Task<MilkyActionResult<MilkyFileDownloadUrlResult>?> GetPrivateFileDownloadUrlAsync(this IMilkyActionSession session, MilkyGetPrivateFileDownloadUrlRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyFileDownloadUrlResult>(MilkyConstant.Api.GetPrivateFileDownloadUrl, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetPrivateFileDownloadUrlRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes list_flash_filesets.</summary>
    public static Task<MilkyActionResult<MilkyListFlashFilesetsResult>?> ListFlashFilesetsAsync(this IMilkyActionSession session, MilkyListFlashFilesetsRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyListFlashFilesetsResult>(MilkyConstant.Api.ListFlashFilesets, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyListFlashFilesetsRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes move_group_file.</summary>
    public static Task<MilkyActionResult?> MoveGroupFileAsync(this IMilkyActionSession session, MilkyMoveGroupFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.MoveGroupFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyMoveGroupFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes publish_group_file.</summary>
    public static Task<MilkyActionResult?> PublishGroupFileAsync(this IMilkyActionSession session, MilkyPublishGroupFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.PublishGroupFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyPublishGroupFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes rename_flash_file.</summary>
    public static Task<MilkyActionResult?> RenameFlashFileAsync(this IMilkyActionSession session, MilkyRenameFlashFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.RenameFlashFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyRenameFlashFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes rename_group_file.</summary>
    public static Task<MilkyActionResult?> RenameGroupFileAsync(this IMilkyActionSession session, MilkyRenameGroupFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.RenameGroupFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyRenameGroupFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes rename_group_folder.</summary>
    public static Task<MilkyActionResult?> RenameGroupFolderAsync(this IMilkyActionSession session, MilkyRenameGroupFolderRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.RenameGroupFolder, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyRenameGroupFolderRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_flash_message.</summary>
    public static Task<MilkyActionResult?> SendFlashMessageAsync(this IMilkyActionSession session, MilkySendFlashMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SendFlashMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendFlashMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_flash_task_status.</summary>
    public static Task<MilkyActionResult?> SetFlashTaskStatusAsync(this IMilkyActionSession session, MilkySetFlashTaskStatusRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetFlashTaskStatus, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetFlashTaskStatusRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes trans_group_file.</summary>
    public static Task<MilkyActionResult<MilkyTransGroupFileResult>?> TransGroupFileAsync(this IMilkyActionSession session, MilkyTransGroupFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyTransGroupFileResult>(MilkyConstant.Api.TransGroupFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyTransGroupFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes upload_group_file.</summary>
    public static Task<MilkyActionResult<MilkyFileUploadResult>?> UploadGroupFileAsync(this IMilkyActionSession session, MilkyUploadGroupFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyFileUploadResult>(MilkyConstant.Api.UploadGroupFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyUploadGroupFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes upload_private_file.</summary>
    public static Task<MilkyActionResult<MilkyFileUploadResult>?> UploadPrivateFileAsync(this IMilkyActionSession session, MilkyUploadPrivateFileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyFileUploadResult>(MilkyConstant.Api.UploadPrivateFile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyUploadPrivateFileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes delete_friend.</summary>
    public static Task<MilkyActionResult?> DeleteFriendAsync(this IMilkyActionSession session, MilkyDeleteFriendRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.DeleteFriend, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyDeleteFriendRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_friend_requests.</summary>
    public static Task<MilkyActionResult<MilkyFriendRequestsResult>?> GetFriendRequestsAsync(this IMilkyActionSession session, CancellationToken cancellationToken)
        => session.InvokeApiAsync<MilkyFriendRequestsResult>(MilkyConstant.Api.GetFriendRequests, MilkyEmptyObject.Instance, cancellationToken);

    /// <summary>Invokes get_unidirectional_friend_list.</summary>
    public static Task<MilkyActionResult<MilkyGetUnidirectionalFriendListResult>?> GetUnidirectionalFriendListAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetUnidirectionalFriendListResult>(MilkyConstant.Api.GetUnidirectionalFriendList, MilkyEmptyObject.Instance, cancellationToken);

    /// <summary>Invokes handle_friend_request.</summary>
    public static Task<MilkyActionResult?> HandleFriendRequestAsync(this IMilkyActionSession session, MilkyHandleFriendRequestRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.HandleFriendRequest, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyHandleFriendRequestRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_friend_nudge.</summary>
    public static Task<MilkyActionResult?> SendFriendNudgeAsync(this IMilkyActionSession session, MilkySendFriendNudgeRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SendFriendNudge, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendFriendNudgeRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_friend_category.</summary>
    public static Task<MilkyActionResult?> SetFriendCategoryAsync(this IMilkyActionSession session, MilkySetFriendCategoryRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetFriendCategory, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetFriendCategoryRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_friend_remark.</summary>
    public static Task<MilkyActionResult?> SetFriendRemarkAsync(this IMilkyActionSession session, MilkySetFriendRemarkRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetFriendRemark, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetFriendRemarkRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes accept_group_invitation.</summary>
    public static Task<MilkyActionResult?> AcceptGroupInvitationAsync(this IMilkyActionSession session, MilkyAcceptGroupInvitationRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.AcceptGroupInvitation, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyAcceptGroupInvitationRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes accept_group_request.</summary>
    public static Task<MilkyActionResult?> AcceptGroupRequestAsync(this IMilkyActionSession session, MilkyAcceptGroupRequestRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.AcceptGroupRequest, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyAcceptGroupRequestRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes cancel_group_todo.</summary>
    public static Task<MilkyActionResult?> CancelGroupTodoAsync(this IMilkyActionSession session, MilkyCancelGroupTodoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.CancelGroupTodo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyCancelGroupTodoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes comment_group_album_media.</summary>
    public static Task<MilkyActionResult<MilkyCommentGroupAlbumMediaResult>?> CommentGroupAlbumMediaAsync(this IMilkyActionSession session, MilkyCommentGroupAlbumMediaRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyCommentGroupAlbumMediaResult>(MilkyConstant.Api.CommentGroupAlbumMedia, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyCommentGroupAlbumMediaRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes complete_group_todo.</summary>
    public static Task<MilkyActionResult?> CompleteGroupTodoAsync(this IMilkyActionSession session, MilkyCompleteGroupTodoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.CompleteGroupTodo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyCompleteGroupTodoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes delete_group_album_media.</summary>
    public static Task<MilkyActionResult?> DeleteGroupAlbumMediaAsync(this IMilkyActionSession session, MilkyDeleteGroupAlbumMediaRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.DeleteGroupAlbumMedia, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyDeleteGroupAlbumMediaRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes delete_group_announcement.</summary>
    public static Task<MilkyActionResult?> DeleteGroupAnnouncementAsync(this IMilkyActionSession session, MilkyDeleteGroupAnnouncementRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.DeleteGroupAnnouncement, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyDeleteGroupAnnouncementRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_admin_settings.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupAdminSettingsResult>?> GetGroupAdminSettingsAsync(this IMilkyActionSession session, MilkyGetGroupAdminSettingsRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupAdminSettingsResult>(MilkyConstant.Api.GetGroupAdminSettings, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupAdminSettingsRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_album_media.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupAlbumMediaResult>?> GetGroupAlbumMediaAsync(this IMilkyActionSession session, MilkyGetGroupAlbumMediaRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupAlbumMediaResult>(MilkyConstant.Api.GetGroupAlbumMedia, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupAlbumMediaRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_album_list.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupAlbumListResult>?> GetGroupAlbumListAsync(this IMilkyActionSession session, MilkyGetGroupAlbumListRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupAlbumListResult>(MilkyConstant.Api.GetGroupAlbumList, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupAlbumListRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_announcements.</summary>
    public static Task<MilkyActionResult<MilkyGroupAnnouncementsResult>?> GetGroupAnnouncementsAsync(this IMilkyActionSession session, MilkyGetGroupAnnouncementsRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGroupAnnouncementsResult>(MilkyConstant.Api.GetGroupAnnouncements, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupAnnouncementsRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_at_all_remain.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupAtAllRemainResult>?> GetGroupAtAllRemainAsync(this IMilkyActionSession session, MilkyGetGroupAtAllRemainRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupAtAllRemainResult>(MilkyConstant.Api.GetGroupAtAllRemain, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupAtAllRemainRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_essence.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupEssenceResult>?> GetGroupEssenceAsync(this IMilkyActionSession session, MilkyGetGroupEssenceRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupEssenceResult>(MilkyConstant.Api.GetGroupEssence, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupEssenceRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_essence_messages.</summary>
    public static Task<MilkyActionResult<MilkyGroupEssenceMessagesResult>?> GetGroupEssenceMessagesAsync(this IMilkyActionSession session, MilkyGetGroupEssenceMessagesRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGroupEssenceMessagesResult>(MilkyConstant.Api.GetGroupEssenceMessages, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupEssenceMessagesRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_honor.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupHonorResult>?> GetGroupHonorAsync(this IMilkyActionSession session, MilkyGetGroupHonorRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupHonorResult>(MilkyConstant.Api.GetGroupHonor, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupHonorRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_notifications.</summary>
    public static Task<MilkyActionResult<MilkyGroupNotificationsResult>?> GetGroupNotificationsAsync(this IMilkyActionSession session, MilkyGetGroupNotificationsRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGroupNotificationsResult>(MilkyConstant.Api.GetGroupNotifications, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupNotificationsRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_sign_in.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupSignInResult>?> GetGroupSignInAsync(this IMilkyActionSession session, MilkyGetGroupSignInRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupSignInResult>(MilkyConstant.Api.GetGroupSignIn, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupSignInRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_todo.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupTodoResult>?> GetGroupTodoAsync(this IMilkyActionSession session, MilkyGetGroupTodoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupTodoResult>(MilkyConstant.Api.GetGroupTodo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupTodoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_todo_list.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupTodoListResult>?> GetGroupTodoListAsync(this IMilkyActionSession session, MilkyGetGroupTodoListRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupTodoListResult>(MilkyConstant.Api.GetGroupTodoList, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupTodoListRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes kick_group_member.</summary>
    public static Task<MilkyActionResult?> KickGroupMemberAsync(this IMilkyActionSession session, MilkyKickGroupMemberRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.KickGroupMember, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyKickGroupMemberRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes quit_group.</summary>
    public static Task<MilkyActionResult?> QuitGroupAsync(this IMilkyActionSession session, MilkyQuitGroupRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.QuitGroup, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyQuitGroupRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes reject_group_invitation.</summary>
    public static Task<MilkyActionResult?> RejectGroupInvitationAsync(this IMilkyActionSession session, MilkyRejectGroupInvitationRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.RejectGroupInvitation, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyRejectGroupInvitationRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes reject_group_request.</summary>
    public static Task<MilkyActionResult?> RejectGroupRequestAsync(this IMilkyActionSession session, MilkyRejectGroupRequestRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.RejectGroupRequest, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyRejectGroupRequestRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_group_announcement.</summary>
    public static Task<MilkyActionResult?> SendGroupAnnouncementAsync(this IMilkyActionSession session, MilkySendGroupAnnouncementRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SendGroupAnnouncement, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendGroupAnnouncementRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_group_message_reaction.</summary>
    public static Task<MilkyActionResult?> SendGroupMessageReactionAsync(this IMilkyActionSession session, MilkySendGroupMessageReactionRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SendGroupMessageReaction, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendGroupMessageReactionRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_group_nudge.</summary>
    public static Task<MilkyActionResult?> SendGroupNudgeAsync(this IMilkyActionSession session, MilkySendGroupNudgeRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SendGroupNudge, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendGroupNudgeRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_group_sign.</summary>
    public static Task<MilkyActionResult<MilkySendGroupSignResult>?> SendGroupSignAsync(this IMilkyActionSession session, MilkySendGroupSignRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySendGroupSignResult>(MilkyConstant.Api.SendGroupSign, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendGroupSignRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_add_option.</summary>
    public static Task<MilkyActionResult?> SetGroupAddOptionAsync(this IMilkyActionSession session, MilkySetGroupAddOptionRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupAddOption, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupAddOptionRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_album_like.</summary>
    public static Task<MilkyActionResult?> SetGroupAlbumLikeAsync(this IMilkyActionSession session, MilkySetGroupAlbumLikeRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupAlbumLike, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupAlbumLikeRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_avatar.</summary>
    public static Task<MilkyActionResult?> SetGroupAvatarAsync(this IMilkyActionSession session, MilkySetGroupAvatarRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupAvatar, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupAvatarRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_essence_message.</summary>
    public static Task<MilkyActionResult?> SetGroupEssenceMessageAsync(this IMilkyActionSession session, MilkySetGroupEssenceMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupEssenceMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupEssenceMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_member_invite_policy.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberInvitePolicyAsync(this IMilkyActionSession session, MilkySetGroupMemberInvitePolicyRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupMemberInvitePolicy, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupMemberInvitePolicyRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_member_admin.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberAdminAsync(this IMilkyActionSession session, MilkySetGroupMemberAdminRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupMemberAdmin, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupMemberAdminRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_member_card.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberCardAsync(this IMilkyActionSession session, MilkySetGroupMemberCardRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupMemberCard, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupMemberCardRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_member_mute.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberMuteAsync(this IMilkyActionSession session, MilkySetGroupMemberMuteRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupMemberMute, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupMemberMuteRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_member_permission.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberPermissionAsync(this IMilkyActionSession session, MilkySetGroupMemberPermissionRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupMemberPermission, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupMemberPermissionRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_member_special_title.</summary>
    public static Task<MilkyActionResult?> SetGroupMemberSpecialTitleAsync(this IMilkyActionSession session, MilkySetGroupMemberSpecialTitleRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupMemberSpecialTitle, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupMemberSpecialTitleRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_name.</summary>
    public static Task<MilkyActionResult?> SetGroupNameAsync(this IMilkyActionSession session, MilkySetGroupNameRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupName, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupNameRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_new_member_history_visibility.</summary>
    public static Task<MilkyActionResult?> SetGroupNewMemberHistoryVisibilityAsync(this IMilkyActionSession session, MilkySetGroupNewMemberHistoryVisibilityRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupNewMemberHistoryVisibility, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupNewMemberHistoryVisibilityRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_remark.</summary>
    public static Task<MilkyActionResult?> SetGroupRemarkAsync(this IMilkyActionSession session, MilkySetGroupRemarkRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupRemark, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupRemarkRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_robot_add_option.</summary>
    public static Task<MilkyActionResult?> SetGroupRobotAddOptionAsync(this IMilkyActionSession session, MilkySetGroupRobotAddOptionRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupRobotAddOption, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupRobotAddOptionRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_search.</summary>
    public static Task<MilkyActionResult?> SetGroupSearchAsync(this IMilkyActionSession session, MilkySetGroupSearchRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupSearch, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupSearchRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_todo.</summary>
    public static Task<MilkyActionResult?> SetGroupTodoAsync(this IMilkyActionSession session, MilkySetGroupTodoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupTodo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupTodoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_whole_mute.</summary>
    public static Task<MilkyActionResult?> SetGroupWholeMuteAsync(this IMilkyActionSession session, MilkySetGroupWholeMuteRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupWholeMute, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupWholeMuteRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes transfer_group.</summary>
    public static Task<MilkyActionResult?> TransferGroupAsync(this IMilkyActionSession session, MilkyTransferGroupRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.TransferGroup, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyTransferGroupRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes upload_group_album_image.</summary>
    public static Task<MilkyActionResult<MilkyUploadGroupAlbumImageResult>?> UploadGroupAlbumImageAsync(this IMilkyActionSession session, MilkyUploadGroupAlbumImageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyUploadGroupAlbumImageResult>(MilkyConstant.Api.UploadGroupAlbumImage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyUploadGroupAlbumImageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes upload_group_album_video.</summary>
    public static Task<MilkyActionResult<MilkyUploadGroupAlbumVideoResult>?> UploadGroupAlbumVideoAsync(this IMilkyActionSession session, MilkyUploadGroupAlbumVideoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyUploadGroupAlbumVideoResult>(MilkyConstant.Api.UploadGroupAlbumVideo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyUploadGroupAlbumVideoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes upload_group_announcement_image.</summary>
    public static Task<MilkyActionResult<MilkyUploadGroupAnnouncementImageResult>?> UploadGroupAnnouncementImageAsync(this IMilkyActionSession session, MilkyUploadGroupAnnouncementImageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyUploadGroupAnnouncementImageResult>(MilkyConstant.Api.UploadGroupAnnouncementImage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyUploadGroupAnnouncementImageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes click_inline_keyboard_button.</summary>
    public static Task<MilkyActionResult<MilkyClickInlineKeyboardButtonResult>?> ClickInlineKeyboardButtonAsync(this IMilkyActionSession session, MilkyClickInlineKeyboardButtonRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyClickInlineKeyboardButtonResult>(MilkyConstant.Api.ClickInlineKeyboardButton, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyClickInlineKeyboardButtonRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_emoji_likes.</summary>
    public static Task<MilkyActionResult<MilkyGetEmojiLikesResult>?> GetEmojiLikesAsync(this IMilkyActionSession session, MilkyGetEmojiLikesRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetEmojiLikesResult>(MilkyConstant.Api.GetEmojiLikes, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetEmojiLikesRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_reaction_summary.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupReactionSummaryResult>?> GetGroupReactionSummaryAsync(this IMilkyActionSession session, MilkyGetGroupReactionSummaryRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupReactionSummaryResult>(MilkyConstant.Api.GetGroupReactionSummary, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupReactionSummaryRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_like.</summary>
    public static Task<MilkyActionResult?> SendLikeAsync(this IMilkyActionSession session, MilkySendLikeRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SendLike, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendLikeRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_poke.</summary>
    public static Task<MilkyActionResult?> SendPokeAsync(this IMilkyActionSession session, MilkySendPokeRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SendPoke, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendPokeRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_group_reaction.</summary>
    public static Task<MilkyActionResult?> SetGroupReactionAsync(this IMilkyActionSession session, MilkySetGroupReactionRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetGroupReaction, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetGroupReactionRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_input_status.</summary>
    public static Task<MilkyActionResult?> SetInputStatusAsync(this IMilkyActionSession session, MilkySetInputStatusRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetInputStatus, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetInputStatusRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_ai_voice_list.</summary>
    public static Task<MilkyActionResult<MilkyGetAiVoiceListResult>?> GetAiVoiceListAsync(this IMilkyActionSession session, MilkyGetAiVoiceListRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetAiVoiceListResult>(MilkyConstant.Api.GetAiVoiceList, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetAiVoiceListRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_collection.</summary>
    public static Task<MilkyActionResult<MilkyGetCollectionResult>?> GetCollectionAsync(this IMilkyActionSession session, MilkyGetCollectionRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetCollectionResult>(MilkyConstant.Api.GetCollection, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetCollectionRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_forwarded_messages.</summary>
    public static Task<MilkyActionResult<MilkyForwardedMessagesResult>?> GetForwardedMessagesAsync(this IMilkyActionSession session, MilkyGetForwardedMessagesRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyForwardedMessagesResult>(MilkyConstant.Api.GetForwardedMessages, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetForwardedMessagesRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_history_messages.</summary>
    public static Task<MilkyActionResult<MilkyHistoryMessagesResult>?> GetHistoryMessagesAsync(this IMilkyActionSession session, MilkyGetHistoryMessagesRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyHistoryMessagesResult>(MilkyConstant.Api.GetHistoryMessages, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetHistoryMessagesRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_message.</summary>
    public static Task<MilkyActionResult<MilkyGetMessageResult>?> GetMessageAsync(this IMilkyActionSession session, MilkyGetMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetMessageResult>(MilkyConstant.Api.GetMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_resource_temp_url.</summary>
    public static Task<MilkyActionResult<MilkyResourceTempUrlResult>?> GetResourceTempUrlAsync(this IMilkyActionSession session, MilkyGetResourceTempUrlRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyResourceTempUrlResult>(MilkyConstant.Api.GetResourceTempUrl, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetResourceTempUrlRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes probe_history_sync_state.</summary>
    public static Task<MilkyActionResult<MilkyProbeHistorySyncStateResult>?> ProbeHistorySyncStateAsync(this IMilkyActionSession session, MilkyProbeHistorySyncStateRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyProbeHistorySyncStateResult>(MilkyConstant.Api.ProbeHistorySyncState, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyProbeHistorySyncStateRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_history_sync_page.</summary>
    public static Task<MilkyActionResult<MilkyGetHistorySyncPageResult>?> GetHistorySyncPageAsync(this IMilkyActionSession session, MilkyGetHistorySyncPageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetHistorySyncPageResult>(MilkyConstant.Api.GetHistorySyncPage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetHistorySyncPageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_private_history_roam_page.</summary>
    public static Task<MilkyActionResult<MilkyGetPrivateHistoryRoamPageResult>?> GetPrivateHistoryRoamPageAsync(this IMilkyActionSession session, MilkyGetPrivateHistoryRoamPageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetPrivateHistoryRoamPageResult>(MilkyConstant.Api.GetPrivateHistoryRoamPage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetPrivateHistoryRoamPageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes mark_all_read.</summary>
    public static Task<MilkyActionResult?> MarkAllReadAsync(this IMilkyActionSession session, MilkyMarkAllReadRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.MarkAllRead, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyMarkAllReadRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes mark_message_as_read.</summary>
    public static Task<MilkyActionResult?> MarkMessageAsReadAsync(this IMilkyActionSession session, MilkyMarkMessageAsReadRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.MarkMessageAsRead, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyMarkMessageAsReadRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes recall_group_message.</summary>
    public static Task<MilkyActionResult?> RecallGroupMessageAsync(this IMilkyActionSession session, MilkyRecallGroupMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.RecallGroupMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyRecallGroupMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes recall_private_message.</summary>
    public static Task<MilkyActionResult?> RecallPrivateMessageAsync(this IMilkyActionSession session, MilkyRecallPrivateMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.RecallPrivateMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyRecallPrivateMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_ai_voice.</summary>
    public static Task<MilkyActionResult<MilkySendAiVoiceResult>?> SendAiVoiceAsync(this IMilkyActionSession session, MilkySendAiVoiceRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySendAiVoiceResult>(MilkyConstant.Api.SendAiVoice, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendAiVoiceRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_group_message.</summary>
    public static Task<MilkyActionResult<MilkySendMessageResult>?> SendGroupMessageAsync(this IMilkyActionSession session, MilkySendGroupMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySendMessageResult>(MilkyConstant.Api.SendGroupMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendGroupMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_private_message.</summary>
    public static Task<MilkyActionResult<MilkySendMessageResult>?> SendPrivateMessageAsync(this IMilkyActionSession session, MilkySendPrivateMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySendMessageResult>(MilkyConstant.Api.SendPrivateMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendPrivateMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_temp_message.</summary>
    public static Task<MilkyActionResult<MilkySendTempMessageResult>?> SendTempMessageAsync(this IMilkyActionSession session, MilkySendTempMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySendTempMessageResult>(MilkyConstant.Api.SendTempMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendTempMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes synthesize_ai_voice.</summary>
    public static Task<MilkyActionResult<MilkySynthesizeAiVoiceResult>?> SynthesizeAiVoiceAsync(this IMilkyActionSession session, MilkySynthesizeAiVoiceRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySynthesizeAiVoiceResult>(MilkyConstant.Api.SynthesizeAiVoice, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySynthesizeAiVoiceRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes transcribe_voice.</summary>
    public static Task<MilkyActionResult<MilkyTranscribeVoiceResult>?> TranscribeVoiceAsync(this IMilkyActionSession session, MilkyTranscribeVoiceRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyTranscribeVoiceResult>(MilkyConstant.Api.TranscribeVoice, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyTranscribeVoiceRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes add_custom_face.</summary>
    public static Task<MilkyActionResult<MilkyAddCustomFaceResult>?> AddCustomFaceAsync(this IMilkyActionSession session, MilkyAddCustomFaceRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyAddCustomFaceResult>(MilkyConstant.Api.AddCustomFace, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyAddCustomFaceRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes comment_qzone_message.</summary>
    public static Task<MilkyActionResult<MilkyCommentQzoneMessageResult>?> CommentQzoneMessageAsync(this IMilkyActionSession session, MilkyCommentQzoneMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyCommentQzoneMessageResult>(MilkyConstant.Api.CommentQzoneMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyCommentQzoneMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes delete_custom_face.</summary>
    public static Task<MilkyActionResult?> DeleteCustomFaceAsync(this IMilkyActionSession session, MilkyDeleteCustomFaceRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.DeleteCustomFace, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyDeleteCustomFaceRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes delete_qzone_message.</summary>
    public static Task<MilkyActionResult?> DeleteQzoneMessageAsync(this IMilkyActionSession session, MilkyDeleteQzoneMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.DeleteQzoneMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyDeleteQzoneMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_system_msg.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupSystemMsgResult>?> GetGroupSystemMsgAsync(this IMilkyActionSession session, MilkyGetGroupSystemMsgRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupSystemMsgResult>(MilkyConstant.Api.GetGroupSystemMsg, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupSystemMsgRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_shut_list.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupShutListResult>?> GetGroupShutListAsync(this IMilkyActionSession session, MilkyGetGroupShutListRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupShutListResult>(MilkyConstant.Api.GetGroupShutList, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupShutListRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_doubt_friends_add_request.</summary>
    public static Task<MilkyActionResult<MilkyGetDoubtFriendsAddRequestResult>?> GetDoubtFriendsAddRequestAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetDoubtFriendsAddRequestResult>(MilkyConstant.Api.GetDoubtFriendsAddRequest, MilkyEmptyObject.Instance, cancellationToken);

    /// <summary>Invokes set_doubt_friends_add_request.</summary>
    public static Task<MilkyActionResult?> SetDoubtFriendsAddRequestAsync(this IMilkyActionSession session, MilkySetDoubtFriendsAddRequestRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetDoubtFriendsAddRequest, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetDoubtFriendsAddRequestRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_qidian_corp_info.</summary>
    public static Task<MilkyActionResult<MilkyGetQidianCorpInfoResult>?> GetQidianCorpInfoAsync(this IMilkyActionSession session, MilkyGetQidianCorpInfoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetQidianCorpInfoResult>(MilkyConstant.Api.GetQidianCorpInfo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetQidianCorpInfoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_ark_share.</summary>
    public static Task<MilkyActionResult<MilkySendArkShareResult>?> SendArkShareAsync(this IMilkyActionSession session, MilkySendArkShareRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySendArkShareResult>(MilkyConstant.Api.SendArkShare, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendArkShareRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_tuwen_ark.</summary>
    public static Task<MilkyActionResult<MilkySendTuwenArkResult>?> SendTuwenArkAsync(this IMilkyActionSession session, MilkySendTuwenArkRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySendTuwenArkResult>(MilkyConstant.Api.SendTuwenArk, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendTuwenArkRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_cookies.</summary>
    public static Task<MilkyActionResult<MilkyCookiesResult>?> GetCookiesAsync(this IMilkyActionSession session, MilkyGetCookiesRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyCookiesResult>(MilkyConstant.Api.GetCookies, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetCookiesRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_custom_face_detail.</summary>
    public static Task<MilkyActionResult<MilkyGetCustomFaceDetailResult>?> GetCustomFaceDetailAsync(this IMilkyActionSession session, MilkyGetCustomFaceDetailRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetCustomFaceDetailResult>(MilkyConstant.Api.GetCustomFaceDetail, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetCustomFaceDetailRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_custom_face_list.</summary>
    public static Task<MilkyActionResult<MilkyGetCustomFaceListResult>?> GetCustomFaceListAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetCustomFaceListResult>(MilkyConstant.Api.GetCustomFaceList, MilkyEmptyObject.Instance, cancellationToken);

    /// <summary>Invokes get_friend_dress.</summary>
    public static Task<MilkyActionResult<MilkyGetFriendDressResult>?> GetFriendDressAsync(this IMilkyActionSession session, MilkyGetFriendDressRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetFriendDressResult>(MilkyConstant.Api.GetFriendDress, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetFriendDressRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_friend_info.</summary>
    public static Task<MilkyActionResult<MilkyFriendResult>?> GetFriendInfoAsync(this IMilkyActionSession session, MilkyGetFriendInfoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyFriendResult>(MilkyConstant.Api.GetFriendInfo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetFriendInfoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_friend_list.</summary>
    public static Task<MilkyActionResult<MilkyFriendsResult>?> GetFriendListAsync(this IMilkyActionSession session, MilkyGetFriendListRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyFriendsResult>(MilkyConstant.Api.GetFriendList, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetFriendListRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_friends_status.</summary>
    public static Task<MilkyActionResult<MilkyGetFriendsStatusResult>?> GetFriendsStatusAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetFriendsStatusResult>(MilkyConstant.Api.GetFriendsStatus, MilkyEmptyObject.Instance, cancellationToken);

    /// <summary>Invokes get_group_ext_info.</summary>
    public static Task<MilkyActionResult<MilkyGetGroupExtInfoResult>?> GetGroupExtInfoAsync(this IMilkyActionSession session, MilkyGetGroupExtInfoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetGroupExtInfoResult>(MilkyConstant.Api.GetGroupExtInfo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupExtInfoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_info.</summary>
    public static Task<MilkyActionResult<MilkyGroupResult>?> GetGroupInfoAsync(this IMilkyActionSession session, MilkyGetGroupInfoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGroupResult>(MilkyConstant.Api.GetGroupInfo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupInfoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_list.</summary>
    public static Task<MilkyActionResult<MilkyGroupsResult>?> GetGroupListAsync(this IMilkyActionSession session, MilkyGetGroupListRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGroupsResult>(MilkyConstant.Api.GetGroupList, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupListRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_member_info.</summary>
    public static Task<MilkyActionResult<MilkyMemberResult>?> GetGroupMemberInfoAsync(this IMilkyActionSession session, MilkyGetGroupMemberInfoRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyMemberResult>(MilkyConstant.Api.GetGroupMemberInfo, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupMemberInfoRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_group_member_list.</summary>
    public static Task<MilkyActionResult<MilkyMembersResult>?> GetGroupMemberListAsync(this IMilkyActionSession session, MilkyGetGroupMemberListRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyMembersResult>(MilkyConstant.Api.GetGroupMemberList, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetGroupMemberListRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_mini_app_ark.</summary>
    public static Task<MilkyActionResult<MilkyGetMiniAppArkResult>?> GetMiniAppArkAsync(this IMilkyActionSession session, MilkyGetMiniAppArkRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetMiniAppArkResult>(MilkyConstant.Api.GetMiniAppArk, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetMiniAppArkRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_online_devices.</summary>
    public static Task<MilkyActionResult<MilkyGetOnlineDevicesResult>?> GetOnlineDevicesAsync(this IMilkyActionSession session, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetOnlineDevicesResult>(MilkyConstant.Api.GetOnlineDevices, MilkyEmptyObject.Instance, cancellationToken);

    /// <summary>Invokes get_like.</summary>
    public static Task<MilkyActionResult<MilkyGetLikeResult>?> GetLikeAsync(this IMilkyActionSession session, MilkyGetLikeRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetLikeResult>(MilkyConstant.Api.GetLike, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetLikeRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_qzone_feeds.</summary>
    public static Task<MilkyActionResult<MilkyGetQzoneFeedsResult>?> GetQzoneFeedsAsync(this IMilkyActionSession session, MilkyGetQzoneFeedsRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetQzoneFeedsResult>(MilkyConstant.Api.GetQzoneFeeds, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetQzoneFeedsRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_qzone_msg_list.</summary>
    public static Task<MilkyActionResult<MilkyGetQzoneMsgListResult>?> GetQzoneMsgListAsync(this IMilkyActionSession session, MilkyGetQzoneMsgListRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetQzoneMsgListResult>(MilkyConstant.Api.GetQzoneMsgList, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetQzoneMsgListRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_system_faces.</summary>
    public static Task<MilkyActionResult<MilkyGetSystemFacesResult>?> GetSystemFacesAsync(this IMilkyActionSession session, MilkyGetSystemFacesRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetSystemFacesResult>(MilkyConstant.Api.GetSystemFaces, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetSystemFacesRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_user_profile.</summary>
    public static Task<MilkyActionResult<MilkyUserProfileResult>?> GetUserProfileAsync(this IMilkyActionSession session, MilkyGetUserProfileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyUserProfileResult>(MilkyConstant.Api.GetUserProfile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetUserProfileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes get_user_status.</summary>
    public static Task<MilkyActionResult<MilkyGetUserStatusResult>?> GetUserStatusAsync(this IMilkyActionSession session, MilkyGetUserStatusRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyGetUserStatusResult>(MilkyConstant.Api.GetUserStatus, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyGetUserStatusRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes image_ocr.</summary>
    public static Task<MilkyActionResult<MilkyImageOcrResult>?> ImageOcrAsync(this IMilkyActionSession session, MilkyImageOcrRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyImageOcrResult>(MilkyConstant.Api.ImageOcr, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyImageOcrRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes modify_custom_face.</summary>
    public static Task<MilkyActionResult?> ModifyCustomFaceAsync(this IMilkyActionSession session, MilkyModifyCustomFaceRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.ModifyCustomFace, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyModifyCustomFaceRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes move_custom_face.</summary>
    public static Task<MilkyActionResult?> MoveCustomFaceAsync(this IMilkyActionSession session, MilkyMoveCustomFaceRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.MoveCustomFace, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyMoveCustomFaceRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes publish_qzone_message.</summary>
    public static Task<MilkyActionResult<MilkyPublishQzoneMessageResult>?> PublishQzoneMessageAsync(this IMilkyActionSession session, MilkyPublishQzoneMessageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyPublishQzoneMessageResult>(MilkyConstant.Api.PublishQzoneMessage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyPublishQzoneMessageRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes request_database_key.</summary>
    public static Task<MilkyActionResult<MilkyRequestDatabaseKeyResult>?> RequestDatabaseKeyAsync(this IMilkyActionSession session, MilkyRequestDatabaseKeyRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyRequestDatabaseKeyResult>(MilkyConstant.Api.RequestDatabaseKey, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyRequestDatabaseKeyRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes request_decrypt_key.</summary>
    public static Task<MilkyActionResult<MilkyRequestDecryptKeyResult>?> RequestDecryptKeyAsync(this IMilkyActionSession session, MilkyRequestDecryptKeyRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyRequestDecryptKeyResult>(MilkyConstant.Api.RequestDecryptKey, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyRequestDecryptKeyRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes search_system_faces.</summary>
    public static Task<MilkyActionResult<MilkySearchSystemFacesResult>?> SearchSystemFacesAsync(this IMilkyActionSession session, MilkySearchSystemFacesRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySearchSystemFacesResult>(MilkyConstant.Api.SearchSystemFaces, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySearchSystemFacesRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_packet.</summary>
    public static Task<MilkyActionResult<MilkyRawPacketData>?> SendPacketAsync(this IMilkyActionSession session, MilkySendPacketRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyRawPacketData>(MilkyConstant.Api.SendPacket, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendPacketRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes send_profile_like.</summary>
    public static Task<MilkyActionResult?> SendProfileLikeAsync(this IMilkyActionSession session, MilkySendProfileLikeRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SendProfileLike, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySendProfileLikeRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_avatar.</summary>
    public static Task<MilkyActionResult?> SetAvatarAsync(this IMilkyActionSession session, MilkySetAvatarRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetAvatar, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetAvatarRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_bio.</summary>
    public static Task<MilkyActionResult?> SetBioAsync(this IMilkyActionSession session, MilkySetBioRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetBio, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetBioRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_diy_online_status.</summary>
    public static Task<MilkyActionResult?> SetDiyOnlineStatusAsync(this IMilkyActionSession session, MilkySetDiyOnlineStatusRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetDiyOnlineStatus, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetDiyOnlineStatusRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_nickname.</summary>
    public static Task<MilkyActionResult?> SetNicknameAsync(this IMilkyActionSession session, MilkySetNicknameRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetNickname, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetNicknameRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_online_status.</summary>
    public static Task<MilkyActionResult?> SetOnlineStatusAsync(this IMilkyActionSession session, MilkySetOnlineStatusRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetOnlineStatus, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetOnlineStatusRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_peer_pin.</summary>
    public static Task<MilkyActionResult?> SetPeerPinAsync(this IMilkyActionSession session, MilkySetPeerPinRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetPeerPin, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetPeerPinRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_profile.</summary>
    public static Task<MilkyActionResult?> SetProfileAsync(this IMilkyActionSession session, MilkySetProfileRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetProfile, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetProfileRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_qzone_black.</summary>
    public static Task<MilkyActionResult?> SetQzoneBlackAsync(this IMilkyActionSession session, MilkySetQzoneBlackRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetQzoneBlack, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetQzoneBlackRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_qzone_like.</summary>
    public static Task<MilkyActionResult<MilkySetQzoneLikeResult>?> SetQzoneLikeAsync(this IMilkyActionSession session, MilkySetQzoneLikeRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkySetQzoneLikeResult>(MilkyConstant.Api.SetQzoneLike, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetQzoneLikeRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_qzone_message_visibility.</summary>
    public static Task<MilkyActionResult?> SetQzoneMessageVisibilityAsync(this IMilkyActionSession session, MilkySetQzoneMessageVisibilityRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetQzoneMessageVisibility, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetQzoneMessageVisibilityRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes set_self_long_nick.</summary>
    public static Task<MilkyActionResult?> SetSelfLongNickAsync(this IMilkyActionSession session, MilkySetSelfLongNickRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync(MilkyConstant.Api.SetSelfLongNick, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkySetSelfLongNickRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes translate_en_to_zh.</summary>
    public static Task<MilkyActionResult<MilkyTranslateEnToZhResult>?> TranslateEnToZhAsync(this IMilkyActionSession session, MilkyTranslateEnToZhRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyTranslateEnToZhResult>(MilkyConstant.Api.TranslateEnToZh, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyTranslateEnToZhRequest)!.AsObject(), cancellationToken);

    /// <summary>Invokes upload_qzone_image.</summary>
    public static Task<MilkyActionResult<MilkyUploadQzoneImageResult>?> UploadQzoneImageAsync(this IMilkyActionSession session, MilkyUploadQzoneImageRequest request, CancellationToken cancellationToken = default)
        => session.InvokeApiAsync<MilkyUploadQzoneImageResult>(MilkyConstant.Api.UploadQzoneImage, JsonSerializer.SerializeToNode(request ?? throw new ArgumentNullException(nameof(request)), MilkyJsonSerializerContext.Default.MilkyUploadQzoneImageRequest)!.AsObject(), cancellationToken);
}
