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
    public class UpdateProductUseCase
    {
        private readonly ProductGateway _productGateway;

        private UpdateProductUseCase(ProductGateway productGateway)
        {
            _productGateway = productGateway;
        }

        public static UpdateProductUseCase Build(ProductGateway productGateway) 
        { 
            return new UpdateProductUseCase(productGateway);
        }

        public async Task ExecuteAsync(UpdateProductRequest updateProductRequest, Guid id) 
        {
            Product product = await _productGateway.GetByIdAsync(id);
            product.UpdateProduct(
                updateProductRequest.Name,
                updateProductRequest.ProductCategory,
                updateProductRequest.Price,
                updateProductRequest.TimeToPrepare ?? TimeSpan.Zero,
                updateProductRequest.Description,
                true
                );
            _productGateway.UpdateAsync(product);

        }
    }
}
