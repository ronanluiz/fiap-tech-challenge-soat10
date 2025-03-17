using Microsoft.Extensions.Configuration;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public class ExternalPaymentService : IExternalPaymentService
    {
        private readonly IMercadoPagoApi _mercadoPagoApi;
        private readonly IConfiguration _configuration;

        public ExternalPaymentService(IMercadoPagoApi mercadoPagoApi, IConfiguration configuration)
        {
            _mercadoPagoApi = mercadoPagoApi;
            _configuration = configuration;
        }

        public async Task<ExternalOrderDao> GetPayment(string id)
        {
            return await _mercadoPagoApi.GetOrder(Convert.ToInt32(id));
        }

        public async Task<QrCodeOrderResponseDao> CreateQrCodeOrder(QrCodeOrderDao qrCodeOrderDao)
        {
            long userId = Convert.ToInt64(_configuration["PaymentService:UserId"]);
            string externalPosId = _configuration["PaymentService:ExternalPosId"];
            qrCodeOrderDao.NotificationUrl = _configuration["PaymentService:NotificationPaymentUrl"];

            QrCodeOrderResponseDao externalOrderResponse = await _mercadoPagoApi.CreateQrCodeOrder(userId, externalPosId, qrCodeOrderDao);

            return externalOrderResponse;
        }
    }
}
