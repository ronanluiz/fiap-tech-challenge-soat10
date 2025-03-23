namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class CartItemDao
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public virtual ProductDao Product { get; set; }
        public int Quantity { get; set; }
        public string? Notes { get; set; }
    }
}
