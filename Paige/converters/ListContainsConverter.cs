using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Paige.converters
{
    // Definition for ListContainsConverter
    public class ListContainsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If list of ints and is parsable, output index, and check if the given list contains the given value. Return appropriate highlight color
            if (value is List<int> list && int.TryParse(parameter?.ToString(), out int num))
            {
                return list.Contains(num) ? new SolidColorBrush(Colors.LightGray) : new SolidColorBrush(Colors.White);
            }

            // Otherwise, just return the unselected color
            return new SolidColorBrush(Colors.White);
        }

        // Other method required by interface (unused)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}