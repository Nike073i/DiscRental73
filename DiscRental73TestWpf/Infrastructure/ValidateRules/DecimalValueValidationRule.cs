using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73TestWpf.Infrastructure.ValidateRules
{
    public class DecimalValueValidationRule : ValidationRule
    {
        #region MaxValue - decimal - максимальное число

        private decimal _MaxValue = 100000M;

        public decimal MaxValue
        {
            get => _MaxValue;
            set
            {
                if (value < _MinValue) return;
                _MaxValue = value;
            }
        }

        #endregion

        #region MinValue - decimal - минимальное число

        private decimal _MinValue;

        public decimal MinValue
        {
            get => _MinValue;
            set
            {
                if (value > _MaxValue || value < 1) return;
                _MinValue = value;
            }
        }

        #endregion

        public bool IsNullable { get; set; } = false;

        public string NullableInfo { get; set; } = "Число обязательно к заполнению";

        public string BadValueInfo { get; set; } = "Некорректный ввод";

        private string ValueInfo => "Значение числа должно быть от {0} до {1}";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string str)
            {
                if (!IsNullable)
                {
                    return new ValidationResult(false, NullableInfo);
                }
            }
            else
            {
                var result = decimal.TryParse(str, out decimal val);
                if (!result) return new ValidationResult(false, BadValueInfo);
                if (val > MaxValue || val < MinValue)
                {
                    return new ValidationResult(false, string.Format(ValueInfo, MinValue, MaxValue));
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}