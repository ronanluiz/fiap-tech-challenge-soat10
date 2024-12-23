using Soat10.TechChallenge.Domain.Aggregates.CostumerAggregate;

namespace Soat10.TechChallenge.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        int Add(Customer customer);
    }
}
