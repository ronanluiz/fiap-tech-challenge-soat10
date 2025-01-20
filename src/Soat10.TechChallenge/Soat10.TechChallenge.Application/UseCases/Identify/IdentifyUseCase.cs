using FluentValidation;
using Soat10.TechChallenge.Domain.Interfaces;

namespace Soat10.TechChallenge.Application.UseCases.Identify
{
    public class IdentifyUseCase : IIdentifyUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<IdentifyRequest> _identifyRequestValidator;

        public IdentifyUseCase(ICustomerRepository customerRepository,
                               IValidator<IdentifyRequest> identifyRequestValidator)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _identifyRequestValidator = identifyRequestValidator ?? throw new ArgumentNullException(nameof(identifyRequestValidator));
        }

        public async Task<IdentifyResponse?> ExecuteSearchAsync(string cpf)
        {
            var validationResult = _identifyRequestValidator.Validate(new IdentifyRequest { Cpf = cpf });
            if (!validationResult.IsValid)
            {
                throw new Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage));
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