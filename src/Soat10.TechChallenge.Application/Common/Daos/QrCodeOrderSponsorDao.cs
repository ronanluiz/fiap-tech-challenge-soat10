using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class QrCodeOrderSponsorDao
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}
