using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases.ProductsUseCases
{
    public class CreateProductUseCase
    {
        private readonly ProductGateway _productGateway;

        private CreateProductUseCase(ProductGateway productGateway)
        {
            _productGateway = productGateway;
        }
        public static CreateProductUseCase Build(ProductGateway productGateway)
        {
            return new CreateProductUseCase(productGateway);
        }

        public async Task<Guid> ExecuteAsync(CreateProductRequest createProductRequest)
        {
            Product product = new Product
                (
                createProductRequest.Id,
                createProductRequest.Name,
                createProductRequest.ProductCategory,
                createProductRequest.Price,
                createProductRequest.TimeToPrepare ?? TimeSpan.Zero,
                createProductRequest.Description,
                true
                );
            return await _productGateway.AddAsync(product);
        }
    }
}
