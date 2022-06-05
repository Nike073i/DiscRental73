using System;
using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73TestWpf.Infrastructure.ValidateRules
{
    public class DateValueValidationRule : ValidationRule
    {
        #region MaxDate - DateTime - максимальная дата

        private DateTime _MaxDate = new DateTime(2100, 1, 1);

        public DateTime MaxDate
        {
            get => _MaxDate;
            set
            {
                if (value < _MinDate) return;
                _MaxDate = value;
            }
        }

        #endregion

        #region MinDate - DateTime - минимальная дата

        private DateTime _MinDate = new DateTime(1900, 1, 1);

        public DateTime MinDate
        {
            get => _MinDate;
            set
            {
                if (value > _MaxDate) return;
                _MinDate = value;
            }
        }

        #endregion

        private string ValueInfo => "Дата должна быть в диапазоне от {0:dd/MM/yyyy} до {1:dd/MM/yyyy}";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var date = (DateTime)value;
            if (date > MaxDate || date < MinDate)
            {
                return new ValidationResult(false, string.Format(ValueInfo, MinDate, MaxDate));
            }
            return ValidationResult.ValidResult;
        }
    }
}
