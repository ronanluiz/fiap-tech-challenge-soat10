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

        public async Task<OrderDao> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                        .AsNoTracking()
                        .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(OrderDao order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(OrderDao orderDao)
        {
            var current = _context.Orders.Local.FirstOrDefault(e => e.Id == orderDao.Id);
            if (current != null)
            {
                _context.Entry(current).State = EntityState.Detached;
            }
            _context.Update(orderDao);
            var saveChanges = await _context.SaveChangesAsync();

            return saveChanges;
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
