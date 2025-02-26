using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.UseCases.CustomerRegistration
{
    public class CustomerRegistrationUseCase
    {
        private readonly CustomerGateway _customerGateway;

        private CustomerRegistrationUseCase(CustomerGateway customerGateway)
        {
            _customerGateway = customerGateway;
        }

        public static CustomerRegistrationUseCase Build(CustomerGateway customerGateway)
        {
            return new CustomerRegistrationUseCase(customerGateway);
        }

        public async Task ExecuteAsync(CustomerDto customerDto)
        {
            Customer customerExists = await _customerGateway.GetAsync(customerDto.Cpf);
            if (customerExists != null)
            {
                throw new NotAllowedException($"Cliente com o CPF {customerDto.Cpf} já está cadastrado.");
            }
            Customer customer = Mapper.MapToEntity(customerDto);
            await _customerGateway.AddAsync(customer);
        }
    }
}