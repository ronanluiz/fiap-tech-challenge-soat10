using FluentValidation;

namespace Soat10.TechChallenge.Application.UseCases.CustomerRegistration
{
    public class CustomerRegistrationRequestValidator : AbstractValidator<CustomerRegistrationRequest>
    {
        public CustomerRegistrationRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("É preciso preencher o campo 'Nome'.")
                .MaximumLength(255).WithMessage("O campo 'Nome' deve ter até 255 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("É preciso preencher o campo 'Email'.")
                .EmailAddress().WithMessage("Email informado em um formato incorreto. Deve ser: 'nome@email.com'.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("É preciso preencher o campo 'CPF'.")
                .Length(11).WithMessage("CPF deve conter exatos 11 caracteres.")
                .Matches(@"^\d+$").WithMessage("CPF deve conter apenas números.");
        }
    }
}
