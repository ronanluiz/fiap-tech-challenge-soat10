using FluentValidation;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório.")
                .MaximumLength(50).WithMessage("O nome do produto deve conter no máximo 50 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição do produto é obrigatória.")
                .MaximumLength(200).WithMessage("A descrição do produto deve conter no máximo 200 caracteres.");

            RuleFor(x => x.ProductCategory)
                .NotNull().WithMessage("A categoria do produto é obrigatória.");

            RuleFor(x => x.Price)
                .GreaterThan(0.01).WithMessage("O preço do produto deve ser maior que 0.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("O status do produto deve ser um valor válido.");

            RuleFor(x => x.TimeToPrepare)
                .GreaterThanOrEqualTo(TimeSpan.Zero).WithMessage("O tempo de preparo deve ser maior ou igual a zero.")
                .LessThanOrEqualTo(TimeSpan.FromMinutes(50)).WithMessage("O tempo de preparo não pode exceder 50 minutos.");

            RuleFor(x => x.Note)
                .MaximumLength(500).WithMessage("A nota do produto deve conter no máximo 500 caracteres.")
                .When(x => !string.IsNullOrEmpty(x.Note));

            RuleFor(x => x.QuantityInStock)
                .GreaterThanOrEqualTo(0).WithMessage("A quantidade em estoque não pode ser negativa.");
        }
    }
}
