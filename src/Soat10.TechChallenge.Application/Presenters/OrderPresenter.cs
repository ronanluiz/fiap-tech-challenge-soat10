using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;
using System.Diagnostics.CodeAnalysis;

namespace Soat10.TechChallenge.Application.Presenters
{
    public class OrderPresenter
    {
        public static IEnumerable<OrderDto> Build(IEnumerable<Order> orders)
        {
            IList<OrderDto> orderDtos = orders
                                        .Select(o => MapperDto.Map(o))
                                        .ToList();

            return orderDtos;
        }

        public static OrderPaymentStatusResponse Present(Order order, Payment payment)
        {
            return new OrderPaymentStatusResponse
            {
                OrderId = order.Id,
                OrderNumber = order.OrderNumber.ToString().PadLeft(7, '0'),
                OrderValue = order.Items.Sum(item => item.Price),
                StatusPayment = payment.Status,
                CustomerName =  order.Customer.Name,
            };
        }

        public static CheckoutResponse Build(Payment payment)
        {
            return new CheckoutResponse()
            {
                OrderId = payment.OrderId,
                QrData = payment.QrData
            };
        }
    }
}
