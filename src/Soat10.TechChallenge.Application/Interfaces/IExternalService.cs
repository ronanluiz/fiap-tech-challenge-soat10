using Soat10.TechChallenge.Application.Daos;

namespace Soat10.TechChallenge.Application.Services
{
    public interface IExternalService
    {
        Task<PaymentOrderDao> ProcessPaymentAsync(string orderId, string paymentQrCode);
    }
}
