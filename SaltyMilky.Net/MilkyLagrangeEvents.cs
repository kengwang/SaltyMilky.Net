using System.Text.Json.Serialization;

namespace SaltyMilky.Net;

/// <summary>Wire contract for FlashFileIncomingSegment.</summary>
public sealed record class MilkyFlashFileIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "flash_file";
    /// <summary>Gets or sets fileset_id.</summary>
    [JsonPropertyName("fileset_id")]
    public string FilesetId { get; set; } = string.Empty;
    /// <summary>Gets or sets file_name.</summary>
    [JsonPropertyName("file_name")]
    public string FileName { get; set; } = string.Empty;
    /// <summary>Gets or sets thumb_url.</summary>
    [JsonPropertyName("thumb_url"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ThumbnailUrl { get; set; }
    /// <summary>Gets or sets scene_type.</summary>
    [JsonPropertyName("scene_type")]
    public uint SceneType { get; set; }
}

/// <summary>Wire contract for PokeIncomingSegment.</summary>
public sealed record class MilkyPokeIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "poke";
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type")]
    public uint PokeType { get; set; }
    /// <summary>Gets or sets strength.</summary>
    [JsonPropertyName("strength")]
    public uint Strength { get; set; }
}

/// <summary>Wire contract for KeyboardIncomingSegment.</summary>
public sealed record class MilkyKeyboardIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "keyboard";
    /// <summary>Gets or sets data.</summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;
}

/// <summary>Wire contract for SpecialPokeIncomingSegment.</summary>
public sealed record class MilkySpecialPokeIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "special_poke";
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; }
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; }
    /// <summary>Gets or sets face_name.</summary>
    [JsonPropertyName("face_name")]
    public string FaceName { get; set; } = string.Empty;
}

/// <summary>Wire contract for JsonIncomingSegment.</summary>
public sealed record class MilkyJsonIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "json";
    /// <summary>Gets or sets data.</summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;
}

/// <summary>Wire contract for LocationIncomingSegment.</summary>
public sealed record class MilkyLocationIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "location";
    /// <summary>Gets or sets latitude.</summary>
    [JsonPropertyName("latitude")]
    public string Latitude { get; set; } = string.Empty;
    /// <summary>Gets or sets longitude.</summary>
    [JsonPropertyName("longitude")]
    public string Longitude { get; set; } = string.Empty;
    /// <summary>Gets or sets title.</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}

/// <summary>Wire contract for MusicIncomingSegment.</summary>
public sealed record class MilkyMusicIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "music";
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type")]
    public string MusicType { get; set; } = string.Empty;
    /// <summary>Gets or sets id.</summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
    /// <summary>Gets or sets audio.</summary>
    [JsonPropertyName("audio")]
    public string Audio { get; set; } = string.Empty;
    /// <summary>Gets or sets title.</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
    /// <summary>Gets or sets image.</summary>
    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;
}

/// <summary>Wire contract for ShareIncomingSegment.</summary>
public sealed record class MilkyShareIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "share";
    /// <summary>Gets or sets url.</summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
    /// <summary>Gets or sets title.</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
    /// <summary>Gets or sets image.</summary>
    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;
}

/// <summary>Wire contract for ContactIncomingSegment.</summary>
public sealed record class MilkyContactIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "contact";
    /// <summary>Gets or sets contact_type.</summary>
    [JsonPropertyName("contact_type")]
    public string ContactType { get; set; } = string.Empty;
    /// <summary>Gets or sets id.</summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;
}

/// <summary>Wire contract for DiceIncomingSegment.</summary>
public sealed record class MilkyDiceIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "dice";
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; }
}

/// <summary>Wire contract for RpsIncomingSegment.</summary>
public sealed record class MilkyRpsIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "rps";
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; }
}

/// <summary>Wire contract for LongMsgIncomingSegment.</summary>
public sealed record class MilkyLongMsgIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "long_msg";
    /// <summary>Gets or sets res_id.</summary>
    [JsonPropertyName("res_id")]
    public string ResId { get; set; } = string.Empty;
    /// <summary>Gets or sets messages.</summary>
    [JsonPropertyName("messages"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<MilkyIncomingForwardedMessage>? Messages { get; set; }
}

/// <summary>Wire contract for StreamIncomingSegment.</summary>
public sealed record class MilkyStreamIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "stream";
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}

