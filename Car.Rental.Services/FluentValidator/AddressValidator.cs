using Car.Rental.Services.Model;
using FluentValidation;
using System;
using System.Linq;


namespace Car.Rental.Services.FluentValidator
{
    public class AddressValidator : AbstractValidator<AddressModel>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Street)
               .NotEmpty().WithMessage("Street is Required");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is Required");            
            RuleFor(x => x.ReferenceNumber)
                .NotEmpty().WithMessage("Number is Required");
            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage("State is Required")
                .Must((a, b) => a.State.Length == 2
                    && a.State.All(Char.IsLetter))
                .WithMessage("State should have 2 letters");
            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("CEP is required")
                .IsZipCode();
        }
    }
}
