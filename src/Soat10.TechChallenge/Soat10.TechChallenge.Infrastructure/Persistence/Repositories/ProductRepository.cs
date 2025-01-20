using Microsoft.EntityFrameworkCore;
using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Enums;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class ProductRepository (ApplicationDbContext DbContext) : IProductRepository
    {
        private readonly ApplicationDbContext _context = DbContext;

        public async Task<int> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAvailableProductsAsync()
        {
            return await _context.Products.Where(product => product.IsAvailable).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(CategoryEnum category)
        {
            return await _context.Products.Where(product => product.ProductCategory == category).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
        }

        public Task<IEnumerable<Product>> GetByStatusAsync(ProductStatusEnum status)
        {
            throw new NotImplementedException();
        }

        public async  Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
