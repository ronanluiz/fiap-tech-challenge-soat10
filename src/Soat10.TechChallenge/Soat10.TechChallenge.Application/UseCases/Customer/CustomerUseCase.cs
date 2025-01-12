using FluentValidation;
using FluentValidation.Results;
using Soat10.TechChallenge.Application.DTOs;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Domain.ValueObjects;

namespace Soat10.TechChallenge.Application.UseCases.CustomerUseCases
{
    public class CustomerUseCase : ICustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<CustomerRegistrationRequest> _registrationValidator;
        private readonly IValidator<CustomerSearchRequest> _searchValidator;

        public CustomerUseCase(ICustomerRepository customerRepository,
                               IValidator<CustomerSearchRequest> searchValidator,
                               IValidator<CustomerRegistrationRequest> registrationValidator)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _searchValidator = searchValidator ?? throw new ArgumentNullException(nameof(searchValidator));
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

        public async Task<CustomerResponseDto?> ExecuteCustomerSearchByCpfAsync(string cpf)
        {
            var validationResult = _searchValidator.Validate(new CustomerSearchRequest { Cpf = cpf });
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var customer = await _customerRepository.GetByCpf(cpf);

            if (customer == null)
            {
                return null;
            }

            return new CustomerResponseDto
            {
                Id = customer.Id,
                CreatedAt = customer.CreatedAt,
                Name = customer.Name,
                Email = customer.Email.Address,
                Cpf = customer.Cpf.Number,
                Status = customer.Status
            };
        }
    }
}