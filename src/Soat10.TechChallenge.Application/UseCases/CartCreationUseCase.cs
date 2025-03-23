using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class CartCreationUseCase
    {
        private readonly CustomerGateway _customerGateway;
        private readonly CartGateway _cartGateway;

        private CartCreationUseCase(CustomerGateway customerGateway, CartGateway cartGateway)
        {
            _customerGateway = customerGateway;
            _cartGateway = cartGateway;
        }

        public static CartCreationUseCase Build(CustomerGateway customerGateway, CartGateway cartGateway)
        {
            return new CartCreationUseCase(customerGateway, cartGateway);
        }

        public async Task<Cart> ExecuteAsync(CartCreationRequest cartCreationRequest)
        {
            Customer customer = await GetCustomer(cartCreationRequest);
            Cart cart = new(customer);
            await _cartGateway.CreateAsync(cart);

            return cart;
        }

        private async Task<Customer> GetCustomer(CartCreationRequest cartCreationRequest)
        {
            Customer customer;
            if (!string.IsNullOrEmpty(cartCreationRequest.CustomerId) && Guid.TryParse(cartCreationRequest.CustomerId, out var customerId))
            {
                customer = await _customerGateway.GetByIdAsync(customerId);
            }
            else
            {
                customer = new(cartCreationRequest.CustomerName);
                await _customerGateway.AddAsync(customer);
            }

            return customer;
        }
    }
}
