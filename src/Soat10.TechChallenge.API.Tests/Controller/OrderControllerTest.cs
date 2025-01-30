using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Domain.Entities;
using Assert = Xunit.Assert;
using Soat10.TechChallenge.Domain.Enums;
using Soat10.TechChallenge.Application.UseCases.GetOrders;

namespace Soat10.TechChallenge.API.Tests.Controller;

public class OrderControllerTest
{
    private OrderController _controller;
    private IGetOrdersUseCase _mockOrderUseCase;
    
    private Customer _mockCustomer1;
    private Customer _mockCustomer2;
    private Customer _mockCustomer3;
    private List<OrderItem> _mockOrderItems;

    public OrderControllerTest()
    {
        _mockOrderUseCase = Substitute.For<IGetOrdersUseCase>();
        _controller = new OrderController(_mockOrderUseCase);
        
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
    public async Task GetAll_ShouldReturnOkResult_WithListOfOrders()
    {
        var mockOrders = new List<Order>
        {
            new (OrderStatus.Preparing, _mockCustomer1, _mockCustomer1.Id, _mockOrderItems, new decimal(40)),
            new (OrderStatus.Preparing, _mockCustomer2, _mockCustomer2.Id, _mockOrderItems, new decimal(57)),
            new (OrderStatus.Ready, _mockCustomer3, _mockCustomer3.Id, _mockOrderItems, new decimal(25)),
        };

        var mockResponse = GetOrdersExtensions.OrdersToOrderResponse(mockOrders);

        _mockOrderUseCase.GetOrdersAsync().Returns(Task.FromResult(mockResponse));

        var result = await _controller.GetAll();

        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult?.StatusCode);

        var orders = okResult?.Value as List<GetOrdersResponse>;
        Assert.NotNull(orders); 
        Assert.Equal(3, orders?.Count); 
        Assert.Equal("Hamburger x2 (sem cebola), Coca Cola G x2, Casquinha Mista x1", orders[1].Items);

        await _mockOrderUseCase.Received(1).GetOrdersAsync();
    }

    [Fact]
    public async Task GetAll_ShouldReturnOkResult_WithEmptyList_WhenNoOrders()
    {
        IEnumerable<GetOrdersResponse> emptyOrders = new List<GetOrdersResponse>();

        _mockOrderUseCase.GetOrdersAsync().Returns(Task.FromResult(emptyOrders));

        var result = await _controller.GetAll();

        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult); 
        Assert.Equal(200, okResult?.StatusCode); 

        var orders = okResult?.Value as List<Order>;
        Assert.NotNull(orders); 
        Assert.Empty(orders); 

        await _mockOrderUseCase.Received(1).GetOrdersAsync();
    }
}