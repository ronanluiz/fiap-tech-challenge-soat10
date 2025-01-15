using Soat10.TechChallenge.Application.ProductApplication.Responses;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases
{
    public interface IGetByIdProductsAsync
    {
        public Task<CreateProductResponse> ExecuteAsync(Guid productId);
    }
}
