using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class GetPaymentByOrderIdUseCase
    {
        private readonly PaymentGateway _paymentGeteway;

        private GetPaymentByOrderIdUseCase(PaymentGateway paymentGeteway)
        {
            _paymentGeteway = paymentGeteway;
        }

        public static GetPaymentByOrderIdUseCase Build(PaymentGateway paymentGeteway)
        {
            return new GetPaymentByOrderIdUseCase(paymentGeteway);
        }

        public async Task<Payment> ExecuteAsync(Guid orderId)
        {
            return await _paymentGeteway.GetByOrderAsync(orderId) ??
                throw new ValidationException($"Pagamento não encontrado para os dados informados");
        }
    }
}
