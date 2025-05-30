﻿using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.MockWebhookReturn
{
    public class PaymentNotificationDto
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("api_version")]
        public string ApiVersion { get; set; }

        [JsonPropertyName("data")]
        public PaymentNotificationDataDto Data { get; set; }

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

        public string Status { get; set; }

        [JsonPropertyName("status_detail")]
        public string StatusDetail { get; set; }
    }
}
