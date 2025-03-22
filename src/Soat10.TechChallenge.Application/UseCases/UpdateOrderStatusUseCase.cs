using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;
using Soat10.TechChallenge.Application.Gateways;

internal class UpdateOrderStatusUseCase
{
    private readonly OrderGateway _orderGateway;

    private UpdateOrderStatusUseCase(OrderGateway orderGateway)
    {
        _orderGateway = orderGateway;
    }

    public static UpdateOrderStatusUseCase Build(OrderGateway orderGateway)
    {
        return new UpdateOrderStatusUseCase(orderGateway);
    }

    public async Task<Order> ExecuteAsync(Guid orderId)
    {
        var order = await _orderGateway.GetByIdAsync(orderId);
        if (order == null)
            return null;

        var validTransitions = new List<OrderStatus>
        {
            OrderStatus.Received,
            OrderStatus.Preparing,
            OrderStatus.Ready,
            OrderStatus.Finished
        };

        var currentStatus = order.Status;
        int currentIndex = validTransitions.IndexOf(currentStatus);

        if (currentIndex == -1 || currentIndex == validTransitions.Count - 1)
            return null;

        OrderStatus nextStatus = validTransitions[currentIndex + 1];

        order.ChangeStatus(nextStatus);
        await _orderGateway.UpdateAsync(order);

        return order;
    }
}
