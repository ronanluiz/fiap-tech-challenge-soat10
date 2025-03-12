using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Presenters;
using Soat10.TechChallenge.Application.UseCases.AddingItemsCart;

namespace Soat10.TechChallenge.Application.Controllers
{
    public class CartController
    {
        private readonly IDataRepository _dataRepository;

        private CartController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public static CartController Build(IDataRepository dataRepository)
        {
            return new CartController(dataRepository);
        }

        public async Task<AddingItemCartResponse> AddItemsCartAsync(List<AddingItemCartRequest> addingItemsCartRequest)
        {   
            var customerGateway = new CustomerGateway(_dataRepository);
            var cartGateway = new CartGateway(_dataRepository);
            var productGateway = new ProductGateway(_dataRepository);
            var cartItemGateway = new CartItemGateway(_dataRepository);

            Cart cart = await AddingItemsCartUseCase.Build(customerGateway, cartGateway, productGateway, cartItemGateway)
                                                    .ExecuteAsync(addingItemsCartRequest);

            return CartPresenter.Build(cart);
        }
    }
}
