using System.Globalization;
using System.Windows.Data;

namespace Paige.converters
{
    // Converter to dynamically change font size based on window size
    public class FontSizeConverter : IValueConverter
    {
        // Returns the calculated font size for text on screen
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the width of the window
            double windowWidth = (double)value;

            // Get the ratio passed
            double ratio = double.Parse(parameter.ToString());

            // Return the value, or the given max value
            return Math.Max(10, windowWidth * ratio);
        }

        // Other item of the interface (unneeded)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
