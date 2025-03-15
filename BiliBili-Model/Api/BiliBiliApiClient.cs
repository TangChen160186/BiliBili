using BiliBili_Model.Api.Models;
using System.Security.Cryptography;
using System.Text;

namespace BiliBili_Model.Api;

/// <summary>
/// 哔哩哔哩API客户端
/// </summary>
public class BiliBiliApiClient : IBiliBiliApiClient
{
    private readonly IHttpClientService _httpClient;
    
    // API基础URL
    private const string BaseUrl = "https://api.bilibili.com";
    private const string AppBaseUrl = "https://app.bilibili.com";
    private const string PassportBaseUrl = "https://passport.bilibili.com";
    private const string LiveBaseUrl = "https://api.live.bilibili.com";
    
    // 用户认证信息
    private string? _accessToken;
    private string? _refreshToken;
    private long _userId;
    
    // 应用密钥（实际使用时应从配置中获取）
    private const string AppKey = "1d8b6e7d45233436";
    private const string AppSecret = "560c52ccd288fed045859ed18bffd973";
    
    public BiliBiliApiClient(IHttpClientService httpClient)
    {
        _httpClient = httpClient;
    }
    
    /// <summary>
    /// 设置用户认证信息
    /// </summary>
    public void SetAuthInfo(string accessToken, string refreshToken, long userId)
    {
        _accessToken = accessToken;
        _refreshToken = refreshToken;
        _userId = userId;
    }
    
    /// <summary>
    /// 获取请求头，包含认证信息
    /// </summary>
    private Dictionary<string, string> GetAuthHeaders()
    {
        var headers = new Dictionary<string, string>();
        
        if (!string.IsNullOrEmpty(_accessToken))
        {
            headers.Add("Authorization", $"Bearer {_accessToken}");
        }
        
        return headers;
    }
    
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <returns>登录响应</returns>
    public async Task<ApiResponse<LoginResponse>?> LoginAsync(string username, string password)
    {
        // 构建登录参数
        var parameters = new Dictionary<string, string>
        {
            { "username", username },
            { "password", password },
            { "appkey", AppKey },
            { "platform", "web" },
            { "ts", DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() }
        };
        
        // 添加签名
        parameters.Add("sign", GenerateSign(parameters));
        
        // 发送登录请求
        var url = $"{PassportBaseUrl}/x/passport-login/oauth2/login";
        var response = await _httpClient.PostFormAsync<ApiResponse<LoginResponse>>(url, parameters);
        
        // 如果登录成功，保存认证信息
        if (response != null && response.IsSuccess && response.Data != null)
        {
            SetAuthInfo(response.Data.AccessToken, response.Data.RefreshToken, response.Data.UserId);
        }
        
        return response;
    }
    
    /// <summary>
    /// 获取当前登录用户信息
    /// </summary>
    /// <returns>用户信息</returns>
    public async Task<ApiResponse<UserInfo>?> GetCurrentUserInfoAsync()
    {
        if (_userId <= 0)
        {
            throw new InvalidOperationException("用户未登录");
        }
        
        return await GetUserInfoAsync(_userId);
    }
    
    /// <summary>
    /// 获取指定用户信息
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>用户信息</returns>
    public async Task<ApiResponse<UserInfo>?> GetUserInfoAsync(long userId)
    {
        var url = $"{BaseUrl}/x/space/acc/info?mid={userId}";
        return await _httpClient.GetAsync<ApiResponse<UserInfo>>(url, GetAuthHeaders());
    }
    
    /// <summary>
    /// 退出登录
    /// </summary>
    /// <returns>操作结果</returns>
    public async Task<ApiResponse<object>?> LogoutAsync()
    {
        if (string.IsNullOrEmpty(_accessToken))
        {
            throw new InvalidOperationException("用户未登录");
        }
        
        var parameters = new Dictionary<string, string>
        {
            { "access_token", _accessToken },
            { "appkey", AppKey },
            { "ts", DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() }
        };
        
        // 添加签名
        parameters.Add("sign", GenerateSign(parameters));
        
        var url = $"{PassportBaseUrl}/x/passport-login/oauth2/revoke";
        var response = await _httpClient.PostFormAsync<ApiResponse<object>>(url, parameters);
        
        // 清除认证信息
        if (response != null && response.IsSuccess)
        {
            _accessToken = null;
            _refreshToken = null;
            _userId = 0;
        }
        
        return response;
    }
    
    /// <summary>
    /// 生成API请求签名
    /// </summary>
    /// <param name="parameters">请求参数</param>
    /// <returns>签名</returns>
    private string GenerateSign(Dictionary<string, string> parameters)
    {
        // 按照参数名排序
        var sortedParams = parameters.OrderBy(p => p.Key).ToList();
        
        // 构建签名字符串
        var builder = new StringBuilder();
        foreach (var param in sortedParams)
        {
            builder.Append($"{param.Key}={param.Value}");
        }
        
        // 添加密钥
        builder.Append(AppSecret);
        
        // 计算MD5
        using var md5 = MD5.Create();
        var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(builder.ToString()));
        
        // 转换为小写十六进制字符串
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
} 