using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.UseCases.GetOrders;

[Route("/api/orders")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IGetOrdersUseCase _getOrdersUseCase;

    public OrderController(IGetOrdersUseCase getOrdersUseCase)
    {
        _getOrdersUseCase = getOrdersUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ordersAsync = await _getOrdersUseCase.GetOrdersAsync();
        return Ok(ordersAsync);
    }
}
