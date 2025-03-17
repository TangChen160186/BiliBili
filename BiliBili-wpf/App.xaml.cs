using System.Windows;
using BiliBili_ViewModel.Services;
using BiliBili_wpf.Services;
using BiliBili_wpf.ViewModels;
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

        // 初始化
        var themeService = Services.GetRequiredService<IThemeService>();
        themeService.InitializeTheme();
    }
    
    private void ConfigureServices(IServiceCollection services)
    {
        // 注册哔哩哔哩API服务
        services.AddBiliBiliServices();
        services.AddSingleton<IThemeService,ThemeService>();

        // ViewModels
        services.AddTransient<MainViewModel>();
    }
}

