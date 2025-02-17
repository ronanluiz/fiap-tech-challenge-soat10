using Soat10.TechChallenge.Application.Dtos;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Gateways;
using Soat10.TechChallenge.Application.Interfaces;
using Soat10.TechChallenge.Application.Presenters;
using Soat10.TechChallenge.Application.Services;
using Soat10.TechChallenge.Application.UseCases.Checkout;
using Soat10.TechChallenge.Application.UseCases.GetOrders;

namespace Soat10.TechChallenge.Application.Controllers
{
    public class OrderController
    {
        private readonly IDataRepository _dataRepository;
        private readonly IExternalService _externalService;

        public OrderController(IDataRepository dataRepository, IExternalService externalService)
        {
            _dataRepository = dataRepository;
            _externalService = externalService;
        }

        public async Task ExecuteOrderCheckoutAsync(CheckoutDto checkoutDto)
        {   
            var paymentGateway = new PaymentGateway(_dataRepository);
            var orderGateway = new OrderGateway(_dataRepository);
            var paymentServiceGateway = new PaymentServiceGateway(_externalService);

            await CheckoutUseCase.ExecuteAsync(checkoutDto.OrderId,
                paymentServiceGateway,
                paymentGateway, 
                orderGateway);            
        }

        public async Task<IJsonPresenter> GetAllOrders()
        {
            var orderGateway = new OrderGateway(_dataRepository);

            IEnumerable<Order> orders = await GetOrdersUseCase.ExecuteAsync(orderGateway);

            var presenter = new JsonPresenter<IEnumerable<Order>>(orders);

            return presenter;
        }
    }
}
