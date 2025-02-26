using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class ProductGateway
    {
        private readonly IDataRepository _dataRepository;

        public ProductGateway(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<ProductDao?> GetByIdAsync(int id)
        {
            var product = await _dataRepository.GetProductByIdAsync(id);
            return product;
        }

        public async Task<IEnumerable<ProductDao>> GetAllAsync()
        {
            var products = await _dataRepository.GetAllProductsAsync();
            return products;
        }

        public async Task<int> AddAsync(ProductDao product)
        {   
            return await _dataRepository.AddProductAsync(product);
        }

        public async Task UpdateAsync(ProductDao product)
        {   
            await _dataRepository.UpdateProductAsync(product);
        }

        public async Task DeleteAsync(ProductDao product)
        {   
            await _dataRepository.DeleteProductAsync(product);
        }

        public async Task<IEnumerable<ProductDao>> GetByCategoryAsync(string category)
        {
            var products = await _dataRepository.GetProductsByCategoryAsync(category);
            return products;
        }

        public async Task<IEnumerable<ProductDao>> GetByStatusAsync(string status)
        {
            var products = await _dataRepository.GetProductsByStatusAsync(status);
            return products;
        }

        public async Task<IEnumerable<ProductDao>> GetAvailableProductsAsync()
        {
            var products = await _dataRepository.GetAvailableProductsAsync();
            return products;
        }
    }
    
    
}
