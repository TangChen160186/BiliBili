using BiliBili_Model.Api.Models;

namespace BiliBili_Model.Api;

/// <summary>
/// 哔哩哔哩API客户端接口
/// </summary>
public interface IBiliBiliApiClient
{
    Task<Result<RecommendVideoModel>> GetRecommendVideos();
} 