using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class OrderDao
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
        public virtual CustomerDao Customer { get; set; }
        public Guid CustomerId { get; set; }
        public virtual ICollection<OrderItemDao> Items { get; set; } = [];
        public decimal Amount { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
