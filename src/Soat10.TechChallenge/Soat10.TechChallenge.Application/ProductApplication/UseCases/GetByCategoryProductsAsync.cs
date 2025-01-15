using Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Enums;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases
{
    public class GetByCategoryProductsAsync(IProductRepository productRepository) : IGetByCategoryProductsAsync
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<IEnumerable<GetAllProductResponse>> ExecuteAsync(CategoryEnum category)
        {
            var product = await _productRepository.GetByCategoryAsync(category);
            return product is null ?
                throw new ArgumentNullException(nameof(category)) : product.ProductToGetAllProductResponse();
        }
    }
}
