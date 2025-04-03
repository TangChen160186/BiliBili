using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BiliBili_wpf.ViewModels;

public partial class MainNavigationItem : ObservableObject
{
    [ObservableProperty] private string _name;

    [ObservableProperty] private string _icon;
    public ObservableCollection<string>? SubNavigationItems { get; set; }

    [ObservableProperty] private string _currentSubNavigationItem;
}

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<MainNavigationItem> MainNavigationItems { get; set; } =
    [
        new()
        {
            Name = "首页", SubNavigationItems = ["直播", "推荐", "热门", "追番", "影视"], Icon = "\ue600"
        },
        new()
        {
            Name = "精选", SubNavigationItems = null, Icon = "\ue73b"
        },
        new()
        {
            Name = "动态", SubNavigationItems = ["综合"], Icon = "\ue621"
        },
        new()
        {
            Name = "我的", SubNavigationItems = null, Icon = "\ue723"
        }
    ];

    [ObservableProperty] public MainNavigationItem _currentMainNavigationItem;


    [RelayCommand]
    void Test()
    {
        Console.WriteLine("faf");
    }
}