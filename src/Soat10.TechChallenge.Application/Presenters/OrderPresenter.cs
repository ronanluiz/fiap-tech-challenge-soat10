using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.Presenters
{
    public class OrderPresenter
    {
        public static IEnumerable<OrderDto> Build(IEnumerable<Order> orders)
        {
            IList<OrderDto> orderDtos = orders
                                        .Select(o => Mapper.MapToDto(o))
                                        .ToList();

            return orderDtos;
        }

        public static IEnumerable<OpenOrdersResponse> BuildOpenOrders(IEnumerable<Order> orders)
        {
            return orders.Select(order => new OpenOrdersResponse()
            {
                OrderId = order.Id,
                Amount = order.Amount,
                Status = order.Status.ToString(),
                Products = string.Join(" | ", order.Items.Select(i => $"{i.Quantity} - {i.Product.Name}")),
                CreatedAt = order.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"),
                CustomerName = order.Customer.Name
            });              
        }
    }
}
