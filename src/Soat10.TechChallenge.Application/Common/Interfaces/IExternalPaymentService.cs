using Soat10.TechChallenge.Application.Common.Daos;

namespace Soat10.TechChallenge.Application.Common.Interfaces
{
    public interface IExternalPaymentService
    {
        Task<PaymentOrderDao> ProcessPaymentAsync(string orderId, string paymentQrCode);
    }
}
