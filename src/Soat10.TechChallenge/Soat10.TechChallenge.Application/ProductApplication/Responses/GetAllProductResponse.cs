using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.Application.ProductApplication.Responses
{
    public class GetAllProductResponse
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public CategoryEnum ProductCategory { get; set; }

        public double Price { get; set; }

        public ProductStatusEnum Status { get; set; }

        public TimeSpan TimeToPrepare { get; set; } = TimeSpan.FromMinutes(10);

        public string? Note { get; set; }

        public bool IsAvailable { get; set; } = true;

        public int QuantityInStock { get; set; }
    }
}
