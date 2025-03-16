using Microsoft.EntityFrameworkCore;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class OrderProductRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderProductDao>> GetOrdersFromViewAsync()
        {
            return await _context.OrderProducts
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
