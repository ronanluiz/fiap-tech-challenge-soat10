using Bogus;
using Soat10.TechChallenge.Application.Daos;
using Soat10.TechChallenge.Application.Services;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public class ExternalService : IExternalService
    {
        private readonly MercadoPagoPaymentService _mercadoPagoPaymentService;

        public ExternalService(MercadoPagoPaymentService mercadoPagoPaymentService)
        {
            _mercadoPagoPaymentService = mercadoPagoPaymentService;
        }

        public async Task<PaymentOrderDao> ProcessPaymentAsync(string orderId, string paymentQrCode)
        {
            return await _mercadoPagoPaymentService.ProcessPaymentAsync(orderId, paymentQrCode);
        }
    }
}
