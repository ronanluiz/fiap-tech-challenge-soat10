using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class GetOrdersUseCase
    {
        private readonly OrderGateway _orderGateway;

        private GetOrdersUseCase(OrderGateway orderGateway)
        {
            _orderGateway = orderGateway;
        }

        public static GetOrdersUseCase Build(OrderGateway orderGateway)
        {
            return new GetOrdersUseCase(orderGateway);
        }

        public async Task<IEnumerable<Order>> ExecuteAsync()
        {
            return await _orderGateway.GetAllAsync();
        }
    }
}