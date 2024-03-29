﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace DiscRental73TestWpf.Infrastructure.Converters
{
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!double.TryParse(value.ToString(), out double d))
                return Binding.DoNothing;
            return d;
        }
    }
}
