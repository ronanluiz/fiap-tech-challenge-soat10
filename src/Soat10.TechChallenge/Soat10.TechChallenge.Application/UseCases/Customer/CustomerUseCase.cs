using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Domain.ValueObjects;

namespace Soat10.TechChallenge.Application.UseCases.CustomerUseCases
{
    public class CustomerUseCase : ICustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task ExecuteCustomerRegistrationAsync(CustomerRegistrationRequest customerRequest)
        {
            if (customerRequest == null)
            {
                throw new ArgumentNullException(nameof(customerRequest));
            }

            Customer customer = new Customer(
                customerRequest.Name);

            customer.SetEmail(new Email(customerRequest.Email));
            customer.SetCpf(new Cpf(customerRequest.Cpf));

            try
            {
                await _customerRepository.Add(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }
    }
}