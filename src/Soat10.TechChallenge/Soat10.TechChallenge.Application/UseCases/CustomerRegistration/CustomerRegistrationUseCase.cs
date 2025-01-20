using FluentValidation;
using FluentValidation.Results;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Domain.ValueObjects;
using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Application.UseCases.Identify;


namespace Soat10.TechChallenge.Application.UseCases.CustomerRegistration
{
    public class CustomerRegistrationUseCase : ICustomerRegistrationUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<CustomerRegistrationRequest> _registrationValidator;

        public CustomerRegistrationUseCase(ICustomerRepository customerRepository,
                               IValidator<CustomerRegistrationRequest> registrationValidator)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _registrationValidator = registrationValidator ?? throw new ArgumentNullException(nameof(registrationValidator));
        }

        public async Task ExecuteCustomerRegistrationAsync(CustomerRegistrationRequest customerRequest)
        {
            ValidationResult result = _registrationValidator.Validate(customerRequest);
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
                    throw new NotAllowedException($"Cliente com o CPF {customerRequest.Cpf} já está cadastrado.");
                }

                throw new ApplicationException("Ocorreu um erro durante o cadastro do cliente.", ex);
            }
        }
    }
}