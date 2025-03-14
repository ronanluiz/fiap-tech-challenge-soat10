using Microsoft.EntityFrameworkCore;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class CartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context) => _context = context;

        public async Task<CartDao> GetByIdAsync(Guid id)
        {
            return await _context.Carts
                        .AsNoTracking()
                        .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddAsync(CartDao cartDao)
        {
            cartDao.Customer = null;
            await _context.Carts.AddAsync(cartDao);
            await _context.SaveChangesAsync();
        }

        public async Task AddAsync(CartItemDao cartItemDao)
        {
            await _context.CartItems.AddAsync(cartItemDao);
            await _context.SaveChangesAsync();
        }
    }
}
