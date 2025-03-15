using BiliBili_Model.Api.Models;
using BiliBili_ViewModel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BiliBili_ViewModel.ViewModels;

/// <summary>
/// 登录ViewModel
/// </summary>
public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthService _authService;
    
    [ObservableProperty]
    private string _username = string.Empty;
    
    [ObservableProperty]
    private string _password = string.Empty;
    
    [ObservableProperty]
    private bool _isLoggingIn;
    
    [ObservableProperty]
    private string _errorMessage = string.Empty;
    
    [ObservableProperty]
    private UserInfo? _currentUser;
    
    [ObservableProperty]
    private bool _isLoggedIn;
    
    /// <summary>
    /// 登录成功事件
    /// </summary>
    public event EventHandler? LoginSucceeded;
    
    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
        
        // 检查是否已登录
        IsLoggedIn = _authService.IsLoggedIn;
        CurrentUser = _authService.CurrentUser;
    }
    
    /// <summary>
    /// 登录命令
    /// </summary>
    [RelayCommand]
    private async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "用户名和密码不能为空";
            return;
        }
        
        try
        {
            IsLoggingIn = true;
            ErrorMessage = string.Empty;
            
            var result = await _authService.LoginAsync(Username, Password);
            
            if (result)
            {
                // 登录成功
                IsLoggedIn = true;
                CurrentUser = _authService.CurrentUser;
                
                // 触发登录成功事件
                LoginSucceeded?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                // 登录失败
                ErrorMessage = "登录失败，请检查用户名和密码";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"登录出错: {ex.Message}";
        }
        finally
        {
            IsLoggingIn = false;
        }
    }
    
    /// <summary>
    /// 退出登录命令
    /// </summary>
    [RelayCommand]
    private async Task LogoutAsync()
    {
        try
        {
            var result = await _authService.LogoutAsync();
            
            if (result)
            {
                // 退出登录成功
                IsLoggedIn = false;
                CurrentUser = null;
                
                // 清除用户名和密码
                Username = string.Empty;
                Password = string.Empty;
            }
            else
            {
                ErrorMessage = "退出登录失败";
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"退出登录出错: {ex.Message}";
        }
    }
} 