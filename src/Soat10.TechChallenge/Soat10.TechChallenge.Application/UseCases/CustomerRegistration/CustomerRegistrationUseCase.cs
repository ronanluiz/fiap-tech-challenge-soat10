using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace Soat10.TechChallenge.Application.UseCases.CustomerRegistration
{
    public class CustomerRegistrationUseCase : ICustomerRegistrationUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRegistrationUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task ExecuteCustomerRegistrationAsync(CustomerRegistrationRequest customerRegistrationRequest)
        {
            if (customerRegistrationRequest == null)
            {
                throw new ArgumentNullException(nameof(customerRegistrationRequest));
            }

            var customer = new Customer(
                customerRegistrationRequest.CustomerId,
                customerRegistrationRequest.Name);

            customer.SetEmail(new Email(customerRegistrationRequest.Email));
            customer.SetCpf(new Cpf(customerRegistrationRequest.Cpf));

            await _customerRepository.Add(customer);
        }
    }
}
