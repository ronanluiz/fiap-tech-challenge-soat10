using Soat10.TechChallenge.Application.UseCases.GetOrders;

namespace Soat10.TechChallenge.Application.UseCases.GetPreparingOrders
{
    public interface IGetStatusOrders
    {
        Task<IEnumerable<GetOrdersResponse>> GetOrdersAsync();
    }
}