/// <summary>Wire contract for BounceFaceIncomingSegment.</summary>
public sealed record class MilkyBounceFaceIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "bounce_face";
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; }
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; }
    /// <summary>Gets or sets name.</summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}

/// <summary>Wire contract for GroupReactionItem.</summary>
public sealed record class MilkyGroupReactionItem
{
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public string FaceId { get; set; } = string.Empty;
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type")]
    public uint Type { get; set; }
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; }
    /// <summary>Gets or sets is_added.</summary>
    [JsonPropertyName("is_added")]
    public bool IsAdded { get; set; }
}

/// <summary>Wire contract for GroupReactionIncomingSegment.</summary>
public sealed record class MilkyGroupReactionIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "group_reaction";
    /// <summary>Gets or sets reactions.</summary>
    [JsonPropertyName("reactions")]
    public IReadOnlyList<MilkyGroupReactionItem> Reactions { get; set; } = [];
}

/// <summary>Wire contract for GreyTipIncomingSegment.</summary>
public sealed record class MilkyGreyTipIncomingSegment : MilkyIncomingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "grey_tip";
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}

/// <summary>Wire contract for PokeSegment.</summary>
public sealed record class MilkyPokeSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "poke";
    /// <summary>Gets or sets type.</summary>
    [JsonPropertyName("type")]
    public uint PokeType { get; set; }
    /// <summary>Gets or sets strength.</summary>
    [JsonPropertyName("strength")]
    public uint Strength { get; set; }
}

/// <summary>Wire contract for KeyboardSegment.</summary>
public sealed record class MilkyKeyboardSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "keyboard";
    /// <summary>Gets or sets data.</summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;
}

/// <summary>Wire contract for SpecialPokeSegment.</summary>
public sealed record class MilkySpecialPokeSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "special_poke";
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; }
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; }
    /// <summary>Gets or sets face_name.</summary>
    [JsonPropertyName("face_name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FaceName { get; set; }
}

/// <summary>Wire contract for JsonSegment.</summary>
public sealed record class MilkyJsonSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "json";
    /// <summary>Gets or sets data.</summary>
    [JsonPropertyName("data")]
    public string Data { get; set; } = string.Empty;
}

/// <summary>Wire contract for LocationSegment.</summary>
public sealed record class MilkyLocationSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "location";
    /// <summary>Gets or sets latitude.</summary>
    [JsonPropertyName("latitude")]
    public string Latitude { get; set; } = string.Empty;
    /// <summary>Gets or sets longitude.</summary>
    [JsonPropertyName("longitude")]
    public string Longitude { get; set; } = string.Empty;
    /// <summary>Gets or sets title.</summary>
    [JsonPropertyName("title"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }
    /// <summary>Gets or sets content.</summary>
    [JsonPropertyName("content"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Content { get; set; }
}

/// <summary>Wire contract for MusicSegment.</summary>
public sealed record class MilkyMusicSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "music";
}

/// <summary>Wire contract for ShareSegment.</summary>
public sealed record class MilkyShareSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "share";
}

/// <summary>Wire contract for ContactSegment.</summary>
public sealed record class MilkyContactSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "contact";
}

/// <summary>Wire contract for DiceSegment.</summary>
public sealed record class MilkyDiceSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "dice";
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; } = 358;
}

/// <summary>Wire contract for RpsSegment.</summary>
public sealed record class MilkyRpsSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "rps";
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; } = 359;
}

/// <summary>Wire contract for LongMsgSegment.</summary>
public sealed record class MilkyLongMsgSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "long_msg";
    /// <summary>Gets or sets res_id.</summary>
    [JsonPropertyName("res_id")]
    public string ResId { get; set; } = string.Empty;
}

/// <summary>Wire contract for StreamSegment.</summary>
public sealed record class MilkyStreamSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "stream";
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}

/// <summary>Wire contract for BounceFaceSegment.</summary>
public sealed record class MilkyBounceFaceSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "bounce_face";
    /// <summary>Gets or sets face_id.</summary>
    [JsonPropertyName("face_id")]
    public uint FaceId { get; set; }
    /// <summary>Gets or sets count.</summary>
    [JsonPropertyName("count")]
    public uint Count { get; set; } = 1;
    /// <summary>Gets or sets name.</summary>
    [JsonPropertyName("name"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
}

/// <summary>Wire contract for GroupReactionSegment.</summary>
public sealed record class MilkyGroupReactionSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "group_reaction";
    /// <summary>Gets or sets reactions.</summary>
    [JsonPropertyName("reactions")]
    public IReadOnlyList<MilkyGroupReactionItem> Reactions { get; set; } = [];
}

