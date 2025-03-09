using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Mappers;

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

        public async Task<IEnumerable<OrderStatusDto>> ExecuteAsync()
        {
            IEnumerable<Order> orders = await _orderGateway.GetStatusAsync();

            return orders.Select(Mapper.MapToStatusDto);
        }
    }
}
