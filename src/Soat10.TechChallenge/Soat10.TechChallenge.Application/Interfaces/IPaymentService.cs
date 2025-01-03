using Soat10.TechChallenge.Application.DTOs;

namespace Soat10.TechChallenge.Application.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> ProcessPaymentAsync(int orderId, string paymentQrCode);
    }
}
