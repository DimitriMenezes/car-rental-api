using FluentValidation;

namespace Car.Rental.Services.FluentValidator
{
    public static class CustomValidator
    {
        public static IRuleBuilderOptions<T, string> IsCpf<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfValidator());
        }
       
        public static IRuleBuilderOptions<T, string> IsZipCode<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new ZipCodeValidator());
        }
    }
}
