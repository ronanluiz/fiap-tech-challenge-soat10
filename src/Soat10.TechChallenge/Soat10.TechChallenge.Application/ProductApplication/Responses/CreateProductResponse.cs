using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.Application.ProductApplication.Responses
{
    public class CreateProductResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CategoryEnum ProductCategory { get; set; }
        public double Price { get; set; }
        public string? Note { get; set; }
        public int QuantityInStock { get; set; }
        public TimeSpan TimeToPrepare { get; set; }
        public bool IsAvailable { get; set; }
        public ProductStatusEnum Status { get; set; }
    }
}
