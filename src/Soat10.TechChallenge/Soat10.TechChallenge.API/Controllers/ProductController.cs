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


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest productRequest)
        {
            return Ok(await _createProduct.ExecuteAsync(productRequest));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _getAllProduct.ExecuteAsync());
        }

        [HttpGet("Availables")]
        public async Task<IActionResult> IGetAvailableProducts()
        {
            return Ok(await _getAvailableProductsAsync.ExecuteAsync());
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(CategoryEnum category)
        {
            return Ok(await _getByCategoryProducts.ExecuteAsync(category));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] Guid productId)
        {
            return Ok(await _getByIdProducts.ExecuteAsync(productId));
        }

        [HttpPut("Update/{productId}")]
        public async Task<IActionResult> Update(Guid productId, [FromBody] CreateProductRequest productRequest)
        {
            return Ok(await _updateProduct.ExecuteAsync(productId, productRequest));
        }

        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> MakeUnavailable(Guid ProductId)
        {
            return Ok(await _makeUnavailableAsync.ExecuteAsync(ProductId));
        }

        [HttpPatch("{productId}/make-available")]
        public async Task<IActionResult> MakeAvailable(Guid ProductId)
        {
            return Ok(await _makeAvailableAsync.ExecuteAsync(ProductId));
        }
    }
}
