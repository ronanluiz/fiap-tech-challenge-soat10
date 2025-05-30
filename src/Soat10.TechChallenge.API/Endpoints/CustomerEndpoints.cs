﻿using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Controllers;

namespace Soat10.TechChallenge.API.Endpoints
{
    public static class CustomerEndpoints
    {
        public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/customers", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CustomerRegistrationRequest customerDto) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();

                var controller = CustomerController.Build(dataRepository);

                await controller.CreateCustomer(customerDto);

                return TypedResults.Created();
            })
            .WithName("CreateCustomer")
            .WithSummary("Cria o registro do cliente.")
            .WithDescription("Este endpoint não tem retorno.");

        }
    }
}
