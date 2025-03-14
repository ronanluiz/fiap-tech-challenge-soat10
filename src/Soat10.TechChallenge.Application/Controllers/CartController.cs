using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Presenters;
using Soat10.TechChallenge.Application.UseCases;

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

        public async Task<CartCreationResponse> CreateCartAsync(CartCreationRequest cartCreationRequest)
        {   
            var customerGateway = new CustomerGateway(_dataRepository);
            var cartGateway = new CartGateway(_dataRepository);

            Cart cart = await CartCreationUseCase.Build(customerGateway, cartGateway)
                                                   .ExecuteAsync(cartCreationRequest);

            return CartPresenter.BuildCartCreation(cart);
        }

        public async Task<AddingItemCartResponse> AddItemsCartAsync(Guid cartId, List<AddingItemCartRequest> addingItemsCartRequest)
        {
            var cartGateway = new CartGateway(_dataRepository);
            var productGateway = new ProductGateway(_dataRepository);
            var cartItemGateway = new CartItemGateway(_dataRepository);

            Cart cart = await AddingItemsCartUseCase.Build(cartGateway, productGateway, cartItemGateway)
                                                    .ExecuteAsync(cartId, addingItemsCartRequest);

            return CartPresenter.BuildAddingItemCart(cart);
        }

        public async Task<CartResponse> GetCartByIdAsync(Guid id)
        {
            var cartGateway = new CartGateway(_dataRepository);

            Cart cart = await GetCartByIdUseCase.Build(cartGateway).ExecuteAsync(id);

            return CartPresenter.BuildCart(cart);
        }
    }
}
