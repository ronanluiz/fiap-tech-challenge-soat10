using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.UseCases.CustomerUseCases;

namespace Soat10.TechChallenge.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerUseCase _customerRegistrationUseCase;

        public CustomerController(ICustomerUseCase customerRegistrationUseCase)
        {
            _customerRegistrationUseCase = customerRegistrationUseCase ?? throw new ArgumentNullException(nameof(customerRegistrationUseCase));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRequest customerRequest)
        {
            if (customerRequest == null)
            {
                return BadRequest("Invalid customer registration request.");
            }

            try
            {
                await _customerRegistrationUseCase.ExecuteCustomerRegistrationAsync(customerRequest);
                return Ok("Customer registered successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
