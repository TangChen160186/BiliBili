using BiliBili_Model.Api;
using BiliBili_Model.Api.Models;
using System.Text.Json;

namespace BiliBili_ViewModel.Services;

/// <summary>
/// 认证服务接口
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    UserInfo? CurrentUser { get; }
    
    /// <summary>
    /// 是否已登录
    /// </summary>
    bool IsLoggedIn { get; }
    
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <returns>登录结果</returns>
    Task<bool> LoginAsync(string username, string password);
    
    /// <summary>
    /// 退出登录
    /// </summary>
    /// <returns>操作结果</returns>
    Task<bool> LogoutAsync();
    
    /// <summary>
    /// 加载用户信息
    /// </summary>
    /// <returns>操作结果</returns>
    Task<bool> LoadUserInfoAsync();
}

/// <summary>
/// 认证服务实现
/// </summary>
public class AuthService : IAuthService
{
    private readonly IBiliBiliApiClient _apiClient;
    private readonly string _authFileName = "auth.json";
    
    /// <summary>
    /// 当前用户信息
    /// </summary>
    public UserInfo? CurrentUser { get; private set; }
    
    /// <summary>
    /// 是否已登录
    /// </summary>
    public bool IsLoggedIn => CurrentUser != null;
    
    public AuthService(IBiliBiliApiClient apiClient)
    {
        _apiClient = apiClient;
        
        // 尝试从本地加载认证信息
        LoadAuthInfoFromLocal();
    }
    
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="username">用户名</param>
    /// <param name="password">密码</param>
    /// <returns>登录结果</returns>
    public async Task<bool> LoginAsync(string username, string password)
    {
        try
        {
            var response = await _apiClient.LoginAsync(username, password);
            
            if (response != null && response.IsSuccess && response.Data != null)
            {
                // 保存认证信息
                SaveAuthInfoToLocal(response.Data.AccessToken, response.Data.RefreshToken, response.Data.UserId);
                
                // 加载用户信息
                await LoadUserInfoAsync();
                
                return true;
            }
            
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"登录失败: {ex.Message}");
            return false;
        }
    }
    
    /// <summary>
    /// 退出登录
    /// </summary>
    /// <returns>操作结果</returns>
    public async Task<bool> LogoutAsync()
    {
        try
        {
            var response = await _apiClient.LogoutAsync();
            
            if (response != null && response.IsSuccess)
            {
                // 清除认证信息
                ClearAuthInfo();
                return true;
            }
            
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"退出登录失败: {ex.Message}");
            return false;
        }
    }
    
    /// <summary>
    /// 加载用户信息
    /// </summary>
    /// <returns>操作结果</returns>
    public async Task<bool> LoadUserInfoAsync()
    {
        try
        {
            var response = await _apiClient.GetCurrentUserInfoAsync();
            
            if (response != null && response.IsSuccess && response.Data != null)
            {
                CurrentUser = response.Data;
                return true;
            }
            
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"加载用户信息失败: {ex.Message}");
            return false;
        }
    }
    
    /// <summary>
    /// 从本地加载认证信息
    /// </summary>
    private void LoadAuthInfoFromLocal()
    {
        try
        {
            var authFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _authFileName);
            
            if (File.Exists(authFilePath))
            {
                var json = File.ReadAllText(authFilePath);
                var authInfo = JsonSerializer.Deserialize<AuthInfo>(json);
                
                if (authInfo != null)
                {
                    _apiClient.SetAuthInfo(authInfo.AccessToken, authInfo.RefreshToken, authInfo.UserId);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"加载认证信息失败: {ex.Message}");
        }
    }
    
    /// <summary>
    /// 保存认证信息到本地
    /// </summary>
    /// <param name="accessToken">访问令牌</param>
    /// <param name="refreshToken">刷新令牌</param>
    /// <param name="userId">用户ID</param>
    private void SaveAuthInfoToLocal(string accessToken, string refreshToken, long userId)
    {
        try
        {
            var authInfo = new AuthInfo
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserId = userId
            };
            
            var json = JsonSerializer.Serialize(authInfo);
            var authFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _authFileName);
            
            File.WriteAllText(authFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"保存认证信息失败: {ex.Message}");
        }
    }
    
    /// <summary>
    /// 清除认证信息
    /// </summary>
    private void ClearAuthInfo()
    {
        try
        {
            var authFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _authFileName);
            
            if (File.Exists(authFilePath))
            {
                File.Delete(authFilePath);
            }
            
            CurrentUser = null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"清除认证信息失败: {ex.Message}");
        }
    }
    
    /// <summary>
    /// 认证信息
    /// </summary>
    private class AuthInfo
    {
        /// <summary>
        /// 访问令牌
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;
        
        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string RefreshToken { get; set; } = string.Empty;
        
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }
    }
} 