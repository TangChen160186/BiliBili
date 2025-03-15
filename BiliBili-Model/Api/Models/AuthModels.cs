using System.Text.Json.Serialization;

namespace BiliBili_Model.Api.Models;

/// <summary>
/// 登录请求模型
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// 用户名
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; } = string.Empty;
    
    /// <summary>
    /// 密码
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}

/// <summary>
/// 登录响应模型
/// </summary>
public class LoginResponse
{
    /// <summary>
    /// 访问令牌
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;
    
    /// <summary>
    /// 刷新令牌
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = string.Empty;
    
    /// <summary>
    /// 令牌类型
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = string.Empty;
    
    /// <summary>
    /// 过期时间（秒）
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
    
    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("mid")]
    public long UserId { get; set; }
    
    /// <summary>
    /// 用户名
    /// </summary>
    [JsonPropertyName("uname")]
    public string Username { get; set; } = string.Empty;
}

/// <summary>
/// 用户信息模型
/// </summary>
public class UserInfo
{
    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonPropertyName("mid")]
    public long UserId { get; set; }
    
    /// <summary>
    /// 用户名
    /// </summary>
    [JsonPropertyName("name")]
    public string Username { get; set; } = string.Empty;
    
    /// <summary>
    /// 头像URL
    /// </summary>
    [JsonPropertyName("face")]
    public string AvatarUrl { get; set; } = string.Empty;
    
    /// <summary>
    /// 签名
    /// </summary>
    [JsonPropertyName("sign")]
    public string Signature { get; set; } = string.Empty;
    
    /// <summary>
    /// 等级
    /// </summary>
    [JsonPropertyName("level")]
    public int Level { get; set; }
    
    /// <summary>
    /// 硬币数
    /// </summary>
    [JsonPropertyName("coins")]
    public decimal Coins { get; set; }
    
    /// <summary>
    /// 是否为会员
    /// </summary>
    [JsonPropertyName("vip")]
    public VipInfo? Vip { get; set; }
}

/// <summary>
/// 会员信息
/// </summary>
public class VipInfo
{
    /// <summary>
    /// 会员类型
    /// </summary>
    [JsonPropertyName("type")]
    public int Type { get; set; }
    
    /// <summary>
    /// 会员状态
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }
    
    /// <summary>
    /// 是否为大会员
    /// </summary>
    public bool IsVip => Type > 0 && Status == 1;
} 