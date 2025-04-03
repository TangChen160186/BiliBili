using System.Collections.Specialized;
using System.Globalization;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;

internal class StringDictionaryConverter : IValueConverter
{
    public ListDictionary Mappings { get; set; }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var key = System.Convert.ToString(value);
        var result = Mappings[key];
        if (parameter != null)
        {
            result = string.Format(result.ToString(), parameter);
        }
        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}