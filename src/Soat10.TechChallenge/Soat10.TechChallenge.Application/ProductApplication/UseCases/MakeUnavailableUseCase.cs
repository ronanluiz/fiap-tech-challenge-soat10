using Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases
{
    public class MakeAvailableUseCase(IProductRepository productRepository, IGetByIdProductsUseCase getByIdProducts) : IMakeAvailableUseCase
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IGetByIdProductsUseCase _getByIdProducts = getByIdProducts;

        public async Task<ProductResponse> ExecuteAsync(Guid productId)
        {
            var product = await _getByIdProducts.ExecuteAsync(productId);
            if (product.QuantityInStock == 0) throw new ArgumentException("Quantidade de produto no estoque insuficiente para tornar produto disponivel");
            var productUpdated = product.UpdateProductAttributesToCreateProductResponse();
            productUpdated.MarkAsAvailable();
            productUpdated.UpdateAuditInfo("Usuario não identificado");
            await _productRepository.UpdateAsync(productUpdated);
            return productUpdated.ProductToCreateProductResponse();
        }
    }
}
