using Bogus;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public class ExternalService : IExternalPaymentService
    {
        private readonly MercadoPagoPaymentService _mercadoPagoPaymentService;
        private readonly IMercadoPagoApi _mercadoPagoApi;

        public ExternalService(MercadoPagoPaymentService mercadoPagoPaymentService, IMercadoPagoApi mercadoPagoApi)
        {
            _mercadoPagoPaymentService = mercadoPagoPaymentService;
            this._mercadoPagoApi = mercadoPagoApi;
        }

        public async Task<ExternalOrderDao> GetPayment(string id)
        {
            return await _mercadoPagoApi.GetOrder(Convert.ToInt32(id));
        }

        public async Task<PaymentOrderDao> ProcessPaymentAsync(string orderId, string paymentQrCode)
        {
            return await _mercadoPagoPaymentService.ProcessPaymentAsync(orderId, paymentQrCode);
        }
    }
}
