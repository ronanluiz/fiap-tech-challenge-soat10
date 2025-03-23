using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class ExternalOrderDao
    {
        public int Id { get; set; }
        public string Status { get; set; }

        [JsonPropertyName("external_reference")]
        public string ExternalReference { get; set; }
    }
}
