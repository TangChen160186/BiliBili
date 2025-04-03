using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BiliBili_wpf.Converters;

public class DoubleRatioToGridLengthConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            if (values.Length == 2 && 
                values[0] is double value && 
                values[1] is double total && 
                total > 0)
            {
                return new GridLength(value / total, GridUnitType.Star);
            }
        }
        catch (InvalidOperationException)
        {
            
        }
        return new GridLength(0, GridUnitType.Star);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}