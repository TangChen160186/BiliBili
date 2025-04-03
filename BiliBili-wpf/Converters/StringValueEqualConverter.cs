using System.Globalization;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;

class StringValueEqualConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null && parameter != null)
        {
            return value.ToString() == parameter.ToString();
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isChecked = (bool)value;
        if (!isChecked)
        {
            return null;
        }
        return parameter;
    }
}