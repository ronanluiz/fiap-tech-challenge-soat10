using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.MockWebhookReturn
{
    public class PaymentNotificationDataDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
