using FluentValidation;

namespace Soat10.TechChallenge.Application.UseCases.Identify
{
    public class IdentifyRequestValidator : AbstractValidator<IdentifyRequest>
    {
        public IdentifyRequestValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("É preciso preencher o campo 'CPF'.")
                .Must(Validate).WithMessage("CPF está inválido");
        }

        private static bool Validate(string cpf)
        {
            return new Domain.ValueObjects.Cpf(cpf).CheckIsValid();
        }
    }
}