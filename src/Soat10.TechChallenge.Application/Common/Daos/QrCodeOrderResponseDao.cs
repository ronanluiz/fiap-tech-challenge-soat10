using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class QrCodeOrderResponseDao
    {
        [JsonPropertyName("qr_data")]
        public string Qrdata { get; set; }

        [JsonPropertyName("in_store_order_id")]
        public string InStoreOrderId { get; set; }
    }
}
