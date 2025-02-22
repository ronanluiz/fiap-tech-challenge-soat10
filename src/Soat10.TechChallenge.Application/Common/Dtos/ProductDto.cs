using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public CategoryEnum ProductCategory { get; set; }
        public double Price { get; set; }
        public ProductStatusEnum Status { get; set; }
        public TimeSpan TimeToPrepare { get; set; }
        public string? Note { get; set; }
        public bool IsAvailable { get; set; }
        public int QuantityInStock { get; set; } = 0;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UserUpdated { get; set; }
    }
}
