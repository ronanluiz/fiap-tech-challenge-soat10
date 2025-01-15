using Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts;
using Soat10.TechChallenge.Application.ProductApplication.Requests;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases
{
    public class UpdateProductAsync(IProductRepository productRepository, IGetByIdProductsAsync getByIdProducts) : IUpdateProductAsync
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IGetByIdProductsAsync _getByIdProducts = getByIdProducts;

        public async Task<CreateProductResponse> ExecuteAsync(Guid productId, CreateProductRequest productRequest)
        {
            var product = await _getByIdProducts.ExecuteAsync(productId);
            var productUpdated = product.UpdateProductAttributesToCreateProductResponse(productRequest);
            productUpdated.UpdateAuditInfo("Usuario não identificado");
            await _productRepository.UpdateAsync(productUpdated);
            return productUpdated.ProductToCreateProductResponse();
        }
    }
}