/// <summary>Wire contract for GreyTipSegment.</summary>
public sealed record class MilkyGreyTipSegment : MilkyOutgoingSegment
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string Type => "grey_tip";
    /// <summary>Gets or sets text.</summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}

/// <summary>Wire contract for FriendRemarkChangedEventData.</summary>
public sealed record class MilkyFriendRemarkChangedEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "friend_remark_changed";
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets user_uid.</summary>
    [JsonPropertyName("user_uid")]
    public string UserUid { get; set; } = string.Empty;
    /// <summary>Gets or sets remark.</summary>
    [JsonPropertyName("remark")]
    public string Remark { get; set; } = string.Empty;
}

/// <summary>Wire contract for FriendInputStatusEventData.</summary>
public sealed record class MilkyFriendInputStatusEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "friend_input_status";
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets user_uid.</summary>
    [JsonPropertyName("user_uid")]
    public string UserUid { get; set; } = string.Empty;
    /// <summary>Gets or sets event_type.</summary>
    [JsonPropertyName("event_type")]
    public uint InputEventType { get; set; }
    /// <summary>Gets or sets status_text.</summary>
    [JsonPropertyName("status_text")]
    public string StatusText { get; set; } = string.Empty;
}

/// <summary>Wire contract for OnlineDevicesChangedEventData.</summary>
public sealed record class MilkyOnlineDevicesChangedEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "online_devices_changed";
    /// <summary>Gets or sets devices.</summary>
    [JsonPropertyName("devices")]
    public IReadOnlyList<MilkyOnlineDevicesChangedDevice> Devices { get; set; } = [];
}

/// <summary>Wire contract for OnlineDevicesChangedDevice.</summary>
public sealed record class MilkyOnlineDevicesChangedDevice
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

/// <summary>Wire contract for FriendProfileLikeEventData.</summary>
public sealed record class MilkyFriendProfileLikeEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "friend_profile_like";
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets times.</summary>
    [JsonPropertyName("times")]
    public int Times { get; set; }
}

/// <summary>Wire contract for GroupSpecialTitleChangeEventData.</summary>
public sealed record class MilkyGroupSpecialTitleChangeEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "group_special_title_change";
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets operator_id.</summary>
    [JsonPropertyName("operator_id")]
    public long OperatorId { get; set; }
    /// <summary>Gets or sets title.</summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
}

/// <summary>Wire contract for FriendAddedEventData.</summary>
public sealed record class MilkyFriendAddedEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "friend_added";
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets user_uid.</summary>
    [JsonPropertyName("user_uid")]
    public string UserUid { get; set; } = string.Empty;
    /// <summary>Gets or sets nickname.</summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; } = string.Empty;
    /// <summary>Gets or sets time.</summary>
    [JsonPropertyName("time")]
    public long Time { get; set; }
}

/// <summary>Wire contract for GroupSelfJoinedEventData.</summary>
public sealed record class MilkyGroupSelfJoinedEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "group_self_joined";
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets operator_id.</summary>
    [JsonPropertyName("operator_id")]
    public long OperatorId { get; set; }
    /// <summary>Gets or sets operator_uid.</summary>
    [JsonPropertyName("operator_uid")]
    public string OperatorUid { get; set; } = string.Empty;
}

/// <summary>Wire contract for GroupMemberCardChangeEventData.</summary>
public sealed record class MilkyGroupMemberCardChangeEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "group_member_card_change";
    /// <summary>Gets or sets group_id.</summary>
    [JsonPropertyName("group_id")]
    public long GroupId { get; set; }
    /// <summary>Gets or sets user_id.</summary>
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }
    /// <summary>Gets or sets old_card.</summary>
    [JsonPropertyName("old_card")]
    public string OldCard { get; set; } = string.Empty;
    /// <summary>Gets or sets new_card.</summary>
    [JsonPropertyName("new_card")]
    public string NewCard { get; set; } = string.Empty;
}

/// <summary>Wire contract for PacketReceivedEventData.</summary>
public sealed record class MilkyPacketReceivedEventData : MilkyEventData
{
    /// <inheritdoc />
    [JsonIgnore]
    public override string EventType => "packet_received";
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

/// <summary>Context for friend_remark_changed.</summary>
public sealed class MilkyFriendRemarkChangedContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyFriendRemarkChangedEventData data, CancellationToken cancellationToken = default)
    : MilkyEventContext<MilkyFriendRemarkChangedEventData>(session, milkyEvent, data, cancellationToken);

