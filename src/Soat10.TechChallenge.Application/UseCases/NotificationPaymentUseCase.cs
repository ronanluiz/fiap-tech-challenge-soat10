using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class NotificationPaymentUseCase
    {
        private readonly PaymentGateway _paymentGateway;
        private readonly OrderGateway _orderGateway;

        private NotificationPaymentUseCase(
            PaymentGateway paymentGateway,
            OrderGateway orderGateway)
        {
            _paymentGateway = paymentGateway;
            _orderGateway = orderGateway;
        }

        public static NotificationPaymentUseCase Build(
            PaymentGateway paymentGateway,
            OrderGateway orderGateway)
        {
            return new NotificationPaymentUseCase(paymentGateway, orderGateway);
        }

        public async Task<Payment> ExecuteAsync(PaymentNotificationRequest paymentNotificationRequest)
        {
            if (!Guid.TryParse(paymentNotificationRequest.ExernalReference, out Guid orderId))
            {
                throw new ValidationException("O id do pedido está inválido");
            }

            Payment payment = await _paymentGateway.GetByOrderAsync(orderId) ?? 
                throw new ValidationException("Não foi encontrado registro de pagamento para o pedido informado");
            Order order = payment.Order;

            order.ChangeStatus(OrderStatus.Paid);
            payment.SetExternalPayment(paymentNotificationRequest.Data.Id);
            payment.SetPaymentDate(paymentNotificationRequest.DateCreated);

            await _paymentGateway.UpdateAsync(payment);
            await _orderGateway.UpdateAsync(order);

            return payment;
        }
    }
}
