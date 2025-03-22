using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases.ProductsUseCases
{
    public class GetProductByIdUseCase
    {
        private readonly ProductGateway _productGateway;

        private GetProductByIdUseCase(ProductGateway productGateway)
        {
            _productGateway = productGateway;
        }

        public static GetProductByIdUseCase Build(ProductGateway productGateway) 
        {
            return new GetProductByIdUseCase(productGateway);
        }

        public async Task<Product> ExecuteAsync(Guid id)
        {
            return await _productGateway.GetByIdAsync(id);
        }
    }
}
