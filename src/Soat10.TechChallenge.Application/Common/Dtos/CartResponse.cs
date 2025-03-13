using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.Application.Common.Dtos
{
    public class CartResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Customer { get; set; }
        public List<CartItemResponse> Items { get; set; } = [];
    }
}
