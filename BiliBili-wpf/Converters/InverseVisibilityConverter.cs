using System.Windows;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;

[ValueConversion(typeof(Visibility), typeof(Visibility))]
class InverseVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
        if (targetType != typeof(Visibility))
            throw new InvalidOperationException("The target must be Visibility");

        return (Visibility)value == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
        return Convert(value, targetType, parameter, culture);
    }
}