using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) => _context = context;

        public async Task<int> Add(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            return await _context.SaveChangesAsync();
        }
    }
}
