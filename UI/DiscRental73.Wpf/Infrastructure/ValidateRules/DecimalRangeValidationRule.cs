using DiscRental73.Wpf.Infrastructure.ValidateRules.Base;
using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73.Wpf.Infrastructure.ValidateRules
{
    public class DecimalRangeValidationRule : RangeValueValidationRule<decimal>
    {
        protected override ValidationResult? DoValidation(object value, CultureInfo cultureInfo)
        {
            var inputString = value as string;
            if (string.IsNullOrWhiteSpace(inputString)) return IsNullable ? null : new ValidationResult(false, NonNullInfo);
            if (!decimal.TryParse(inputString, out var decimalValue)) return new ValidationResult(false, BadValueInfo);
            if (decimalValue > MaxValue || decimalValue < MinValue)
                return new ValidationResult(false, string.Format(CorrectValueFormat, MinValue, MaxValue));
            return null;
        }
    }
}