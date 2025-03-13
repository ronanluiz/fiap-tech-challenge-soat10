using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Presenters
{
    public static class CartPresenter
    {
        public static AddingItemCartResponse BuildAddingItemCart(Cart cart)
        {
            return new AddingItemCartResponse()
            {
                CartId = cart.Id
            };
        }

        public static CartResponse BuildCart(Cart cart)
        {
            return new CartResponse()
            {
                Id = cart.Id,
                Customer = cart.Customer?.Name,
                Status = cart.Status.ToString(),
                Items = [.. cart.Items.Select(item => new CartItemResponse()
                {
                    ProductName = item.Product?.Name,
                    ProductCategory = item.Product.ProductCategory,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    Notes = item.Notes
                })]
            };
        }
    }
}
