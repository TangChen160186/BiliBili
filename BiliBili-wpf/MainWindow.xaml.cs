using System.Windows;
using System.Windows.Input;
using BiliBili_wpf.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BiliBili_wpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // 设置DataContext
        // DataContext = App.Services.GetRequiredService<MainViewModel>();

        CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand,
            (sender, e) => SystemCommands.MinimizeWindow(this)));
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var themeService = App.Services.GetRequiredService<IThemeService>();
        themeService.CurrentTheme = themeService.CurrentTheme==ThemeType.Dark ? ThemeType.Light : ThemeType.Dark;
    }
    
    private void MaximizeButton_Click(object sender, RoutedEventArgs e)
    {
        // 切换最大化/还原状态
        this.WindowState = (this.WindowState == WindowState.Maximized) 
            ? WindowState.Normal 
            : WindowState.Maximized;
    }
    
    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        // 关闭窗口
        this.Close();
    }
}