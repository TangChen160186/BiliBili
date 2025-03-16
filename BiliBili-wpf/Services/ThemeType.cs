using System.Windows;
using Application = System.Windows.Application;

namespace BiliBili_wpf.Services;

public enum ThemeType : byte
{
    Light,
    Dark
}

public interface IThemeService
{
    void InitializeTheme();
    ThemeType CurrentTheme { get; set; }
}


public class ThemeService : IThemeService
{
    private ThemeType _currentThemeType;

    public ThemeType CurrentTheme
    {
        get=>_currentThemeType;
        set
        {
            if (_currentThemeType == value) return;
            _currentThemeType = value;
            ApplyTheme(value);
            Properties.Settings.Default.Theme = value.ToString();
            Properties.Settings.Default.Save();
        }
    }

    private readonly Dictionary<ThemeType, ResourceDictionary> _themeCache = new Dictionary<ThemeType, ResourceDictionary>();
    private bool _firstLoad = true;
    public void InitializeTheme()
    {
        if(!_firstLoad) return;
        // 从设置中加载主题
        var themeSetting = Properties.Settings.Default.Theme??"Dark";

        var theme = Enum.TryParse<ThemeType>(themeSetting, out var themeType) &&
                    Enum.IsDefined(typeof(ThemeType), themeType)
            ? themeType
            : ThemeType.Dark;
        ApplyTheme(theme);
        _firstLoad = false;
    }


    private void ApplyTheme(ThemeType theme)
    {
        var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

        var existingTheme = mergedDictionaries.FirstOrDefault(d =>
            d.Source?.OriginalString.EndsWith("/Theme.xaml") == true &&
            d.Source?.OriginalString.Contains("/Themes/") == true);
        if (existingTheme != null)
            mergedDictionaries.Remove(existingTheme);

        if (_themeCache.TryGetValue(theme, out var themeResourceDictionary))
        {
            mergedDictionaries.Add(themeResourceDictionary);
        }
        else
        {
            var themePath = $"/Themes/{theme}/Theme.xaml";
            var newTheme = new ResourceDictionary
            {
                Source = new Uri(themePath, UriKind.Relative)
            };
            mergedDictionaries.Add(newTheme);
            _themeCache.TryAdd(theme, newTheme);
        }
    }

}
