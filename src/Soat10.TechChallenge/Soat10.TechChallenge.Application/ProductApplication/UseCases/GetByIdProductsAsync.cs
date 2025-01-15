using Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases
{
    public class GetByIdProductsAsync(IProductRepository productRepository) : IGetByIdProductsAsync
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<CreateProductResponse> ExecuteAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return product is null ?
                throw new ArgumentNullException(nameof(productId)) : product.ProductToCreateProductResponse();
        }
    }
}
