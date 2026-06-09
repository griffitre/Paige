using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace Paige.converters
{
    // Converter to check which values are in a given list and return the appropraite colour based on the result
    public class ListContainsConverter : IValueConverter
    {
        // Returns appropriate selected colour for items based on whether or not it is in a given list
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // If list of ints and is parsable, output index, and check if the given list contains the given value. Return appropriate selected color
            if (value is List<int> list && int.TryParse(parameter?.ToString(), out int num))
            {
                return list.Contains(num) ? new SolidColorBrush(Colors.LightGray) : new SolidColorBrush(Colors.White);
            }

            // Otherwise, just return the unselected colour
            return new SolidColorBrush(Colors.White);
        }

        // Other item of the interface (unneeded)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
