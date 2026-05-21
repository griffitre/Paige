using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Paige.converters
{
    // Definition of SelectedValueToColourConverter
    public class SelectedValueToColourConverter : IValueConverter
    {
        // Convert method
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If a button's value matches the selected value, return the highlight colour
            return value?.ToString() == parameter.ToString() ? new SolidColorBrush(Colors.LightGray) : new SolidColorBrush(Colors.White);
        }

        // Other method required by interface (unused)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
