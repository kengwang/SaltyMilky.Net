using System.Text.Json;
using System.Text.Json.Nodes;
using SaltyMilky.Net;

namespace SaltyMilky.Net.Tests;

public sealed class LagrangeApiContractSmoke
{
    public async Task RunAsync()
    {
        await CommitFlashFile_MatchesServerWireContract();
        await CompleteFlashTask_MatchesServerWireContract();
        await ConvertRecord_MatchesServerWireContract();
        await CreateFlashTask_MatchesServerWireContract();
        await CreateGroupFolder_MatchesServerWireContract();
        await DeleteFlashFile_MatchesServerWireContract();
        await DeleteGroupFile_MatchesServerWireContract();
        await DeleteGroupFolder_MatchesServerWireContract();
        await UploadFlashFiles_MatchesServerWireContract();
        await GetFlashDownload_MatchesServerWireContract();
        await GetFlashShareLink_MatchesServerWireContract();
        await ResolveFlashShareCode_MatchesServerWireContract();
        await GetDownloadRkeys_MatchesServerWireContract();
        await GetFlashFileset_MatchesServerWireContract();
        await GetFlashFileUrl_MatchesServerWireContract();
        await GetGroupFileCount_MatchesServerWireContract();
        await GetGroupFileDownloadUrl_MatchesServerWireContract();
        await GetGroupFiles_MatchesServerWireContract();
        await GetGroupFileSpace_MatchesServerWireContract();
        await GetGroupFileUrl_MatchesServerWireContract();
        await GetGroupPttUrl_MatchesServerWireContract();
        await GetGroupVideoUrl_MatchesServerWireContract();
        await GetPrivatePttUrl_MatchesServerWireContract();
        await GetPrivateVideoUrl_MatchesServerWireContract();
        await GetPrivateFileDownloadUrl_MatchesServerWireContract();
        await ListFlashFilesets_MatchesServerWireContract();
        await MoveGroupFile_MatchesServerWireContract();
        await PublishGroupFile_MatchesServerWireContract();
        await RenameFlashFile_MatchesServerWireContract();
        await RenameGroupFile_MatchesServerWireContract();
        await RenameGroupFolder_MatchesServerWireContract();
        await SendFlashMessage_MatchesServerWireContract();
        await SetFlashTaskStatus_MatchesServerWireContract();
        await TransGroupFile_MatchesServerWireContract();
        await UploadGroupFile_MatchesServerWireContract();
        await UploadPrivateFile_MatchesServerWireContract();
        await DeleteFriend_MatchesServerWireContract();
        await GetFriendRequests_MatchesServerWireContract();
        await GetUnidirectionalFriendList_MatchesServerWireContract();
        await HandleFriendRequest_MatchesServerWireContract();
        await SendFriendNudge_MatchesServerWireContract();
        await SetFriendCategory_MatchesServerWireContract();
        await SetFriendRemark_MatchesServerWireContract();
        await AcceptGroupInvitation_MatchesServerWireContract();
        await AcceptGroupRequest_MatchesServerWireContract();
        await CancelGroupTodo_MatchesServerWireContract();
        await CommentGroupAlbumMedia_MatchesServerWireContract();
        await CompleteGroupTodo_MatchesServerWireContract();
        await DeleteGroupAlbumMedia_MatchesServerWireContract();
        await DeleteGroupAnnouncement_MatchesServerWireContract();
        await GetGroupAdminSettings_MatchesServerWireContract();
        await GetGroupAlbumMedia_MatchesServerWireContract();
        await GetGroupAlbumList_MatchesServerWireContract();
        await GetGroupAnnouncements_MatchesServerWireContract();
        await GetGroupAtAllRemain_MatchesServerWireContract();
        await GetGroupEssence_MatchesServerWireContract();
        await GetGroupEssenceMessages_MatchesServerWireContract();
        await GetGroupHonor_MatchesServerWireContract();
        await GetGroupNotifications_MatchesServerWireContract();
        await GetGroupSignIn_MatchesServerWireContract();
        await GetGroupTodo_MatchesServerWireContract();
        await GetGroupTodoList_MatchesServerWireContract();
        await KickGroupMember_MatchesServerWireContract();
        await QuitGroup_MatchesServerWireContract();
        await RejectGroupInvitation_MatchesServerWireContract();
        await RejectGroupRequest_MatchesServerWireContract();
        await SendGroupAnnouncement_MatchesServerWireContract();
        await SendGroupMessageReaction_MatchesServerWireContract();
        await SendGroupNudge_MatchesServerWireContract();
        await SendGroupSign_MatchesServerWireContract();
        await SetGroupAddOption_MatchesServerWireContract();
        await SetGroupAlbumLike_MatchesServerWireContract();
        await SetGroupAvatar_MatchesServerWireContract();
        await SetGroupEssenceMessage_MatchesServerWireContract();
        await SetGroupMemberInvitePolicy_MatchesServerWireContract();
        await SetGroupMemberAdmin_MatchesServerWireContract();
        await SetGroupMemberCard_MatchesServerWireContract();
        await SetGroupMemberMute_MatchesServerWireContract();
        await SetGroupMemberPermission_MatchesServerWireContract();
        await SetGroupMemberSpecialTitle_MatchesServerWireContract();
        await SetGroupName_MatchesServerWireContract();
        await SetGroupNewMemberHistoryVisibility_MatchesServerWireContract();
        await SetGroupRemark_MatchesServerWireContract();
        await SetGroupRobotAddOption_MatchesServerWireContract();
        await SetGroupSearch_MatchesServerWireContract();
        await SetGroupTodo_MatchesServerWireContract();
        await SetGroupWholeMute_MatchesServerWireContract();
        await TransferGroup_MatchesServerWireContract();
        await UploadGroupAlbumImage_MatchesServerWireContract();
        await UploadGroupAlbumVideo_MatchesServerWireContract();
        await UploadGroupAnnouncementImage_MatchesServerWireContract();
        await ClickInlineKeyboardButton_MatchesServerWireContract();
        await GetEmojiLikes_MatchesServerWireContract();
        await GetGroupReactionSummary_MatchesServerWireContract();
        await SendLike_MatchesServerWireContract();
        await SendPoke_MatchesServerWireContract();
        await SetGroupReaction_MatchesServerWireContract();
        await SetInputStatus_MatchesServerWireContract();
        await GetAiVoiceList_MatchesServerWireContract();
        await GetCollection_MatchesServerWireContract();
        await GetForwardedMessages_MatchesServerWireContract();
        await GetHistoryMessages_MatchesServerWireContract();
        await GetMessage_MatchesServerWireContract();
        await GetResourceTempUrl_MatchesServerWireContract();
        await ProbeHistorySyncState_MatchesServerWireContract();
        await GetHistorySyncPage_MatchesServerWireContract();
        await GetPrivateHistoryRoamPage_MatchesServerWireContract();
        await MarkAllRead_MatchesServerWireContract();
        await MarkMessageAsRead_MatchesServerWireContract();
        await RecallGroupMessage_MatchesServerWireContract();
        await RecallPrivateMessage_MatchesServerWireContract();
        await SendAiVoice_MatchesServerWireContract();
        await SendGroupMessage_MatchesServerWireContract();
        await SendPrivateMessage_MatchesServerWireContract();
        await SendTempMessage_MatchesServerWireContract();
        await SynthesizeAiVoice_MatchesServerWireContract();
        await TranscribeVoice_MatchesServerWireContract();
        await AddCustomFace_MatchesServerWireContract();
        await CommentQzoneMessage_MatchesServerWireContract();
        await DeleteCustomFace_MatchesServerWireContract();
        await DeleteQzoneMessage_MatchesServerWireContract();
        await GetGroupSystemMsg_MatchesServerWireContract();
        await GetGroupShutList_MatchesServerWireContract();
        await GetDoubtFriendsAddRequest_MatchesServerWireContract();
        await SetDoubtFriendsAddRequest_MatchesServerWireContract();
        await GetQidianCorpInfo_MatchesServerWireContract();
        await SendArkShare_MatchesServerWireContract();
        await SendTuwenArk_MatchesServerWireContract();
        await GetCookies_MatchesServerWireContract();
        await GetCsrfToken_MatchesServerWireContract();
        await GetCustomFaceDetail_MatchesServerWireContract();
        await GetCustomFaceList_MatchesServerWireContract();
        await GetCustomFaceUrlList_MatchesServerWireContract();
        await GetFriendDress_MatchesServerWireContract();
        await GetFriendInfo_MatchesServerWireContract();
        await GetFriendList_MatchesServerWireContract();
        await GetFriendsStatus_MatchesServerWireContract();
        await GetGroupExtInfo_MatchesServerWireContract();
        await GetGroupInfo_MatchesServerWireContract();
        await GetGroupList_MatchesServerWireContract();
        await GetGroupMemberInfo_MatchesServerWireContract();
        await GetGroupMemberList_MatchesServerWireContract();
        await GetImplInfo_MatchesServerWireContract();
        await GetLoginInfo_MatchesServerWireContract();
        await GetMiniAppArk_MatchesServerWireContract();
        await GetOnlineDevices_MatchesServerWireContract();
        await GetPeerPins_MatchesServerWireContract();
        await GetLike_MatchesServerWireContract();
        await GetQzoneFeeds_MatchesServerWireContract();
        await GetQzoneMsgList_MatchesServerWireContract();
        await GetSystemFaces_MatchesServerWireContract();
        await GetUserProfile_MatchesServerWireContract();
        await GetUserStatus_MatchesServerWireContract();
        await ImageOcr_MatchesServerWireContract();
        await ModifyCustomFace_MatchesServerWireContract();
        await MoveCustomFace_MatchesServerWireContract();
        await PublishQzoneMessage_MatchesServerWireContract();
        await RequestDatabaseKey_MatchesServerWireContract();
        await RequestDecryptKey_MatchesServerWireContract();
        await SearchSystemFaces_MatchesServerWireContract();
        await SendPacket_MatchesServerWireContract();
        await SendProfileLike_MatchesServerWireContract();
        await SetAvatar_MatchesServerWireContract();
        await SetBio_MatchesServerWireContract();
        await SetDiyOnlineStatus_MatchesServerWireContract();
        await SetNickname_MatchesServerWireContract();
        await SetOnlineStatus_MatchesServerWireContract();
        await SetPeerPin_MatchesServerWireContract();
        await SetProfile_MatchesServerWireContract();
        await SetQzoneBlack_MatchesServerWireContract();
        await SetQzoneLike_MatchesServerWireContract();
        await SetQzoneMessageVisibility_MatchesServerWireContract();
        await SetSelfLongNick_MatchesServerWireContract();
        await TranslateEnToZh_MatchesServerWireContract();
        await UploadQzoneImage_MatchesServerWireContract();
        CommitFlashFile_PreservesServerDefaults();
        CreateFlashTask_PreservesServerDefaults();
        GetGroupFiles_PreservesServerDefaults();
        ListFlashFilesets_PreservesServerDefaults();
        MoveGroupFile_PreservesServerDefaults();
        SetFlashTaskStatus_PreservesServerDefaults();
        UploadGroupFile_PreservesServerDefaults();
        DeleteFriend_PreservesServerDefaults();
        SendFriendNudge_PreservesServerDefaults();
        AcceptGroupRequest_PreservesServerDefaults();
        GetGroupAnnouncements_PreservesServerDefaults();
        GetGroupEssence_PreservesServerDefaults();
        GetGroupEssenceMessages_PreservesServerDefaults();
        GetGroupHonor_PreservesServerDefaults();
        GetGroupNotifications_PreservesServerDefaults();
        KickGroupMember_PreservesServerDefaults();
        RejectGroupRequest_PreservesServerDefaults();
        SendGroupAnnouncement_PreservesServerDefaults();
        SendGroupMessageReaction_PreservesServerDefaults();
        SetGroupAlbumLike_PreservesServerDefaults();
        SetGroupEssenceMessage_PreservesServerDefaults();
        SetGroupMemberMute_PreservesServerDefaults();
        SetGroupWholeMute_PreservesServerDefaults();
        UploadGroupAlbumImage_PreservesServerDefaults();
        GetEmojiLikes_PreservesServerDefaults();
        SendLike_PreservesServerDefaults();
        SetGroupReaction_PreservesServerDefaults();
        GetCollection_PreservesServerDefaults();
        GetForwardedMessages_PreservesServerDefaults();
        GetHistoryMessages_PreservesServerDefaults();
        SendTuwenArk_PreservesServerDefaults();
        GetFriendInfo_PreservesServerDefaults();
        GetFriendList_PreservesServerDefaults();
        GetGroupInfo_PreservesServerDefaults();
        GetGroupList_PreservesServerDefaults();
        GetGroupMemberInfo_PreservesServerDefaults();
        GetGroupMemberList_PreservesServerDefaults();
        GetLike_PreservesServerDefaults();
        GetQzoneFeeds_PreservesServerDefaults();
        GetQzoneMsgList_PreservesServerDefaults();
        GetSystemFaces_PreservesServerDefaults();
        PublishQzoneMessage_PreservesServerDefaults();
        SearchSystemFaces_PreservesServerDefaults();
        SendPacket_PreservesServerDefaults();
        SendProfileLike_PreservesServerDefaults();
        SetPeerPin_PreservesServerDefaults();
        SetQzoneBlack_PreservesServerDefaults();
        SetQzoneLike_PreservesServerDefaults();
    }
    public async Task CommitFlashFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("commit_flash_file", """{"fileset_uuid":"fixture","upload_key":"fixture","file_uuid":"fixture","file_name":"fixture","file_size":23,"index":23,"format_code":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyCommitFlashFileRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture","upload_key":"fixture","file_uuid":"fixture","file_name":"fixture","file_size":23,"index":23,"format_code":23}""", MilkyJson.GetTypeInfo<MilkyCommitFlashFileRequest>())!;
        var result = await session.CommitFlashFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void CommitFlashFile_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyCommitFlashFileRequest(), MilkyJson.GetTypeInfo<MilkyCommitFlashFileRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"index":1,"format_code":26}"""));
    }

    public async Task CompleteFlashTask_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("complete_flash_task", """{"fileset_uuid":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyCompleteFlashTaskRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture"}""", MilkyJson.GetTypeInfo<MilkyCompleteFlashTaskRequest>())!;
        var result = await session.CompleteFlashTaskAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task ConvertRecord_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("convert_record", """{"file_uri":"fixture","format":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"base64":"fixture","size":23,"format":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyConvertRecordRequest request = JsonSerializer.Deserialize("""{"file_uri":"fixture","format":"fixture"}""", MilkyJson.GetTypeInfo<MilkyConvertRecordRequest>())!;
        var result = await session.ConvertRecordAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyConvertRecordResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"base64":"fixture","size":23,"format":"fixture"}"""));
    }

    public async Task CreateFlashTask_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("create_flash_task", """{"file_name":"fixture","file_size":23,"file_type":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"fileset_uuid":"fixture","upload_key":"fixture","upload_url":"fixture","expire":23,"ttl":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyCreateFlashTaskRequest request = JsonSerializer.Deserialize("""{"file_name":"fixture","file_size":23,"file_type":23}""", MilkyJson.GetTypeInfo<MilkyCreateFlashTaskRequest>())!;
        var result = await session.CreateFlashTaskAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyCreateFlashTaskResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"fileset_uuid":"fixture","upload_key":"fixture","upload_url":"fixture","expire":23,"ttl":23}"""));
    }

    public void CreateFlashTask_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyCreateFlashTaskRequest(), MilkyJson.GetTypeInfo<MilkyCreateFlashTaskRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"file_type":7}"""));
    }

    public async Task CreateGroupFolder_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("create_group_folder", """{"group_id":23,"folder_name":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"folder_id":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyCreateGroupFolderRequest request = JsonSerializer.Deserialize("""{"group_id":23,"folder_name":"fixture"}""", MilkyJson.GetTypeInfo<MilkyCreateGroupFolderRequest>())!;
        var result = await session.CreateGroupFolderAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyCreateGroupFolderResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"folder_id":"fixture"}"""));
    }

    public async Task DeleteFlashFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("delete_flash_file", """{"fileset_uuid":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyDeleteFlashFileRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture"}""", MilkyJson.GetTypeInfo<MilkyDeleteFlashFileRequest>())!;
        var result = await session.DeleteFlashFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task DeleteGroupFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("delete_group_file", """{"group_id":23,"file_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyDeleteGroupFileRequest request = JsonSerializer.Deserialize("""{"group_id":23,"file_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyDeleteGroupFileRequest>())!;
        var result = await session.DeleteGroupFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task DeleteGroupFolder_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("delete_group_folder", """{"group_id":23,"folder_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyDeleteGroupFolderRequest request = JsonSerializer.Deserialize("""{"group_id":23,"folder_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyDeleteGroupFolderRequest>())!;
        var result = await session.DeleteGroupFolderAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task UploadFlashFiles_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("upload_flash_files", """{"files":[{"file_uri":"fixture","file_name":"fixture"}],"name":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"fileset_uuid":"fixture","share_url":"fixture","files":[{"file_uuid":"fixture","file_index":23,"file_name":"fixture","file_size":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyUploadFlashFilesRequest request = JsonSerializer.Deserialize("""{"files":[{"file_uri":"fixture","file_name":"fixture"}],"name":"fixture"}""", MilkyJson.GetTypeInfo<MilkyUploadFlashFilesRequest>())!;
        var result = await session.UploadFlashFilesAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyUploadFlashFilesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"fileset_uuid":"fixture","share_url":"fixture","files":[{"file_uuid":"fixture","file_index":23,"file_name":"fixture","file_size":23}]}"""));
    }

    public async Task GetFlashDownload_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_flash_download", """{"fileset_uuid":"fixture","file_index":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"download_url":"fixture","file_name":"fixture","file_size":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetFlashDownloadRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture","file_index":23}""", MilkyJson.GetTypeInfo<MilkyGetFlashDownloadRequest>())!;
        var result = await session.GetFlashDownloadAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetFlashDownloadResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"download_url":"fixture","file_name":"fixture","file_size":23}"""));
    }

    public async Task GetFlashShareLink_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_flash_share_link", """{"fileset_uuid":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"share_url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetFlashShareLinkRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetFlashShareLinkRequest>())!;
        var result = await session.GetFlashShareLinkAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetFlashShareLinkResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"share_url":"fixture"}"""));
    }

    public async Task ResolveFlashShareCode_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("resolve_flash_share_code", """{"share_code":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"fileset_uuid":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyResolveFlashShareCodeRequest request = JsonSerializer.Deserialize("""{"share_code":"fixture"}""", MilkyJson.GetTypeInfo<MilkyResolveFlashShareCodeRequest>())!;
        var result = await session.ResolveFlashShareCodeAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyResolveFlashShareCodeResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"fileset_uuid":"fixture"}"""));
    }

    public async Task GetDownloadRkeys_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_download_rkeys", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"keys":[{"type":23,"key":"fixture","created_at":23,"ttl_seconds":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetDownloadRkeysAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetDownloadRkeysResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"keys":[{"type":23,"key":"fixture","created_at":23,"ttl_seconds":23}]}"""));
    }

    public async Task GetFlashFileset_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_flash_fileset", """{"fileset_uuid":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"files":[{"fileset_uuid":"fixture","file_name":"fixture","original_name":"fixture","file_type":23,"file_size":23,"upload_url":"fixture","file_id":"fixture","download_url":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetFlashFilesetRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetFlashFilesetRequest>())!;
        var result = await session.GetFlashFilesetAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetFlashFilesetResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"files":[{"fileset_uuid":"fixture","file_name":"fixture","original_name":"fixture","file_type":23,"file_size":23,"upload_url":"fixture","file_id":"fixture","download_url":"fixture"}]}"""));
    }

    public async Task GetFlashFileUrl_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_flash_file_url", """{"fileset_uuid":"fixture","file_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"download_url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetFlashFileUrlRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture","file_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetFlashFileUrlRequest>())!;
        var result = await session.GetFlashFileUrlAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetFlashFileUrlResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"download_url":"fixture"}"""));
    }

    public async Task GetGroupFileCount_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_file_count", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"file_count":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupFileCountRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupFileCountRequest>())!;
        var result = await session.GetGroupFileCountAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupFileCountResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"file_count":23}"""));
    }

    public async Task GetGroupFileDownloadUrl_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_file_download_url", """{"group_id":23,"file_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"download_url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupFileDownloadUrlRequest request = JsonSerializer.Deserialize("""{"group_id":23,"file_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetGroupFileDownloadUrlRequest>())!;
        var result = await session.GetGroupFileDownloadUrlAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyFileDownloadUrlResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"download_url":"fixture"}"""));
    }

    public async Task GetGroupFiles_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_files", """{"group_id":23,"parent_folder_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"files":[{"group_id":23,"file_id":"fixture","file_name":"fixture","parent_folder_id":"fixture","file_size":23,"uploaded_time":23,"modify_time":23,"expire_time":23,"uploader_id":23,"downloaded_times":23,"uploader_name":"fixture","create_time":23,"download_url":"fixture"}],"folders":[{"group_id":23,"folder_id":"fixture","parent_folder_id":"fixture","folder_name":"fixture","created_time":23,"last_modified_time":23,"creator_id":23,"file_count":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupFilesRequest request = JsonSerializer.Deserialize("""{"group_id":23,"parent_folder_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetGroupFilesRequest>())!;
        var result = await session.GetGroupFilesAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGroupFilesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"files":[{"group_id":23,"file_id":"fixture","file_name":"fixture","parent_folder_id":"fixture","file_size":23,"uploaded_time":23,"modify_time":23,"expire_time":23,"uploader_id":23,"downloaded_times":23,"uploader_name":"fixture","create_time":23,"download_url":"fixture"}],"folders":[{"group_id":23,"folder_id":"fixture","parent_folder_id":"fixture","folder_name":"fixture","created_time":23,"last_modified_time":23,"creator_id":23,"file_count":23}]}"""));
    }

    public void GetGroupFiles_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupFilesRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupFilesRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"parent_folder_id":"/"}"""));
    }

    public async Task GetGroupFileSpace_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_file_space", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"used_space":23,"total_space":23,"free_space":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupFileSpaceRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupFileSpaceRequest>())!;
        var result = await session.GetGroupFileSpaceAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupFileSpaceResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"used_space":23,"total_space":23,"free_space":23}"""));
    }

    public async Task GetGroupFileUrl_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_file_url", """{"group_id":23,"file_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupFileUrlRequest request = JsonSerializer.Deserialize("""{"group_id":23,"file_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetGroupFileUrlRequest>())!;
        var result = await session.GetGroupFileUrlAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupFileUrlResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"url":"fixture"}"""));
    }

    public async Task GetGroupPttUrl_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_ptt_url", """{"resource_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupPttUrlRequest request = JsonSerializer.Deserialize("""{"resource_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetGroupPttUrlRequest>())!;
        var result = await session.GetGroupPttUrlAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupPttUrlResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"url":"fixture"}"""));
    }

    public async Task GetGroupVideoUrl_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_video_url", """{"resource_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupVideoUrlRequest request = JsonSerializer.Deserialize("""{"resource_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetGroupVideoUrlRequest>())!;
        var result = await session.GetGroupVideoUrlAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupVideoUrlResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"url":"fixture"}"""));
    }

    public async Task GetPrivatePttUrl_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_private_ptt_url", """{"resource_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetPrivatePttUrlRequest request = JsonSerializer.Deserialize("""{"resource_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetPrivatePttUrlRequest>())!;
        var result = await session.GetPrivatePttUrlAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetPrivatePttUrlResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"url":"fixture"}"""));
    }

    public async Task GetPrivateVideoUrl_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_private_video_url", """{"resource_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetPrivateVideoUrlRequest request = JsonSerializer.Deserialize("""{"resource_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetPrivateVideoUrlRequest>())!;
        var result = await session.GetPrivateVideoUrlAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetPrivateVideoUrlResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"url":"fixture"}"""));
    }

    public async Task GetPrivateFileDownloadUrl_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_private_file_download_url", """{"file_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"download_url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetPrivateFileDownloadUrlRequest request = JsonSerializer.Deserialize("""{"file_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetPrivateFileDownloadUrlRequest>())!;
        var result = await session.GetPrivateFileDownloadUrlAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyFileDownloadUrlResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"download_url":"fixture"}"""));
    }

    public async Task ListFlashFilesets_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("list_flash_filesets", """{"limit":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"files":[{"fileset_uuid":"fixture","file_name":"fixture","file_size":23,"file_id":"fixture","download_url":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyListFlashFilesetsRequest request = JsonSerializer.Deserialize("""{"limit":23}""", MilkyJson.GetTypeInfo<MilkyListFlashFilesetsRequest>())!;
        var result = await session.ListFlashFilesetsAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyListFlashFilesetsResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"files":[{"fileset_uuid":"fixture","file_name":"fixture","file_size":23,"file_id":"fixture","download_url":"fixture"}]}"""));
    }

    public void ListFlashFilesets_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyListFlashFilesetsRequest(), MilkyJson.GetTypeInfo<MilkyListFlashFilesetsRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"limit":10}"""));
    }

    public async Task MoveGroupFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("move_group_file", """{"group_id":23,"file_id":"fixture","parent_folder_id":"fixture","target_folder_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyMoveGroupFileRequest request = JsonSerializer.Deserialize("""{"group_id":23,"file_id":"fixture","parent_folder_id":"fixture","target_folder_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyMoveGroupFileRequest>())!;
        var result = await session.MoveGroupFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void MoveGroupFile_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyMoveGroupFileRequest(), MilkyJson.GetTypeInfo<MilkyMoveGroupFileRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"parent_folder_id":"/","target_folder_id":"/"}"""));
    }

    public async Task PublishGroupFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("publish_group_file", """{"group_id":23,"file_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyPublishGroupFileRequest request = JsonSerializer.Deserialize("""{"group_id":23,"file_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyPublishGroupFileRequest>())!;
        var result = await session.PublishGroupFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task RenameFlashFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("rename_flash_file", """{"fileset_uuid":"fixture","new_name":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyRenameFlashFileRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture","new_name":"fixture"}""", MilkyJson.GetTypeInfo<MilkyRenameFlashFileRequest>())!;
        var result = await session.RenameFlashFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task RenameGroupFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("rename_group_file", """{"group_id":23,"file_id":"fixture","parent_directory":"fixture","new_file_name":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyRenameGroupFileRequest request = JsonSerializer.Deserialize("""{"group_id":23,"file_id":"fixture","parent_directory":"fixture","new_file_name":"fixture"}""", MilkyJson.GetTypeInfo<MilkyRenameGroupFileRequest>())!;
        var result = await session.RenameGroupFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task RenameGroupFolder_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("rename_group_folder", """{"group_id":23,"folder_id":"fixture","new_folder_name":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyRenameGroupFolderRequest request = JsonSerializer.Deserialize("""{"group_id":23,"folder_id":"fixture","new_folder_name":"fixture"}""", MilkyJson.GetTypeInfo<MilkyRenameGroupFolderRequest>())!;
        var result = await session.RenameGroupFolderAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SendFlashMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_flash_message", """{"fileset_uuid":"fixture","user_id":23,"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendFlashMessageRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture","user_id":23,"group_id":23}""", MilkyJson.GetTypeInfo<MilkySendFlashMessageRequest>())!;
        var result = await session.SendFlashMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetFlashTaskStatus_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_flash_task_status", """{"fileset_uuid":"fixture","status":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetFlashTaskStatusRequest request = JsonSerializer.Deserialize("""{"fileset_uuid":"fixture","status":23}""", MilkyJson.GetTypeInfo<MilkySetFlashTaskStatusRequest>())!;
        var result = await session.SetFlashTaskStatusAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SetFlashTaskStatus_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySetFlashTaskStatusRequest(), MilkyJson.GetTypeInfo<MilkySetFlashTaskStatusRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"status":6}"""));
    }

    public async Task TransGroupFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("trans_group_file", """{"group_id":23,"file_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"save_bus_id":23,"save_file_path":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyTransGroupFileRequest request = JsonSerializer.Deserialize("""{"group_id":23,"file_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyTransGroupFileRequest>())!;
        var result = await session.TransGroupFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyTransGroupFileResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"save_bus_id":23,"save_file_path":"fixture"}"""));
    }

    public async Task UploadGroupFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("upload_group_file", """{"group_id":23,"file_uri":"fixture","file_name":"fixture","parent_folder_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"file_id":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyUploadGroupFileRequest request = JsonSerializer.Deserialize("""{"group_id":23,"file_uri":"fixture","file_name":"fixture","parent_folder_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyUploadGroupFileRequest>())!;
        var result = await session.UploadGroupFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyFileUploadResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"file_id":"fixture"}"""));
    }

    public void UploadGroupFile_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyUploadGroupFileRequest(), MilkyJson.GetTypeInfo<MilkyUploadGroupFileRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"parent_folder_id":"/"}"""));
    }

    public async Task UploadPrivateFile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("upload_private_file", """{"user_id":23,"file_uri":"fixture","file_name":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"file_id":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyUploadPrivateFileRequest request = JsonSerializer.Deserialize("""{"user_id":23,"file_uri":"fixture","file_name":"fixture"}""", MilkyJson.GetTypeInfo<MilkyUploadPrivateFileRequest>())!;
        var result = await session.UploadPrivateFileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyFileUploadResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"file_id":"fixture"}"""));
    }

    public async Task DeleteFriend_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("delete_friend", """{"user_id":23,"block":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyDeleteFriendRequest request = JsonSerializer.Deserialize("""{"user_id":23,"block":true}""", MilkyJson.GetTypeInfo<MilkyDeleteFriendRequest>())!;
        var result = await session.DeleteFriendAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void DeleteFriend_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyDeleteFriendRequest(), MilkyJson.GetTypeInfo<MilkyDeleteFriendRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"block":false}"""));
    }

    public async Task GetFriendRequests_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_friend_requests", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"requests":[{"target_user_id":23,"source_user_id":23,"comment":"fixture","source":"fixture","time":23,"state":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetFriendRequestsAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyFriendRequestsResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"requests":[{"target_user_id":23,"source_user_id":23,"comment":"fixture","source":"fixture","time":23,"state":"fixture"}]}"""));
    }

    public async Task GetUnidirectionalFriendList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_unidirectional_friend_list", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"entries":[{"fixture":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetUnidirectionalFriendListAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetUnidirectionalFriendListResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"entries":[{"fixture":"fixture"}]}"""));
    }

    public async Task HandleFriendRequest_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("handle_friend_request", """{"flag":"fixture","approve":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyHandleFriendRequestRequest request = JsonSerializer.Deserialize("""{"flag":"fixture","approve":true}""", MilkyJson.GetTypeInfo<MilkyHandleFriendRequestRequest>())!;
        var result = await session.HandleFriendRequestAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SendFriendNudge_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_friend_nudge", """{"user_id":23,"is_self":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendFriendNudgeRequest request = JsonSerializer.Deserialize("""{"user_id":23,"is_self":true}""", MilkyJson.GetTypeInfo<MilkySendFriendNudgeRequest>())!;
        var result = await session.SendFriendNudgeAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SendFriendNudge_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySendFriendNudgeRequest(), MilkyJson.GetTypeInfo<MilkySendFriendNudgeRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_self":false}"""));
    }

    public async Task SetFriendCategory_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_friend_category", """{"user_id":23,"category_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetFriendCategoryRequest request = JsonSerializer.Deserialize("""{"user_id":23,"category_id":23}""", MilkyJson.GetTypeInfo<MilkySetFriendCategoryRequest>())!;
        var result = await session.SetFriendCategoryAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetFriendRemark_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_friend_remark", """{"user_id":23,"remark":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetFriendRemarkRequest request = JsonSerializer.Deserialize("""{"user_id":23,"remark":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetFriendRemarkRequest>())!;
        var result = await session.SetFriendRemarkAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task AcceptGroupInvitation_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("accept_group_invitation", """{"group_id":23,"invitation_seq":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyAcceptGroupInvitationRequest request = JsonSerializer.Deserialize("""{"group_id":23,"invitation_seq":23}""", MilkyJson.GetTypeInfo<MilkyAcceptGroupInvitationRequest>())!;
        var result = await session.AcceptGroupInvitationAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task AcceptGroupRequest_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("accept_group_request", """{"notification_seq":23,"notification_type":"fixture","group_id":23,"is_filtered":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyAcceptGroupRequestRequest request = JsonSerializer.Deserialize("""{"notification_seq":23,"notification_type":"fixture","group_id":23,"is_filtered":true}""", MilkyJson.GetTypeInfo<MilkyAcceptGroupRequestRequest>())!;
        var result = await session.AcceptGroupRequestAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void AcceptGroupRequest_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyAcceptGroupRequestRequest(), MilkyJson.GetTypeInfo<MilkyAcceptGroupRequestRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_filtered":false}"""));
    }

    public async Task CancelGroupTodo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("cancel_group_todo", """{"message_seq":23,"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyCancelGroupTodoRequest request = JsonSerializer.Deserialize("""{"message_seq":23,"group_id":23}""", MilkyJson.GetTypeInfo<MilkyCancelGroupTodoRequest>())!;
        var result = await session.CancelGroupTodoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task CommentGroupAlbumMedia_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("comment_group_album_media", """{"group_id":23,"album_id":"fixture","media_id":"fixture","content":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"comment_id":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyCommentGroupAlbumMediaRequest request = JsonSerializer.Deserialize("""{"group_id":23,"album_id":"fixture","media_id":"fixture","content":"fixture"}""", MilkyJson.GetTypeInfo<MilkyCommentGroupAlbumMediaRequest>())!;
        var result = await session.CommentGroupAlbumMediaAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyCommentGroupAlbumMediaResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"comment_id":"fixture"}"""));
    }

    public async Task CompleteGroupTodo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("complete_group_todo", """{"message_seq":23,"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyCompleteGroupTodoRequest request = JsonSerializer.Deserialize("""{"message_seq":23,"group_id":23}""", MilkyJson.GetTypeInfo<MilkyCompleteGroupTodoRequest>())!;
        var result = await session.CompleteGroupTodoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task DeleteGroupAlbumMedia_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("delete_group_album_media", """{"group_id":23,"album_id":"fixture","media_id":"fixture","batch_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyDeleteGroupAlbumMediaRequest request = JsonSerializer.Deserialize("""{"group_id":23,"album_id":"fixture","media_id":"fixture","batch_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyDeleteGroupAlbumMediaRequest>())!;
        var result = await session.DeleteGroupAlbumMediaAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task DeleteGroupAnnouncement_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("delete_group_announcement", """{"group_id":23,"announcement_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyDeleteGroupAnnouncementRequest request = JsonSerializer.Deserialize("""{"group_id":23,"announcement_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyDeleteGroupAnnouncementRequest>())!;
        var result = await session.DeleteGroupAnnouncementAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task GetGroupAdminSettings_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_admin_settings", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"add_type":23,"group_question":"fixture","group_answer":"fixture","member_invite_policy":"fixture","new_member_history_visible":true,"robot_member_switch":23,"robot_member_examine":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupAdminSettingsRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupAdminSettingsRequest>())!;
        var result = await session.GetGroupAdminSettingsAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupAdminSettingsResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"add_type":23,"group_question":"fixture","group_answer":"fixture","member_invite_policy":"fixture","new_member_history_visible":true,"robot_member_switch":23,"robot_member_examine":23}"""));
    }

    public async Task GetGroupAlbumMedia_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_album_media", """{"group_id":23,"album_id":"fixture","attach_info":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"media":[{"type":"fixture","id":"fixture","url":"fixture","cover_url":"fixture","width":23,"height":23,"upload_time":23}],"previous_cursor":"fixture","next_cursor":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupAlbumMediaRequest request = JsonSerializer.Deserialize("""{"group_id":23,"album_id":"fixture","attach_info":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetGroupAlbumMediaRequest>())!;
        var result = await session.GetGroupAlbumMediaAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupAlbumMediaResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"media":[{"type":"fixture","id":"fixture","url":"fixture","cover_url":"fixture","width":23,"height":23,"upload_time":23}],"previous_cursor":"fixture","next_cursor":"fixture"}"""));
    }

    public async Task GetGroupAlbumList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_album_list", """{"group_id":23,"attach_info":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"albums":[{"album_id":"fixture","owner":"fixture","name":"fixture","description":"fixture","create_time":23,"modify_time":23,"last_upload_time":23,"upload_number":23,"cover_url":"fixture"}],"has_more":true,"attach_info":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupAlbumListRequest request = JsonSerializer.Deserialize("""{"group_id":23,"attach_info":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetGroupAlbumListRequest>())!;
        var result = await session.GetGroupAlbumListAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupAlbumListResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"albums":[{"album_id":"fixture","owner":"fixture","name":"fixture","description":"fixture","create_time":23,"modify_time":23,"last_upload_time":23,"upload_number":23,"cover_url":"fixture"}],"has_more":true,"attach_info":"fixture"}"""));
    }

    public async Task GetGroupAnnouncements_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_announcements", """{"group_id":23,"start":23,"count":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"announcements":[{"id":"fixture","publisher_id":23,"publish_time":23,"text":"fixture","pinned":true,"read_count":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupAnnouncementsRequest request = JsonSerializer.Deserialize("""{"group_id":23,"start":23,"count":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupAnnouncementsRequest>())!;
        var result = await session.GetGroupAnnouncementsAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGroupAnnouncementsResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"announcements":[{"id":"fixture","publisher_id":23,"publish_time":23,"text":"fixture","pinned":true,"read_count":23}]}"""));
    }

    public void GetGroupAnnouncements_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupAnnouncementsRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupAnnouncementsRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"start":-1,"count":20}"""));
    }

    public async Task GetGroupAtAllRemain_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_at_all_remain", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"can_at_all":true,"remain_for_uin":23,"remain_for_group":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupAtAllRemainRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupAtAllRemainRequest>())!;
        var result = await session.GetGroupAtAllRemainAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupAtAllRemainResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"can_at_all":true,"remain_for_uin":23,"remain_for_group":23}"""));
    }

    public async Task GetGroupEssence_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_essence", """{"group_id":23,"page_start":23,"page_limit":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"messages":[{"group_code":"fixture","message_sequence":23,"message_random":23,"sender_uin":"fixture","sender_nick":"fixture","sender_time":23,"add_digest_uin":"fixture","add_digest_nick":"fixture","add_digest_time":23,"can_be_removed":true,"text":"fixture"}],"is_end":true,"group_role":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupEssenceRequest request = JsonSerializer.Deserialize("""{"group_id":23,"page_start":23,"page_limit":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupEssenceRequest>())!;
        var result = await session.GetGroupEssenceAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupEssenceResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"messages":[{"group_code":"fixture","message_sequence":23,"message_random":23,"sender_uin":"fixture","sender_nick":"fixture","sender_time":23,"add_digest_uin":"fixture","add_digest_nick":"fixture","add_digest_time":23,"can_be_removed":true,"text":"fixture"}],"is_end":true,"group_role":23}"""));
    }

    public void GetGroupEssence_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupEssenceRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupEssenceRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"page_start":0,"page_limit":50}"""));
    }

    public async Task GetGroupEssenceMessages_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_essence_messages", """{"group_id":23,"page_start":23,"page_limit":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"messages":[{"group_code":"fixture","message_sequence":23,"message_random":23,"sender_uin":"fixture","sender_nick":"fixture","sender_time":23,"add_digest_uin":"fixture","add_digest_nick":"fixture","add_digest_time":23,"can_be_removed":true,"text":"fixture"}],"is_end":true,"group_role":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupEssenceMessagesRequest request = JsonSerializer.Deserialize("""{"group_id":23,"page_start":23,"page_limit":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupEssenceMessagesRequest>())!;
        var result = await session.GetGroupEssenceMessagesAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGroupEssenceMessagesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"messages":[{"group_code":"fixture","message_sequence":23,"message_random":23,"sender_uin":"fixture","sender_nick":"fixture","sender_time":23,"add_digest_uin":"fixture","add_digest_nick":"fixture","add_digest_time":23,"can_be_removed":true,"text":"fixture"}],"is_end":true,"group_role":23}"""));
    }

    public void GetGroupEssenceMessages_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupEssenceMessagesRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupEssenceMessagesRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"page_start":0,"page_limit":50}"""));
    }

    public async Task GetGroupHonor_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_honor", """{"group_id":23,"honor_type":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"honor_type":"fixture","items":[{"user_id":23,"nickname":"fixture","avatar":"fixture","description":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupHonorRequest request = JsonSerializer.Deserialize("""{"group_id":23,"honor_type":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetGroupHonorRequest>())!;
        var result = await session.GetGroupHonorAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupHonorResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"honor_type":"fixture","items":[{"user_id":23,"nickname":"fixture","avatar":"fixture","description":"fixture"}]}"""));
    }

    public void GetGroupHonor_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupHonorRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupHonorRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"honor_type":"all"}"""));
    }

    public async Task GetGroupNotifications_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_notifications", """{"start_notification_seq":23,"is_filtered":true,"limit":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"notifications":[{"group_id":23,"notification_seq":23,"is_filtered":true,"initiator_id":23,"state":"fixture","operator_id":23,"comment":"fixture","type":"join_request"}],"next_notification_seq":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupNotificationsRequest request = JsonSerializer.Deserialize("""{"start_notification_seq":23,"is_filtered":true,"limit":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupNotificationsRequest>())!;
        var result = await session.GetGroupNotificationsAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGroupNotificationsResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"notifications":[{"group_id":23,"notification_seq":23,"is_filtered":true,"initiator_id":23,"state":"fixture","operator_id":23,"comment":"fixture","type":"join_request"}],"next_notification_seq":23}"""));
    }

    public void GetGroupNotifications_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupNotificationsRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupNotificationsRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_filtered":false,"limit":20}"""));
    }

    public async Task GetGroupSignIn_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_sign_in", """{"group_id":23,"day":"2026-10-14T00:00:00"}""", """{"status":"ok","retcode":0,"message":null,"data":{"members":[{"user_id":23,"nickname":"fixture","time":23,"rank":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupSignInRequest request = JsonSerializer.Deserialize("""{"group_id":23,"day":"2026-10-14T00:00:00"}""", MilkyJson.GetTypeInfo<MilkyGetGroupSignInRequest>())!;
        var result = await session.GetGroupSignInAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupSignInResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"members":[{"user_id":23,"nickname":"fixture","time":23,"rank":23}]}"""));
    }

    public async Task GetGroupTodo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_todo", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"group_id":23,"message_seq":23,"preview":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupTodoRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupTodoRequest>())!;
        var result = await session.GetGroupTodoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupTodoResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"group_id":23,"message_seq":23,"preview":"fixture"}"""));
    }

    public async Task GetGroupTodoList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_todo_list", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"items":[{"message_seq":23,"random":23,"text":"fixture","created_at":23,"updated_at":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupTodoListRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupTodoListRequest>())!;
        var result = await session.GetGroupTodoListAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupTodoListResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"items":[{"message_seq":23,"random":23,"text":"fixture","created_at":23,"updated_at":23}]}"""));
    }

    public async Task KickGroupMember_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("kick_group_member", """{"group_id":23,"user_id":23,"reject_add_request":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyKickGroupMemberRequest request = JsonSerializer.Deserialize("""{"group_id":23,"user_id":23,"reject_add_request":true}""", MilkyJson.GetTypeInfo<MilkyKickGroupMemberRequest>())!;
        var result = await session.KickGroupMemberAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void KickGroupMember_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyKickGroupMemberRequest(), MilkyJson.GetTypeInfo<MilkyKickGroupMemberRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"reject_add_request":false}"""));
    }

    public async Task QuitGroup_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("quit_group", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyQuitGroupRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkyQuitGroupRequest>())!;
        var result = await session.QuitGroupAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task RejectGroupInvitation_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("reject_group_invitation", """{"group_id":23,"invitation_seq":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyRejectGroupInvitationRequest request = JsonSerializer.Deserialize("""{"group_id":23,"invitation_seq":23}""", MilkyJson.GetTypeInfo<MilkyRejectGroupInvitationRequest>())!;
        var result = await session.RejectGroupInvitationAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task RejectGroupRequest_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("reject_group_request", """{"notification_seq":23,"notification_type":"fixture","group_id":23,"reason":"fixture","is_filtered":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyRejectGroupRequestRequest request = JsonSerializer.Deserialize("""{"notification_seq":23,"notification_type":"fixture","group_id":23,"reason":"fixture","is_filtered":true}""", MilkyJson.GetTypeInfo<MilkyRejectGroupRequestRequest>())!;
        var result = await session.RejectGroupRequestAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void RejectGroupRequest_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyRejectGroupRequestRequest(), MilkyJson.GetTypeInfo<MilkyRejectGroupRequestRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_filtered":false}"""));
    }

    public async Task SendGroupAnnouncement_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_group_announcement", """{"group_id":23,"content":"fixture","pinned":true,"send_to_new_members":true,"show_edit_card":true,"show_popup":true,"confirm_required":true,"picture_id":"fixture","image_width":23,"image_height":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendGroupAnnouncementRequest request = JsonSerializer.Deserialize("""{"group_id":23,"content":"fixture","pinned":true,"send_to_new_members":true,"show_edit_card":true,"show_popup":true,"confirm_required":true,"picture_id":"fixture","image_width":23,"image_height":23}""", MilkyJson.GetTypeInfo<MilkySendGroupAnnouncementRequest>())!;
        var result = await session.SendGroupAnnouncementAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SendGroupAnnouncement_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySendGroupAnnouncementRequest(), MilkyJson.GetTypeInfo<MilkySendGroupAnnouncementRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"pinned":false,"show_edit_card":true,"confirm_required":true,"image_width":540,"image_height":300}"""));
    }

    public async Task SendGroupMessageReaction_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_group_message_reaction", """{"group_id":23,"message_seq":23,"reaction":"fixture","reaction_type":"fixture","is_add":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendGroupMessageReactionRequest request = JsonSerializer.Deserialize("""{"group_id":23,"message_seq":23,"reaction":"fixture","reaction_type":"fixture","is_add":true}""", MilkyJson.GetTypeInfo<MilkySendGroupMessageReactionRequest>())!;
        var result = await session.SendGroupMessageReactionAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SendGroupMessageReaction_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySendGroupMessageReactionRequest(), MilkyJson.GetTypeInfo<MilkySendGroupMessageReactionRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"reaction_type":"face","is_add":true}"""));
    }

    public async Task SendGroupNudge_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_group_nudge", """{"group_id":23,"user_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendGroupNudgeRequest request = JsonSerializer.Deserialize("""{"group_id":23,"user_id":23}""", MilkyJson.GetTypeInfo<MilkySendGroupNudgeRequest>())!;
        var result = await session.SendGroupNudgeAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SendGroupSign_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_group_sign", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"is_success":true,"title":"fixture","keep_day_text":"fixture","group_rank_text":"fixture","clock_in_time":23,"detail_url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendGroupSignRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkySendGroupSignRequest>())!;
        var result = await session.SendGroupSignAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySendGroupSignResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_success":true,"title":"fixture","keep_day_text":"fixture","group_rank_text":"fixture","clock_in_time":23,"detail_url":"fixture"}"""));
    }

    public async Task SetGroupAddOption_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_add_option", """{"group_id":23,"add_type":23,"group_question":"fixture","group_answer":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupAddOptionRequest request = JsonSerializer.Deserialize("""{"group_id":23,"add_type":23,"group_question":"fixture","group_answer":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetGroupAddOptionRequest>())!;
        var result = await session.SetGroupAddOptionAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupAlbumLike_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_album_like", """{"group_id":23,"album_id":"fixture","batch_id":"fixture","media_id":"fixture","is_like":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupAlbumLikeRequest request = JsonSerializer.Deserialize("""{"group_id":23,"album_id":"fixture","batch_id":"fixture","media_id":"fixture","is_like":true}""", MilkyJson.GetTypeInfo<MilkySetGroupAlbumLikeRequest>())!;
        var result = await session.SetGroupAlbumLikeAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SetGroupAlbumLike_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySetGroupAlbumLikeRequest(), MilkyJson.GetTypeInfo<MilkySetGroupAlbumLikeRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_like":true}"""));
    }

    public async Task SetGroupAvatar_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_avatar", """{"group_id":23,"image_uri":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupAvatarRequest request = JsonSerializer.Deserialize("""{"group_id":23,"image_uri":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetGroupAvatarRequest>())!;
        var result = await session.SetGroupAvatarAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupEssenceMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_essence_message", """{"group_id":23,"message_seq":23,"is_set":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupEssenceMessageRequest request = JsonSerializer.Deserialize("""{"group_id":23,"message_seq":23,"is_set":true}""", MilkyJson.GetTypeInfo<MilkySetGroupEssenceMessageRequest>())!;
        var result = await session.SetGroupEssenceMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SetGroupEssenceMessage_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySetGroupEssenceMessageRequest(), MilkyJson.GetTypeInfo<MilkySetGroupEssenceMessageRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_set":true}"""));
    }

    public async Task SetGroupMemberInvitePolicy_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_member_invite_policy", """{"group_id":23,"current_privilege_flag":23,"policy":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupMemberInvitePolicyRequest request = JsonSerializer.Deserialize("""{"group_id":23,"current_privilege_flag":23,"policy":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetGroupMemberInvitePolicyRequest>())!;
        var result = await session.SetGroupMemberInvitePolicyAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupMemberAdmin_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_member_admin", """{"group_id":23,"user_id":23,"is_set":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupMemberAdminRequest request = JsonSerializer.Deserialize("""{"group_id":23,"user_id":23,"is_set":true}""", MilkyJson.GetTypeInfo<MilkySetGroupMemberAdminRequest>())!;
        var result = await session.SetGroupMemberAdminAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupMemberCard_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_member_card", """{"group_id":23,"user_id":23,"card":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupMemberCardRequest request = JsonSerializer.Deserialize("""{"group_id":23,"user_id":23,"card":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetGroupMemberCardRequest>())!;
        var result = await session.SetGroupMemberCardAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupMemberMute_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_member_mute", """{"group_id":23,"user_id":23,"duration":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupMemberMuteRequest request = JsonSerializer.Deserialize("""{"group_id":23,"user_id":23,"duration":23}""", MilkyJson.GetTypeInfo<MilkySetGroupMemberMuteRequest>())!;
        var result = await session.SetGroupMemberMuteAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SetGroupMemberMute_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySetGroupMemberMuteRequest(), MilkyJson.GetTypeInfo<MilkySetGroupMemberMuteRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"duration":0}"""));
    }

    public async Task SetGroupMemberPermission_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_member_permission", """{"group_id":23,"permission":"fixture","allow":true,"current_privilege_flag":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupMemberPermissionRequest request = JsonSerializer.Deserialize("""{"group_id":23,"permission":"fixture","allow":true,"current_privilege_flag":23}""", MilkyJson.GetTypeInfo<MilkySetGroupMemberPermissionRequest>())!;
        var result = await session.SetGroupMemberPermissionAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupMemberSpecialTitle_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_member_special_title", """{"group_id":23,"user_id":23,"special_title":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupMemberSpecialTitleRequest request = JsonSerializer.Deserialize("""{"group_id":23,"user_id":23,"special_title":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetGroupMemberSpecialTitleRequest>())!;
        var result = await session.SetGroupMemberSpecialTitleAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupName_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_name", """{"group_id":23,"new_group_name":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupNameRequest request = JsonSerializer.Deserialize("""{"group_id":23,"new_group_name":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetGroupNameRequest>())!;
        var result = await session.SetGroupNameAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupNewMemberHistoryVisibility_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_new_member_history_visibility", """{"group_id":23,"visible":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupNewMemberHistoryVisibilityRequest request = JsonSerializer.Deserialize("""{"group_id":23,"visible":true}""", MilkyJson.GetTypeInfo<MilkySetGroupNewMemberHistoryVisibilityRequest>())!;
        var result = await session.SetGroupNewMemberHistoryVisibilityAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupRemark_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_remark", """{"group_id":23,"remark":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupRemarkRequest request = JsonSerializer.Deserialize("""{"group_id":23,"remark":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetGroupRemarkRequest>())!;
        var result = await session.SetGroupRemarkAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupRobotAddOption_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_robot_add_option", """{"group_id":23,"robot_member_switch":23,"robot_member_examine":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupRobotAddOptionRequest request = JsonSerializer.Deserialize("""{"group_id":23,"robot_member_switch":23,"robot_member_examine":23}""", MilkyJson.GetTypeInfo<MilkySetGroupRobotAddOptionRequest>())!;
        var result = await session.SetGroupRobotAddOptionAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupSearch_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_search", """{"group_id":23,"no_finger_open":23,"no_code_finger_open":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupSearchRequest request = JsonSerializer.Deserialize("""{"group_id":23,"no_finger_open":23,"no_code_finger_open":23}""", MilkyJson.GetTypeInfo<MilkySetGroupSearchRequest>())!;
        var result = await session.SetGroupSearchAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupTodo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_todo", """{"group_id":23,"message_seq":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupTodoRequest request = JsonSerializer.Deserialize("""{"group_id":23,"message_seq":23}""", MilkyJson.GetTypeInfo<MilkySetGroupTodoRequest>())!;
        var result = await session.SetGroupTodoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupWholeMute_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_whole_mute", """{"group_id":23,"is_mute":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupWholeMuteRequest request = JsonSerializer.Deserialize("""{"group_id":23,"is_mute":true}""", MilkyJson.GetTypeInfo<MilkySetGroupWholeMuteRequest>())!;
        var result = await session.SetGroupWholeMuteAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SetGroupWholeMute_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySetGroupWholeMuteRequest(), MilkyJson.GetTypeInfo<MilkySetGroupWholeMuteRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_mute":true}"""));
    }

    public async Task TransferGroup_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("transfer_group", """{"group_id":23,"user_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyTransferGroupRequest request = JsonSerializer.Deserialize("""{"group_id":23,"user_id":23}""", MilkyJson.GetTypeInfo<MilkyTransferGroupRequest>())!;
        var result = await session.TransferGroupAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task UploadGroupAlbumImage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("upload_group_album_image", """{"group_id":23,"album_id":"fixture","image_uri":"fixture","album_name":"fixture","file_name":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"media_id":"fixture","album_id":"fixture","url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyUploadGroupAlbumImageRequest request = JsonSerializer.Deserialize("""{"group_id":23,"album_id":"fixture","image_uri":"fixture","album_name":"fixture","file_name":"fixture"}""", MilkyJson.GetTypeInfo<MilkyUploadGroupAlbumImageRequest>())!;
        var result = await session.UploadGroupAlbumImageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyUploadGroupAlbumImageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"media_id":"fixture","album_id":"fixture","url":"fixture"}"""));
    }

    public void UploadGroupAlbumImage_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyUploadGroupAlbumImageRequest(), MilkyJson.GetTypeInfo<MilkyUploadGroupAlbumImageRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"album_name":"","file_name":"image.jpg"}"""));
    }

    public async Task UploadGroupAlbumVideo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("upload_group_album_video", """{"group_id":23,"album_id":"fixture","album_name":"fixture","video_uri":"fixture","cover_uri":"fixture","duration_ms":23,"file_name":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"video_id":"fixture","album_id":"fixture","cover_id":"fixture","cover_url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyUploadGroupAlbumVideoRequest request = JsonSerializer.Deserialize("""{"group_id":23,"album_id":"fixture","album_name":"fixture","video_uri":"fixture","cover_uri":"fixture","duration_ms":23,"file_name":"fixture"}""", MilkyJson.GetTypeInfo<MilkyUploadGroupAlbumVideoRequest>())!;
        var result = await session.UploadGroupAlbumVideoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyUploadGroupAlbumVideoResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"video_id":"fixture","album_id":"fixture","cover_id":"fixture","cover_url":"fixture"}"""));
    }

    public async Task UploadGroupAnnouncementImage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("upload_group_announcement_image", """{"image_uri":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"id":"fixture","width":23,"height":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyUploadGroupAnnouncementImageRequest request = JsonSerializer.Deserialize("""{"image_uri":"fixture"}""", MilkyJson.GetTypeInfo<MilkyUploadGroupAnnouncementImageRequest>())!;
        var result = await session.UploadGroupAnnouncementImageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyUploadGroupAnnouncementImageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"id":"fixture","width":23,"height":23}"""));
    }

    public async Task ClickInlineKeyboardButton_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("click_inline_keyboard_button", """{"group_id":23,"app_id":23,"message_seq":23,"button_id":"fixture","callback_data":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"prompt_text":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyClickInlineKeyboardButtonRequest request = JsonSerializer.Deserialize("""{"group_id":23,"app_id":23,"message_seq":23,"button_id":"fixture","callback_data":"fixture"}""", MilkyJson.GetTypeInfo<MilkyClickInlineKeyboardButtonRequest>())!;
        var result = await session.ClickInlineKeyboardButtonAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyClickInlineKeyboardButtonResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"prompt_text":"fixture"}"""));
    }

    public async Task GetEmojiLikes_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_emoji_likes", """{"group_id":23,"message_seq":23,"code":"fixture","cookie":"fixture","count":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"users":[{"user_id":23,"nickname":"fixture","head_url":"fixture"}],"cookie":"fixture","is_last":true}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetEmojiLikesRequest request = JsonSerializer.Deserialize("""{"group_id":23,"message_seq":23,"code":"fixture","cookie":"fixture","count":23}""", MilkyJson.GetTypeInfo<MilkyGetEmojiLikesRequest>())!;
        var result = await session.GetEmojiLikesAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetEmojiLikesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"users":[{"user_id":23,"nickname":"fixture","head_url":"fixture"}],"cookie":"fixture","is_last":true}"""));
    }

    public void GetEmojiLikes_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetEmojiLikesRequest(), MilkyJson.GetTypeInfo<MilkyGetEmojiLikesRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"cookie":"","count":20}"""));
    }

    public async Task GetGroupReactionSummary_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_reaction_summary", """{"group_id":23,"message_seq":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"entries":[{"emoji_id":"fixture","emoji_type":23,"count":23,"last_reaction_time":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupReactionSummaryRequest request = JsonSerializer.Deserialize("""{"group_id":23,"message_seq":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupReactionSummaryRequest>())!;
        var result = await session.GetGroupReactionSummaryAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupReactionSummaryResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"entries":[{"emoji_id":"fixture","emoji_type":23,"count":23,"last_reaction_time":23}]}"""));
    }

    public async Task SendLike_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_like", """{"user_id":23,"count":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendLikeRequest request = JsonSerializer.Deserialize("""{"user_id":23,"count":23}""", MilkyJson.GetTypeInfo<MilkySendLikeRequest>())!;
        var result = await session.SendLikeAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SendLike_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySendLikeRequest(), MilkyJson.GetTypeInfo<MilkySendLikeRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"count":1}"""));
    }

    public async Task SendPoke_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_poke", """{"message_scene":"fixture","peer_id":23,"target_user_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendPokeRequest request = JsonSerializer.Deserialize("""{"message_scene":"fixture","peer_id":23,"target_user_id":23}""", MilkyJson.GetTypeInfo<MilkySendPokeRequest>())!;
        var result = await session.SendPokeAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetGroupReaction_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_group_reaction", """{"group_id":23,"message_seq":23,"code":"fixture","is_set":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetGroupReactionRequest request = JsonSerializer.Deserialize("""{"group_id":23,"message_seq":23,"code":"fixture","is_set":true}""", MilkyJson.GetTypeInfo<MilkySetGroupReactionRequest>())!;
        var result = await session.SetGroupReactionAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SetGroupReaction_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySetGroupReactionRequest(), MilkyJson.GetTypeInfo<MilkySetGroupReactionRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_set":true}"""));
    }

    public async Task SetInputStatus_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_input_status", """{"user_id":23,"event_type":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetInputStatusRequest request = JsonSerializer.Deserialize("""{"user_id":23,"event_type":23}""", MilkyJson.GetTypeInfo<MilkySetInputStatusRequest>())!;
        var result = await session.SetInputStatusAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task GetAiVoiceList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_ai_voice_list", """{"group_id":23,"chat_type":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"categories":[{"name":"fixture","voices":[{"id":"fixture","name":"fixture","example_url":"fixture"}]}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetAiVoiceListRequest request = JsonSerializer.Deserialize("""{"group_id":23,"chat_type":23}""", MilkyJson.GetTypeInfo<MilkyGetAiVoiceListRequest>())!;
        var result = await session.GetAiVoiceListAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetAiVoiceListResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"categories":[{"name":"fixture","voices":[{"id":"fixture","name":"fixture","example_url":"fixture"}]}]}"""));
    }

    public async Task GetCollection_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_collection", """{"count":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"items":[{"id":"fixture","type":23,"text":"fixture","share_url":"fixture","create_time":23,"collect_time":23,"modify_time":23,"author_uid":"fixture","author_uin":23}],"total_count":23,"reached_bottom":true}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetCollectionRequest request = JsonSerializer.Deserialize("""{"count":23}""", MilkyJson.GetTypeInfo<MilkyGetCollectionRequest>())!;
        var result = await session.GetCollectionAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetCollectionResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"items":[{"id":"fixture","type":23,"text":"fixture","share_url":"fixture","create_time":23,"collect_time":23,"modify_time":23,"author_uid":"fixture","author_uin":23}],"total_count":23,"reached_bottom":true}"""));
    }

    public void GetCollection_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetCollectionRequest(), MilkyJson.GetTypeInfo<MilkyGetCollectionRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"count":50}"""));
    }

    public async Task GetForwardedMessages_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_forwarded_messages", """{"forward_id":"fixture","message_scene":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"message_seq":23,"sender_name":"fixture","avatar_url":"fixture","time":23,"segments":[{"type":"text","data":{"text":"fixture"}}]}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetForwardedMessagesRequest request = JsonSerializer.Deserialize("""{"forward_id":"fixture","message_scene":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetForwardedMessagesRequest>())!;
        var result = await session.GetForwardedMessagesAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyForwardedMessagesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"message_seq":23,"sender_name":"fixture","avatar_url":"fixture","time":23,"segments":[{"type":"text","data":{"text":"fixture"}}]}]}"""));
    }

    public void GetForwardedMessages_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetForwardedMessagesRequest(), MilkyJson.GetTypeInfo<MilkyGetForwardedMessagesRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"message_scene":"friend"}"""));
    }

    public async Task GetHistoryMessages_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_history_messages", """{"message_scene":"fixture","peer_id":23,"start_message_seq":23,"limit":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"peer_id":23,"message_seq":23,"sender_id":23,"time":23,"segments":[{"type":"text","data":{"text":"fixture"}}],"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}},"message_scene":"friend"}],"next_message_seq":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetHistoryMessagesRequest request = JsonSerializer.Deserialize("""{"message_scene":"fixture","peer_id":23,"start_message_seq":23,"limit":23}""", MilkyJson.GetTypeInfo<MilkyGetHistoryMessagesRequest>())!;
        var result = await session.GetHistoryMessagesAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyHistoryMessagesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"peer_id":23,"message_seq":23,"sender_id":23,"time":23,"segments":[{"type":"text","data":{"text":"fixture"}}],"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}},"message_scene":"friend"}],"next_message_seq":23}"""));
    }

    public void GetHistoryMessages_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetHistoryMessagesRequest(), MilkyJson.GetTypeInfo<MilkyGetHistoryMessagesRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"limit":20}"""));
    }

    public async Task GetMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_message", """{"message_scene":"fixture","peer_id":23,"message_seq":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"message":{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"peer_id":23,"message_seq":23,"sender_id":23,"time":23,"segments":[{"type":"text","data":{"text":"fixture"}}],"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}},"message_scene":"friend"}}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetMessageRequest request = JsonSerializer.Deserialize("""{"message_scene":"fixture","peer_id":23,"message_seq":23}""", MilkyJson.GetTypeInfo<MilkyGetMessageRequest>())!;
        var result = await session.GetMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetMessageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"message":{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"peer_id":23,"message_seq":23,"sender_id":23,"time":23,"segments":[{"type":"text","data":{"text":"fixture"}}],"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}},"message_scene":"friend"}}"""));
    }

    public async Task GetResourceTempUrl_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_resource_temp_url", """{"resource_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"url":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetResourceTempUrlRequest request = JsonSerializer.Deserialize("""{"resource_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetResourceTempUrlRequest>())!;
        var result = await session.GetResourceTempUrlAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyResourceTempUrlResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"url":"fixture"}"""));
    }

    public async Task ProbeHistorySyncState_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("probe_history_sync_state", """{"group_ids":[23],"private_targets":[{"user_id":23,"uid":"fixture"}]}""", """{"status":"ok","retcode":0,"message":null,"data":{"groups":[{"group_id":23,"read_seq":23,"latest_seq":23}],"private_users":[{"user_id":23,"uid":"fixture","read_seq":23,"latest_seq":23,"last_message_time":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyProbeHistorySyncStateRequest request = JsonSerializer.Deserialize("""{"group_ids":[23],"private_targets":[{"user_id":23,"uid":"fixture"}]}""", MilkyJson.GetTypeInfo<MilkyProbeHistorySyncStateRequest>())!;
        var result = await session.ProbeHistorySyncStateAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyProbeHistorySyncStateResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"groups":[{"group_id":23,"read_seq":23,"latest_seq":23}],"private_users":[{"user_id":23,"uid":"fixture","read_seq":23,"latest_seq":23,"last_message_time":23}]}"""));
    }

    public async Task GetHistorySyncPage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_history_sync_page", """{"message_scene":"fixture","peer_id":23,"next_seq":23,"latest_seq":23,"limit":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"peer_id":23,"message_seq":23,"sender_id":23,"time":23,"segments":[{"type":"text","data":{"text":"fixture"}}],"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}},"message_scene":"friend"}],"next_seq":23,"is_complete":true}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetHistorySyncPageRequest request = JsonSerializer.Deserialize("""{"message_scene":"fixture","peer_id":23,"next_seq":23,"latest_seq":23,"limit":23}""", MilkyJson.GetTypeInfo<MilkyGetHistorySyncPageRequest>())!;
        var result = await session.GetHistorySyncPageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetHistorySyncPageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"peer_id":23,"message_seq":23,"sender_id":23,"time":23,"segments":[{"type":"text","data":{"text":"fixture"}}],"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}},"message_scene":"friend"}],"next_seq":23,"is_complete":true}"""));
    }

    public async Task GetPrivateHistoryRoamPage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_private_history_roam_page", """{"user_id":23,"time":23,"random":23,"limit":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"peer_id":23,"message_seq":23,"sender_id":23,"time":23,"segments":[{"type":"text","data":{"text":"fixture"}}],"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}},"message_scene":"friend"}],"next_cursor":{"time":23,"random":23},"is_complete":true}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetPrivateHistoryRoamPageRequest request = JsonSerializer.Deserialize("""{"user_id":23,"time":23,"random":23,"limit":23}""", MilkyJson.GetTypeInfo<MilkyGetPrivateHistoryRoamPageRequest>())!;
        var result = await session.GetPrivateHistoryRoamPageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetPrivateHistoryRoamPageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"peer_id":23,"message_seq":23,"sender_id":23,"time":23,"segments":[{"type":"text","data":{"text":"fixture"}}],"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}},"message_scene":"friend"}],"next_cursor":{"time":23,"random":23},"is_complete":true}"""));
    }

    public async Task MarkAllRead_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("mark_all_read", """{"group_ids":[23],"private_user_ids":[23]}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyMarkAllReadRequest request = JsonSerializer.Deserialize("""{"group_ids":[23],"private_user_ids":[23]}""", MilkyJson.GetTypeInfo<MilkyMarkAllReadRequest>())!;
        var result = await session.MarkAllReadAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task MarkMessageAsRead_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("mark_message_as_read", """{"message_scene":"fixture","peer_id":23,"last_read_seq":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyMarkMessageAsReadRequest request = JsonSerializer.Deserialize("""{"message_scene":"fixture","peer_id":23,"last_read_seq":23}""", MilkyJson.GetTypeInfo<MilkyMarkMessageAsReadRequest>())!;
        var result = await session.MarkMessageAsReadAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task RecallGroupMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("recall_group_message", """{"group_id":23,"message_seq":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyRecallGroupMessageRequest request = JsonSerializer.Deserialize("""{"group_id":23,"message_seq":23}""", MilkyJson.GetTypeInfo<MilkyRecallGroupMessageRequest>())!;
        var result = await session.RecallGroupMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task RecallPrivateMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("recall_private_message", """{"user_id":23,"message_seq":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyRecallPrivateMessageRequest request = JsonSerializer.Deserialize("""{"user_id":23,"message_seq":23}""", MilkyJson.GetTypeInfo<MilkyRecallPrivateMessageRequest>())!;
        var result = await session.RecallPrivateMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SendAiVoice_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_ai_voice", """{"group_id":23,"voice_id":"fixture","text":"fixture","chat_type":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"message_seq":23,"time":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendAiVoiceRequest request = JsonSerializer.Deserialize("""{"group_id":23,"voice_id":"fixture","text":"fixture","chat_type":23}""", MilkyJson.GetTypeInfo<MilkySendAiVoiceRequest>())!;
        var result = await session.SendAiVoiceAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySendAiVoiceResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"message_seq":23,"time":23}"""));
    }

    public async Task SendGroupMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_group_message", """{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"group_id":23,"message":[{"type":"text","data":{"text":"fixture"}}]}""", """{"status":"ok","retcode":0,"message":null,"data":{"message_seq":23,"time":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendGroupMessageRequest request = JsonSerializer.Deserialize("""{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"group_id":23,"message":[{"type":"text","data":{"text":"fixture"}}]}""", MilkyJson.GetTypeInfo<MilkySendGroupMessageRequest>())!;
        var result = await session.SendGroupMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySendMessageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"message_seq":23,"time":23}"""));
    }

    public async Task SendPrivateMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_private_message", """{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"user_id":23,"message":[{"type":"text","data":{"text":"fixture"}}]}""", """{"status":"ok","retcode":0,"message":null,"data":{"message_seq":23,"time":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendPrivateMessageRequest request = JsonSerializer.Deserialize("""{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"user_id":23,"message":[{"type":"text","data":{"text":"fixture"}}]}""", MilkyJson.GetTypeInfo<MilkySendPrivateMessageRequest>())!;
        var result = await session.SendPrivateMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySendMessageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"message_seq":23,"time":23}"""));
    }

    public async Task SendTempMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_temp_message", """{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"group_id":23,"user_id":23,"message":[{"type":"text","data":{"text":"fixture"}}]}""", """{"status":"ok","retcode":0,"message":null,"data":{"message_seq":23,"time":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendTempMessageRequest request = JsonSerializer.Deserialize("""{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"group_id":23,"user_id":23,"message":[{"type":"text","data":{"text":"fixture"}}]}""", MilkyJson.GetTypeInfo<MilkySendTempMessageRequest>())!;
        var result = await session.SendTempMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySendTempMessageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"message_seq":23,"time":23}"""));
    }

    public async Task SynthesizeAiVoice_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("synthesize_ai_voice", """{"group_id":23,"voice_id":"fixture","text":"fixture","chat_type":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"url":"fixture","resource_id":"fixture","file_name":"fixture","file_size":23,"duration":23,"format":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySynthesizeAiVoiceRequest request = JsonSerializer.Deserialize("""{"group_id":23,"voice_id":"fixture","text":"fixture","chat_type":23}""", MilkyJson.GetTypeInfo<MilkySynthesizeAiVoiceRequest>())!;
        var result = await session.SynthesizeAiVoiceAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySynthesizeAiVoiceResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"url":"fixture","resource_id":"fixture","file_name":"fixture","file_size":23,"duration":23,"format":23}"""));
    }

    public async Task TranscribeVoice_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("transcribe_voice", """{"message_scene":"fixture","peer_id":23,"message_seq":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"text":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyTranscribeVoiceRequest request = JsonSerializer.Deserialize("""{"message_scene":"fixture","peer_id":23,"message_seq":23}""", MilkyJson.GetTypeInfo<MilkyTranscribeVoiceRequest>())!;
        var result = await session.TranscribeVoiceAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyTranscribeVoiceResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"text":"fixture"}"""));
    }

    public async Task AddCustomFace_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("add_custom_face", """{"image_uri":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"face_id":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyAddCustomFaceRequest request = JsonSerializer.Deserialize("""{"image_uri":"fixture"}""", MilkyJson.GetTypeInfo<MilkyAddCustomFaceRequest>())!;
        var result = await session.AddCustomFaceAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyAddCustomFaceResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"face_id":"fixture"}"""));
    }

    public async Task CommentQzoneMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("comment_qzone_message", """{"target_uin":23,"message_id":"fixture","content":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"comment_id":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyCommentQzoneMessageRequest request = JsonSerializer.Deserialize("""{"target_uin":23,"message_id":"fixture","content":"fixture"}""", MilkyJson.GetTypeInfo<MilkyCommentQzoneMessageRequest>())!;
        var result = await session.CommentQzoneMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyCommentQzoneMessageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"comment_id":"fixture"}"""));
    }

    public async Task DeleteCustomFace_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("delete_custom_face", """{"face_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyDeleteCustomFaceRequest request = JsonSerializer.Deserialize("""{"face_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyDeleteCustomFaceRequest>())!;
        var result = await session.DeleteCustomFaceAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task DeleteQzoneMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("delete_qzone_message", """{"message_id":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyDeleteQzoneMessageRequest request = JsonSerializer.Deserialize("""{"message_id":"fixture"}""", MilkyJson.GetTypeInfo<MilkyDeleteQzoneMessageRequest>())!;
        var result = await session.DeleteQzoneMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task GetGroupSystemMsg_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_system_msg", """{"group_id":23,"message_type":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"messages":[{"group_id":23,"notification_seq":23,"is_filtered":true,"initiator_id":23,"state":"fixture","operator_id":23,"comment":"fixture","type":"join_request"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupSystemMsgRequest request = JsonSerializer.Deserialize("""{"group_id":23,"message_type":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetGroupSystemMsgRequest>())!;
        var result = await session.GetGroupSystemMsgAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupSystemMsgResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"messages":[{"group_id":23,"notification_seq":23,"is_filtered":true,"initiator_id":23,"state":"fixture","operator_id":23,"comment":"fixture","type":"join_request"}]}"""));
    }

    public async Task GetGroupShutList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_shut_list", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"members":[{"user_id":23,"shut_up_timestamp":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupShutListRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupShutListRequest>())!;
        var result = await session.GetGroupShutListAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupShutListResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"members":[{"user_id":23,"shut_up_timestamp":23}]}"""));
    }

    public async Task GetDoubtFriendsAddRequest_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_doubt_friends_add_request", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"requests":[{"uid":"fixture","user_id":23,"nick":"fixture","source":"fixture","reason":"fixture","message":"fixture","group_code":"fixture","request_time":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetDoubtFriendsAddRequestAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetDoubtFriendsAddRequestResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"requests":[{"uid":"fixture","user_id":23,"nick":"fixture","source":"fixture","reason":"fixture","message":"fixture","group_code":"fixture","request_time":23}]}"""));
    }

    public async Task SetDoubtFriendsAddRequest_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_doubt_friends_add_request", """{"request_id":"fixture","approve":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetDoubtFriendsAddRequestRequest request = JsonSerializer.Deserialize("""{"request_id":"fixture","approve":true}""", MilkyJson.GetTypeInfo<MilkySetDoubtFriendsAddRequestRequest>())!;
        var result = await session.SetDoubtFriendsAddRequestAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task GetQidianCorpInfo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_qidian_corp_info", """{"user_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"info":{"name":"fixture","intro":"fixture","website":"fixture","slogan":"fixture","address":"fixture","phone":"fixture","email":"fixture"}}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetQidianCorpInfoRequest request = JsonSerializer.Deserialize("""{"user_id":23}""", MilkyJson.GetTypeInfo<MilkyGetQidianCorpInfoRequest>())!;
        var result = await session.GetQidianCorpInfoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetQidianCorpInfoResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"info":{"name":"fixture","intro":"fixture","website":"fixture","slogan":"fixture","address":"fixture","phone":"fixture","email":"fixture"}}"""));
    }

    public async Task SendArkShare_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_ark_share", """{"user_id":23,"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"ark":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendArkShareRequest request = JsonSerializer.Deserialize("""{"user_id":23,"group_id":23}""", MilkyJson.GetTypeInfo<MilkySendArkShareRequest>())!;
        var result = await session.SendArkShareAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySendArkShareResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"ark":"fixture"}"""));
    }

    public async Task SendTuwenArk_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_tuwen_ark", """{"peer_id":23,"group_id":23,"title":"fixture","description":"fixture","summary":"fixture","url":"fixture","preview_url":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"message_id":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendTuwenArkRequest request = JsonSerializer.Deserialize("""{"peer_id":23,"group_id":23,"title":"fixture","description":"fixture","summary":"fixture","url":"fixture","preview_url":"fixture"}""", MilkyJson.GetTypeInfo<MilkySendTuwenArkRequest>())!;
        var result = await session.SendTuwenArkAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySendTuwenArkResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"message_id":23}"""));
    }

    public void SendTuwenArk_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySendTuwenArkRequest(), MilkyJson.GetTypeInfo<MilkySendTuwenArkRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"title":"","description":"","summary":"","url":"","preview_url":""}"""));
    }

    public async Task GetCookies_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_cookies", """{"domains":["fixture"]}""", """{"status":"ok","retcode":0,"message":null,"data":{"cookies":{"fixture":"fixture"}}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetCookiesRequest request = JsonSerializer.Deserialize("""{"domains":["fixture"]}""", MilkyJson.GetTypeInfo<MilkyGetCookiesRequest>())!;
        var result = await session.GetCookiesAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyCookiesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"cookies":{"fixture":"fixture"}}"""));
    }

    public async Task GetCsrfToken_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_csrf_token", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"token":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetCsrfTokenAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyCsrfTokenResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"token":"fixture"}"""));
    }

    public async Task GetCustomFaceDetail_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_custom_face_detail", """{"entries":[{"face_id":"fixture","md5":"fixture"}]}""", """{"status":"ok","retcode":0,"message":null,"data":{"entries":[{"face_id":"fixture","description":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetCustomFaceDetailRequest request = JsonSerializer.Deserialize("""{"entries":[{"face_id":"fixture","md5":"fixture"}]}""", MilkyJson.GetTypeInfo<MilkyGetCustomFaceDetailRequest>())!;
        var result = await session.GetCustomFaceDetailAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetCustomFaceDetailResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"entries":[{"face_id":"fixture","description":"fixture"}]}"""));
    }

    public async Task GetCustomFaceList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_custom_face_list", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"face_ids":["fixture"],"total_count":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetCustomFaceListAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetCustomFaceListResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"face_ids":["fixture"],"total_count":23}"""));
    }

    public async Task GetCustomFaceUrlList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_custom_face_url_list", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"face_ids":["fixture"],"urls":["fixture"]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetCustomFaceUrlListAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyStringListResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"face_ids":["fixture"],"urls":["fixture"]}"""));
    }

    public async Task GetFriendDress_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_friend_dress", """{"user_id":23,"target_uin":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"target_uin":"fixture","is_svip":true,"avatar_url":"fixture","items":[{"app_id":23,"kind":"fixture","item_id":23,"name":"fixture","preview_url":"fixture","video_url":"fixture","price":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetFriendDressRequest request = JsonSerializer.Deserialize("""{"user_id":23,"target_uin":23}""", MilkyJson.GetTypeInfo<MilkyGetFriendDressRequest>())!;
        var result = await session.GetFriendDressAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetFriendDressResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"target_uin":"fixture","is_svip":true,"avatar_url":"fixture","items":[{"app_id":23,"kind":"fixture","item_id":23,"name":"fixture","preview_url":"fixture","video_url":"fixture","price":23}]}"""));
    }

    public async Task GetFriendInfo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_friend_info", """{"user_id":23,"no_cache":true}""", """{"status":"ok","retcode":0,"message":null,"data":{"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}}}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetFriendInfoRequest request = JsonSerializer.Deserialize("""{"user_id":23,"no_cache":true}""", MilkyJson.GetTypeInfo<MilkyGetFriendInfoRequest>())!;
        var result = await session.GetFriendInfoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyFriendResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}}}"""));
    }

    public void GetFriendInfo_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetFriendInfoRequest(), MilkyJson.GetTypeInfo<MilkyGetFriendInfoRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"no_cache":false}"""));
    }

    public async Task GetFriendList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_friend_list", """{"no_cache":true}""", """{"status":"ok","retcode":0,"message":null,"data":{"friends":[{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetFriendListRequest request = JsonSerializer.Deserialize("""{"no_cache":true}""", MilkyJson.GetTypeInfo<MilkyGetFriendListRequest>())!;
        var result = await session.GetFriendListAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyFriendsResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"friends":[{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}}]}"""));
    }

    public void GetFriendList_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetFriendListRequest(), MilkyJson.GetTypeInfo<MilkyGetFriendListRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"no_cache":false}"""));
    }

    public async Task GetFriendsStatus_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_friends_status", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"self_uid":"fixture","friends":[{"uid":"fixture","status":23,"status_text":"fixture","raw_fields":[{"field":23,"wire_type":23,"value":"fixture"}]}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetFriendsStatusAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetFriendsStatusResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"self_uid":"fixture","friends":[{"uid":"fixture","status":23,"status_text":"fixture","raw_fields":[{"field":23,"wire_type":23,"value":"fixture"}]}]}"""));
    }

    public async Task GetGroupExtInfo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_ext_info", """{"group_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"latest_message_sequence":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupExtInfoRequest request = JsonSerializer.Deserialize("""{"group_id":23}""", MilkyJson.GetTypeInfo<MilkyGetGroupExtInfoRequest>())!;
        var result = await session.GetGroupExtInfoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetGroupExtInfoResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"latest_message_sequence":23}"""));
    }

    public async Task GetGroupInfo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_info", """{"group_id":23,"no_cache":true}""", """{"status":"ok","retcode":0,"message":null,"data":{"group":{"group_id":23,"group_name":"fixture","member_count":23,"max_member_count":23,"remark":"fixture","created_time":23,"description":"fixture","question":"fixture","announcement":"fixture"}}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupInfoRequest request = JsonSerializer.Deserialize("""{"group_id":23,"no_cache":true}""", MilkyJson.GetTypeInfo<MilkyGetGroupInfoRequest>())!;
        var result = await session.GetGroupInfoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGroupResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"group":{"group_id":23,"group_name":"fixture","member_count":23,"max_member_count":23,"remark":"fixture","created_time":23,"description":"fixture","question":"fixture","announcement":"fixture"}}"""));
    }

    public void GetGroupInfo_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupInfoRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupInfoRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"no_cache":false}"""));
    }

    public async Task GetGroupList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_list", """{"no_cache":true}""", """{"status":"ok","retcode":0,"message":null,"data":{"groups":[{"group_id":23,"group_name":"fixture","member_count":23,"max_member_count":23,"remark":"fixture","created_time":23,"description":"fixture","question":"fixture","announcement":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupListRequest request = JsonSerializer.Deserialize("""{"no_cache":true}""", MilkyJson.GetTypeInfo<MilkyGetGroupListRequest>())!;
        var result = await session.GetGroupListAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGroupsResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"groups":[{"group_id":23,"group_name":"fixture","member_count":23,"max_member_count":23,"remark":"fixture","created_time":23,"description":"fixture","question":"fixture","announcement":"fixture"}]}"""));
    }

    public void GetGroupList_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupListRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupListRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"no_cache":false}"""));
    }

    public async Task GetGroupMemberInfo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_member_info", """{"group_id":23,"user_id":23,"no_cache":true}""", """{"status":"ok","retcode":0,"message":null,"data":{"member":{"user_id":23,"nickname":"fixture","sex":"fixture","group_id":23,"card":"fixture","title":"fixture","level":23,"role":"fixture","join_time":23,"last_sent_time":23,"shut_up_end_time":23}}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupMemberInfoRequest request = JsonSerializer.Deserialize("""{"group_id":23,"user_id":23,"no_cache":true}""", MilkyJson.GetTypeInfo<MilkyGetGroupMemberInfoRequest>())!;
        var result = await session.GetGroupMemberInfoAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyMemberResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"member":{"user_id":23,"nickname":"fixture","sex":"fixture","group_id":23,"card":"fixture","title":"fixture","level":23,"role":"fixture","join_time":23,"last_sent_time":23,"shut_up_end_time":23}}"""));
    }

    public void GetGroupMemberInfo_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupMemberInfoRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupMemberInfoRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"no_cache":false}"""));
    }

    public async Task GetGroupMemberList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_group_member_list", """{"group_id":23,"no_cache":true}""", """{"status":"ok","retcode":0,"message":null,"data":{"members":[{"user_id":23,"nickname":"fixture","sex":"fixture","group_id":23,"card":"fixture","title":"fixture","level":23,"role":"fixture","join_time":23,"last_sent_time":23,"shut_up_end_time":23}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetGroupMemberListRequest request = JsonSerializer.Deserialize("""{"group_id":23,"no_cache":true}""", MilkyJson.GetTypeInfo<MilkyGetGroupMemberListRequest>())!;
        var result = await session.GetGroupMemberListAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyMembersResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"members":[{"user_id":23,"nickname":"fixture","sex":"fixture","group_id":23,"card":"fixture","title":"fixture","level":23,"role":"fixture","join_time":23,"last_sent_time":23,"shut_up_end_time":23}]}"""));
    }

    public void GetGroupMemberList_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetGroupMemberListRequest(), MilkyJson.GetTypeInfo<MilkyGetGroupMemberListRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"no_cache":false}"""));
    }

    public async Task GetImplInfo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_impl_info", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"impl_name":"fixture","impl_version":"fixture","qq_protocol_version":"fixture","qq_protocol_type":"fixture","milky_version":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetImplInfoAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyImplInfoResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"impl_name":"fixture","impl_version":"fixture","qq_protocol_version":"fixture","qq_protocol_type":"fixture","milky_version":"fixture"}"""));
    }

    public async Task GetLoginInfo_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_login_info", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"uin":23,"nickname":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetLoginInfoAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyLoginInfoResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"uin":23,"nickname":"fixture"}"""));
    }

    public async Task GetMiniAppArk_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_mini_app_ark", """{"type":"fixture","title":"fixture","description":"fixture","picture_url":"fixture","jump_url":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"json_payload":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetMiniAppArkRequest request = JsonSerializer.Deserialize("""{"type":"fixture","title":"fixture","description":"fixture","picture_url":"fixture","jump_url":"fixture"}""", MilkyJson.GetTypeInfo<MilkyGetMiniAppArkRequest>())!;
        var result = await session.GetMiniAppArkAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetMiniAppArkResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"json_payload":"fixture"}"""));
    }

    public async Task GetOnlineDevices_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_online_devices", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"observed":true,"devices":[{"app_id":23,"instance_id":23,"client_type":23,"platform":23,"device_name":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetOnlineDevicesAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetOnlineDevicesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"observed":true,"devices":[{"app_id":23,"instance_id":23,"client_type":23,"platform":23,"device_name":"fixture"}]}"""));
    }

    public async Task GetPeerPins_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_peer_pins", """{}""", """{"status":"ok","retcode":0,"message":null,"data":{"peer_uins":[23]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        var result = await session.GetPeerPinsAsync(cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyPeerPinsResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"peer_uins":[23]}"""));
    }

    public async Task GetLike_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_like", """{"user_id":23,"start":23,"limit":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"uid":"fixture","time":23,"total_count":23,"new_count":23,"users":[{"uid":"fixture","user_id":23,"nickname":"fixture","latest_time":23,"count":23,"is_friend":true}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetLikeRequest request = JsonSerializer.Deserialize("""{"user_id":23,"start":23,"limit":23}""", MilkyJson.GetTypeInfo<MilkyGetLikeRequest>())!;
        var result = await session.GetLikeAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetLikeResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"uid":"fixture","time":23,"total_count":23,"new_count":23,"users":[{"uid":"fixture","user_id":23,"nickname":"fixture","latest_time":23,"count":23,"is_friend":true}]}"""));
    }

    public void GetLike_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetLikeRequest(), MilkyJson.GetTypeInfo<MilkyGetLikeRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"start":0,"limit":10}"""));
    }

    public async Task GetQzoneFeeds_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_qzone_feeds", """{"page_num":23,"position":23,"user_id":23,"count":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"has_more":true,"feeds":[{"user_id":23,"nickname":"fixture","time":23,"app_id":23,"key":"fixture","html":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetQzoneFeedsRequest request = JsonSerializer.Deserialize("""{"page_num":23,"position":23,"user_id":23,"count":23}""", MilkyJson.GetTypeInfo<MilkyGetQzoneFeedsRequest>())!;
        var result = await session.GetQzoneFeedsAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetQzoneFeedsResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"has_more":true,"feeds":[{"user_id":23,"nickname":"fixture","time":23,"app_id":23,"key":"fixture","html":"fixture"}]}"""));
    }

    public void GetQzoneFeeds_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetQzoneFeedsRequest(), MilkyJson.GetTypeInfo<MilkyGetQzoneFeedsRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"page_num":1,"count":10}"""));
    }

    public async Task GetQzoneMsgList_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_qzone_msg_list", """{"target_uin":23,"position":23,"count":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"total":23,"messages":[{"id":"fixture","content":"fixture","time":23,"comment_count":23,"is_private":true,"images":["fixture"]}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetQzoneMsgListRequest request = JsonSerializer.Deserialize("""{"target_uin":23,"position":23,"count":23}""", MilkyJson.GetTypeInfo<MilkyGetQzoneMsgListRequest>())!;
        var result = await session.GetQzoneMsgListAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetQzoneMsgListResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"total":23,"messages":[{"id":"fixture","content":"fixture","time":23,"comment_count":23,"is_private":true,"images":["fixture"]}]}"""));
    }

    public void GetQzoneMsgList_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetQzoneMsgListRequest(), MilkyJson.GetTypeInfo<MilkyGetQzoneMsgListRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"position":0,"count":20}"""));
    }

    public async Task GetSystemFaces_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_system_faces", """{"refresh":true}""", """{"status":"ok","retcode":0,"message":null,"data":{"packs":[{"pack_name":"fixture","faces":[{"sid":"fixture","description":"fixture","em_code":"fixture","category_id":23,"url":"fixture","aliases":["fixture"]}]}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetSystemFacesRequest request = JsonSerializer.Deserialize("""{"refresh":true}""", MilkyJson.GetTypeInfo<MilkyGetSystemFacesRequest>())!;
        var result = await session.GetSystemFacesAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetSystemFacesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"packs":[{"pack_name":"fixture","faces":[{"sid":"fixture","description":"fixture","em_code":"fixture","category_id":23,"url":"fixture","aliases":["fixture"]}]}]}"""));
    }

    public void GetSystemFaces_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyGetSystemFacesRequest(), MilkyJson.GetTypeInfo<MilkyGetSystemFacesRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"refresh":false}"""));
    }

    public async Task GetUserProfile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_user_profile", """{"user_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"nickname":"fixture","qid":"fixture","age":23,"sex":"fixture","remark":"fixture","bio":"fixture","level":23,"country":"fixture","city":"fixture","school":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetUserProfileRequest request = JsonSerializer.Deserialize("""{"user_id":23}""", MilkyJson.GetTypeInfo<MilkyGetUserProfileRequest>())!;
        var result = await session.GetUserProfileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyUserProfileResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"nickname":"fixture","qid":"fixture","age":23,"sex":"fixture","remark":"fixture","bio":"fixture","level":23,"country":"fixture","city":"fixture","school":"fixture"}"""));
    }

    public async Task GetUserStatus_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("get_user_status", """{"user_id":23}""", """{"status":"ok","retcode":0,"message":null,"data":{"status":23,"extended_status":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyGetUserStatusRequest request = JsonSerializer.Deserialize("""{"user_id":23}""", MilkyJson.GetTypeInfo<MilkyGetUserStatusRequest>())!;
        var result = await session.GetUserStatusAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyGetUserStatusResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"status":23,"extended_status":23}"""));
    }

    public async Task ImageOcr_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("image_ocr", """{"image_url":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"language":"fixture","texts":[{"text":"fixture","confidence":23,"coordinates":[{"x":23,"y":23}]}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyImageOcrRequest request = JsonSerializer.Deserialize("""{"image_url":"fixture"}""", MilkyJson.GetTypeInfo<MilkyImageOcrRequest>())!;
        var result = await session.ImageOcrAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyImageOcrResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"language":"fixture","texts":[{"text":"fixture","confidence":23,"coordinates":[{"x":23,"y":23}]}]}"""));
    }

    public async Task ModifyCustomFace_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("modify_custom_face", """{"face_id":"fixture","md5":"fixture","description":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyModifyCustomFaceRequest request = JsonSerializer.Deserialize("""{"face_id":"fixture","md5":"fixture","description":"fixture"}""", MilkyJson.GetTypeInfo<MilkyModifyCustomFaceRequest>())!;
        var result = await session.ModifyCustomFaceAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task MoveCustomFace_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("move_custom_face", """{"face_id":"fixture","position":23,"entries":[{"face_id":"fixture","md5":"fixture"}]}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyMoveCustomFaceRequest request = JsonSerializer.Deserialize("""{"face_id":"fixture","position":23,"entries":[{"face_id":"fixture","md5":"fixture"}]}""", MilkyJson.GetTypeInfo<MilkyMoveCustomFaceRequest>())!;
        var result = await session.MoveCustomFaceAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task PublishQzoneMessage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("publish_qzone_message", """{"content":"fixture","rich_value":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"message_id":"fixture","time":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyPublishQzoneMessageRequest request = JsonSerializer.Deserialize("""{"content":"fixture","rich_value":"fixture"}""", MilkyJson.GetTypeInfo<MilkyPublishQzoneMessageRequest>())!;
        var result = await session.PublishQzoneMessageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyPublishQzoneMessageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"message_id":"fixture","time":23}"""));
    }

    public void PublishQzoneMessage_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkyPublishQzoneMessageRequest(), MilkyJson.GetTypeInfo<MilkyPublishQzoneMessageRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"rich_value":""}"""));
    }

    public async Task RequestDatabaseKey_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("request_database_key", """{"db_salt":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"key":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyRequestDatabaseKeyRequest request = JsonSerializer.Deserialize("""{"db_salt":"fixture"}""", MilkyJson.GetTypeInfo<MilkyRequestDatabaseKeyRequest>())!;
        var result = await session.RequestDatabaseKeyAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyRequestDatabaseKeyResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"key":"fixture"}"""));
    }

    public async Task RequestDecryptKey_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("request_decrypt_key", """{"mode":"fixture","key_meta":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"key":"fixture","key_meta":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyRequestDecryptKeyRequest request = JsonSerializer.Deserialize("""{"mode":"fixture","key_meta":"fixture"}""", MilkyJson.GetTypeInfo<MilkyRequestDecryptKeyRequest>())!;
        var result = await session.RequestDecryptKeyAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyRequestDecryptKeyResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"key":"fixture","key_meta":"fixture"}"""));
    }

    public async Task SearchSystemFaces_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("search_system_faces", """{"query":"fixture","refresh":true}""", """{"status":"ok","retcode":0,"message":null,"data":{"faces":[{"sid":"fixture","description":"fixture","em_code":"fixture","url":"fixture"}]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySearchSystemFacesRequest request = JsonSerializer.Deserialize("""{"query":"fixture","refresh":true}""", MilkyJson.GetTypeInfo<MilkySearchSystemFacesRequest>())!;
        var result = await session.SearchSystemFacesAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySearchSystemFacesResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"faces":[{"sid":"fixture","description":"fixture","em_code":"fixture","url":"fixture"}]}"""));
    }

    public void SearchSystemFaces_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySearchSystemFacesRequest(), MilkyJson.GetTypeInfo<MilkySearchSystemFacesRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"refresh":false}"""));
    }

    public async Task SendPacket_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_packet", """{"cmd":"fixture","data":"fixture","rsp":true}""", """{"status":"ok","retcode":0,"message":null,"data":{"cmd":"fixture","data":"fixture","sequence":23,"ret_code":23,"extra":"fixture"}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendPacketRequest request = JsonSerializer.Deserialize("""{"cmd":"fixture","data":"fixture","rsp":true}""", MilkyJson.GetTypeInfo<MilkySendPacketRequest>())!;
        var result = await session.SendPacketAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyRawPacketData>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"cmd":"fixture","data":"fixture","sequence":23,"ret_code":23,"extra":"fixture"}"""));
    }

    public void SendPacket_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySendPacketRequest(), MilkyJson.GetTypeInfo<MilkySendPacketRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"data":"","rsp":true}"""));
    }

    public async Task SendProfileLike_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("send_profile_like", """{"user_id":23,"count":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySendProfileLikeRequest request = JsonSerializer.Deserialize("""{"user_id":23,"count":23}""", MilkyJson.GetTypeInfo<MilkySendProfileLikeRequest>())!;
        var result = await session.SendProfileLikeAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SendProfileLike_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySendProfileLikeRequest(), MilkyJson.GetTypeInfo<MilkySendProfileLikeRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"count":1}"""));
    }

    public async Task SetAvatar_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_avatar", """{"uri":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetAvatarRequest request = JsonSerializer.Deserialize("""{"uri":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetAvatarRequest>())!;
        var result = await session.SetAvatarAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetBio_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_bio", """{"bio":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetBioRequest request = JsonSerializer.Deserialize("""{"bio":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetBioRequest>())!;
        var result = await session.SetBioAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetDiyOnlineStatus_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_diy_online_status", """{"face_id":23,"text":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetDiyOnlineStatusRequest request = JsonSerializer.Deserialize("""{"face_id":23,"text":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetDiyOnlineStatusRequest>())!;
        var result = await session.SetDiyOnlineStatusAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetNickname_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_nickname", """{"nickname":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetNicknameRequest request = JsonSerializer.Deserialize("""{"nickname":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetNicknameRequest>())!;
        var result = await session.SetNicknameAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetOnlineStatus_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_online_status", """{"status":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetOnlineStatusRequest request = JsonSerializer.Deserialize("""{"status":23}""", MilkyJson.GetTypeInfo<MilkySetOnlineStatusRequest>())!;
        var result = await session.SetOnlineStatusAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetPeerPin_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_peer_pin", """{"message_scene":"fixture","peer_id":23,"is_pinned":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetPeerPinRequest request = JsonSerializer.Deserialize("""{"message_scene":"fixture","peer_id":23,"is_pinned":true}""", MilkyJson.GetTypeInfo<MilkySetPeerPinRequest>())!;
        var result = await session.SetPeerPinAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SetPeerPin_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySetPeerPinRequest(), MilkyJson.GetTypeInfo<MilkySetPeerPinRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"is_pinned":true}"""));
    }

    public async Task SetProfile_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_profile", """{"nickname":"fixture","personal_note":"fixture","sex":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetProfileRequest request = JsonSerializer.Deserialize("""{"nickname":"fixture","personal_note":"fixture","sex":23}""", MilkyJson.GetTypeInfo<MilkySetProfileRequest>())!;
        var result = await session.SetProfileAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetQzoneBlack_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_qzone_black", """{"target_uin":23,"ban":true}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetQzoneBlackRequest request = JsonSerializer.Deserialize("""{"target_uin":23,"ban":true}""", MilkyJson.GetTypeInfo<MilkySetQzoneBlackRequest>())!;
        var result = await session.SetQzoneBlackAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public void SetQzoneBlack_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySetQzoneBlackRequest(), MilkyJson.GetTypeInfo<MilkySetQzoneBlackRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"ban":true}"""));
    }

    public async Task SetQzoneLike_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_qzone_like", """{"target_uin":23,"message_id":"fixture","like":true,"abstime":23}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetQzoneLikeRequest request = JsonSerializer.Deserialize("""{"target_uin":23,"message_id":"fixture","like":true,"abstime":23}""", MilkyJson.GetTypeInfo<MilkySetQzoneLikeRequest>())!;
        var result = await session.SetQzoneLikeAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkySetQzoneLikeResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{}"""));
    }

    public void SetQzoneLike_PreservesServerDefaults()
    {
        var actual = JsonSerializer.SerializeToNode(new MilkySetQzoneLikeRequest(), MilkyJson.GetTypeInfo<MilkySetQzoneLikeRequest>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"like":true,"abstime":0}"""));
    }

    public async Task SetQzoneMessageVisibility_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_qzone_message_visibility", """{"message_id":"fixture","right":23,"users":[23]}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetQzoneMessageVisibilityRequest request = JsonSerializer.Deserialize("""{"message_id":"fixture","right":23,"users":[23]}""", MilkyJson.GetTypeInfo<MilkySetQzoneMessageVisibilityRequest>())!;
        var result = await session.SetQzoneMessageVisibilityAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task SetSelfLongNick_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("set_self_long_nick", """{"long_nick":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkySetSelfLongNickRequest request = JsonSerializer.Deserialize("""{"long_nick":"fixture"}""", MilkyJson.GetTypeInfo<MilkySetSelfLongNickRequest>())!;
        var result = await session.SetSelfLongNickAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
    }

    public async Task TranslateEnToZh_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("translate_en_to_zh", """{"words":["fixture"]}""", """{"status":"ok","retcode":0,"message":null,"data":{"words":["fixture"]}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyTranslateEnToZhRequest request = JsonSerializer.Deserialize("""{"words":["fixture"]}""", MilkyJson.GetTypeInfo<MilkyTranslateEnToZhRequest>())!;
        var result = await session.TranslateEnToZhAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyTranslateEnToZhResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"words":["fixture"]}"""));
    }

    public async Task UploadQzoneImage_MatchesServerWireContract()
    {
        using ContractHttpHandler handler = new("upload_qzone_image", """{"image_uri":"fixture"}""", """{"status":"ok","retcode":0,"message":null,"data":{"rich_value":"fixture","url":"fixture","album_id":"fixture","location":"fixture","type":23,"width":23,"height":23}}""");
        using HttpClient client = new(handler);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/"), HttpClient = client });
        using CancellationTokenSource cancellation = new();
        MilkyUploadQzoneImageRequest request = JsonSerializer.Deserialize("""{"image_uri":"fixture"}""", MilkyJson.GetTypeInfo<MilkyUploadQzoneImageRequest>())!;
        var result = await session.UploadQzoneImageAsync(request, cancellationToken: cancellation.Token);
        ContractHttpHandler.Check(result?.IsSuccess == true, "API should succeed.");
        ContractHttpHandler.Check(handler.Called && handler.CancellationCanBeCanceled, "Request should forward cancellation.");
        JsonNode? actual = JsonSerializer.SerializeToNode(result!.Data!, MilkyJson.GetTypeInfo<MilkyUploadQzoneImageResult>());
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse("""{"rich_value":"fixture","url":"fixture","album_id":"fixture","location":"fixture","type":23,"width":23,"height":23}"""));
    }

}
