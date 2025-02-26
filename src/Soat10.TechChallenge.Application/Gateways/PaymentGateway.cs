using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class PaymentGateway
    {
        private readonly IDataRepository _dataRepository;

        public PaymentGateway(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<int> AddAsync(Payment payment)
        {
            PaymentDao paymentDto = Mapper.MapToDao(payment);
            return await _dataRepository.AddPaymentAsync(paymentDto);
        }        
    }
}
