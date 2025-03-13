using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Presenters;
using Soat10.TechChallenge.Application.UseCases;
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

        public async Task ExecuteCheckoutAsync(CheckoutRequest checkoutRequest)
        {
            var cartGateway = new CartGateway(_dataRepository);
            var paymentGateway = new PaymentGateway(_dataRepository);
            var orderGateway = new OrderGateway(_dataRepository);
            var paymentServiceGateway = new PaymentServiceGateway(_externalPaymentService);

            await CheckoutUseCase.Build(cartGateway, paymentServiceGateway, paymentGateway, orderGateway)
                                    .ExecuteAsync(checkoutRequest);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orderGateway = new OrderGateway(_dataRepository);

            IEnumerable<Order> orders = await GetOrdersUseCase.Build(orderGateway).ExecuteAsync();

            IEnumerable<OrderDto> ordersResult = OrderPresenter.Build(orders);

            return ordersResult;
        }
    }
}
