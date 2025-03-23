using FluentValidation;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(c => c.Items)
                .NotNull().WithMessage("Pelo menos um item do pedido é obrigatório");
        }
    }
}
