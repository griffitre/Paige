using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Paige.converters
{
    // Converter to determine whether or not a button/image should be visible at a given moment
    public class NullToVisibilityConverter : IValueConverter
    {
        // Return visible if value is null, collapsed if not
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value?.ToString()) ? Visibility.Visible : Visibility.Collapsed;
        }

        // Other item of the interface (unneeded)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    // Definition of NotNullToVisibilityConverter
    public class NotNullToVisibilityConverter : IValueConverter
    {
        // Return visible if value is not null, collapsed if null
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? Visibility.Visible : Visibility.Collapsed;
        }

        // Other item of the interface (also unneeded)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
