using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Refit;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Exceptions;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public class ExternalPaymentService : IExternalPaymentService
    {
        private readonly IMercadoPagoApi _mercadoPagoApi;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExternalPaymentService> _logger;

        public ExternalPaymentService(IMercadoPagoApi mercadoPagoApi, 
            IConfiguration configuration,
            ILogger<ExternalPaymentService> logger)
        {
            _mercadoPagoApi = mercadoPagoApi;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ExternalOrderDao> GetPayment(string id)
        {
            return await _mercadoPagoApi.GetOrder(Convert.ToInt32(id));
        }

        public async Task<QrCodeOrderResponseDao> CreateQrCodeOrder(QrCodeOrderDao qrCodeOrderDao)
        {
            try
            {
                long userId = Convert.ToInt64(_configuration["PaymentService:UserId"]);
                string externalPosId = _configuration["PaymentService:ExternalPosId"];
                qrCodeOrderDao.NotificationUrl = _configuration["PaymentService:NotificationPaymentUrl"];

                QrCodeOrderResponseDao externalOrderResponse = await _mercadoPagoApi.CreateQrCodeOrder(userId, externalPosId, qrCodeOrderDao);

                return externalOrderResponse;
            }
            catch(ApiException ex)
            {
                _logger.LogError(ex, "Erro na integração com o Mercado Pago");
                throw new PaymentServiceException("Erro na integração com o Mercado Pago", ex);
            }
        }
    }
}
