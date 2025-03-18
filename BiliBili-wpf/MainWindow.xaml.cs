using System.Windows;
using System.Windows.Input;
using BiliBili_wpf.Services;
using BiliBili_wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace BiliBili_wpf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = App.Services.GetRequiredService<MainViewModel>();
        // 设置DataContext
        // DataContext = App.Services.GetRequiredService<MainViewModel>();
        CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand,
            (sender, e) => SystemCommands.MinimizeWindow(this)));
        CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand,
            (sender, e) => SystemCommands.CloseWindow(this)));
        CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand,
            (sender, e) => SystemCommands.MaximizeWindow(this)));
        CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand,
            (sender, e) => SystemCommands.RestoreWindow(this)));
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var themeService = App.Services.GetRequiredService<IThemeService>();
        themeService.CurrentTheme = themeService.CurrentTheme == ThemeType.Dark ? ThemeType.Light : ThemeType.Dark;
    }
}