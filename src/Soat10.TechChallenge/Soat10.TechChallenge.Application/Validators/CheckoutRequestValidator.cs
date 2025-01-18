using FluentValidation;
using Soat10.TechChallenge.Application.UseCases.Checkout;

namespace Soat10.TechChallenge.Application.Validators
{
    public class CheckoutRequestValidator : AbstractValidator<CheckoutRequest>
    {
        public CheckoutRequestValidator()
        {
            RuleFor(x => x.OrderNumber)
                .GreaterThan(0).WithMessage("Número do pedido inválido");

            RuleFor(x => x.PaymentQrCode)
                .Must(x => !string.IsNullOrEmpty(x)).WithMessage("QrCode inválido");
        }
    }
}
