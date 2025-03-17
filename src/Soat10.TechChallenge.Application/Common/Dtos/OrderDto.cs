using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public Guid CustomerId { get; set; }
        public virtual ICollection<OrderItemDto> Items { get; set; } = [];
        public decimal Amount { get; set; }
    }
}
