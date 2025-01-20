using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.UseCases.GetOrders
{
    public class GetOrdersUseCase : IGetOrdersUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<GetOrdersResponse>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return orders.OrdersToOrderResponse();
        }
    }
}