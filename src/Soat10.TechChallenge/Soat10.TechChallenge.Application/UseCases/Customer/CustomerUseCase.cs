using FluentValidation;
using FluentValidation.Results;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Domain.ValueObjects;

namespace Soat10.TechChallenge.Application.UseCases.CustomerUseCases
{
    public class CustomerUseCase : ICustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<CustomerRegistrationRequest> _validator;

        public CustomerUseCase(ICustomerRepository customerRepository, IValidator<CustomerRegistrationRequest> validator)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task ExecuteCustomerRegistrationAsync(CustomerRegistrationRequest customerRequest)
        {
            ValidationResult result = _validator.Validate(customerRequest);
            if (!result.IsValid)
            {
                throw new Exceptions.ValidationException(result.Errors.Select(e => e.ErrorMessage));
            }

            Customer customer = new Customer(customerRequest.Name);
            customer.SetEmail(new Email(customerRequest.Email));
            customer.SetCpf(new Cpf(customerRequest.Cpf));

            try
            {
                await _customerRepository.Add(customer);
            }
            catch (Exception ex)
            {
                if (ex.InnerException?.Message.Contains("unique constraint") ?? ex.Message.Contains("UNIQUE constraint failed"))
                {
                    throw new NotAllowedException($"Customer with CPF {customerRequest.Cpf} already exists.");
                }

                throw new ApplicationException("An error occurred while registering the customer.", ex);
            }

        }
    }
}