using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;

namespace Soat10.TechChallenge.Application.UseCases.GetOrders
{
    public class GetOrdersUseCase
    {
        public static async Task<IEnumerable<Order>> ExecuteAsync(OrderGateway orderGateway)
        {
            return await orderGateway.GetAllAsync();
        }
    }
}