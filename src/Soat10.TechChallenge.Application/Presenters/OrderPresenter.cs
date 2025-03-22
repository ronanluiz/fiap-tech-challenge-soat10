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
                OrderNumber = order.OrderNumberToDisplay,
                OrderValue = order.Items.Sum(item => item.Price),
                PaymentStatus = payment.Status,
                PaymentDetailedStatus = payment.StatusDetail,
                CustomerName =  order.Customer.Name,
            };
        }

        public static CheckoutResponse Build(Payment payment)
        {
            return new CheckoutResponse()
            {
                OrderId = payment.OrderId,
                OrderNumber = payment.Order.OrderNumberToDisplay,
                QrData = payment.QrData
            };
        }

        public static IEnumerable<OpenOrdersResponse> BuildOpenOrders(IEnumerable<Order> orders)
        {
            return orders.Select(order => new OpenOrdersResponse()
            {
                OrderId = order.Id,
                OrderNumber = order.OrderNumberToDisplay,
                Amount = order.TotalAmount,
                Status = order.Status.ToString(),
                Products = string.Join(" | ", order.Items.Select(i => $"{i.Quantity} - {i.Product.Name}")),
                CreatedAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"),
                CustomerName = order.Customer.Name
            });              
        }
    }
}
