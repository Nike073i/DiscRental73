using DiscRental73.Wpf.Infrastructure.ValidateRules.Base;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73.Wpf.Infrastructure.ValidateRules
{
    public class DateValueValidationRule : RangeValueValidationRule<DateTime>
    {
        public DateValueValidationRule()
        {
            MaxValue = new DateTime(2100, 1, 1);
            MinValue = new DateTime(1900, 1, 1);
        }

        public override string CorrectValueFormat => "Дата должна быть в диапазоне [{0:dd/MM/yyyy};{1:dd/MM/yyyy}]";

        protected override ValidationResult? DoValidation(object value, CultureInfo cultureInfo)
        {
            if (value is not DateTime date) return new ValidationResult(false, BadValueInfo);
            if (date > MaxValue || date < MinValue)
                return new ValidationResult(false, string.Format(CorrectValueFormat, MinValue, MaxValue));
            return null;
        }
    }
}
