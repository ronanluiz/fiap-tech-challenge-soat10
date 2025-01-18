using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Enums;
using Soat10.TechChallenge.Domain.Interfaces;
using System.Text.Json;

namespace Soat10.TechChallenge.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryTemp : IProductRepository
    {
        private readonly string _filePath;

        public ProductRepositoryTemp(string filePath)
        {
            _filePath = filePath;

            // Cria o arquivo caso não exista
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]"); // Inicializa como uma lista vazia
            }
        }

        private async Task<List<Product>> LoadFromFileAsync()
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        private async Task SaveToFileAsync(List<Product> products)
        {
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            var products = await LoadFromFileAsync();
            return products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await LoadFromFileAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var products = await LoadFromFileAsync();
            var index = products.FindIndex(p => p.Id == product.Id);
            if (index >= 0)
            {
                products[index] = product;
                await SaveToFileAsync(products);
            }
        }

        public async Task DeleteAsync(Product product)
        {
            var products = await LoadFromFileAsync();
            products.RemoveAll(p => p.Id == product.Id);
            await SaveToFileAsync(products);
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(CategoryEnum category)
        {
            var products = await LoadFromFileAsync();
            return products.Where(p => p.ProductCategory == category).ToList();
        }

        public async Task<IEnumerable<Product>> GetByStatusAsync(ProductStatusEnum status)
        {
            var products = await LoadFromFileAsync();
            return products.Where(p => p.Status == status).ToList();
        }

        public async Task<IEnumerable<Product>> GetAvailableProductsAsync()
        {
            var products = await LoadFromFileAsync();
            return products.Where(p => p.IsAvailable).ToList();
        }

        public async Task<int> AddAsync(Product product)
        {

            var products = await LoadFromFileAsync();
            products.Add(product);
            await SaveToFileAsync(products);
            return products.Count;
        }
    }
}
