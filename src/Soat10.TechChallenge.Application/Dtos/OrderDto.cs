using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<OrderItemDto> Items { get; set; } = [];
        public decimal Amount { get; set; }
    }
}
