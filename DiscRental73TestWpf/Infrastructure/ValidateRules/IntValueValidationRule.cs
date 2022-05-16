using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73TestWpf.Infrastructure.ValidateRules
{
    public class IntValueValidationRule : ValidationRule
    {
        #region MaxValue - int - максимальное число

        private int _MaxValue = 10000;

        public int MaxValue
        {
            get => _MaxValue;
            set
            {
                if (value < _MinValue) return;
                _MaxValue = value;
            }
        }

        #endregion

        #region MinValue - int - минимальное число

        private int _MinValue = 1;

        public int MinValue
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
            var str = value as string;
            if (str is null)
            {
                if (!IsNullable)
                {
                    return new ValidationResult(false, NullableInfo);
                }
            }
            else
            {
                var result = int.TryParse(str, out int val);
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