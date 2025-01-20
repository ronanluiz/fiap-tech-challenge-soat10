using Soat10.TechChallenge.Domain.Base;

namespace Soat10.TechChallenge.Domain.Entities
{
    public class OrderItem : Entity<int>
    {
        public OrderItem(int id) : base(default)
        {

        }

        public OrderItem(int orderId, Order order, int productId, Product product, int quantity, decimal price, string note)
        {
            OrderId = orderId;
            Order = order;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Note = note;
        }

        public OrderItem(int id, int orderId, Order order, int productId, Product product, int quantity, decimal price, string note) : base(id)
        {
            OrderId = orderId;
            Order = order;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Note = note;
        }

        public OrderItem(Product product, int quantity, string note)
        {
            Product = product;
            Quantity = quantity;
            Note = note;
        }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public string? Note { get; private set; }

    }
}