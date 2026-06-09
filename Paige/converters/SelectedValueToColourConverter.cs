using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Paige.converters
{
    // Converter to return the selected colour if a button's value matches the selected value stored
    public class SelectedValueToColourConverter : IValueConverter
    {
        // Return the selected colour if a button's value matches the selected value, unselected colour if not
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() == parameter.ToString() ? new SolidColorBrush(Colors.LightGray) : new SolidColorBrush(Colors.White);
        }

        // Other item of the interface (unneeded)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
