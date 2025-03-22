namespace Soat10.TechChallenge.Application.Entities
{
    public class OrderItem : Entity<Guid>
    {
        public OrderItem(Guid orderId, Product product, int quantity, decimal price, string note)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = product.Id;
            Product = product;
            Quantity = quantity;
            Price = price;
            Note = note;
        }

        public OrderItem(Guid id, Guid orderId, Guid productId, Product product, int quantity, decimal price, string note) : base(id)
        {
            OrderId = orderId;
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

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public string? Note { get; private set; }
        public decimal TotalAmont => Price * Quantity;

    }
}