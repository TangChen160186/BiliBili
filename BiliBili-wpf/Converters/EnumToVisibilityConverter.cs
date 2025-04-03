using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;
/// <summary>
/// 根据枚举值控制 UI 元素的可见性
/// </summary>
internal class EnumToVisibilityConverter : IValueConverter
{
    public bool IsReverse { get; set; }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value?.ToString() == parameter?.ToString())
        {
            return IsReverse ? Visibility.Collapsed : Visibility.Visible;
        }

        return IsReverse ? Visibility.Visible : Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}