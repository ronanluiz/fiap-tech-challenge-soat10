using Microsoft.EntityFrameworkCore;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) => _context = context;

        public async Task<int> AddAsync(CustomerDao customer)
        {
            await _context.Customers.AddAsync(customer);
            return await _context.SaveChangesAsync();
        }

        public async Task<CustomerDao> Get(string cpf)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Cpf == cpf);
        }

        public async Task<CustomerDao> GetByIdAsync(Guid id)
        {
            return await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
