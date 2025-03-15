using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BiliBili_wpf_ui.Converters;

/// <summary>
/// 布尔值到可见性转换器
/// </summary>
public class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isInverse = parameter != null && parameter.ToString() == "Inverse";
        bool boolValue = value is bool b && b;
        
        if (isInverse)
        {
            return boolValue ? Visibility.Collapsed : Visibility.Visible;
        }
        
        return boolValue ? Visibility.Visible : Visibility.Collapsed;
    }
    
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isInverse = parameter != null && parameter.ToString() == "Inverse";
        bool isVisible = value is Visibility v && v == Visibility.Visible;
        
        if (isInverse)
        {
            return !isVisible;
        }
        
        return isVisible;
    }
}

/// <summary>
/// 布尔值取反转换器
/// </summary>
public class BooleanInverseConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool b)
        {
            return !b;
        }
        
        return value;
    }
    
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool b)
        {
            return !b;
        }
        
        return value;
    }
}

/// <summary>
/// 字符串到可见性转换器
/// </summary>
public class StringToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool isInverse = parameter != null && parameter.ToString() == "Inverse";
        bool hasValue = value is string s && !string.IsNullOrEmpty(s);
        
        if (isInverse)
        {
            return hasValue ? Visibility.Collapsed : Visibility.Visible;
        }
        
        return hasValue ? Visibility.Visible : Visibility.Collapsed;
    }
    
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
} 