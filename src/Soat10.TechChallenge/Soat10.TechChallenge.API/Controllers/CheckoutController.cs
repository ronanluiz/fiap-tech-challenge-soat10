using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.UseCases.Checkout;

namespace Soat10.TechChallenge.API.Controllers
{
    [Route("api/checkouts")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutUseCase _checkoutUseCase;

        public CheckoutController(ICheckoutUseCase checkoutUseCase)
        {
            _checkoutUseCase = checkoutUseCase;
        }

        [HttpPost]
        public async Task<ActionResult> Checkout([FromBody] CheckoutRequest checkoutRequest)
        {
            await _checkoutUseCase.ExecuteOrderCheckoutAsync(checkoutRequest);

            return Ok(checkoutRequest);
        }
    }
}
