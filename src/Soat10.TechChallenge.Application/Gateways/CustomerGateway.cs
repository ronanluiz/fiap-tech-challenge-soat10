using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class CustomerGateway
    {
        private readonly IDataRepository _dataRepository;

        private CustomerGateway(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public static CustomerGateway Build(IDataRepository dataRepository)
        {
            return new CustomerGateway(dataRepository);
        }
        
        public async Task<int> AddAsync(Customer customer)
        {
            CustomerDao customerDto = Mapper.MapToDao(customer);

            return await _dataRepository.AddCustomerAsync(customerDto);
        }

        public async Task<Customer> GetAsync(string cpf)
        {
            var customerDto = await _dataRepository.GetCustomerAsync(cpf);

            Customer customer = Mapper.MapToEntity(customerDto);

            return customer;
        }
    }
}
