using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Controllers;

namespace Soat10.TechChallenge.API.Endpoints
{
    public static class CustomerOrderEndpoints
    {
        public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/customers", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CustomerDto customerDto) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();

                var controller = CustomerController.Build(dataRepository);

                await controller.CreateCustomer(customerDto);

                return TypedResults.Created();
            });
        }
    }
}
