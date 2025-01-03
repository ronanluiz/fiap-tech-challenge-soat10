using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.UseCases.CustomerRegistration;
using Soat10.TechChallenge.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.API.Controllers
{
    [Route("api/ustomerRegistration")]
    [ApiController]
    public class CustomerRegistrationController : ControllerBase
    {
        private readonly ICustomerRegistrationUseCase _customerRegistrationUseCase;

        public CustomerRegistrationController(ICustomerRegistrationUseCase customerRegistrationUseCase)
        {
            _customerRegistrationUseCase = customerRegistrationUseCase ?? throw new ArgumentNullException(nameof(customerRegistrationUseCase));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegistrationRequest customerRegistrationRequest)
        {
            if (customerRegistrationRequest == null)
            {
                return BadRequest("Invalid customer registration request.");
            }

            try
            {
                await _customerRegistrationUseCase.ExecuteCustomerRegistrationAsync(customerRegistrationRequest);
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
