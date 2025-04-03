using System.Globalization;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;

class StringLengthToBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string result = value as string;
        return result?.Length > 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}