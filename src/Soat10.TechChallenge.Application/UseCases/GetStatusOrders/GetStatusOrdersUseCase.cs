using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Mappers;
using Soat10.TechChallenge.Application.UseCases.GetStatusOrders;

namespace Soat10.TechChallenge.Application.UseCases.GetStatusOrdersUseCase
{
    internal class GetStatusOrdersUseCase
    {
        private readonly OrderGateway _orderGateway;

        private GetStatusOrdersUseCase(OrderGateway orderGateway)
        {
            _orderGateway = orderGateway;
        }

        public static GetStatusOrdersUseCase Build(OrderGateway orderGateway)
        {
            return new GetStatusOrdersUseCase(orderGateway);
        }

        public async Task<IEnumerable<GetStatusOrdersResponse>> ExecuteAsync()
        {
            IEnumerable<Order> orders = await _orderGateway.GetStatusAsync();

            return orders.Select(o => new GetStatusOrdersResponse(o.Id, o.Status.ToString()));
        }
    }
}
