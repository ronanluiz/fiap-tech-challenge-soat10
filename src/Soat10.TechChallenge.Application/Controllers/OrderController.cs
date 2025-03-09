using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Presenters;
using Soat10.TechChallenge.Application.UseCases.Checkout;
using Soat10.TechChallenge.Application.UseCases.GetOrders;
using Soat10.TechChallenge.Application.UseCases.GetPreparingOrders;
using Soat10.TechChallenge.Application.UseCases.GetStatusOrdersUseCase;

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
            var paymentGateway = new PaymentGateway(_dataRepository);
            var orderGateway = new OrderGateway(_dataRepository, _externalPaymentService);
            var paymentServiceGateway = new PaymentServiceGateway(_externalPaymentService);

            await CheckoutUseCase.Build(paymentServiceGateway, paymentGateway, orderGateway)
                                    .ExecuteAsync(checkoutDto.OrderId);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orderGateway = new OrderGateway(_dataRepository, _externalPaymentService);

            IEnumerable<Order> orders = await GetOrdersUseCase.Build(orderGateway).ExecuteAsync();

            IEnumerable<OrderDto> ordersResult = OrderPresenter.Build(orders);

            return ordersResult;
        }

        public async Task<IEnumerable<OrderStatusDto>> GetStatusOrders()
        {
            var orderGateway = new OrderGateway(_dataRepository, _externalPaymentService);

            IEnumerable<Order> orders = await GetStatusOrdersUseCase.Build(orderGateway).ExecuteAsync();

            IEnumerable<OrderStatusDto> ordersResult = OrderStatusPresenter.Build(orders);

            return ordersResult;
        }
    }
}
