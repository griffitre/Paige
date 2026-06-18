using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Paige.converters
{
    // Converter to dynamically return dimensions based on window size
    public class DimensionSizeConverter : IMultiValueConverter
    {
        // Returns either a minimum size or a calculated size OR a max size, depending on whether or not the calculated size is larger than the minimum
        // Primarily used to determine row/column sizes in a grid
        public virtual object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the passed value
            double givenValue = (double)values[0];

            // Get the ratio
            double ratio = double.Parse(parameter.ToString());

            // Get the minimum size
            double minimumValue = (double)values[1];

            // Get the maximum size
            double maximumValue = (double)values[2];

            // Define calculatedValue and assign it the value of either the givenValue * ratio or the max value, depending on which is smaller
            double calculatedValue = Math.Min(maximumValue, givenValue * ratio);

            // Return either the minimum value or the calculated value, whichever is larger
            return Math.Max(minimumValue, calculatedValue);
        }

        // Other item of the interface (unneeded)
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Converter to convert the returned double to a gridlength
    public class GridLengthSizeConverter : DimensionSizeConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double finalLength = (double)base.Convert(values, targetType, parameter, culture);

            return new GridLength(finalLength);
        }
    }
}
