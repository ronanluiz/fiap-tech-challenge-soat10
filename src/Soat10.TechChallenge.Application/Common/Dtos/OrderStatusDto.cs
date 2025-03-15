using Soat10.TechChallenge.Application.Enums;
using System.Text.Json.Serialization;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class OrderStatusDto
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OrderStatus Status { get; set; }

        public OrderStatusDto() { }
        public OrderStatusDto(int id, OrderStatus status)
        {
            Id = id;
            Status = status;
        }
    }
}
