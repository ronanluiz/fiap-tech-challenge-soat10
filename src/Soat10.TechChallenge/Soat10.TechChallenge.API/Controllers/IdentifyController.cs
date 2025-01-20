using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.UseCases.Identify;

namespace Soat10.TechChallenge.API.Controllers
{
    [Route("api/identify")]
    [ApiController]
    public class IdentifyController : Controller
    {
        private readonly IIdentifyUseCase _identifyUseCase;

        public IdentifyController(IIdentifyUseCase identifyUseCase)
        {
            _identifyUseCase = identifyUseCase ?? throw new ArgumentNullException(nameof(identifyUseCase));
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetCustomerByCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return BadRequest(new { Message = "O CPF deve ser informado." });
            }

            var customer = await _identifyUseCase.ExecuteSearchAsync(cpf);

            if (customer == null)
            {
                return NotFound(new { Message = $"Nenhum cliente encontrado com o CPF {cpf}." });
            }

            return Ok(customer);
        }
    }
}
