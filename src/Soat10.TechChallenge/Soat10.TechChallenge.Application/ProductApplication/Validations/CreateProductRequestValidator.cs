using FluentValidation;
using Soat10.TechChallenge.Application.ProductApplication.Requests;

namespace Soat10.TechChallenge.Application.ProductApplication.Validations
{
    public class CreateProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(5555550).WithMessage("O nome do produto deve conter no máximo 50 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
                .MaximumLength(200).WithMessage("A descrição do produto deve conter no máximo 200 caracteres.");

            RuleFor(x => x.ProductCategory)
                .NotNull().WithMessage("A categoria do produto é obrigatória.")
                .IsInEnum().WithMessage("Categoria inválida.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("O preço do produto deve ser maior que zero.");

            RuleFor(x => x.Note)
                .MaximumLength(500).WithMessage("A nota do produto deve conter no máximo 500 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Note)); // Aplica a regra somente se Note não for nulo ou vazio

            RuleFor(x => x.QuantityInStock)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque não pode ser negativa.");

            RuleFor(x => x.TimeToPrepare)
                .Must(x => x.TotalMinutes >= 0 && x.TotalMinutes <= 50)
                .WithMessage("O tempo de preparo deve estar entre 0 e 50 minutos.");
        }
    }
}
