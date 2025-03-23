using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class QrCodeOrderCashOutDao
    {
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}
