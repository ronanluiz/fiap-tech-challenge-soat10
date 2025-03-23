using FluentValidation;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Validators
{
    public class CustomerRegistrationRequestValidator : AbstractValidator<CustomerRegistrationRequest>
    {
        public CustomerRegistrationRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("É preciso preencher o campo 'Nome'.")
                .MaximumLength(255).WithMessage("O campo 'Nome' deve ter até 255 caracteres.");

            RuleFor(x => x.Email)                
                .EmailAddress()
                    .When(x => !string.IsNullOrEmpty(x.Email))
                    .WithMessage("Email informado em um formato incorreto. Deve ser: 'nome@email.com'.");

            RuleFor(x => x.Cpf)
                .Length(11)
                    .When(x => !string.IsNullOrEmpty(x.Cpf))
                    .WithMessage("CPF deve conter exatos 11 caracteres.")
                .Matches(@"^\d+$")
                    .When(x => !string.IsNullOrEmpty(x.Cpf))
                    .WithMessage("CPF deve conter apenas números.")
                .Must(Validate)
                    .When(x => !string.IsNullOrEmpty(x.Cpf))
                    .WithMessage("Não foi possível validar o CPF. Verificação inválida"); // Esse erro ocorre quando o dígito verificador do CPF é inválido.
        }

        private static bool Validate(string cpf)
        {
            return new Cpf(cpf).CheckIsValid();
        }
    }
}
