using System.Globalization;
using System.Windows.Data;

namespace Paige.converters
{
    // Converter to dynamically change font size based on window size
    public class FontSizeConverter : IMultiValueConverter
    {
        // Returns the calculated largest font size for text on screen using the window width/height and a given ratio. Acts as the base class for the next converters
        public virtual object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the width of the window
            double windowWidth = (double)values[0];

            // Get the height of the window
            double windowHeight = (double)values[1];

            // Get the ratio passed
            double ratio = double.Parse(parameter.ToString());

            // Return the the smaller value between the width * ratio or height * ratio
            return Math.Max(windowWidth * ratio, windowHeight * ratio);
        }

        // Other item of the interface (unneeded)
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // Converter for header text 1
    public class HeaderText1Converter : FontSizeConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the returned value from FontSizeConverter
            double returnedSize = (double)base.Convert(values, targetType, parameter, culture);

            // Return either 20 or the returned size
            return Math.Max(20, returnedSize);
        }
    }

    // Converter for header text 2
    public class HeaderText2Converter : FontSizeConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the returned value from FontSizeConverter
            double returnedSize = (double)base.Convert(values, targetType, parameter, culture);

            // Return either 16 or the returned size
            return Math.Max(16, returnedSize);
        }
    }

    // Converter for normal text
    public class NormalTextConverter : FontSizeConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the returned value from FontSizeConverter
            double returnedSize = (double)base.Convert(values, targetType, parameter, culture);

            // Return either 13 or the returned size
            return Math.Max(13, returnedSize);
        }
    }

    // Converter for subtext
    public class SubtextConverter : FontSizeConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the returned value from FontSizeConverter
            double returnedSize = (double)base.Convert(values, targetType, parameter, culture);

            // Return either 8 or the returned size
            return Math.Max(8, returnedSize);
        }
    }
}