/// <summary>Context for friend_input_status.</summary>
public sealed class MilkyFriendInputStatusContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyFriendInputStatusEventData data, CancellationToken cancellationToken = default)
    : MilkyEventContext<MilkyFriendInputStatusEventData>(session, milkyEvent, data, cancellationToken);

/// <summary>Context for online_devices_changed.</summary>
public sealed class MilkyOnlineDevicesChangedContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyOnlineDevicesChangedEventData data, CancellationToken cancellationToken = default)
    : MilkyEventContext<MilkyOnlineDevicesChangedEventData>(session, milkyEvent, data, cancellationToken);

/// <summary>Context for friend_profile_like.</summary>
public sealed class MilkyFriendProfileLikeContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyFriendProfileLikeEventData data, CancellationToken cancellationToken = default)
    : MilkyEventContext<MilkyFriendProfileLikeEventData>(session, milkyEvent, data, cancellationToken);

/// <summary>Context for group_special_title_change.</summary>
public sealed class MilkyGroupSpecialTitleChangeContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupSpecialTitleChangeEventData data, CancellationToken cancellationToken = default)
    : MilkyEventContext<MilkyGroupSpecialTitleChangeEventData>(session, milkyEvent, data, cancellationToken);

/// <summary>Context for friend_added.</summary>
public sealed class MilkyFriendAddedContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyFriendAddedEventData data, CancellationToken cancellationToken = default)
    : MilkyEventContext<MilkyFriendAddedEventData>(session, milkyEvent, data, cancellationToken);

/// <summary>Context for group_self_joined.</summary>
public sealed class MilkyGroupSelfJoinedContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupSelfJoinedEventData data, CancellationToken cancellationToken = default)
    : MilkyEventContext<MilkyGroupSelfJoinedEventData>(session, milkyEvent, data, cancellationToken);

/// <summary>Context for group_member_card_change.</summary>
public sealed class MilkyGroupMemberCardChangeContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyGroupMemberCardChangeEventData data, CancellationToken cancellationToken = default)
    : MilkyEventContext<MilkyGroupMemberCardChangeEventData>(session, milkyEvent, data, cancellationToken);

/// <summary>Context for packet_received.</summary>
public sealed class MilkyPacketReceivedContext(IMilkyActionSession session, MilkyEvent milkyEvent, MilkyPacketReceivedEventData data, CancellationToken cancellationToken = default)
    : MilkyEventContext<MilkyPacketReceivedEventData>(session, milkyEvent, data, cancellationToken);

