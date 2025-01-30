using Bogus;
using Soat10.TechChallenge.Application.DTOs;
using Soat10.TechChallenge.Application.Services;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public class MercadoPagoPaymentService : IPaymentService
    {

        public async Task<PaymentResponseDto> ProcessPaymentAsync(int orderId, string paymentQrCode)
        {
            int paymentId = new Faker().Random.Number(1, 100000);
            return new PaymentResponseDto()
            {
                IsSuccess = true,
                PaymentId = $"MP-{paymentId}"
            };
        }
    }
}
