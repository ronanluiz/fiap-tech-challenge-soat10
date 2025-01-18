using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<int> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);

        Task<IEnumerable<Product>> GetByCategoryAsync(CategoryEnum category);
        Task<IEnumerable<Product>> GetByStatusAsync(ProductStatusEnum status);
        Task<IEnumerable<Product>> GetAvailableProductsAsync();
    }
}
