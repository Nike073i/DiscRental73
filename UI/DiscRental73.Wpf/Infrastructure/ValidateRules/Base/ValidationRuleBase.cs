using System.Globalization;
using System.Windows.Controls;

namespace DiscRental73.Wpf.Infrastructure.ValidateRules.Base
{
    public abstract class ValidationRuleBase : ValidationRule
    {
        ///<summary>Доступно ли null-значение. По умолчанию = false</summary>
        public bool IsNullable { get; set; } = false;

        ///<summary>Текст ошибки при незаполненном поле и включенном флаге IsNullable</summary>
        public virtual string NonNullInfo { get; set; } = "Значение обязательно к заполнению";

        ///<summary>Текст ошибки при неккореткном вводе данных</summary>
        public virtual string BadValueInfo { get; set; } = "Некорректный ввод";

        ///<summary>Строка форматирования подсказки корректного значения</summary>
        public virtual string CorrectValueFormat { get; set; } = string.Empty;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) =>
            DoValidation(value, cultureInfo) ?? ValidationResult.ValidResult;

        protected abstract ValidationResult? DoValidation(object value, CultureInfo cultureInfo);
    }
}
