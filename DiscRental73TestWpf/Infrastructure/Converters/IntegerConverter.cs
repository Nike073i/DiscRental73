using System;
using System.Globalization;
using System.Windows.Data;

namespace DiscRental73TestWpf.Infrastructure.Converters
{
    public class IntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!int.TryParse(value.ToString(), out int d))
                return Binding.DoNothing;
            return d;
        }
    }
}
