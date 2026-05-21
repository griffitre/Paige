using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Paige.converters
{
    // Definition of SelectedValueToColorConverter
    public class SelectedValueToColorConverter : IValueConverter
    {
        // Convert method
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If a button's value matches the selected value, return the highlight color
            return value?.ToString() == parameter.ToString() ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.White);
        }

        // Other method required by interface (unused)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
