using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class PaymentServiceGateway
    {
        private readonly IExternalPaymentService _externalService;

        public PaymentServiceGateway(IExternalPaymentService externalService)
        {
            _externalService = externalService;
        }        

        public async Task<PaymentOrder> Create(Order order)
        {
            PaymentOrderDao paymentOrderResponse = await _externalService.ProcessPaymentAsync(order.Id.ToString(), string.Empty);

            return new PaymentOrder(paymentOrderResponse.InStoreOrderId, paymentOrderResponse.Qrdata, string.Empty);
        }

        public async Task<PaymentOrder> Get(string paymentId)
        {
            ExternalOrderDao externalOrder = await _externalService.GetPayment(paymentId);

            return new PaymentOrder(externalOrder.Id.ToString(), externalOrder.ExternalReference, externalOrder.Status);
        }
    }
}
