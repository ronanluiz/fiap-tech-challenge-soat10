using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases
{
    internal class GetOpenOrdersUseCase
    {
        private readonly OrderGateway _orderGateway;

        private GetOpenOrdersUseCase(OrderGateway orderGateway)
        {
            _orderGateway = orderGateway;
        }

        public static GetOpenOrdersUseCase Build(OrderGateway orderGateway)
        {
            return new GetOpenOrdersUseCase(orderGateway);
        }

        public async Task<IEnumerable<Order>> ExecuteAsync()
        {
            IEnumerable<Order> orders = await _orderGateway.GetOpenAsync();

            var ordenateOrders = orders.OrderBy(o => GetNumberOrder(o.Status))
                                        .ThenBy(o => o.CreatedAt);
            return ordenateOrders;
        }

        private int GetNumberOrder(OrderStatus orderStatus)
        {
            var statusNumberOrder = new Dictionary<OrderStatus, int>
            {
                { OrderStatus.Received, 0 },
                { OrderStatus.Preparing, 1 },
                { OrderStatus.Ready, 2 }
            };

            if (statusNumberOrder.TryGetValue(orderStatus, out int number))
            {
                return number;
            }
            else
            {
                return 3;
            }
        }

    }
}
