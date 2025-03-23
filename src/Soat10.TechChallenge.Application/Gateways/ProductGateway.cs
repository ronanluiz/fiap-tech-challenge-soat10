using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;
using System.Collections.Generic;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class ProductGateway
    {
        private readonly IDataRepository _dataRepository;

        public ProductGateway(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            ProductDao productDao = await _dataRepository.GetProductByIdAsync(id);
            if(productDao is null) throw new ArgumentNullException($"Não foi encontrado o produto para o ID {id}");
            Product product = MapperEntity.MapToEntity(productDao);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IEnumerable<ProductDao> productsDao = await _dataRepository.GetAllProductsAsync();
            IList<Product> products = new List<Product>();

            foreach (ProductDao productDao in productsDao)
            {
                products.Add(MapperEntity.MapToEntity(productDao));
            }
            return products;
        }

        public async Task<Guid> AddAsync(Product product)
        {
            ProductDao productDao = MapperEntity.MapToDao(product);
            return await _dataRepository.AddProductAsync(productDao);
        }

        public async Task UpdateAsync(Product product)
        {
            ProductDao productDao = MapperEntity.MapToDao(product);
            await _dataRepository.UpdateProductAsync(productDao);
        }

        public async Task DeleteAsync(Product product)
        {
            ProductDao productDao = MapperEntity.MapToDao(product);
            await _dataRepository.DeleteProductAsync(productDao);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
        {
            IEnumerable<ProductDao> productsDao = await _dataRepository.GetProductsByCategoryAsync(category);

            IList<Product> products = new List<Product>();

            foreach (ProductDao productDao in productsDao)
            {
                products.Add(MapperEntity.MapToEntity(productDao));
            }
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
