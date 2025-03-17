using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Application.Common.Interfaces
{
    public interface IExternalPaymentService
    {
        Task<QrCodeOrderResponseDao> CreateQrCodeOrder(QrCodeOrderDao externalOrderRequestDao);
        Task<ExternalOrderDao> GetPayment(string id);
    }
}
