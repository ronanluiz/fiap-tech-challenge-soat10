namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class OrderItemDao
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDao Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? Note { get; set; }
    }
}
