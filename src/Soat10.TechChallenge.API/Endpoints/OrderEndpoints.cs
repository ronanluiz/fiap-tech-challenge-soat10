using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Controllers;

namespace Soat10.TechChallenge.API.Endpoints
{
    public static class OrderEndpoints
    {
        public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/orders", async ([FromServices] IServiceProvider serviceProvider) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                IExternalPaymentService externalService = serviceProvider.GetService<IExternalPaymentService>();

                var controller = OrderController.Build(dataRepository, externalService);

                IEnumerable<OrderDto> orders = await controller.GetAllOrders();

                return TypedResults.Ok(orders);
            });

            app.MapGet("/api/orders/payment-status", async ([FromServices] IServiceProvider serviceProvider, [AsParameters] OrderPaymentStatusRequest paymentStatusRequest) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>() ?? throw new InvalidOperationException("IDataRepository service not found.");
                IExternalPaymentService externalService = serviceProvider.GetService<IExternalPaymentService>() ?? throw new InvalidOperationException("IDataRepository service not found.");

                var controller = OrderController.Build(dataRepository, externalService);

                var paymentStatusResult = await controller.GetOrderByNumber(paymentStatusRequest.OrderNumber);

                return TypedResults.Ok(paymentStatusResult);
            });

            app.MapPost("/api/checkouts", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CheckoutRequest checkout) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                IExternalPaymentService externalService = serviceProvider.GetService<IExternalPaymentService>();

                CheckoutResponse checkoutResponse = await OrderController.Build(dataRepository, externalService)
                                                                        .ExecuteCheckoutAsync(checkout);

                return TypedResults.Ok(checkoutResponse);
            });

            app.MapGet("/api/orders/open", async ([FromServices] IServiceProvider serviceProvider) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                IExternalPaymentService externalService = serviceProvider.GetService<IExternalPaymentService>();

                var controller = OrderController.Build(dataRepository, externalService);

                IEnumerable<OpenOrdersResponse> orders = await controller.GetOpenOrders();

                return TypedResults.Ok(orders);
            });

            app.MapPatch("/api/orders/{orderId}/status", async ([FromServices] IServiceProvider serviceProvider, Guid orderId) =>
            {
                IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
                IExternalPaymentService externalService = serviceProvider.GetService<IExternalPaymentService>();

                var controller = OrderController.Build(dataRepository, externalService);

                var result = await controller.UpdateOrderStatusAsync(orderId);

                if (result == null)
                    return Results.BadRequest("Invalid status transition.");

                return Results.Ok(result);
            });

        }
    }
}
