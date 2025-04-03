using System.Globalization;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;
/// <summary>
/// 检查绑定值中至少 N 个为 true。
/// </summary>
internal class AtLeastNTrueValueConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        int minTrueCount = parameter != null ? System.Convert.ToInt32(parameter) : values.Length;

        return values.Count(x => x is true) >= minTrueCount;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}