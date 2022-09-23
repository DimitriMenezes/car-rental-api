using Car.Rental.Services.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Services.FluentValidator
{
    public class ClientValidator : AbstractValidator<ClientModel>
    {
        public ClientValidator()
        {
            RuleFor(i => i.Birthday)
                .NotEmpty()
                .WithMessage("Birthday is Required");
                
            RuleFor(i => i.Name)
                .NotEmpty()
                .WithMessage("Name is Required");
            RuleFor(i => i.Password)
                .NotEmpty()
                .WithMessage("Password is required");
            RuleFor(i => i.Cpf)
                .NotEmpty()
                .WithMessage("Cpf is Required")
                .IsCpf();

            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage("Address is Required")
                .SetValidator(new AddressValidator());
        }
    }
}
