using Microsoft.EntityFrameworkCore;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) => _context = context;

        public async Task<ProductDao> GetByIdAsync(Guid id)
        {
            return await _context.Products
                        .AsNoTracking()
                        .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<ProductDao>> GetByCategoryAsync(string category)
        {
            return  _context.Products
                        .AsNoTracking()
                        .Where(o => o.ProductCategory.ToString().ToUpper() == category.ToUpper());
        }
        public async Task<IEnumerable<ProductDao>> GetAllProductsAsync()
        {
            return await _context
                            .Products
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<Guid> AddProductAsync(ProductDao product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
        public async Task DeleteProductAsync(ProductDao product)
        {

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(ProductDao product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
