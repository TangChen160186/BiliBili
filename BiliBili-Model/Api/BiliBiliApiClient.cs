using BiliBili_Model.Api.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace BiliBili_Model.Api;

/// <summary>
/// 哔哩哔哩API客户端
/// </summary>
public class BiliBiliApiClient : IBiliBiliApiClient
{
    private readonly IHttpClientService _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;
    
    // API基础URL
    private const string BaseUrl = "https://api.bilibili.com";
    private const string AppBaseUrl = "https://app.bilibili.com"; 
    private const string PassportBaseUrl = "https://passport.bilibili.com";
    private const string LiveBaseUrl = "https://api.live.bilibili.com";

    private const string RecommendVideoUrl = $"{BaseUrl}/x/web-interface/wbi/index/top/feed/rcmd";
    // 用户认证信息
    private string? _accessToken;
    private string? _refreshToken;
    private long _userId;
    
    // 应用密钥（实际使用时应从配置中获取）
    private const string AppKey = "1d8b6e7d45233436";
    private const string AppSecret = "560c52ccd288fed045859ed18bffd973";
    
    public BiliBiliApiClient(IHttpClientService httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        
        // 配置JSON序列化选项
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false,
            PropertyNameCaseInsensitive = true
        };
    }
    

    private async Task<Result<T>> ExecuteApiRequestAsync<T>(Func<Task<ApiResponse<T>>> requestFunc, [CallerMemberName] string operatorName = "")
    {
        try
        {
            var apiResponse = await requestFunc();
            return apiResponse.Code == 0 ?
                Result<T>.Success(apiResponse.Data) : Result<T>.Fail(apiResponse.Message, apiResponse.Code);
        }
        catch (HttpRequestException httpEx)
        {
            return Result<T>.Fail($"{operatorName}: {httpEx.Message}");
        }
        catch (JsonException jsonEx)
        {
            return Result<T>.Fail($"JSON解析错误: {jsonEx.Message}");
        }
        catch (Exception ex)
        {
            return Result<T>.Fail($"{operatorName}: {ex.Message}");
        }
    }

    private async Task<Result> ExecuteApiRequestAsync(Func<Task<ApiResponse>> requestFunc, [CallerMemberName] string operatorName = "")
    {
        try
        {
            var apiResponse = await requestFunc();
            return apiResponse.Code == 0 ?
                Result.Success() : Result.Fail(apiResponse.Message, apiResponse.Code);
        }
        catch (HttpRequestException httpEx)
        {
            return Result.Fail($"{operatorName}: {httpEx.Message}");
        }
        catch (JsonException jsonEx)
        {
            return Result.Fail($"JSON解析错误: {jsonEx.Message}");
        }
        catch (Exception ex)
        {
            return Result.Fail($"{operatorName}: {ex.Message}");
        }
    }

    
    private string GenerateSign(Dictionary<string, string> parameters)
    {
        // 按照参数名称排序
        var sortedParams = parameters.OrderBy(p => p.Key).ToList();
        
        // 构建签名字符串
        var signStr = string.Join("&", sortedParams.Select(p => $"{p.Key}={p.Value}")) + AppSecret;
        
        // 计算MD5哈希
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(signStr));
        
        // 转换为小写十六进制字符串
        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }



    public async Task<Result<RecommendVideoModel>> GetRecommendVideos()
    {
        var result = await ExecuteApiRequestAsync(() => 
            _httpClient.GetAsync<RecommendVideoModel>(RecommendVideoUrl));
        return result;
    }
} 