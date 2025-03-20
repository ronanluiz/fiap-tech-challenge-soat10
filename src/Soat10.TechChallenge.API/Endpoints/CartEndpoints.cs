using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Controllers;

namespace Soat10.TechChallenge.API.Endpoints
{
    public static class CartEndpoints
    {
        public static void MapCartEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/carts", async ([FromServices] IServiceProvider serviceProvider, CartCreationRequest cartCreationRequest) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();

                CartCreationResponse cartCreationResponse = await CartController.Build(dataRepository)
                                                                .CreateCartAsync(cartCreationRequest);

                return TypedResults.Ok(cartCreationResponse);
            });

            app.MapPost("/api/carts/{id}/items", async ([FromServices] IServiceProvider serviceProvider, Guid id, [FromBody] List<AddingItemCartRequest> addingItemsCart) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();

                AddingItemCartResponse addingItemCartResponse = await CartController.Build(dataRepository)
                                                                .AddItemsCartAsync(id, addingItemsCart);

                return TypedResults.Ok(addingItemCartResponse);
            });

            app.MapGet("/api/carts/{id}", async ([FromServices] IServiceProvider serviceProvider, Guid id) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();

                CartResponse cartResponse = await CartController.Build(dataRepository)
                                                                .GetCartByIdAsync(id);

                return TypedResults.Ok(cartResponse);
            });
        }
    }
}
