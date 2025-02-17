using Soat10.TechChallenge.Application.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Interfaces;
using Soat10.TechChallenge.Application.Mappers;
using Soat10.TechChallenge.Application.UseCases.CustomerRegistration;

namespace Soat10.TechChallenge.Application.Controllers
{
    public class CustomerController
    {
        private readonly IDataRepository _dataRepository;

        public CustomerController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task CreateCustomer(CustomerDto customerDto)
        {
            var customerGateway = new CustomerGateway(_dataRepository);

            await CustomerRegistrationUseCase.ExecuteAsync(customerDto, customerGateway);
        }
    }
}
