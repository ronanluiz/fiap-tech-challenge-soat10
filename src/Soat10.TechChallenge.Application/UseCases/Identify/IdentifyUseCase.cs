using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Validators;

namespace Soat10.TechChallenge.Application.UseCases.Identify
{
    public class IdentifyUseCase
    {
        public static async Task<Customer> ExecuteSearchAsync(IdentifyDto identify, CustomerGateway customerGateway)
        {
            var validator = new IdentifyValidator();
            var validationResult = validator.Validate(identify);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            Customer customer = await customerGateway.GetAsync(identify.Cpf);

            if (customer == null)
            {
                throw new ValidationException("Cliente não encontrado");
            }

            return customer;
        }
    }
}