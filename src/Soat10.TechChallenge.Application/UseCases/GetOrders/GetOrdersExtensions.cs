using Soat10.TechChallenge.Application.Entities;

namespace Soat10.TechChallenge.Application.UseCases.GetOrders
{
    public static class GetOrdersExtensions
    {
        public static GetOrdersResponse OrderToOrderResponse(this Order order)
        {
            return new GetOrdersResponse
            {
                OrderId = order.Id,
                CustumerId = order.CustomerId,
                CustomerName = order.Customer.Name,
                Status = order.Status.ToString(),
                Amount = order.Amount,
                Items = string.Join(", ", order.Items.Select(item =>
                    string.IsNullOrWhiteSpace(item.Note)
                        ? $"{item.Product.Name} x{item.Quantity}"
                        : $"{item.Product.Name} x{item.Quantity} ({item.Note})"))
            };
        }

        public static IEnumerable<GetOrdersResponse> OrdersToOrderResponse(this IEnumerable<Order> orders)
        {
            var orderResponse = new List<GetOrdersResponse>();

            foreach (var order in orders)
            {
                orderResponse.Add(order.OrderToOrderResponse());
            }

            return orderResponse;
        }
    }
}