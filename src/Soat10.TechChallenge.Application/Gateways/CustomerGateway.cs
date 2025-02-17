using Soat10.TechChallenge.Application.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;
using Soat10.TechChallenge.Application.Daos;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class CustomerGateway
    {
        private readonly IDataRepository _dataRepository;

        public CustomerGateway(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
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
