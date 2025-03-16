using BiliBili_Model.Api;
using Microsoft.Extensions.DependencyInjection;

namespace BiliBili_ViewModel.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBiliBiliServices(this IServiceCollection services)
    {
        // 注册HttpClient服务
        services.AddHttpClient<IHttpClientService, HttpClientService>();
        
        // 注册API客户端
        services.AddSingleton<IBiliBiliApiClient, BiliBiliApiClient>();
        
        return services;
    }
} 