using BiliBili_Model.Api;
using Microsoft.Extensions.DependencyInjection;

namespace BiliBili_ViewModel.Services;

/// <summary>
/// 服务集合扩展
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// 注册哔哩哔哩API服务
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddBiliBiliServices(this IServiceCollection services)
    {
        // 注册HttpClient服务
        services.AddHttpClient<IHttpClientService, HttpClientService>();
        
        // 注册API客户端
        services.AddSingleton<IBiliBiliApiClient, BiliBiliApiClient>();
        
        // 注册认证服务
        services.AddSingleton<IAuthService, AuthService>();
        
        return services;
    }
} 