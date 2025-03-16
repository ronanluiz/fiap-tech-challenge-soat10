using Soat10.TechChallenge.Application.Gateways;
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
            return await _orderGateway.GetStatusAsync();
        }

    }
}
