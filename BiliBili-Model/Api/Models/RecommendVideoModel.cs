using System.Text.Json.Serialization;

namespace BiliBili_Model.Api.Models;

public record RecommendVideoModel(
    [property: JsonPropertyName("item")] IReadOnlyList<RecommendVideo> Item,
    [property: JsonPropertyName("side_bar_column")]
    IReadOnlyList<SideBarColumn> SideBarColumn,
    [property: JsonPropertyName("business_card")]
    object BusinessCard,
    [property: JsonPropertyName("floor_info")]
    object FloorInfo,
    [property: JsonPropertyName("user_feature")]
    object UserFeature,
    [property: JsonPropertyName("preload_expose_pct")]
    double PreloadExposePct,
    [property: JsonPropertyName("preload_floor_expose_pct")]
    double PreloadFloorExposePct,
    [property: JsonPropertyName("mid")] long Mid
);
public record Area(
    [property: JsonPropertyName("area_id")]
    long AreaId,
    [property: JsonPropertyName("area_name")]
    string AreaName,
    [property: JsonPropertyName("parent_area_id")]
    long ParentAreaId,
    [property: JsonPropertyName("parent_area_name")]
    string ParentAreaName,
    [property: JsonPropertyName("old_area_id")]
    long OldAreaId,
    [property: JsonPropertyName("old_area_name")]
    string OldAreaName,
    [property: JsonPropertyName("old_area_tag")]
    string OldAreaTag,
    [property: JsonPropertyName("area_pk_status")]
    long AreaPkStatus,
    [property: JsonPropertyName("is_video_room")]
    bool IsVideoRoom
);

public record BusinessInfo(
    [property: JsonPropertyName("id")] long Id,
    [property: JsonPropertyName("contract_id")]
    string ContractId,
    [property: JsonPropertyName("res_id")] long ResId,
    [property: JsonPropertyName("asg_id")] long AsgId,
    [property: JsonPropertyName("pos_num")]
    long PosNum,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("pic")] string Pic,
    [property: JsonPropertyName("litpic")] string Litpic,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("style")] long Style,
    [property: JsonPropertyName("agency")] string Agency,
    [property: JsonPropertyName("label")] string Label,
    [property: JsonPropertyName("longro")] string longro,
    [property: JsonPropertyName("creative_type")]
    long CreativeType,
    [property: JsonPropertyName("request_id")]
    string RequestId,
    [property: JsonPropertyName("src_id")] long SrcId,
    [property: JsonPropertyName("area")] long Area,
    [property: JsonPropertyName("is_ad_loc")]
    bool IsAdLoc,
    [property: JsonPropertyName("ad_cb")] string AdCb,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("server_type")]
    long ServerType,
    [property: JsonPropertyName("cm_mark")]
    long CmMark,
    [property: JsonPropertyName("stime")] long Stime,
    [property: JsonPropertyName("mid")] string Mid,
    [property: JsonPropertyName("activity_type")]
    long ActivityType,
    [property: JsonPropertyName("epid")] long Epid,
    [property: JsonPropertyName("sub_title")]
    string SubTitle,
    [property: JsonPropertyName("ad_desc")]
    string AdDesc,
    [property: JsonPropertyName("adver_name")]
    string AdverName,
    [property: JsonPropertyName("null_frame")]
    bool NullFrame,
    [property: JsonPropertyName("pic_main_color")]
    string PicMainColor,
    [property: JsonPropertyName("card_type")]
    long CardType,
    [property: JsonPropertyName("business_mark")]
    object BusinessMark,
    [property: JsonPropertyName("inline")] Inline Inline,
    [property: JsonPropertyName("operater")]
    string Operater,
    [property: JsonPropertyName("jump_target")]
    long JumpTarget,
    [property: JsonPropertyName("show_urls")]
    object ShowUrls,
    [property: JsonPropertyName("click_urls")]
    object ClickUrls
);

