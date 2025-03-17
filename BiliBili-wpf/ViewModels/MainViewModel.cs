using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BiliBili_wpf.ViewModels;

public partial class MainNavigationItem: ObservableObject
{
    [ObservableProperty]
    public string _name;
    public ObservableCollection<string>? SubNavigationItems { get; set; }

}
public class MainViewModel: ObservableObject
{
    public ObservableCollection<MainNavigationItem> MainNavigationItems { get; set; } =
    [
        new() { _name = "首页", SubNavigationItems = ["直播", "推荐", "热门", "追番", "影视"] },
        new() { _name = "精选", SubNavigationItems = null },
        new() { _name = "动态", SubNavigationItems = ["综合"] },
        new() { _name = "我的", SubNavigationItems = null }
    ];

}