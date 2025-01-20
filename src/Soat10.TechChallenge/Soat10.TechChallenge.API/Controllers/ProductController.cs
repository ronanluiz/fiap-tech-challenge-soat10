using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.ProductApplication.Requests;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController(
        ICreateProductUseCase createProduct,
        IGetAllProductUseCase getAllProduct,
        IGetByIdProductsUseCase getByIdProducts,
        IGetByCategoryProductsUseCase getByCategoryProducts,
        IUpdateProductUseCase updateProduct,
        IMakeUnavailableUseCase makeUnavailableAsync,
         IMakeAvailableUseCase makeAvailableAsync,
          IGetAvailableProductsUseCase getAvailableProductsAsync
        ) : ControllerBase
    {
        private readonly ICreateProductUseCase _createProduct = createProduct;
        private readonly IGetAllProductUseCase _getAllProduct = getAllProduct;
        private readonly IGetByIdProductsUseCase _getByIdProducts = getByIdProducts;
        private readonly IGetByCategoryProductsUseCase _getByCategoryProducts = getByCategoryProducts;
        private readonly IUpdateProductUseCase _updateProduct = updateProduct;
        private readonly IMakeUnavailableUseCase _makeUnavailableAsync = makeUnavailableAsync;
        private readonly IMakeAvailableUseCase _makeAvailableAsync = makeAvailableAsync;
        private readonly IGetAvailableProductsUseCase _getAvailableProductsAsync = getAvailableProductsAsync;


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRequest productRequest)
        {
            return Ok(await _createProduct.ExecuteAsync(productRequest));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(CategoryEnum? category)
        {
            if (category.HasValue)
            {
                return Ok(await _getByCategoryProducts.ExecuteAsync(category.Value));
            }
            else
            {
                return Ok(await _getAllProduct.ExecuteAsync());
            }
        }

        [HttpGet("availables")]
        public async Task<IActionResult> IGetAvailableProducts()
        {
            return Ok(await _getAvailableProductsAsync.ExecuteAsync());
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById(int productId)
        {
            return Ok(await _getByIdProducts.ExecuteAsync(productId));
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Update(int productId, [FromBody] ProductRequest productRequest)
        {
            return Ok(await _updateProduct.ExecuteAsync(productId, productRequest));
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> MakeUnavailable(int productId)
        {
            return Ok(await _makeUnavailableAsync.ExecuteAsync(productId));
        }

        [HttpPatch("{productId}/make-available")]
        public async Task<IActionResult> MakeAvailable(int productId)
        {
            return Ok(await _makeAvailableAsync.ExecuteAsync(productId));
        }
    }
}
