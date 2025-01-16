using Soat10.TechChallenge.Application.ProductApplication.Requests;
using Soat10.TechChallenge.Application.ProductApplication.Responses;

namespace Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases
{
    public interface ICreateProductUseCase
    {
        public Task<CreateProductResponse> ExecuteAsync(CreateProductRequest productRequest);

    }
}
