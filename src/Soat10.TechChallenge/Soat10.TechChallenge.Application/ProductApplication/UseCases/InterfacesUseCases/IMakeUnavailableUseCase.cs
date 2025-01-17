using Soat10.TechChallenge.Application.ProductApplication.Responses;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases
{
    public interface IMakeUnavailableUseCase
    {
        public Task<ProductResponse> ExecuteAsync(Guid productId);
    }
}
