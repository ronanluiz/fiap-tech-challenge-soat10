using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Presenters;
using Soat10.TechChallenge.Application.UseCases;

namespace Soat10.TechChallenge.Application.Controllers
{
    public class PaymentController
    {
        private readonly IDataRepository _dataRepository;
        private readonly IExternalPaymentService _externalPaymentService;

        private PaymentController(IDataRepository dataRepository, IExternalPaymentService externalPaymentService)
        {
            _dataRepository = dataRepository;
            _externalPaymentService = externalPaymentService;
        }

        public static PaymentController Build(IDataRepository dataRepository, IExternalPaymentService externalService)
        {
            return new PaymentController(dataRepository, externalService);
        }

        public async Task ProcessPaymentNotifications(PaymentNotificationRequest paymentNotificationRequest)
        {
            var paymentGateway = new PaymentGateway(_dataRepository, _externalPaymentService);
            var orderGateway = new OrderGateway(_dataRepository);

            await NotificationPaymentUseCase.Build(paymentGateway, orderGateway)
                                             .ExecuteAsync(paymentNotificationRequest);    
        }
    }
}
