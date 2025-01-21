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
                .Matches(@"^\d+$").WithMessage("CPF deve conter apenas números.")
                .Must(Validate).WithMessage("Não foi possível validar o CPF. Verificação inválida"); // Esse erro ocorre quando o dígito verificador do CPF é inválido.
        }

        private static bool Validate(string cpf)
        {
            return new Domain.ValueObjects.Cpf(cpf).CheckIsValid();
        }
    }
}
