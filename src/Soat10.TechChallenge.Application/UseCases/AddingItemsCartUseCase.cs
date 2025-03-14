using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class AddingItemsCartUseCase
    {
        private readonly CartGateway _cartGateway;
        private readonly ProductGateway _productGateway;
        private readonly CartItemGateway _cartItemGateway;

        private AddingItemsCartUseCase(CartGateway cartGateway,
            ProductGateway productGateway,
            CartItemGateway cartItemGateway)
        {
            _cartGateway = cartGateway;
            _productGateway = productGateway;
            _cartItemGateway = cartItemGateway;
        }

        public static AddingItemsCartUseCase Build(CartGateway cartGateway,
            ProductGateway productGateway,
            CartItemGateway cartItemGateway)
        {
            return new AddingItemsCartUseCase(cartGateway, productGateway, cartItemGateway);
        }

        public async Task<Cart> ExecuteAsync(Guid cartId, List<AddingItemCartRequest> addingItemsCart)
        {
            Cart cart = await GetCart(cartId);
            foreach (AddingItemCartRequest itemCart in addingItemsCart)
            {
                Product product = await _productGateway.GetByIdAsync(itemCart.ProductId) ?? 
                    throw new ValidationException($"Produto com id {itemCart.ProductId} não encontrado");
                CartItem cartItem = new(cart.Id, product, itemCart.Quantity, itemCart.Notes);
                await _cartItemGateway.CreateAsync(cartItem);
            }

            return cart;
        }

        private async Task<Cart> GetCart(Guid cartId)
        {
            Cart cart = await _cartGateway.GetByIdAsync(cartId);

            if (cart == null)
            {
                throw new ValidationException("Carrinho não encontrado");
            }

            return cart;
        }
    }
}
