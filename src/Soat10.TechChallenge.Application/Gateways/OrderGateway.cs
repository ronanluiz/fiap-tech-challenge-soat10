using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class OrderGateway
    {
        private readonly IDataRepository _dataRepository;        

        public OrderGateway(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            OrderDao orderDao = await _dataRepository.GetOrderByIdAsync(id);

            Order order = Mapper.MapToEntity(orderDao);

            return order;
        }

        public async Task UpdateAsync(Order order)
        {
            OrderDao orderDto = Mapper.MapToDao(order);
            await _dataRepository.UpdateOrderAsync(orderDto);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            IEnumerable<OrderDao> orders = await _dataRepository.GetAllOrdersAsync();
            IList<Order> ordersReturn = new List<Order>();

            foreach(OrderDao order in orders)
            {
                ordersReturn.Add(Mapper.MapToEntity(order));
            }

            return ordersReturn;
        }
    }
}
