using Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases
{
    public class MakeUnavailableAsync(IProductRepository productRepository, IGetByIdProductsAsync getByIdProducts) : IMakeUnavailableAsync
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IGetByIdProductsAsync _getByIdProducts = getByIdProducts;

        public async Task<CreateProductResponse> ExecuteAsync(Guid productId)
        {
            var product = await _getByIdProducts.ExecuteAsync(productId);
            var productUpdated = product.UpdateProductAttributesToCreateProductResponse();
            productUpdated.MarkAsUnavailable();
            productUpdated.UpdateAuditInfo("Usuario não identificado");
            await _productRepository.UpdateAsync(productUpdated);
            return productUpdated.ProductToCreateProductResponse();
        }
    }
}
