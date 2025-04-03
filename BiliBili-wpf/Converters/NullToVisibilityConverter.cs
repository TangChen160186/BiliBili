using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;

public class NullToVisibilityConverter : IValueConverter
{
    public bool UseCollapsed { get; set; }
    public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null ? UseCollapsed?Visibility.Collapsed : Visibility.Hidden: Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}