using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class QrCodeOrderDao
    {
        [JsonPropertyName("external_reference")]
        public string ExternalReference { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("notification_url")]
        public string NotificationUrl { get; set; }

        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("items")]
        public List<QrCodeOrderItemDao> Items { get; set; } = [];

        [JsonPropertyName("cash_out")]
        public QrCodeOrderCashOutDao CashOut { get; set; } = new QrCodeOrderCashOutDao();
    }
}
