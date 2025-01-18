using Soat10.TechChallenge.Application.ProductApplication.ExtensionsProducts;
using Soat10.TechChallenge.Application.ProductApplication.Requests;
using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Interfaces;


namespace Soat10.TechChallenge.Application.ProductApplication.UseCases
{
    public class CreateProductUseCase(IProductRepository productRepository) : ICreateProductUseCase
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<ProductResponse> ExecuteAsync(ProductRequest productRequest)
        {
            var product = productRequest.CreateProductRequestToProduct();
            var productCreated = await _productRepository.AddAsync(product);

            if (productCreated == 1)
            {
                return product.ProductToCreateProductResponse();
            }
            else
            {
                throw new Exception("Error ao criar Produto");
            }
        }
    }
}
