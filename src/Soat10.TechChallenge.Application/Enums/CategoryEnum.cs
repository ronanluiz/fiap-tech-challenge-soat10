using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoryEnum
    {
        Lanche,
        Acompanhamento,
        Bebida,
        Sobremesa
    }
}
