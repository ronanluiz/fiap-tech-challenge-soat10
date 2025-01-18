using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Enums;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<int> AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAvailableProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetByCategoryAsync(CategoryEnum category)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
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