public partial class MilkyEventPlugin
{
    /// <summary>Called for friend_remark_changed.</summary>
    public virtual void OnFriendRemarkChanged(MilkyFriendRemarkChangedEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called for friend_remark_changed with its session.</summary>
    protected virtual void OnFriendRemarkChanged(MilkyFriendRemarkChangedContext context) { }
    /// <summary>Called for friend_remark_changed.</summary>
    public virtual Task OnFriendRemarkChangedAsync(MilkyFriendRemarkChangedEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for friend_remark_changed with its session.</summary>
    protected virtual Task OnFriendRemarkChangedAsync(MilkyFriendRemarkChangedContext context) => Task.CompletedTask;
    /// <summary>Called for friend_input_status.</summary>
    public virtual void OnFriendInputStatus(MilkyFriendInputStatusEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called for friend_input_status with its session.</summary>
    protected virtual void OnFriendInputStatus(MilkyFriendInputStatusContext context) { }
    /// <summary>Called for friend_input_status.</summary>
    public virtual Task OnFriendInputStatusAsync(MilkyFriendInputStatusEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for friend_input_status with its session.</summary>
    protected virtual Task OnFriendInputStatusAsync(MilkyFriendInputStatusContext context) => Task.CompletedTask;
    /// <summary>Called for online_devices_changed.</summary>
    public virtual void OnOnlineDevicesChanged(MilkyOnlineDevicesChangedEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called for online_devices_changed with its session.</summary>
    protected virtual void OnOnlineDevicesChanged(MilkyOnlineDevicesChangedContext context) { }
    /// <summary>Called for online_devices_changed.</summary>
    public virtual Task OnOnlineDevicesChangedAsync(MilkyOnlineDevicesChangedEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for online_devices_changed with its session.</summary>
    protected virtual Task OnOnlineDevicesChangedAsync(MilkyOnlineDevicesChangedContext context) => Task.CompletedTask;
    /// <summary>Called for friend_profile_like.</summary>
    public virtual void OnFriendProfileLike(MilkyFriendProfileLikeEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called for friend_profile_like with its session.</summary>
    protected virtual void OnFriendProfileLike(MilkyFriendProfileLikeContext context) { }
    /// <summary>Called for friend_profile_like.</summary>
    public virtual Task OnFriendProfileLikeAsync(MilkyFriendProfileLikeEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for friend_profile_like with its session.</summary>
    protected virtual Task OnFriendProfileLikeAsync(MilkyFriendProfileLikeContext context) => Task.CompletedTask;
    /// <summary>Called for group_special_title_change.</summary>
    public virtual void OnGroupSpecialTitleChange(MilkyGroupSpecialTitleChangeEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called for group_special_title_change with its session.</summary>
    protected virtual void OnGroupSpecialTitleChange(MilkyGroupSpecialTitleChangeContext context) { }
    /// <summary>Called for group_special_title_change.</summary>
    public virtual Task OnGroupSpecialTitleChangeAsync(MilkyGroupSpecialTitleChangeEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group_special_title_change with its session.</summary>
    protected virtual Task OnGroupSpecialTitleChangeAsync(MilkyGroupSpecialTitleChangeContext context) => Task.CompletedTask;
    /// <summary>Called for friend_added.</summary>
    public virtual void OnFriendAdded(MilkyFriendAddedEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called for friend_added with its session.</summary>
    protected virtual void OnFriendAdded(MilkyFriendAddedContext context) { }
    /// <summary>Called for friend_added.</summary>
    public virtual Task OnFriendAddedAsync(MilkyFriendAddedEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for friend_added with its session.</summary>
    protected virtual Task OnFriendAddedAsync(MilkyFriendAddedContext context) => Task.CompletedTask;
    /// <summary>Called for group_self_joined.</summary>
    public virtual void OnGroupSelfJoined(MilkyGroupSelfJoinedEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called for group_self_joined with its session.</summary>
    protected virtual void OnGroupSelfJoined(MilkyGroupSelfJoinedContext context) { }
    /// <summary>Called for group_self_joined.</summary>
    public virtual Task OnGroupSelfJoinedAsync(MilkyGroupSelfJoinedEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group_self_joined with its session.</summary>
    protected virtual Task OnGroupSelfJoinedAsync(MilkyGroupSelfJoinedContext context) => Task.CompletedTask;
    /// <summary>Called for group_member_card_change.</summary>
    public virtual void OnGroupMemberCardChange(MilkyGroupMemberCardChangeEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called for group_member_card_change with its session.</summary>
    protected virtual void OnGroupMemberCardChange(MilkyGroupMemberCardChangeContext context) { }
    /// <summary>Called for group_member_card_change.</summary>
    public virtual Task OnGroupMemberCardChangeAsync(MilkyGroupMemberCardChangeEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for group_member_card_change with its session.</summary>
    protected virtual Task OnGroupMemberCardChangeAsync(MilkyGroupMemberCardChangeContext context) => Task.CompletedTask;
    /// <summary>Called for packet_received.</summary>
    public virtual void OnPacketReceived(MilkyPacketReceivedEventData data, MilkyEvent milkyEvent) { }
    /// <summary>Called for packet_received with its session.</summary>
    protected virtual void OnPacketReceived(MilkyPacketReceivedContext context) { }
    /// <summary>Called for packet_received.</summary>
    public virtual Task OnPacketReceivedAsync(MilkyPacketReceivedEventData data, MilkyEvent milkyEvent) => Task.CompletedTask;
    /// <summary>Called for packet_received with its session.</summary>
    protected virtual Task OnPacketReceivedAsync(MilkyPacketReceivedContext context) => Task.CompletedTask;
}

public static partial class MilkyEventSessionExtensions
{
    /// <summary>Registers a handler for friend_remark_changed.</summary>
    public static IMilkyEventSession UseFriendRemarkChanged(this IMilkyEventSession session, Func<MilkyFriendRemarkChangedEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_remark_changed.</summary>
    public static IMilkyEventSession UseFriendRemarkChanged(this IMilkyEventSession session, Func<MilkyFriendRemarkChangedEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_remark_changed.</summary>
    public static IMilkyEventSession UseFriendRemarkChanged(this IMilkyEventSession session, Action<MilkyFriendRemarkChangedEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_input_status.</summary>
    public static IMilkyEventSession UseFriendInputStatus(this IMilkyEventSession session, Func<MilkyFriendInputStatusEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_input_status.</summary>
    public static IMilkyEventSession UseFriendInputStatus(this IMilkyEventSession session, Func<MilkyFriendInputStatusEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_input_status.</summary>
    public static IMilkyEventSession UseFriendInputStatus(this IMilkyEventSession session, Action<MilkyFriendInputStatusEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for online_devices_changed.</summary>
    public static IMilkyEventSession UseOnlineDevicesChanged(this IMilkyEventSession session, Func<MilkyOnlineDevicesChangedEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for online_devices_changed.</summary>
    public static IMilkyEventSession UseOnlineDevicesChanged(this IMilkyEventSession session, Func<MilkyOnlineDevicesChangedEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for online_devices_changed.</summary>
    public static IMilkyEventSession UseOnlineDevicesChanged(this IMilkyEventSession session, Action<MilkyOnlineDevicesChangedEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_profile_like.</summary>
    public static IMilkyEventSession UseFriendProfileLike(this IMilkyEventSession session, Func<MilkyFriendProfileLikeEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_profile_like.</summary>
    public static IMilkyEventSession UseFriendProfileLike(this IMilkyEventSession session, Func<MilkyFriendProfileLikeEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_profile_like.</summary>
    public static IMilkyEventSession UseFriendProfileLike(this IMilkyEventSession session, Action<MilkyFriendProfileLikeEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for group_special_title_change.</summary>
    public static IMilkyEventSession UseGroupSpecialTitleChange(this IMilkyEventSession session, Func<MilkyGroupSpecialTitleChangeEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for group_special_title_change.</summary>
    public static IMilkyEventSession UseGroupSpecialTitleChange(this IMilkyEventSession session, Func<MilkyGroupSpecialTitleChangeEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for group_special_title_change.</summary>
    public static IMilkyEventSession UseGroupSpecialTitleChange(this IMilkyEventSession session, Action<MilkyGroupSpecialTitleChangeEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_added.</summary>
    public static IMilkyEventSession UseFriendAdded(this IMilkyEventSession session, Func<MilkyFriendAddedEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_added.</summary>
    public static IMilkyEventSession UseFriendAdded(this IMilkyEventSession session, Func<MilkyFriendAddedEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for friend_added.</summary>
    public static IMilkyEventSession UseFriendAdded(this IMilkyEventSession session, Action<MilkyFriendAddedEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for group_self_joined.</summary>
    public static IMilkyEventSession UseGroupSelfJoined(this IMilkyEventSession session, Func<MilkyGroupSelfJoinedEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for group_self_joined.</summary>
    public static IMilkyEventSession UseGroupSelfJoined(this IMilkyEventSession session, Func<MilkyGroupSelfJoinedEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for group_self_joined.</summary>
    public static IMilkyEventSession UseGroupSelfJoined(this IMilkyEventSession session, Action<MilkyGroupSelfJoinedEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for group_member_card_change.</summary>
    public static IMilkyEventSession UseGroupMemberCardChange(this IMilkyEventSession session, Func<MilkyGroupMemberCardChangeEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for group_member_card_change.</summary>
    public static IMilkyEventSession UseGroupMemberCardChange(this IMilkyEventSession session, Func<MilkyGroupMemberCardChangeEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for group_member_card_change.</summary>
    public static IMilkyEventSession UseGroupMemberCardChange(this IMilkyEventSession session, Action<MilkyGroupMemberCardChangeEventData, MilkyEvent> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for packet_received.</summary>
    public static IMilkyEventSession UsePacketReceived(this IMilkyEventSession session, Func<MilkyPacketReceivedEventData, MilkyEvent, Func<Task>, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for packet_received.</summary>
    public static IMilkyEventSession UsePacketReceived(this IMilkyEventSession session, Func<MilkyPacketReceivedEventData, MilkyEvent, Task> middleware) => UseData(session, middleware);
    /// <summary>Registers a handler for packet_received.</summary>
    public static IMilkyEventSession UsePacketReceived(this IMilkyEventSession session, Action<MilkyPacketReceivedEventData, MilkyEvent> middleware) => UseData(session, middleware);
}
