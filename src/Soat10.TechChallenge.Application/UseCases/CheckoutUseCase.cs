using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class CheckoutUseCase
    {
        private readonly CartGateway _cartGateway;
        private readonly PaymentServiceGateway _paymentServiceGateway;
        private readonly PaymentGateway _paymentGateway;
        private readonly OrderGateway _orderGateway;

        private CheckoutUseCase(CartGateway cartGateway,
            PaymentServiceGateway paymentServiceGateway,
            PaymentGateway paymentGateway,
            OrderGateway orderGateway)
        {
            _cartGateway = cartGateway;
            _paymentServiceGateway = paymentServiceGateway;
            _paymentGateway = paymentGateway;
            _orderGateway = orderGateway;
        }

        public static CheckoutUseCase Build(CartGateway cartGateway,
            PaymentServiceGateway paymentServiceGateway,
            PaymentGateway paymentGateway,
            OrderGateway orderGateway)
        {
            return new CheckoutUseCase(cartGateway, paymentServiceGateway, paymentGateway, orderGateway);
        }

        public async Task<Payment> ExecuteAsync(CheckoutRequest checkoutRequest)
        {
            Cart cart = await _cartGateway.GetByIdAsync(checkoutRequest.CartId) ?? 
                throw new ValidationException($"Carrinho com o id {checkoutRequest.CartId} não encontrado");
            Order order = MapperEntity.MapToOrder(cart);

            order = await _orderGateway.AddAsync(order);
            Payment payment = await _paymentGateway.CreateQrCodeOrder(order);

            await _paymentGateway.AddAsync(payment);

            return payment;            
        }
    }
}
