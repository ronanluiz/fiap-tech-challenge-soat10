using NSubstitute;
using Assert = Xunit.Assert;
using Soat10.TechChallenge.Domain.Entities;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Domain.Enums;
using Soat10.TechChallenge.Application.UseCases.GetOrders;

namespace Soat10.TechChallenge.Application.Tests.UseCases.Order;

public class OrderUseCaseTest
{
    private IOrderRepository _mockOrderRepository;
    private GetOrdersUseCase _orderUseCase;
    private Customer _mockCustomer1;
    private Customer _mockCustomer2;
    private Customer _mockCustomer3;
    private List<OrderItem> _mockOrderItems;

    public OrderUseCaseTest()
    {
        _mockOrderRepository = Substitute.For<IOrderRepository>();
        _orderUseCase = new GetOrdersUseCase(_mockOrderRepository);
        
        _mockCustomer1 = new Customer(1, "Jessica");
        _mockCustomer2 = new Customer(2, "Matheus");
        _mockCustomer3 = new Customer(3, "Vitor");
        _mockOrderItems =
        [
            new OrderItem(new Product("Hamburger"), 2, "sem cebola"),
            new OrderItem(new Product("Coca Cola G"), 2, ""),
            new OrderItem(new Product("Casquinha Mista"), 1, "")
        ];
    }

    [Fact]
    public async Task GetOrdersAsync_ShouldReturnOrders_WhenRepositoryHasOrders()
    {
        IEnumerable<Domain.Entities.Order> mockOrders = new List<Domain.Entities.Order>
        {
            new (OrderStatus.Preparing, _mockCustomer1, _mockCustomer1.Id, _mockOrderItems, new decimal(40)),
            new (OrderStatus.Preparing, _mockCustomer2, _mockCustomer2.Id, _mockOrderItems, new decimal(57)),
            new (OrderStatus.Ready, _mockCustomer3, _mockCustomer3.Id, _mockOrderItems, new decimal(25)),
        };
        
        _mockOrderRepository.GetAllAsync().Returns(Task.FromResult(mockOrders));

        var result = await _orderUseCase.GetOrdersAsync();

        Assert.NotNull(result);
        var orders = result.ToList();
        Assert.Equal(3, orders.Count);
        Assert.Equal("Hamburger x2 (sem cebola), Coca Cola G x2, Casquinha Mista x1", orders[1].Items);

        await _mockOrderRepository.Received(1).GetAllAsync();
    }

    [Fact]
    public async Task GetOrdersAsync_ShouldReturnEmptyList_WhenNoOrders()
    {
        IEnumerable<Domain.Entities.Order> emptyOrders = new List<Domain.Entities.Order>();

        _mockOrderRepository.GetAllAsync().Returns(Task.FromResult(emptyOrders));

        var result = await _orderUseCase.GetOrdersAsync();

        Assert.NotNull(result);
        Assert.Empty(result);

        await _mockOrderRepository.Received(1).GetAllAsync();
    }
}