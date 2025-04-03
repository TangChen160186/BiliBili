using System.Globalization;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;
/// <summary>
/// 检查所有绑定值是否都为 true。
/// </summary>
internal class AllAreTrueValueConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values.All(x => x is true);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}