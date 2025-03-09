using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;

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

        public async Task<IEnumerable<Order>> ExecuteAsync()
        {
            return await _orderGateway.GetStatusAsync();
        }
    }
}
