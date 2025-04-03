using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace BiliBili_wpf.Converters;

class StringToImageSourceConverter : IValueConverter
{
    /// <summary>
    /// 将字符串路径或 URI 转换为 ImageSource。
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string path)
        {
            try
            {
                if (File.Exists(path)) // 如果是本地文件路径
                {
                    return new BitmapImage(new Uri(path, UriKind.Absolute));
                }

                if (Uri.TryCreate(path, UriKind.Absolute, out var uri)) // 如果是 URI
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = uri;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;  // 图片立即加载
                    bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;  // 忽略缓存
                    bitmap.EndInit();
                    return bitmap;
                }
            }
            catch
            {
                // 忽略异常，返回 null
            }
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}