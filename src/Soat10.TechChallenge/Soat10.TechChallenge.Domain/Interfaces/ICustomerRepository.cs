using Soat10.TechChallenge.Domain.Aggregates.CostumerAggregate;

namespace Soat10.TechChallenge.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> Add(Customer customer);
    }
}
