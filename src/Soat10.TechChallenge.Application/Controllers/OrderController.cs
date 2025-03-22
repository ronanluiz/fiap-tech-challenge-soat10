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

        public async Task<CheckoutResponse> ExecuteCheckoutAsync(CheckoutRequest checkoutRequest)
        {
            var cartGateway = new CartGateway(_dataRepository);
            var paymentGateway = new PaymentGateway(_dataRepository, _externalPaymentService);
            var orderGateway = new OrderGateway(_dataRepository);
            var paymentServiceGateway = new PaymentServiceGateway(_externalPaymentService);

            Payment payment = await CheckoutUseCase.Build(cartGateway, paymentServiceGateway, paymentGateway, orderGateway)
                                                    .ExecuteAsync(checkoutRequest);

            return OrderPresenter.Build(payment);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orderGateway = new OrderGateway(_dataRepository);

            IEnumerable<Order> orders = await GetOrdersUseCase.Build(orderGateway).ExecuteAsync();

            IEnumerable<OrderDto> ordersResult = OrderPresenter.Build(orders);

            return ordersResult;
        }

        public async Task<OrderPaymentStatusResponse> GetOrderByNumber(int orderNumber)
        {
            var orderGateway = new OrderGateway(_dataRepository);
            var paymentGateway = new PaymentGateway(_dataRepository, _externalPaymentService);

            Order order = await GetOrderPaymentStatusUseCase.Build(orderGateway).ExecuteAsync(orderNumber);
            Payment payment = await GetPaymentByOrderIdUseCase.Build(paymentGateway).ExecuteAsync(order.Id);

            OrderPaymentStatusResponse orderPaymentStatusResponse = OrderPresenter.Present(order, payment);

            return orderPaymentStatusResponse;
        }

        public async Task<IEnumerable<OpenOrdersResponse>> GetOpenOrders()
        {
            var orderGateway = new OrderGateway(_dataRepository);
            IEnumerable<Order> orders = await GetOpenOrdersUseCase.Build(orderGateway)
                                                                    .ExecuteAsync();

            return OrderPresenter.BuildOpenOrders(orders);
        }

        public async Task<OrderStatusResponse> UpdateOrderStatusAsync(Guid orderId)
        {
            var orderGateway = new OrderGateway(_dataRepository);

            var order = await UpdateOrderStatusUseCase.Build(orderGateway)
                                                      .ExecuteAsync(orderId);

            if (order == null)
                return null;

            return OrderPresenter.Build(order);
        }
    }
}
