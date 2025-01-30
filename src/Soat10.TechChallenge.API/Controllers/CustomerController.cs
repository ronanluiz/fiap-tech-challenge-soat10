using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.UseCases.CustomerRegistration;

namespace Soat10.TechChallenge.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRegistrationUseCase _customerRegistrationUseCase;

        public CustomerController(ICustomerRegistrationUseCase customerRegistrationUseCase)
        {
            _customerRegistrationUseCase = customerRegistrationUseCase ?? throw new ArgumentNullException(nameof(customerRegistrationUseCase));
        }
        /// <summary>
        ///  Permite o cadastro de novos clientes no sistema.
        /// </summary>
        /// <param name="customerRegistrationRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegistrationRequest customerRegistrationRequest)
        {
            await _customerRegistrationUseCase.ExecuteCustomerRegistrationAsync(customerRegistrationRequest);
            return Ok("Customer registered successfully.");
        }
    }
}
