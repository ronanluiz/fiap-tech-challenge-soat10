using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;

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

        public async Task ExecuteAsync(CheckoutRequest checkoutRequest)
        {
            Cart cart = await _cartGateway.GetByIdAsync(checkoutRequest.CartId) ?? 
                throw new ValidationException("Carrinho não encontrado");

            //Order order = await _orderGateway.GetByIdAsync(checkoutRequest.);
            //PaymentOrder paymentOrder = await _paymentServiceGateway.Create(order);

            //order.ChangeStatus(OrderStatus.Paid);
            //await _orderGateway.UpdateAsync(order);

            //Payment payment = new(paymentOrder.Id, order.Id, order.Amount);
            //await _paymentGateway.AddAsync(payment);
        }
    }
}
