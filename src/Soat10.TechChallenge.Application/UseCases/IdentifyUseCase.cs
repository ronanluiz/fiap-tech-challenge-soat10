using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Validators;

namespace Soat10.TechChallenge.Application.UseCases
{
    public class IdentifyUseCase
    {
        private readonly CustomerGateway _customerGateway;

        private IdentifyUseCase(CustomerGateway customerGateway)
        {
            _customerGateway = customerGateway;
        }

        public static IdentifyUseCase Build(CustomerGateway customerGateway)
        {
            return new IdentifyUseCase(customerGateway);
        }

        public async Task<Customer> ExecuteAsync(IdentifyRequest identify)
        {
            var validator = new IdentifyValidator();
            var validationResult = validator.Validate(identify);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            Customer customer = await _customerGateway.GetAsync(identify.Cpf);

            return customer == null ? throw new ValidationException("Cliente não encontrado") : customer;
        }
    }
}