using Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts;
using Soat10.TechChallenge.Application.ProductApplication.Requests;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases
{
    public class UpdateProductUseCase(IProductRepository productRepository, IGetByIdProductsUseCase getByIdProducts) : IUpdateProductUseCase
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IGetByIdProductsUseCase _getByIdProducts = getByIdProducts;

        public async Task<ProductResponse> ExecuteAsync(Guid productId, ProductRequest productRequest)
        {
            var product = await _getByIdProducts.ExecuteAsync(productId);
            var productUpdated = product.UpdateProductAttributesToCreateProductResponse(productRequest);
            productUpdated.UpdateAuditInfo("Usuario não identificado");
            await _productRepository.UpdateAsync(productUpdated);
            return productUpdated.ProductToCreateProductResponse();
        }
    }
}
