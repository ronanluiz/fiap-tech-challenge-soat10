using Soat10.TechChallenge.Domain.Entities;

namespace Soat10.TechChallenge.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
        Task UpdateAsync(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
    }
}
