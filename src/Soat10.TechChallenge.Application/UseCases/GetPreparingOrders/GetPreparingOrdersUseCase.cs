using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases.GetPreparingOrders
{
    internal class GetPreparingOrdersUseCase
    {
        private readonly OrderGateway _orderGateway;

        private GetPreparingOrdersUseCase(OrderGateway orderGateway)
        {
            _orderGateway = orderGateway;
        }

        public static GetPreparingOrdersUseCase Build(OrderGateway orderGateway)
        {
            return new GetPreparingOrdersUseCase(orderGateway);
        }

        public async Task<IEnumerable<Order>> ExecuteAsync()
        {
            return await _orderGateway.GetPreparingAsync();
        }
    }
}
