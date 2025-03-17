namespace Soat10.TechChallenge.Application.UseCases.GetStatusOrders
{
    public interface IGetStatusOrders
    {
        Task<IEnumerable<GetStatusOrdersResponse>> GetOrdersAsync();
    }
}
