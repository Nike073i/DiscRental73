using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73TestWpf.Infrastructure.ValidateRules
{
    public class StringLengthValidationRule : ValidationRule
    {
        #region MaxLength - int - максимальная длина строки

        private int _MaxLength = 255;

        public int MaxLength
        {
            get => _MaxLength;
            set
            {
                if (value < _MinLength || value < 1) return;
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
                if (value > _MaxLength || value < 1) return;
                _MinLength = value;
            }
        }

        #endregion

        public bool IsNullable { get; set; } = false;

        public string NullableInfo { get; set; } = "Строка обязательна к заполнению";

        private string LengthInfo => "Длина строки должна быть от {0} до {1} символов";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                if (!IsNullable)
                {
                    return new ValidationResult(false, NullableInfo);
                }
            }
            else
            {
                if (str.Length > MaxLength || str.Length < MinLength)
                {
                    return new ValidationResult(false, string.Format(LengthInfo, MinLength, MaxLength));
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
