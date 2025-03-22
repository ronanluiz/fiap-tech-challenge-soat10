using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;
using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;

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
            CustomerDao customerDto = MapperEntity.MapToDao(customer);

            return await _dataRepository.AddCustomerAsync(customerDto);
        }

        public async Task<Customer> GetAsync(string cpf)
        {
            CustomerDao customerDto = await _dataRepository.GetCustomerAsync(cpf);

            Customer customer = MapperEntity.MapToEntity(customerDto);

            return customer;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            CustomerDao customerDto = await _dataRepository.GetCustomerByIdAsync(id);

            Customer customer = MapperEntity.MapToEntity(customerDto);

            return customer;
        }
    }
}
