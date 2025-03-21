using Refit;

namespace Soat10.TechChallenge.MockWebhookReturn
{
    public interface IWebhookService
    {
        [Post("/webhook/payment-notifications")]
        Task SendPaymentNotification([Body] PaymentNotificationDto paymentNotification);
    }
}
