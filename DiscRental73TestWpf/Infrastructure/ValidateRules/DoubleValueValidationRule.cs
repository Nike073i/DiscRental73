using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73TestWpf.Infrastructure.ValidateRules
{
    public class DoubleValueValidationRule : ValidationRule
    {
        #region MaxValue - double - максимальное число

        private double _MaxValue = 100000d;

        public double MaxValue
        {
            get => _MaxValue;
            set
            {
                if (value < _MinValue) return;
                _MaxValue = value;
            }
        }

        #endregion

        #region MinValue - double - минимальное число

        private double _MinValue = 0d;

        public double MinValue
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
                var result = double.TryParse(str, out double val);
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