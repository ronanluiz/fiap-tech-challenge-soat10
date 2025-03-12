using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.Presenters
{
    public static class CartPresenter
    {
        public static AddingItemCartResponse Build(Cart cart)
        {
            return new AddingItemCartResponse()
            {
                CartId = cart.Id
            };
        }
    }
}
