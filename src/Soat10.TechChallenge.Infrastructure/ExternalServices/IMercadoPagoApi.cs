using Refit;
using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public interface IMercadoPagoApi
    {
        [Get("/merchant_orders/{id}")]
        Task<ExternalOrderDao> GetOrder(int id);

        [Post("/instore/orders/qr/seller/collectors/{userId}/pos/{externalPosId}/qrs")]
        Task<QrCodeOrderResponseDao> CreateQrCodeOrder(long userId, 
            string externalPosId, 
            [Body] QrCodeOrderDao externalOrderRequestDao);
    }
}
