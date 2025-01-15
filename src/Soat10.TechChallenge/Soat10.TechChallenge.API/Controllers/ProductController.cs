using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.ProductApplication.Requests;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(
        ICreateProductAsync createProduct,
        IGetAllProductAsync getAllProduct,
        IGetByIdProductsAsync getByIdProducts,
        IGetByCategoryProductsAsync getByCategoryProducts,
        IUpdateProductAsync updateProduct,
        IMakeUnavailableAsync makeUnavailableAsync,
         IMakeAvailableAsync makeAvailableAsync,
          IGetAvailableProductsAsync getAvailableProductsAsync
        ) : ControllerBase
    {
        private readonly ICreateProductAsync _createProduct = createProduct;
        private readonly IGetAllProductAsync _getAllProduct = getAllProduct;
        private readonly IGetByIdProductsAsync _getByIdProducts = getByIdProducts;
        private readonly IGetByCategoryProductsAsync _getByCategoryProducts = getByCategoryProducts;
        private readonly IUpdateProductAsync _updateProduct = updateProduct;

        private readonly IMakeUnavailableAsync _makeUnavailableAsync = makeUnavailableAsync;
        private readonly IMakeAvailableAsync _makeAvailableAsync = makeAvailableAsync;
        private readonly IGetAvailableProductsAsync _getAvailableProductsAsync = getAvailableProductsAsync;


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

        [HttpGet("IGetAvailableProductsAsync")]
        public async Task<IActionResult> IGetAvailableProducts()
        {
            return Ok(await _getAvailableProductsAsync.ExecuteAsync());
        }


        [HttpGet("GetByCategory/{category}")]
        public async Task<IActionResult> GetByCategory(CategoryEnum category)
        {
            return Ok(await _getByCategoryProducts.ExecuteAsync(category));
        }

        [HttpGet("GetById/{productId}")]
        public async Task<IActionResult> GetById(Guid productId)
        {
            return Ok(await _getByIdProducts.ExecuteAsync(productId));
        }

        [HttpPut("Update/{productId}")]
        public async Task<IActionResult> Update(Guid productId, [FromBody] CreateProductRequest productRequest)
        {
            return Ok(await _updateProduct.ExecuteAsync(productId, productRequest));
        }

        [HttpDelete("MakeUnavailableAsync/{ProductId}")]
        public async Task<IActionResult> MakeUnavailable(Guid ProductId)
        {
            return Ok(await _makeUnavailableAsync.ExecuteAsync(ProductId));
        }

        [HttpPatch("MakeAvailableAsync/{ProductId}")]
        public async Task<IActionResult> MakeAvailable(Guid ProductId)
        {
            return Ok(await _makeAvailableAsync.ExecuteAsync(ProductId));
        }


        [HttpGet("Healthcheck")]
        public string HealthCheck()
        {
            return "OK";
        }
    }
}
