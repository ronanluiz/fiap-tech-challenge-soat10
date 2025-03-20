namespace Soat10.TechChallenge.Application.Entities
{
    public class CartItem : Entity<Guid>
    {
        public CartItem() : base(Guid.NewGuid())
        {
        }

        public CartItem(Guid cartId, Product product, int quantity, string notes) : this()
        {
            CartId = cartId;
            Product = product;
            ProductId = product.Id;
            Quantity = quantity;
            Notes = notes;
        }

        public CartItem(Guid id, Guid cartId, int productId, Product product, int quantity, string notes)
        {
            Id = id;
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Notes = notes;
        }

        public CartItem(Product product, int quantity, string note)
        {
            Product = product;
            Quantity = quantity;
            Notes = note;
        }

        public Guid CartId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; private set; }
        public string? Notes { get; private set; }
        public decimal Price => (decimal)(Product?.Price);

    }
}