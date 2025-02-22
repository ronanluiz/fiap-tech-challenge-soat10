using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Mappers;
using Soat10.TechChallenge.Application.UseCases.CustomerRegistration;

namespace Soat10.TechChallenge.Application.Controllers
{
    public class CustomerController
    {
        private readonly IDataRepository _dataRepository;

        private CustomerController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public static CustomerController Build(IDataRepository dataRepository)
        {
            return new CustomerController(dataRepository);
        }

        public async Task CreateCustomer(CustomerDto customerDto)
        {
            var customerGateway = CustomerGateway.Build(_dataRepository);

            await CustomerRegistrationUseCase.ExecuteAsync(customerDto, customerGateway);
        }
    }
}
