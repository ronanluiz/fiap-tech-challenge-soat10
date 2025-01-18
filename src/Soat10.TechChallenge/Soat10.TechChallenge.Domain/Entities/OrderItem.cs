using Soat10.TechChallenge.Domain.Base;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class OrderItem : Entity<int>
    {
        public OrderItem(int id) : base(default)
        {

        }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public string Note { get; private set; }

    }
}