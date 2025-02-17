using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Daos
{
    public class OrderDao
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public virtual CustomerDao Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<OrderItemDao> Items { get; set; } = [];
        public decimal Amount { get; set; }
    }
}
