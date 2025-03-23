using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Presenters;
using Soat10.TechChallenge.Application.UseCases.ProductsUseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.Controllers
{
    public class ProductController
    {
        private readonly IDataRepository _datarepository;
        private ProductController(IDataRepository datarepository)
        {
            _datarepository = datarepository;
        }

        public static ProductController Build(IDataRepository datarepository)
        {
            return new ProductController(datarepository);
        }
        public async Task<IEnumerable<GetProductResponse>> GetProducts()
        {
            ProductGateway productGateway = new ProductGateway(_datarepository);
            IEnumerable<Product> product = await GetProductsUseCase.Build(productGateway).ExecuteAsync();
            return ProductPresenter.ProductsPresenterGeneric(product);
        }

        public async Task<GetProductResponse> GetProductById(Guid id)
        {
            ProductGateway productGateway = new ProductGateway(_datarepository);
            Product product = await GetProductByIdUseCase.Build(productGateway).ExecuteAsync(id);
            return ProductPresenter.ProductPresenterClient(product);
        }

        public async Task DeleteProduct(Guid id)
        {
            ProductGateway productGateway = new ProductGateway(_datarepository);
            await DeleteProductUseCase.Build(productGateway).ExecuteAsync(id);
        }

        public async Task<IEnumerable<GetProductResponse>> GetProductByCategory(CategoryEnum? category)
        {
            ProductGateway productGateway = new ProductGateway(_datarepository);
            IEnumerable<Product> product = await GetProductByCategoryUseCase.Build(productGateway).ExecuteAsync(category);
            return ProductPresenter.ProductsPresenterClient(product);
        }

        public async Task<Guid> CreateProduct(CreateProductRequest createProductRequest)
        {
            ProductGateway productGateway = new ProductGateway(_datarepository);
            return await CreateProductUseCase.Build(productGateway).ExecuteAsync(createProductRequest);
        }

        public async Task UpdateProduct(UpdateProductRequest updateProductRequest, Guid id)
        {
            ProductGateway productGateway = new ProductGateway(_datarepository);
            await UpdateProductUseCase.Build(productGateway).ExecuteAsync(updateProductRequest, id);
        }
    }
}
