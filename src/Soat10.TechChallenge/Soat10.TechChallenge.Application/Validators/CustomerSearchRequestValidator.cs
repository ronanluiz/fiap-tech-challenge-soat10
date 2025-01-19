using FluentValidation;
using Soat10.TechChallenge.Application.UseCases.CustomerUseCases;

namespace Soat10.TechChallenge.Application.Validators
{
    public class CustomerSearchRequestValidator : AbstractValidator<IdentifyResponse>
    {
        public CustomerSearchRequestValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("É preciso preencher o campo 'CPF'.")
                .Length(11).WithMessage("CPF deve conter exatos 11 caracteres.")
                .Matches(@"^\d+$").WithMessage("CPF deve conter apenas números.");
        }
    }
}