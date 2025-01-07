using FluentValidation;
using Soat10.TechChallenge.Application.UseCases.CustomerUseCases;

namespace Soat10.TechChallenge.Application.Validators
{
    public class CustomerRegistrationRequestValidator : AbstractValidator<CustomerRegistrationRequest>
    {
        public CustomerRegistrationRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must be at most 255 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF is required.")
                .Length(11).WithMessage("CPF must be 11 numeric characters.")
                .Matches(@"^\d+$").WithMessage("CPF must contain only numbers.");
        }
    }
}
