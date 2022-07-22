using DiscRental73.Wpf.Infrastructure.ValidateRules.Base;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73.Wpf.Infrastructure.ValidateRules
{
    public class IntRangeValidationRule : RangeValueValidationRule<int>
    {
        protected override ValidationResult? DoValidation(object value, CultureInfo cultureInfo)
        {
            var inputString = value as string;
            if (string.IsNullOrWhiteSpace(inputString)) return IsNullable ? null : new ValidationResult(false, NonNullInfo);
            if (!int.TryParse(inputString, out var intValue)) return new ValidationResult(false, BadValueInfo);
            if (intValue > MaxValue || intValue < MinValue)
                return new ValidationResult(false, string.Format(CorrectValueFormat, MinValue, MaxValue));
            return null;
        }
    }
}