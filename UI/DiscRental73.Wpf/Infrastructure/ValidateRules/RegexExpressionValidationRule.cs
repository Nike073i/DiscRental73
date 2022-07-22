using DiscRental73.Wpf.Infrastructure.ValidateRules.Base;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace DiscRental73.Wpf.Infrastructure.ValidateRules
{
    public class RegexExpressionValidationRule : ValidationRuleBase
    {
        public string RegexExpression { get; set; } = "^.*$";
        public string CorrectValue { get; set; } = "любой текст";
        public override string NonNullInfo { get; set; } = "Строка обязательна к заполнению";
        public override string CorrectValueFormat { get; set; } = "Строка должна сооответствовать примеру: {0}";

        protected override ValidationResult? DoValidation(object value, CultureInfo cultureInfo)
        {
            var inputString = value as string;
            if (string.IsNullOrWhiteSpace(inputString)) return IsNullable ? null : new ValidationResult(false, NonNullInfo);
            return !Regex.IsMatch(inputString!, RegexExpression, RegexOptions.IgnoreCase)
                ? new ValidationResult(false, string.Format(CorrectValueFormat, CorrectValue))
                : null;
        }
    }
}
