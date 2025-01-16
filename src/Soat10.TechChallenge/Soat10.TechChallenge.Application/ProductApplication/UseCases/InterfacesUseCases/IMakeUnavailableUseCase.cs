using Soat10.TechChallenge.Application.ProductApplication.Responses;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases
{
    public interface IMakeUnavailableUseCase
    {
        public Task<CreateProductResponse> ExecuteAsync(Guid productId);
    }
}
