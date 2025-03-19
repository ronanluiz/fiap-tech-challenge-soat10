using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Common.Requests
{
    public class PaymentNotificationRequest
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("api_version")]
        public string ApiVersion { get; set; }

        [JsonPropertyName("data")]
        public PaymentNotificationDataRequest Data { get; set; }

        [JsonPropertyName("date_created")]
        public DateTime DateCreated { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("live_mode")]
        public bool LiveMode { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("external_reference")]
        public string ExernalReference { get; set; }
    }
}
