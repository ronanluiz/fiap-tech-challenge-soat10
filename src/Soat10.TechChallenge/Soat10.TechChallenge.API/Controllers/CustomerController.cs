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
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegistrationRequest customerRegistrationRequest)
        {
            await _customerRegistrationUseCase.ExecuteCustomerRegistrationAsync(customerRegistrationRequest);
            return Ok("Customer registered successfully.");
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetCustomerByCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return BadRequest(new { Message = "O CPF deve ser informado." });
            }

            var customer = await _customerRegistrationUseCase.ExecuteCustomerSearchByCpfAsync(cpf);

            if (customer == null)
            {
                return NotFound(new { Message = $"Nenhum cliente encontrado com o CPF {cpf}." });
            }

            return Ok(customer);
        }
    }
}
