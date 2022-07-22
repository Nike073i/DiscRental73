namespace DiscRental73.Wpf.Infrastructure.ValidateRules.Base
{
    public abstract class RangeValueValidationRule<T> : ValidationRuleBase
        where T : struct
    {
        ///<summary>Максимальное число в диапазоне (Включая данное число)</summary>
        public T MaxValue { get; set; } = default;

        ///<summary>Минимальное число в диапазоне (Включая данное число)</summary>
        public T MinValue { get; set; } = default;

        public override string CorrectValueFormat { get; set; } = "Значение числа должно быть [{0};{1}]";
    }
}
