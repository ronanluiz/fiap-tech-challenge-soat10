using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class CartItemResponse
    {
        public string ProductName { get; set; }
        public CategoryEnum ProductCategory { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Notes { get; set; }
    }
}
