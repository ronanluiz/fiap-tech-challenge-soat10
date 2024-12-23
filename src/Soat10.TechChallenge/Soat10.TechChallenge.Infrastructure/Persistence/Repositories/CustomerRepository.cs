using Soat10.TechChallenge.Domain.Aggregates.CostumerAggregate;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        int ICustomerRepository.Add(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
