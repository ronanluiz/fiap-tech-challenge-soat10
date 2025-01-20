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

        public Task<int> AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<IEnumerable<Product>> GetAvailableProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(CategoryEnum category)
        {
            return await _context.Products.Where(product => product.ProductCategory == category).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
        }

        public Task<IEnumerable<Product>> GetByStatusAsync(ProductStatusEnum status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
