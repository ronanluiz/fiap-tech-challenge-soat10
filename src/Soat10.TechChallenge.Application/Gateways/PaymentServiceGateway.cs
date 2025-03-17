using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class PaymentServiceGateway
    {
        private readonly IExternalPaymentService _externalService;

        public PaymentServiceGateway(IExternalPaymentService externalService)
        {
            _externalService = externalService;
        }

        public async Task<ExternalPaymentOrder> Get(string paymentId)
        {
            ExternalOrderDao externalOrder = await _externalService.GetPayment(paymentId);

            return new ExternalPaymentOrder(externalOrder.Id.ToString(), Guid.NewGuid(), externalOrder.Status);
        }
    }
}
