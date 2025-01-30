using FluentValidation;

namespace Soat10.TechChallenge.Application.UseCases.Identify
{
    public class IdentifyRequestValidator : AbstractValidator<IdentifyRequest>
    {
        public IdentifyRequestValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("É preciso preencher o campo 'CPF'.")
                .Length(11).WithMessage("CPF deve conter exatos 11 caracteres.")
                .Matches(@"^\d+$").WithMessage("CPF deve conter apenas números.");

        }
    }
}