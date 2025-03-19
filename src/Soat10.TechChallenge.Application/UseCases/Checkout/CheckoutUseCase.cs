using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases.Checkout
{
    public class CheckoutUseCase
    {
        private readonly PaymentServiceGateway _paymentServiceGateway;
        private readonly PaymentGateway _paymentGateway;
        private readonly OrderGateway _orderGateway;

        private CheckoutUseCase(PaymentServiceGateway paymentServiceGateway,
            PaymentGateway paymentGateway,
            OrderGateway orderGateway)
        {
            _paymentServiceGateway = paymentServiceGateway;
            _paymentGateway = paymentGateway;
            _orderGateway = orderGateway;
        }

        public static CheckoutUseCase Build(PaymentServiceGateway paymentServiceGateway,
            PaymentGateway paymentGateway,
            OrderGateway orderGateway)
        {
            return new CheckoutUseCase(paymentServiceGateway, paymentGateway, orderGateway);
        }

        public async Task ExecuteAsync(int orderId)
        {
            Order order = await _orderGateway.GetByIdAsync(orderId);
            PaymentOrder paymentOrder = await _paymentServiceGateway.Create(order);

            order.ChangeStatus(OrderStatus.Paid);
            await _orderGateway.UpdateAsync(order);

            Payment payment = new(int.Parse(paymentOrder.Id), order.Id, order.Amount, null, null);
            await _paymentGateway.AddAsync(payment);
        }
    }
}
