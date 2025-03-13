using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Daos
{
    public class ProductDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public CategoryEnum ProductCategory { get; set; }
        public decimal Price { get; set; }
        public ProductStatusEnum Status { get; set; }
        public TimeSpan TimeToPrepare { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
