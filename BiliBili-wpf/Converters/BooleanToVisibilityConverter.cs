using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;

public class BooleanToVisibilityConverter : IValueConverter
{
    public bool IsInverted { get; set; }

    public bool UseCollapsed { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not bool boolValue)
        {
            return Visibility.Visible;
        }

        if (IsInverted)
        {
            boolValue = !boolValue;
        }

        return boolValue
            ? Visibility.Visible
            : (UseCollapsed ? Visibility.Collapsed : Visibility.Hidden);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException("ConvertBack is not supported.");
    }
}