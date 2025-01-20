using Soat10.TechChallenge.Domain.Entities;

namespace Soat10.TechChallenge.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> Add(Customer customer);
        Task<Customer?> Get(string cpf);
    }
}
