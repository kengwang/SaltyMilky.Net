using System.Text.Json;
using System.Text.Json.Nodes;
using SaltyMilky.Net;
using TUnit.Core;

namespace SaltyMilky.Net.Tests;

public sealed class LagrangeMessageEventContractTests
{
    [Test]
    public void TextIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"text","data":{"text":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "text", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MentionIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"mention","data":{"user_id":23,"name":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "mention", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MentionAllIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"mention_all","data":{}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "mention_all", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ReplyIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"reply","data":{"message_seq":23,"sender_id":23,"sender_name":"fixture","time":23,"segments":[{"type":"text","data":{"text":"fixture"}}]}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "reply", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ImageIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"image","data":{"flash":true,"resource_id":"fixture","temp_url":"fixture","width":23,"height":23,"summary":"fixture","sub_type":"fixture","file_md5":"fixture","file_sha1":"fixture","file_size":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "image", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void RecordIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"record","data":{"resource_id":"fixture","temp_url":"fixture","duration":23,"file_md5":"fixture","file_sha1":"fixture","file_size":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "record", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void VideoIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"video","data":{"resource_id":"fixture","temp_url":"fixture","width":23,"height":23,"duration":23,"file_md5":"fixture","file_sha1":"fixture","file_size":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "video", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void FileIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"file","data":{"file_id":"fixture","file_name":"fixture","file_size":23,"file_hash":"fixture","url":"fixture","title":"fixture","preview":"fixture","summary":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "file", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void FlashFileIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"flash_file","data":{"fileset_id":"fixture","file_name":"fixture","thumb_url":"fixture","scene_type":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "flash_file", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ForwardIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"forward","data":{"forward_id":"fixture","title":"fixture","preview":["fixture"],"summary":"fixture","prompt":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "forward", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void LightAppIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"light_app","data":{"app_name":"fixture","json_payload":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "light_app", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void FaceIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"face","data":{"is_large":true,"result_id":"fixture","face_id":"fixture","raw":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "face", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void XmlIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"xml","data":{"xml":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "xml", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MarketFaceIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"market_face","data":{"face_id":23,"name":"fixture","url":"fixture","summary":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "market_face", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void PokeIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"poke","data":{"type":23,"strength":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "poke", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MarkdownIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"markdown","data":{"content":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "markdown", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void KeyboardIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"keyboard","data":{"data":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "keyboard", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void SpecialPokeIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"special_poke","data":{"face_id":23,"count":23,"face_name":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "special_poke", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void JsonIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"json","data":{"data":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "json", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void LocationIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"location","data":{"latitude":"fixture","longitude":"fixture","title":"fixture","content":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "location", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MusicIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"music","data":{"type":"fixture","id":"fixture","url":"fixture","audio":"fixture","title":"fixture","content":"fixture","image":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "music", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ShareIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"share","data":{"url":"fixture","title":"fixture","content":"fixture","image":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "share", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ContactIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"contact","data":{"contact_type":"fixture","id":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "contact", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void DiceIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"dice","data":{"face_id":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "dice", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void RpsIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"rps","data":{"face_id":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "rps", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void LongMsgIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"long_msg","data":{"res_id":"fixture","messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"message_seq":23,"sender_name":"fixture","avatar_url":"fixture","time":23,"segments":[{"type":"text","data":{"text":"fixture"}}]}]}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "long_msg", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void StreamIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"stream","data":{"text":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "stream", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void BounceFaceIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"bounce_face","data":{"face_id":23,"count":23,"name":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "bounce_face", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void GroupReactionIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"group_reaction","data":{"reactions":[{"face_id":"fixture","type":23,"count":23,"is_added":true}]}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "group_reaction", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void GreyTipIncomingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"grey_tip","data":{"text":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.IncomingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "grey_tip", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.IncomingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void TextOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"text","data":{"text":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "text", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MentionOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"mention","data":{"user_id":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "mention", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MentionAllOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"mention_all","data":{}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "mention_all", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ReplyOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"reply","data":{"message_seq":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "reply", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ImageOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"image","data":{"uri":"fixture","sub_type":"fixture","summary":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "image", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void RecordOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"record","data":{"uri":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "record", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void VideoOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"video","data":{"uri":"fixture","thumb_uri":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "video", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void FileOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"file","data":{"file_id":"fixture","file_name":"fixture","file_size":23,"file_hash":"fixture","url":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "file", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ForwardOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"forward","data":{"messages":[{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"user_id":23,"sender_name":"fixture","segments":[{"type":"text","data":{"text":"fixture"}}]}],"title":"fixture","preview":["fixture"],"summary":"fixture","prompt":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "forward", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void LightAppOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"light_app","data":{"json_payload":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "light_app", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void FaceOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"face","data":{"is_large":true,"result_id":"fixture","face_id":"fixture","raw":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "face", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MarketFaceOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"market_face","data":{"face_id":23,"name":"fixture","url":"fixture","summary":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "market_face", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void XmlOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"xml","data":{"xml":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "xml", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void PokeOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"poke","data":{"type":23,"strength":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "poke", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MarkdownOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"markdown","data":{"content":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "markdown", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void KeyboardOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"keyboard","data":{"data":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "keyboard", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void SpecialPokeOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"special_poke","data":{"face_id":23,"count":23,"face_name":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "special_poke", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void JsonOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"json","data":{"data":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "json", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void LocationOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"location","data":{"latitude":"fixture","longitude":"fixture","title":"fixture","content":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "location", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void MusicOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"music","data":{}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "music", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ShareOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"share","data":{}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "share", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void ContactOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"contact","data":{}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "contact", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void DiceOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"dice","data":{"face_id":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "dice", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void RpsOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"rps","data":{"face_id":23}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "rps", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void LongMsgOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"long_msg","data":{"res_id":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "long_msg", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void StreamOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"stream","data":{"text":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "stream", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void BounceFaceOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"bounce_face","data":{"face_id":23,"count":23,"name":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "bounce_face", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void GroupReactionOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"group_reaction","data":{"reactions":[{"face_id":"fixture","type":23,"count":23,"is_added":true}]}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "group_reaction", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public void GreyTipOutgoingSegment_RetainsAllServerFields()
    {
        const string json = """{"type":"grey_tip","data":{"text":"fixture"}}""";
        var segment = JsonSerializer.Deserialize(json, MilkyJson.OutgoingSegmentTypeInfo)!;
        ContractHttpHandler.Check(segment.Type == "grey_tip", "Known segment should retain its type.");
        var actual = JsonSerializer.SerializeToNode(segment, MilkyJson.OutgoingSegmentTypeInfo);
        ContractHttpHandler.CheckContains(actual, JsonNode.Parse(json));
    }

    [Test]
    public async Task BotOffline_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"bot_offline","time":23,"self_id":23,"data":{"reason":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task FriendRemarkChanged_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"friend_remark_changed","time":23,"self_id":23,"data":{"user_id":23,"user_uid":"fixture","remark":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        ContractHttpHandler.Check(evt.Data is MilkyFriendRemarkChangedEventData && context is MilkyFriendRemarkChangedContext, "Expected specialized event and context.");
        CountingPlugin plugin = new();
        session.UsePlugin(plugin);
        int registered = 0;
        session.UseFriendRemarkChanged((data, envelope) => { registered++; });
        session.UseFriendRemarkChanged((data, envelope) => { registered++; return Task.CompletedTask; });
        session.UseFriendRemarkChanged(async (data, envelope, next) => { registered++; await next(); });
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");
    }

    [Test]
    public async Task FriendInputStatus_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"friend_input_status","time":23,"self_id":23,"data":{"user_id":23,"user_uid":"fixture","event_type":23,"status_text":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        ContractHttpHandler.Check(evt.Data is MilkyFriendInputStatusEventData && context is MilkyFriendInputStatusContext, "Expected specialized event and context.");
        CountingPlugin plugin = new();
        session.UsePlugin(plugin);
        int registered = 0;
        session.UseFriendInputStatus((data, envelope) => { registered++; });
        session.UseFriendInputStatus((data, envelope) => { registered++; return Task.CompletedTask; });
        session.UseFriendInputStatus(async (data, envelope, next) => { registered++; await next(); });
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");
    }

    [Test]
    public async Task OnlineDevicesChanged_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"online_devices_changed","time":23,"self_id":23,"data":{"devices":[{"app_id":23,"instance_id":23,"client_type":23,"platform":23,"device_name":"fixture"}]}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        ContractHttpHandler.Check(evt.Data is MilkyOnlineDevicesChangedEventData && context is MilkyOnlineDevicesChangedContext, "Expected specialized event and context.");
        CountingPlugin plugin = new();
        session.UsePlugin(plugin);
        int registered = 0;
        session.UseOnlineDevicesChanged((data, envelope) => { registered++; });
        session.UseOnlineDevicesChanged((data, envelope) => { registered++; return Task.CompletedTask; });
        session.UseOnlineDevicesChanged(async (data, envelope, next) => { registered++; await next(); });
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");
    }

    [Test]
    public async Task FriendProfileLike_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"friend_profile_like","time":23,"self_id":23,"data":{"user_id":23,"nickname":"fixture","times":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        ContractHttpHandler.Check(evt.Data is MilkyFriendProfileLikeEventData && context is MilkyFriendProfileLikeContext, "Expected specialized event and context.");
        CountingPlugin plugin = new();
        session.UsePlugin(plugin);
        int registered = 0;
        session.UseFriendProfileLike((data, envelope) => { registered++; });
        session.UseFriendProfileLike((data, envelope) => { registered++; return Task.CompletedTask; });
        session.UseFriendProfileLike(async (data, envelope, next) => { registered++; await next(); });
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");
    }

    [Test]
    public async Task GroupSpecialTitleChange_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_special_title_change","time":23,"self_id":23,"data":{"group_id":23,"user_id":23,"operator_id":23,"title":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        ContractHttpHandler.Check(evt.Data is MilkyGroupSpecialTitleChangeEventData && context is MilkyGroupSpecialTitleChangeContext, "Expected specialized event and context.");
        CountingPlugin plugin = new();
        session.UsePlugin(plugin);
        int registered = 0;
        session.UseGroupSpecialTitleChange((data, envelope) => { registered++; });
        session.UseGroupSpecialTitleChange((data, envelope) => { registered++; return Task.CompletedTask; });
        session.UseGroupSpecialTitleChange(async (data, envelope, next) => { registered++; await next(); });
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");
    }

    [Test]
    public async Task FriendAdded_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"friend_added","time":23,"self_id":23,"data":{"user_id":23,"user_uid":"fixture","nickname":"fixture","time":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        ContractHttpHandler.Check(evt.Data is MilkyFriendAddedEventData && context is MilkyFriendAddedContext, "Expected specialized event and context.");
        CountingPlugin plugin = new();
        session.UsePlugin(plugin);
        int registered = 0;
        session.UseFriendAdded((data, envelope) => { registered++; });
        session.UseFriendAdded((data, envelope) => { registered++; return Task.CompletedTask; });
        session.UseFriendAdded(async (data, envelope, next) => { registered++; await next(); });
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");
    }

    [Test]
    public async Task GroupSelfJoined_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_self_joined","time":23,"self_id":23,"data":{"group_id":23,"operator_id":23,"operator_uid":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        ContractHttpHandler.Check(evt.Data is MilkyGroupSelfJoinedEventData && context is MilkyGroupSelfJoinedContext, "Expected specialized event and context.");
        CountingPlugin plugin = new();
        session.UsePlugin(plugin);
        int registered = 0;
        session.UseGroupSelfJoined((data, envelope) => { registered++; });
        session.UseGroupSelfJoined((data, envelope) => { registered++; return Task.CompletedTask; });
        session.UseGroupSelfJoined(async (data, envelope, next) => { registered++; await next(); });
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");
    }

    [Test]
    public async Task FriendFileUpload_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"friend_file_upload","time":23,"self_id":23,"data":{"peer_id":23,"user_id":23,"file_id":"fixture","file_name":"fixture","file_size":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task FriendNudge_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"friend_nudge","time":23,"self_id":23,"data":{"peer_id":23,"sender_id":23,"receiver_id":23,"display_action":"fixture","display_action_img_url":"fixture","display_suffix":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task FriendRequest_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"friend_request","time":23,"self_id":23,"data":{"initiator_id":23,"initiator_uid":"fixture","comment":"fixture","via":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupAdminChange_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_admin_change","time":23,"self_id":23,"data":{"group_id":23,"user_id":23,"is_promote":true}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupMemberCardChange_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_member_card_change","time":23,"self_id":23,"data":{"group_id":23,"user_id":23,"old_card":"fixture","new_card":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        ContractHttpHandler.Check(evt.Data is MilkyGroupMemberCardChangeEventData && context is MilkyGroupMemberCardChangeContext, "Expected specialized event and context.");
        CountingPlugin plugin = new();
        session.UsePlugin(plugin);
        int registered = 0;
        session.UseGroupMemberCardChange((data, envelope) => { registered++; });
        session.UseGroupMemberCardChange((data, envelope) => { registered++; return Task.CompletedTask; });
        session.UseGroupMemberCardChange(async (data, envelope, next) => { registered++; await next(); });
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");
    }

    [Test]
    public async Task GroupEssenceMessageChange_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_essence_message_change","time":23,"self_id":23,"data":{"group_id":23,"message_seq":23,"sender_id":23,"operator_id":23,"is_set":true}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupFileUpload_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_file_upload","time":23,"self_id":23,"data":{"group_id":23,"user_id":23,"file_id":"fixture","file_name":"fixture","file_size":23,"bus_id":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupInvitation_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_invitation","time":23,"self_id":23,"data":{"group_id":23,"invitation_seq":23,"initiator_id":23,"source_group_id":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupInvitedJoinRequest_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_invited_join_request","time":23,"self_id":23,"data":{"group_id":23,"notification_seq":23,"initiator_id":23,"target_user_id":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupJoinRequest_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_join_request","time":23,"self_id":23,"data":{"group_id":23,"notification_seq":23,"is_filtered":true,"initiator_id":23,"comment":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupMemberDecrease_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_member_decrease","time":23,"self_id":23,"data":{"group_id":23,"user_id":23,"operator_id":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupMemberIncrease_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_member_increase","time":23,"self_id":23,"data":{"group_id":23,"user_id":23,"operator_id":23,"invitor_id":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupMessageReaction_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_message_reaction","time":23,"self_id":23,"data":{"group_id":23,"user_id":23,"message_seq":23,"face_id":"fixture","reaction_type":"fixture","is_add":true,"current_count":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupMute_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_mute","time":23,"self_id":23,"data":{"group_id":23,"operator_id":23,"user_id":23,"duration":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupWholeMute_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_whole_mute","time":23,"self_id":23,"data":{"group_id":23,"operator_id":23,"is_mute":true}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupNameChange_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_name_change","time":23,"self_id":23,"data":{"group_id":23,"operator_id":23,"name":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task GroupNudge_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"group_nudge","time":23,"self_id":23,"data":{"group_id":23,"sender_id":23,"receiver_id":23,"display_action":"fixture","display_suffix":"fixture","display_action_img_url":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task MessageRecall_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"message_recall","time":23,"self_id":23,"data":{"message_scene":"fixture","peer_id":23,"message_seq":23,"sender_id":23,"operator_id":23,"display_suffix":"fixture","recalled_by_self":true,"peer_uid":"fixture","time":23}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task MessageReceive_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"message_receive","time":23,"self_id":23,"data":{"message_style":{"bubble_id":23,"pendant_id":23,"font_id":23,"font_effect_id":23,"is_cs_font_effect_enabled":true,"bubble_diy_text_id":23},"peer_id":23,"message_seq":23,"sender_id":23,"time":23,"segments":[{"type":"text","data":{"text":"fixture"}}],"friend":{"user_id":23,"nickname":"fixture","sex":"fixture","qid":"fixture","remark":"fixture","category":{"category_id":23,"category_name":"fixture"}},"message_scene":"friend"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    [Test]
    public async Task PacketReceived_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"packet_received","time":23,"self_id":23,"data":{"cmd":"fixture","data":"fixture","sequence":23,"ret_code":23,"extra":"fixture"}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        ContractHttpHandler.Check(evt.Data is MilkyPacketReceivedEventData && context is MilkyPacketReceivedContext, "Expected specialized event and context.");
        CountingPlugin plugin = new();
        session.UsePlugin(plugin);
        int registered = 0;
        session.UsePacketReceived((data, envelope) => { registered++; });
        session.UsePacketReceived((data, envelope) => { registered++; return Task.CompletedTask; });
        session.UsePacketReceived(async (data, envelope, next) => { registered++; await next(); });
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
        ContractHttpHandler.Check(plugin.DataCalls == 1 && plugin.ContextCalls == 1 && registered == 3, "Plugin and each registration must dispatch once.");
    }

    [Test]
    public async Task PeerPinChange_ParsesSerializesAndDispatches()
    {
        const string json = """{"event_type":"peer_pin_change","time":23,"self_id":23,"data":{"peer_type":"fixture","peer_id":23,"is_pinned":true}}""";
        var evt = MilkyEventParser.ParseJson(json)!;
        ContractHttpHandler.Check(evt.Data is not MilkyUnknownEventData, "Known event must be typed.");
        var actual = JsonSerializer.SerializeToNode(evt, MilkyJson.EventTypeInfo)!;
        ContractHttpHandler.CheckContains(actual["data"], JsonNode.Parse(json)!["data"]);
        using MilkyHttpSession session = new(new MilkyHttpSessionOptions { BaseAddress = new Uri("http://localhost/") });
        using CancellationTokenSource cancellation = new();
        var context = MilkyEventContextFactory.Create(session, evt, cancellation.Token);
        ContractHttpHandler.Check(ReferenceEquals(context.Session, session) && context.CancellationToken == cancellation.Token, "Context should retain its session and cancellation token.");
        await session.EventPipeline.ExecuteAsync(evt, cancellation.Token);
    }

    private sealed class CountingPlugin : MilkyEventPlugin
    {
        public int DataCalls;
        public int ContextCalls;
        public override Task OnFriendRemarkChangedAsync(MilkyFriendRemarkChangedEventData data, MilkyEvent evt) { DataCalls++; return Task.CompletedTask; }
        protected override Task OnFriendRemarkChangedAsync(MilkyFriendRemarkChangedContext context) { ContextCalls++; return Task.CompletedTask; }
        public override Task OnFriendInputStatusAsync(MilkyFriendInputStatusEventData data, MilkyEvent evt) { DataCalls++; return Task.CompletedTask; }
        protected override Task OnFriendInputStatusAsync(MilkyFriendInputStatusContext context) { ContextCalls++; return Task.CompletedTask; }
        public override Task OnOnlineDevicesChangedAsync(MilkyOnlineDevicesChangedEventData data, MilkyEvent evt) { DataCalls++; return Task.CompletedTask; }
        protected override Task OnOnlineDevicesChangedAsync(MilkyOnlineDevicesChangedContext context) { ContextCalls++; return Task.CompletedTask; }
        public override Task OnFriendProfileLikeAsync(MilkyFriendProfileLikeEventData data, MilkyEvent evt) { DataCalls++; return Task.CompletedTask; }
        protected override Task OnFriendProfileLikeAsync(MilkyFriendProfileLikeContext context) { ContextCalls++; return Task.CompletedTask; }
        public override Task OnGroupSpecialTitleChangeAsync(MilkyGroupSpecialTitleChangeEventData data, MilkyEvent evt) { DataCalls++; return Task.CompletedTask; }
        protected override Task OnGroupSpecialTitleChangeAsync(MilkyGroupSpecialTitleChangeContext context) { ContextCalls++; return Task.CompletedTask; }
        public override Task OnFriendAddedAsync(MilkyFriendAddedEventData data, MilkyEvent evt) { DataCalls++; return Task.CompletedTask; }
        protected override Task OnFriendAddedAsync(MilkyFriendAddedContext context) { ContextCalls++; return Task.CompletedTask; }
        public override Task OnGroupSelfJoinedAsync(MilkyGroupSelfJoinedEventData data, MilkyEvent evt) { DataCalls++; return Task.CompletedTask; }
        protected override Task OnGroupSelfJoinedAsync(MilkyGroupSelfJoinedContext context) { ContextCalls++; return Task.CompletedTask; }
        public override Task OnGroupMemberCardChangeAsync(MilkyGroupMemberCardChangeEventData data, MilkyEvent evt) { DataCalls++; return Task.CompletedTask; }
        protected override Task OnGroupMemberCardChangeAsync(MilkyGroupMemberCardChangeContext context) { ContextCalls++; return Task.CompletedTask; }
        public override Task OnPacketReceivedAsync(MilkyPacketReceivedEventData data, MilkyEvent evt) { DataCalls++; return Task.CompletedTask; }
        protected override Task OnPacketReceivedAsync(MilkyPacketReceivedContext context) { ContextCalls++; return Task.CompletedTask; }
    }
}
