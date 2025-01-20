using Soat10.TechChallenge.Application.ProductApplication.Requests;
using Soat10.TechChallenge.Application.ProductApplication.Responses;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases
{
    public interface IUpdateProductUseCase
    {
        public Task<ProductResponse> ExecuteAsync(int productId, ProductRequest productRequest);
    }
}
