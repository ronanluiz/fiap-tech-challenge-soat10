using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Controllers;
using Soat10.TechChallenge.Application.Entities;
using Soat10.TechChallenge.Application.Enums;

namespace Soat10.TechChallenge.API.Endpoints
{
    public static class ProducterEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/products", async ([FromServices] IServiceProvider serviceProvider) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                IEnumerable<GetProductResponse> productsResponse = await ProductController.Build(dataRepository).GetProducts();
                return TypedResults.Ok(productsResponse);
            });

            app.MapGet("api/products/{id}", async ([FromServices] IServiceProvider serviceProvider, Guid id) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                GetProductResponse productsResponse = await ProductController.Build(dataRepository).GetProductById(id);
                return TypedResults.Ok(productsResponse);
            });

            app.MapDelete("api/products/{id}", async ([FromServices] IServiceProvider serviceProvider, Guid id) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                await ProductController.Build(dataRepository).DeleteProduct(id);
                return TypedResults.Ok();
            });

            app.MapGet("api/products/by-category/{category}", async ([FromServices] IServiceProvider serviceProvider, CategoryEnum? category) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                IEnumerable<GetProductResponse> productsResponse = await ProductController.Build(dataRepository).GetProductByCategory(category);
                return TypedResults.Ok(productsResponse);
            });

            app.MapPost("api/products", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CreateProductRequest createProduct) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                Guid id = await ProductController.Build(dataRepository).CreateProduct(createProduct);
                return TypedResults.Ok(id);
            });

            app.MapPut("api/products/{id}", async ([FromServices] IServiceProvider serviceProvider, Guid id, [FromBody] UpdateProductRequest createProduct) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                await ProductController.Build(dataRepository).UpdateProduct(createProduct, id);
                return TypedResults.Ok();
            });

        }
    }
}
