using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases.Checkout
{
    public class CheckoutUseCase
    {
        protected CheckoutUseCase()
        {
        }

        public static async Task ExecuteAsync(int orderId,
            PaymentServiceGateway paymentServiceGateway,
            PaymentGateway paymentGateway,
            OrderGateway orderGateway)
        {
            Order order = await orderGateway.GetByIdAsync(orderId);
            PaymentOrder paymentOrder = await paymentServiceGateway.Create(order);

            order.ChangeStatus(OrderStatus.Paid);
            await orderGateway.UpdateAsync(order);

            Payment payment = new(paymentOrder.Id, order.Id, order.Amount);
            await paymentGateway.AddAsync(payment);
        }
    }
}
