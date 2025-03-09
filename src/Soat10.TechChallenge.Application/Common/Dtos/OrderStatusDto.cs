using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class OrderStatusDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }

        public OrderStatusDto() { }
        public OrderStatusDto(int id, OrderStatus status)
        {
            Id = id;
            Status = status;
        }
    }
}
