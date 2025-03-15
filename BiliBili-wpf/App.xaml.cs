using System.Configuration;
using System.Data;
using System.Windows;
using BiliBili_ViewModel.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BiliBili_wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // 配置服务
        var services = new ServiceCollection();
        ConfigureServices(services);
        Services = services.BuildServiceProvider();
    }
    
    private void ConfigureServices(IServiceCollection services)
    {
        // 注册哔哩哔哩API服务
        services.AddBiliBiliServices();
        
        // 注册视图模型
        // services.AddTransient<MainViewModel>();
        
        // 注册视图
        // services.AddTransient<MainWindow>();
    }
}

