using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace DiscRental73TestWpf.Infrastructure.ValidateRules
{
    public class RegexExpressionValidationRule : ValidationRule
    {
        #region RegexFormat - string - строка формата

        private string _RegexFormat;

        public string RegexFormat
        {
            get => _RegexFormat;
            set => _RegexFormat = value;
        }

        #endregion

        #region RegexExample - string - строка примера

        private string _RegexExample;

        public string RegexExample
        {
            get => _RegexExample;
            set => _RegexExample = value;
        }

        #endregion

        public bool IsNullable { get; set; } = false;

        public string NullableInfo { get; set; } = "Строка обязательна к заполнению";

        private string RegexInfo => "Строка должна сооответствовать примеру: {0}";


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
            else if (!string.IsNullOrEmpty(RegexFormat) && !Regex.IsMatch(str, RegexFormat, RegexOptions.IgnoreCase))
            {
                return new ValidationResult(false, string.Format(RegexInfo, RegexExample));
            }

            return ValidationResult.ValidResult;
        }
    }
}
