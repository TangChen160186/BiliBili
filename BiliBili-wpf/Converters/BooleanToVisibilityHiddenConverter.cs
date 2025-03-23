using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;

public class BooleanToVisibilityHiddenConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? Visibility.Visible : Visibility.Hidden;
        }
        return Visibility.Hidden; // 默认返回 Hidden
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Visibility visibilityValue)
        {
            return visibilityValue == Visibility.Visible;
        }
        return false;
    }
}
