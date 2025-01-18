using Soat10.TechChallenge.Application.ProductApplication.Responses;
using Soat10.TechChallenge.Domain.Enums;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases
{
    public interface IGetByCategoryProductsUseCase
    {
        Task<IEnumerable<ProductResponse>> ExecuteAsync(CategoryEnum category);
    }
}