public record Comic(
    [property: JsonPropertyName("comic_id")]
    long ComicId,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("horizontal_cover")]
    string HorizontalCover,
    [property: JsonPropertyName("square_cover")]
    string SquareCover,
    [property: JsonPropertyName("vertical_cover")]
    string VerticalCover,
    [property: JsonPropertyName("is_finish")]
    long IsFinish,
    [property: JsonPropertyName("status")] long Status,
    [property: JsonPropertyName("last_ord")]
    long LastOrd,
    [property: JsonPropertyName("total")] long Total,
    [property: JsonPropertyName("release_time")]
    string ReleaseTime,
    [property: JsonPropertyName("last_short_title")]
    string LastShortTitle,
    [property: JsonPropertyName("discount_type")]
    long DiscountType,
    [property: JsonPropertyName("recommendation")]
    string Recommendation,
    [property: JsonPropertyName("last_read_ep_id")]
    long LastReadEpId,
    [property: JsonPropertyName("latest_ep_short_title")]
    string LatestEpShortTitle,
    [property: JsonPropertyName("style")] IReadOnlyList<string> Style,
    [property: JsonPropertyName("author_name")]
    IReadOnlyList<string> AuthorName,
    [property: JsonPropertyName("allow_wait_free")]
    bool AllowWaitFree,
    [property: JsonPropertyName("type")] long Type,
    [property: JsonPropertyName("rank")] object Rank,
    [property: JsonPropertyName("operate_cover")]
    string OperateCover,
    [property: JsonPropertyName("rookie_type")]
    long RookieType
);



public record Inline(
    [property: JsonPropertyName("inline_use_same")]
    long InlineUseSame,
    [property: JsonPropertyName("inline_type")]
    long InlineType,
    [property: JsonPropertyName("inline_url")]
    string InlineUrl,
    [property: JsonPropertyName("inline_barrage_switch")]
    long InlineBarrageSwitch
);

public record RecommendVideo(
    [property: JsonPropertyName("id")] long Id,
    [property: JsonPropertyName("bvid")] string Bvid,
    [property: JsonPropertyName("cid")] long Cid,
    [property: JsonPropertyName("goto")] string Goto,
    [property: JsonPropertyName("uri")] string Uri,
    [property: JsonPropertyName("pic")] string Pic,
    [property: JsonPropertyName("pic_4_3")]
    string Pic43,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("duration")]
    long Duration,
    [property: JsonPropertyName("pubdate")]
    long Pubdate,
    [property: JsonPropertyName("owner")] Owner Owner,
    [property: JsonPropertyName("stat")] Stat Stat,
    [property: JsonPropertyName("av_feature")]
    object AvFeature,
    [property: JsonPropertyName("is_followed")]
    long IsFollowed,
    [property: JsonPropertyName("rcmd_reason")]
    RcmdReason RcmdReason,
    [property: JsonPropertyName("show_info")]
    long ShowInfo,
    [property: JsonPropertyName("track_id")]
    string TrackId,
    [property: JsonPropertyName("pos")] long Pos,
    [property: JsonPropertyName("room_info")]
    RoomInfo RoomInfo,
    [property: JsonPropertyName("ogv_info")]
    object OgvInfo,
    [property: JsonPropertyName("business_info")]
    BusinessInfo BusinessInfo,
    [property: JsonPropertyName("is_stock")]
    long IsStock,
    [property: JsonPropertyName("enable_vt")]
    long EnableVt,
    [property: JsonPropertyName("vt_display")]
    string VtDisplay,
    [property: JsonPropertyName("dislike_switch")]
    long DislikeSwitch,
    [property: JsonPropertyName("dislike_switch_pc")]
    long DislikeSwitchPc
);

public record NewEp(
    [property: JsonPropertyName("id")] long Id,
    [property: JsonPropertyName("index_show")]
    string IndexShow,
    [property: JsonPropertyName("cover")] string Cover,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("long_title")]
    string LongTitle,
    [property: JsonPropertyName("pub_time")]
    string PubTime,
    [property: JsonPropertyName("duration")]
    long Duration,
    [property: JsonPropertyName("day_of_week")]
    long DayOfWeek
);

public record Owner(
    [property: JsonPropertyName("mid")] long Mid,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("face")] string Face
);

public record Producer(
    [property: JsonPropertyName("mid")] long Mid,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("type")] long Type,
    [property: JsonPropertyName("is_contribute")]
    long IsContribute
);

