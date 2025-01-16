using Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases
{
    public class GetAvailableProductsUseCase(IProductRepository productRepository) : IGetAvailableProductsUseCase
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<IEnumerable<GetAllProductResponse>> ExecuteAsync()
        {
            var products = await _productRepository.GetAvailableProductsAsync();
            return products.ProductToGetAllProductResponse();
        }
    }
}
