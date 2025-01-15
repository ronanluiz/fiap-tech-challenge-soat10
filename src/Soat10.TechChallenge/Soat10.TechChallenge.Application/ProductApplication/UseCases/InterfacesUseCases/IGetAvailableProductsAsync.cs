using Soat10.TechChallenge.Application.ProductApplication.Responses;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases
{
    public interface IGetAvailableProductsAsync
    {
        Task<IEnumerable<GetAllProductResponse>> ExecuteAsync();
    }
}
