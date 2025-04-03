using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BiliBili_wpf.Converters;

//internal class StringToQrCodeImageConverter : IValueConverter
//{
//    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
//    {
//        ImageSource? result = null;
//        try
//        {
//            if (value is string qrcode)
//                result =  QrCodeUtil.GenerateQrCode(qrcode);
//        }
//        catch
//        {
//            result = null;
//        }
//        return result;
//    }

//    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
//    {
//        throw new NotImplementedException();
//    }
//}