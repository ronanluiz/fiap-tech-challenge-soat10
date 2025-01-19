using FluentValidation;
using FluentValidation.Results;
using Soat10.TechChallenge.Application.DTOs;
using Soat10.TechChallenge.Application.Exceptions;
using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Domain.ValueObjects;

namespace Soat10.TechChallenge.Application.UseCases.CustomerUseCases
{
    public class IdentifyUseCase : IIdentifyUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<IdentifyResponse> _searchValidator;

        public IdentifyUseCase(ICustomerRepository customerRepository,
                               IValidator<IdentifyResponse> searchValidator)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _searchValidator = searchValidator ?? throw new ArgumentNullException(nameof(searchValidator));
        }

        public async Task<IdentifyResponse?> ExecuteCustomerSearchByCpfAsync(string cpf)
        {
            var validationResult = _searchValidator.Validate(new IdentifyResponse { Cpf = cpf });
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var customer = await _customerRepository.Get(cpf);

            if (customer == null)
            {
                return null;
            }

            return new IdentifyResponse
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