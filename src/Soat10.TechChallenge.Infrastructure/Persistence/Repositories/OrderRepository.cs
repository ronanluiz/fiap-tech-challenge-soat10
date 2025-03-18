using Bogus;
using Microsoft.EntityFrameworkCore;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) => _context = context;

        public async Task<OrderDao> GetByIdAsync(int id)
        {
            return await _context.Orders
                        .AsNoTracking()
                        .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(OrderDao order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderDao>> GetAllAsync()
        {
            return await _context.Orders
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OrderDao> GetOrderByNumber(int orderNumber)
        {
            return await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(order => order.OrderNumber == orderNumber);
        }
    }
}
