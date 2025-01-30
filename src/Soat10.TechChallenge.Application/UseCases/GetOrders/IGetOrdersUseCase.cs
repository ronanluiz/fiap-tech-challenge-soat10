namespace Soat10.TechChallenge.Application.UseCases.GetOrders
{
    public interface IGetOrdersUseCase
    {
        Task<IEnumerable<GetOrdersResponse>> GetOrdersAsync();
    }
}
