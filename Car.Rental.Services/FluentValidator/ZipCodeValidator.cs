using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car.Rental.Services.FluentValidator
{
    public class ZipCodeValidator : PropertyValidator
    {
        public ZipCodeValidator() : base("Invalid Zip Code")
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var zipCode = context.PropertyValue as string;
            return IsZipCodeValid(zipCode);
        }

        private bool IsZipCodeValid(string zipCode)
        {
            if (!zipCode.All(char.IsDigit))
                return false;

            return zipCode.Length == 8;
        }
    }
}
