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
    public class DeleteProductUseCase
    {
        private readonly ProductGateway _productGateway;

        private DeleteProductUseCase(ProductGateway productGateway)
        {
            _productGateway = productGateway;
        }

        public static DeleteProductUseCase Build(ProductGateway productGateway) 
        {
            return new DeleteProductUseCase(productGateway);
        }

        public async Task ExecuteAsync(Guid id)
        {
            Product product = await _productGateway.GetByIdAsync(id);
            product.MarkAsUnavailable();
            await _productGateway.UpdateAsync(product);
        }
    }
}
