using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class AddingItemsCartUseCase
    {
        private readonly CustomerGateway _customerGateway;
        private readonly CartGateway _cartGateway;
        private readonly ProductGateway _productGateway;
        private readonly CartItemGateway _cartItemGateway;

        private AddingItemsCartUseCase(CustomerGateway customerGateway,
            CartGateway cartGateway,
            ProductGateway productGateway,
            CartItemGateway cartItemGateway)
        {
            _customerGateway = customerGateway;
            _cartGateway = cartGateway;
            _productGateway = productGateway;
            _cartItemGateway = cartItemGateway;
        }

        public static AddingItemsCartUseCase Build(CustomerGateway customerGateway,
            CartGateway cartGateway,
            ProductGateway productGateway,
            CartItemGateway cartItemGateway)
        {
            return new AddingItemsCartUseCase(customerGateway, cartGateway, productGateway, cartItemGateway);
        }

        public async Task<Cart> ExecuteAsync(List<AddingItemCartRequest> addingItemsCart)
        {
            Cart cart = await GetCart(addingItemsCart.FirstOrDefault());
            foreach (AddingItemCartRequest itemCart in addingItemsCart)
            {
                Product product = await _productGateway.GetByIdAsync(itemCart.ProductId);
                CartItem cartItem = new(cart.Id, product, itemCart.Quantity, itemCart.Notes);
                await _cartItemGateway.CreateAsync(cartItem);
            }

            return cart;
        }

        private async Task<Cart> GetCart(AddingItemCartRequest addingItemsCart)
        {
            Cart cart;

            if (addingItemsCart.CartId.HasValue)
            {
                cart = await _cartGateway.GetByIdAsync(addingItemsCart.CartId.Value);
            }
            else
            {
                Customer customer = await GetCustomer(addingItemsCart);
                cart = new(customer);

                await _cartGateway.CreateAsync(cart);
            }

            if (cart == null)
            {
                throw new ValidationException("Carrinho não encontrado");
            }

            return cart;
        }

        private async Task<Customer> GetCustomer(AddingItemCartRequest addingItemsCart)
        {
            Customer customer = null;
            if (addingItemsCart.CustomerId.HasValue)
            {
                customer = await _customerGateway.GetAsync(addingItemsCart.CustomerId.Value);
            }

            return customer;
        }
    }
}
