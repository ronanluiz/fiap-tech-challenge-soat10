using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Presenters;
using Soat10.TechChallenge.Application.UseCases;

namespace Soat10.TechChallenge.Application.Controllers
{
    public class IdentityController
    {
        private readonly IDataRepository _dataRepository;

        private IdentityController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public static IdentityController Build(IDataRepository dataRepository)
        {
            return new IdentityController(dataRepository);
        }

        public async Task<IdentifyResponse> GetIdentity(string cpf)
        {
            var customerGateway = new CustomerGateway(_dataRepository);

            var request = new IdentifyRequest() { Cpf = cpf };

            Customer customer = await IdentifyUseCase.Build(customerGateway)
                                                     .ExecuteAsync(request);

            return IdentityPresenter.Build(customer);
        }
    }
}
