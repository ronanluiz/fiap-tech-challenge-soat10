using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Presenters;
using Soat10.TechChallenge.Application.UseCases.Checkout;
using Soat10.TechChallenge.Application.UseCases.GetOrders;

namespace Soat10.TechChallenge.Application.Controllers
{
    public class OrderController
    {
        private readonly IDataRepository _dataRepository;
        private readonly IExternalPaymentService _externalPaymentService;

        private OrderController(IDataRepository dataRepository, IExternalPaymentService externalPaymentService)
        {
            _dataRepository = dataRepository;
            _externalPaymentService = externalPaymentService;
        }

        public static OrderController Build(IDataRepository dataRepository, IExternalPaymentService externalService)
        {
            return new OrderController(dataRepository, externalService);
        }

        public async Task ExecuteOrderCheckoutAsync(CheckoutDto checkoutDto)
        {   
            var paymentGateway = PaymentGateway.Build(_dataRepository);
            var orderGateway = OrderGateway.Build(_dataRepository, _externalPaymentService);
            var paymentServiceGateway = new PaymentServiceGateway(_externalPaymentService);

            await CheckoutUseCase.ExecuteAsync(checkoutDto.OrderId,
                paymentServiceGateway,
                paymentGateway,
                orderGateway);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orderGateway = OrderGateway.Build(_dataRepository, _externalPaymentService);

            IEnumerable<Order> orders = await GetOrdersUseCase.ExecuteAsync(orderGateway);

            IEnumerable<OrderDto> ordersResult = OrderPresenter.Build(orders);

            return ordersResult;
        }
    }
}
