using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases.ProductsUseCases
{
    public class GetProductsUseCase
    {
        private readonly ProductGateway _productGateway;

        private GetProductsUseCase(ProductGateway productGateway)
        {
            _productGateway = productGateway;
        }

        public static GetProductsUseCase Build(ProductGateway productGateway) 
        {
            return new GetProductsUseCase(productGateway);
        }

        public async Task<IEnumerable<Product>> ExecuteAsync()
        {
            return await _productGateway.GetAllAsync();
        }
    }
}
