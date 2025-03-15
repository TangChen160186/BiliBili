using BiliBili_Model.Api.Models;

namespace BiliBili_Model.Api;

/// <summary>
/// 哔哩哔哩API客户端接口
/// </summary>
public interface IBiliBiliApiClient
{
    /// <summary>
    /// 设置用户认证信息
    /// </summary>
    /// <param name="accessToken">访问令牌</param>
    /// <param name="refreshToken">刷新令牌</param>
    /// <param name="userId">用户ID</param>
    void SetAuthInfo(string accessToken, string refreshToken, long userId);
    
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <returns>登录响应</returns>
    Task<ApiResponse<LoginResponse>?> LoginAsync(string username, string password);
    
    /// <summary>
    /// 获取当前登录用户信息
    /// </summary>
    /// <returns>用户信息</returns>
    Task<ApiResponse<UserInfo>?> GetCurrentUserInfoAsync();
    
    /// <summary>
    /// 获取指定用户信息
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>用户信息</returns>
    Task<ApiResponse<UserInfo>?> GetUserInfoAsync(long userId);
    
    /// <summary>
    /// 退出登录
    /// </summary>
    /// <returns>操作结果</returns>
    Task<ApiResponse<object>?> LogoutAsync();
    
    // 在这里添加API方法的接口定义
    // 例如：获取用户信息、获取视频信息、搜索等
} 