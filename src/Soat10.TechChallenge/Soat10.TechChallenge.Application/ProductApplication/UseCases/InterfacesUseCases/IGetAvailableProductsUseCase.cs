using Soat10.TechChallenge.Application.ProductApplication.Responses;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases
{
    public interface IGetAvailableProductsUseCase
    {
        Task<IEnumerable<GetAllProductResponse>> ExecuteAsync();
    }
}
