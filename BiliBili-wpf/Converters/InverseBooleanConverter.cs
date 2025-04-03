using System.Windows.Data;

namespace BiliBili_wpf.Converters;

[ValueConversion(typeof(bool), typeof(bool))]
class InverseBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
        if (targetType != typeof(bool) && targetType != typeof(bool?))
            throw new InvalidOperationException("The target must be a boolean");

        if (targetType == typeof(bool))
            return !(bool)value;
        return (bool?)value;
    }

    public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
    {
        return Convert(value, targetType, parameter, culture);
    }
}