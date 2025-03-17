using System.Windows;
using System.Windows.Controls;
using BiliBili_wpf.ViewModels;

namespace BiliBili_wpf.DataTemplateSelectors;

class MainNavigationItemSelector: DataTemplateSelector
{
    public DataTemplate HomeDataTemplate { get; set; }
    public DataTemplate HighlightDataTemplate { get; set; }
    public DataTemplate DynamicDataTemplate { get; set; }
    public DataTemplate MineDataTemplate { get; set; }
    public override DataTemplate? SelectTemplate(object? item, DependencyObject container)
    {
       
        switch (item)
        {
            case "首页":
                return HomeDataTemplate;
            case "精选":
                return HighlightDataTemplate;
            case "动态":
                return DynamicDataTemplate;
            case "我的":
                return MineDataTemplate;
        }
        return base.SelectTemplate(item, container);
    }
}