using System.Globalization;
using System.Windows.Data;

namespace Paige.converters
{
    // Converter to dynamically return dimensions based on window size
    public class DimensionSizeConverter : IMultiValueConverter
    {
        // Returns either a minimum size or a calculated size, depending on whether or not the calculated size is larger than the minimum
        // Primarily used to determine row/column sizes in a grid
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the passed value
            double givenValue = (double)values[0];

            // Get the ratio
            double ratio = double.Parse(parameter.ToString());

            // Get the minimum size
            double minimumValue = (double)values[1];

            // Return either the minimum value or the calculated value, whichever is larger
            return Math.Max(minimumValue, givenValue * ratio);
        }

        // Other item of the interface (unneeded)
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
