using Soat10.TechChallenge.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Soat10.TechChallenge.Application.ProductApplication.Requests
{
    public class ProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public CategoryEnum ProductCategory { get; set; }

        public double Price { get; set; }

        public string? Note { get; set; }

        public int QuantityInStock { get; set; }

        public TimeSpan TimeToPrepare { get; set; }

    }
}
