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

        public async Task<Order> GetByIdAsync(Guid id)
        {
            OrderDao orderDao = await _dataRepository.GetOrderByIdAsync(id);

            Order order = Mapper.MapToEntity(orderDao);

            return order;
        }

        public async Task<Order> AddAsync(Order order)
        {
            OrderDao orderDao = MapperDao.Map(order);
            await _dataRepository.AddOrderAsync(orderDao);
            orderDao = await _dataRepository.GetOrderByIdAsync(order.Id);

            return Mapper.MapToEntity(orderDao);
        }
        public async Task UpdateAsync(Order order)
        {
            OrderDao orderDao = MapperDao.Map(order);
            orderDao.Items = [];
            await _dataRepository.UpdateOrderAsync(orderDao);
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

        public async Task<Order> GetOrderByNumber(int orderNumber)
        {
            OrderDao orderDao = await _dataRepository.GetOrderByNumberAsync(orderNumber);

            Order order = Mapper.MapToEntity(orderDao);

            return order;
        }
    }
}