public record RcmdReason(
    [property: JsonPropertyName("reason_type")]
    long ReasonType,
    [property: JsonPropertyName("content")]
    string Content
);

public record RoomInfo(
    [property: JsonPropertyName("room_id")]
    long RoomId,
    [property: JsonPropertyName("uid")] long Uid,
    [property: JsonPropertyName("live_status")]
    long LiveStatus,
    [property: JsonPropertyName("show")] Show Show,
    [property: JsonPropertyName("area")] Area Area,
    [property: JsonPropertyName("watched_show")]
    WatchedShow WatchedShow
);

public record Show(
    [property: JsonPropertyName("short_id")]
    long ShortId,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("cover")] string Cover,
    [property: JsonPropertyName("keyframe")]
    string Keyframe,
    [property: JsonPropertyName("popularity_count")]
    long PopularityCount,
    [property: JsonPropertyName("tag_list")]
    object TagList,
    [property: JsonPropertyName("live_start_time")]
    long LiveStartTime,
    [property: JsonPropertyName("live_id")]
    long LiveId,
    [property: JsonPropertyName("hidden_online")]
    bool HiddenOnline
);

public record SideBarColumn(
    [property: JsonPropertyName("id")] long Id,
    [property: JsonPropertyName("goto")] string Goto,
    [property: JsonPropertyName("track_id")]
    string TrackId,
    [property: JsonPropertyName("pos")] long Pos,
    [property: JsonPropertyName("card_type")]
    string CardType,
    [property: JsonPropertyName("card_type_en")]
    string CardTypeEn,
    [property: JsonPropertyName("cover")] string Cover,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("sub_title")]
    string SubTitle,
    [property: JsonPropertyName("duration")]
    long Duration,
    [property: JsonPropertyName("stats")] Stats Stats,
    [property: JsonPropertyName("room_info")]
    object RoomInfo,
    [property: JsonPropertyName("styles")] IReadOnlyList<string> Styles,
    [property: JsonPropertyName("comic")] Comic Comic,
    [property: JsonPropertyName("producer")]
    IReadOnlyList<Producer> Producer,
    [property: JsonPropertyName("source")] string Source,
    [property: JsonPropertyName("av_feature")]
    object AvFeature,
    [property: JsonPropertyName("is_rec")] long IsRec,
    [property: JsonPropertyName("is_finish")]
    long IsFinish,
    [property: JsonPropertyName("is_started")]
    long IsStarted,
    [property: JsonPropertyName("is_play")]
    long IsPlay,
    [property: JsonPropertyName("enable_vt")]
    long EnableVt,
    [property: JsonPropertyName("vt_display")]
    string VtDisplay,
    [property: JsonPropertyName("new_ep")] NewEp NewEp,
    [property: JsonPropertyName("horizontal_cover_16_9")]
    string HorizontalCover169,
    [property: JsonPropertyName("horizontal_cover_16_10")]
    string HorizontalCover1610
);

public record Stat(
    [property: JsonPropertyName("view")] long View,
    [property: JsonPropertyName("like")] long Like,
    [property: JsonPropertyName("danmaku")]
    long Danmaku,
    [property: JsonPropertyName("vt")] long Vt
);

public record Stats(
    [property: JsonPropertyName("follow")] long Follow,
    [property: JsonPropertyName("view")] long View,
    [property: JsonPropertyName("danmaku")]
    long Danmaku,
    [property: JsonPropertyName("reply")] long Reply,
    [property: JsonPropertyName("coin")] long Coin,
    [property: JsonPropertyName("series_follow")]
    long SeriesFollow,
    [property: JsonPropertyName("series_view")]
    long SeriesView,
    [property: JsonPropertyName("likes")] long Likes,
    [property: JsonPropertyName("favorite")]
    long Favorite
);

public record WatchedShow(
    [property: JsonPropertyName("switch")] bool Switch,
    [property: JsonPropertyName("num")] long Num,
    [property: JsonPropertyName("text_small")]
    string TextSmall,
    [property: JsonPropertyName("text_large")]
    string TextLarge,
    [property: JsonPropertyName("icon")] string Icon,
    [property: JsonPropertyName("icon_location")]
    string IconLocation,
    [property: JsonPropertyName("icon_web")]
    string IconWeb
);