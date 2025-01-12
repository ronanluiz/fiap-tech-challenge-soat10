using Soat10.TechChallenge.Application.DTOs;

namespace Soat10.TechChallenge.Application.UseCases.CustomerUseCases
{
    public interface ICustomerUseCase
    {
        Task ExecuteCustomerRegistrationAsync(CustomerRegistrationRequest customerRequest);
        Task<CustomerResponseDto?> ExecuteCustomerSearchByCpfAsync(string cpf);
    }
}