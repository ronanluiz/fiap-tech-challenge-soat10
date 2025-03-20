using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class GetCartByIdUseCase
    {
        private readonly CartGateway _cartGateway;

        private GetCartByIdUseCase(CartGateway cartGateway)
        {
            _cartGateway = cartGateway;
        }

        public static GetCartByIdUseCase Build(CartGateway cartGateway)
        {
            return new GetCartByIdUseCase(cartGateway);
        }

        public async Task<Cart> ExecuteAsync(Guid id)
        {
            Cart cart = await _cartGateway.GetByIdAsync(id);
            return cart == null ? throw new ValidationException("Carrinho não encontrado") : cart;
        }
    }
}
