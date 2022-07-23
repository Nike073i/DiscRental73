using DiscRental73.Wpf.Infrastructure.ValidateRules.Base;
using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73.Wpf.Infrastructure.ValidateRules
{
    public class StringLengthValidationRule : ValidationRuleBase
    {
        #region MaxLength - int - максимальная длина строки

        private int _MaxLength = 255;

        public int MaxLength
        {
            get => _MaxLength;
            set
            {
                if (value < _MinLength || value < 0) return;
                _MaxLength = value;
            }
        }

        #endregion

        #region MinLength - int - минимальная длина строки

        private int _MinLength = 1;

        public int MinLength
        {
            get => _MinLength;
            set
            {
                if (value > _MaxLength || value < 0) return;
                _MinLength = value;
            }
        }

        #endregion

        public override string NonNullInfo { get; set; } = "Строка обязательна к заполнению";
        public override string BadValueInfo { get; set; } = "Введена неккоректная строка";
        public override string CorrectValueFormat { get; set; } = "Длина строки должна быть [{0};{1}] символов";

        protected override ValidationResult? DoValidation(object value, CultureInfo cultureInfo)
        {
            var inputString = value as string;
            if (string.IsNullOrWhiteSpace(inputString)) return IsNullable ? null : new ValidationResult(false, NonNullInfo);
            if (inputString?.Length > MaxLength || inputString?.Length < MinLength)
                return new ValidationResult(false, string.Format(CorrectValueFormat, MinLength, MaxLength));
            return null;
        }
    }
}
