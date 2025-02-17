using Soat10.TechChallenge.Application.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.UseCases.CustomerRegistration
{
    public class CustomerRegistrationUseCase
    {
        public static async Task ExecuteAsync(CustomerDto customerDto,
            CustomerGateway customerGateway)
        {
            Customer customerExists = await customerGateway.GetAsync(customerDto.Cpf);
            if (customerExists != null)
            {
                throw new NotAllowedException($"Cliente com o CPF {customerDto.Cpf} já está cadastrado.");
            }
            Customer customer = Mapper.MapToEntity(customerDto);
            await customerGateway.AddAsync(customer);
        }
    }
}