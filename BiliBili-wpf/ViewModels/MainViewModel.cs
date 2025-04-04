using System.Collections.ObjectModel;
using System.ComponentModel;
using BiliBili_wpf.ViewModels.Advance;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BiliBili_wpf.ViewModels;

partial class BigHitViewModel: ObservableObject
{
 
}

partial class SubNavigationItem: ObservableObject
{
    [ObservableProperty] private string _name;
    public Type TargetPage { get; set; }
}

partial class MainNavigationItem : NavigationViewModel
{
    [ObservableProperty] private string _name;

    [ObservableProperty] private string _icon;
    public ObservableCollection<SubNavigationItem> SubNavigationItems { get; set; }

    [ObservableProperty] private SubNavigationItem _currentSubNavigationItem;

    public MainNavigationItem(string name, string icon,IEnumerable<SubNavigationItem> subNavigationItems)
    {
        _name = name;
        _icon = icon;
        SubNavigationItems = new ObservableCollection<SubNavigationItem>(subNavigationItems);
        CurrentSubNavigationItem = SubNavigationItems.FirstOrDefault();
    }


    partial void OnCurrentSubNavigationItemChanged(SubNavigationItem value)
    {
        Open(App.Services.GetService(value.TargetPage));
    }

    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName == nameof(Current))
        {
            if(CurrentSubNavigationItem.GetType() != Current.GetType())
                CurrentSubNavigationItem = SubNavigationItems.FirstOrDefault(e => e.TargetPage == Current.GetType());
        }
    }
}

partial class MainViewModel : ObservableObject
{
    public ObservableCollection<MainNavigationItem> MainNavigationItems { get; set; } =
    [
        new("首页","\ue600",[
            new SubNavigationItem {Name = "推荐",TargetPage = typeof(RecommendViewModel) },
            new SubNavigationItem {Name = "热门",TargetPage = typeof(BigHitViewModel) },
        ]),
        new("精选", "\ue73b",[]),
        new( "动态", "\ue621",[]),
        new(  "我的", "\ue723",[]),
    ];
    [ObservableProperty] private MainNavigationItem _currentMainNavigationItem;

    public MainViewModel()
    {
        CurrentMainNavigationItem = MainNavigationItems.FirstOrDefault();
    }
}