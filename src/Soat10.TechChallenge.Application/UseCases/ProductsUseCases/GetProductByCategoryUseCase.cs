using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases.ProductsUseCases
{
    public class GetProductByCategoryUseCase
    {
        private readonly ProductGateway _productGateway;

        private GetProductByCategoryUseCase(ProductGateway productGateway)
        {
            _productGateway = productGateway;
        }

        public static GetProductByCategoryUseCase Build(ProductGateway productGateway) 
        {
            return new GetProductByCategoryUseCase(productGateway);
        }

        public async Task<IEnumerable<Product>> ExecuteAsync(CategoryEnum? category)
        {
            return await _productGateway.GetByCategoryAsync(category.ToString());
        }
    }
}
