using Soat10.TechChallenge.Application.Common.Daos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Mappers;

namespace Soat10.TechChallenge.Application.Gateways
{
    public class PaymentGateway(IDataRepository dataRepository,
        IExternalPaymentService externalService)
    {
        private readonly IDataRepository _dataRepository = dataRepository;
        private readonly IExternalPaymentService _externalService = externalService;

        public async Task<Payment> CreateQrCodeOrder(Order order)
        {
            QrCodeOrderDao qrCodeOrderDao = MapperDao.MapToQrCodeOrder(order);

            QrCodeOrderResponseDao qrCodeOrderResponse = await _externalService.CreateQrCodeOrder(qrCodeOrderDao);

            return new Payment(order, order.TotalAmount, qrCodeOrderResponse.Qrdata);
        }

        public async Task<int> AddAsync(Payment payment)
        {
            PaymentDao paymentDto = MapperDao.Map(payment);
            return await _dataRepository.AddPaymentAsync(paymentDto);
        }

        public async Task<Payment> GetByOrder(Guid orderId)
        {
            PaymentDao paymentDao = await _dataRepository.GetPaymentByOrder(orderId);
            
            Payment payment = Mapper.MapToEntity(paymentDao);

            return payment;
        }

        public async Task UpdateAsync(Payment payment)
        {
            PaymentDao paymentDao = MapperDao.Map(payment);

            await _dataRepository.UpdatePaymentAsync(paymentDao);
        }
    }
}
