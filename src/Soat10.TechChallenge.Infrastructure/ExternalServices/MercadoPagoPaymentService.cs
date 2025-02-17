using Soat10.TechChallenge.Application.Daos;

namespace Soat10.TechChallenge.Infrastructure.ExternalServices
{
    public class MercadoPagoPaymentService
    {
        public async Task<PaymentOrderDao> ProcessPaymentAsync(string orderId, string paymentQrCode)
        {
            return new PaymentOrderDao()
            {
                Qrdata = "00020101021243650016COM.MERCADOLIBRE02013063638f1192a-5fd1-4180-a180-8bcae3556bc35204000053039865802BR5925IZABEL AAAA DE MELO6007BARUERI62070503***63040B6D",
                InStoreOrderId = "d4e8ca59-3e1d-4c03-b1f6-580e87c654ae"
            };
        }
    }
}
