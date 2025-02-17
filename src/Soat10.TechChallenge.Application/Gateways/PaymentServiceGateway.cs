using Soat10.TechChallenge.Application.Daos;
using Soat10.TechChallenge.Application.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Services;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class PaymentServiceGateway
    {
        private readonly IExternalService _externalService;

        public PaymentServiceGateway(IExternalService externalService)
        {
            _externalService = externalService;
        }        

        public async Task<PaymentOrder> Create(Order order)
        {
            PaymentOrderDao paymentOrderResponse = await _externalService.ProcessPaymentAsync(order.Id.ToString(), string.Empty);

            return new PaymentOrder(paymentOrderResponse.InStoreOrderId, paymentOrderResponse.Qrdata);
        }
    }
}
