namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class OrderItemDao
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public virtual ProductDao Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Note { get; set; }
    }
}
