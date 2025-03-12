using Microsoft.EntityFrameworkCore;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) => _context = context;

        public async Task<ProductDao> GetByIdAsync(int id)
        {
            return await _context.Products
                        .AsNoTracking()
                        .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
