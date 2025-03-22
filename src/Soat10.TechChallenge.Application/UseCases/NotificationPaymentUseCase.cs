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
        private readonly Dictionary<string, PaymentStatus> _mapPaymentStatus = new()
        {
            { "approved", PaymentStatus.Approved },
            { "authorized", PaymentStatus.Authorized },
            { "in_process", PaymentStatus.InProcess },
            { "pending", PaymentStatus.Pending },
            { "cancelled", PaymentStatus.Cancelled },
            { "charged_back", PaymentStatus.ChargedBack },
            { "refunded", PaymentStatus.Refunded },
            { "rejected", PaymentStatus.Rejected }
        };
        private readonly Dictionary<PaymentStatus, OrderStatus> _mapPaymentOrderStatus = new()
        {
            { PaymentStatus.Approved, OrderStatus.Paid },
            { PaymentStatus.Authorized , OrderStatus.Paid },
            { PaymentStatus.InProcess , OrderStatus.Requested },
            { PaymentStatus.Pending , OrderStatus.Requested },
            { PaymentStatus.Cancelled , OrderStatus.Cancelled },
            { PaymentStatus.ChargedBack , OrderStatus.Cancelled },
            { PaymentStatus.Refunded , OrderStatus.Cancelled },
            { PaymentStatus.Rejected , OrderStatus.Cancelled }
        };

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

            PaymentStatus paymentStatus = _mapPaymentStatus[paymentNotificationRequest.Status];
            OrderStatus orderStatus = _mapPaymentOrderStatus[paymentStatus];
            order.ChangeStatus(orderStatus);
            payment.SetStatus(paymentStatus, paymentNotificationRequest.StatusDetail);
            payment.SetExternalPayment(paymentNotificationRequest.Data.Id);

            if(orderStatus == OrderStatus.Paid)
            {
                payment.Finish(paymentNotificationRequest.DateCreated, paymentNotificationRequest.StatusDetail);
            }  

            await _paymentGateway.UpdateAsync(payment);
            await _orderGateway.UpdateAsync(order);

            return payment;
        }
    }
}
