using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Soat10.TechChallenge.API.Middlewares;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Common.Responses;
using Soat10.TechChallenge.Application.Controllers;
using Soat10.TechChallenge.Application.Validators;
using Soat10.TechChallenge.Infrastructure;
using Soat10.TechChallenge.Infrastructure.ExternalServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureEnviroment(builder);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();

ConfigureLog(builder);

builder.Services.AddFluentValidationAutoValidation(); // Adiciona valida��o autom�tica com FluentValidation
builder.Services.AddFluentValidationClientsideAdapters(); // (opcional) Adiciona valida��o no cliente

// Registra todos os validadores encontrados no assembly do projeto Application
builder.Services.AddValidatorsFromAssemblyContaining<OrderValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Soat 10 Tech Challenge - Api Fast Food",
        Version = "v1",
        Description = "Api Fast Food � um sistema de autoatendimento de fast food projetado para gerenciar clientes, produtos e pedidos, al�m de facilitar o processo de checkout e acompanhamento dos pedidos"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

builder.Services.AddFluentValidationRulesToSwagger(); // Integra��o com Swagger

ApplicationBootstrapper.Register(builder.Services);
InfrastructureBootstrapper.Register(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapPost("/api/customers", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CustomerDto customerDto) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();

    var controller = CustomerController.Build(dataRepository);

    await controller.CreateCustomer(customerDto);

    return TypedResults.Created();
});

app.MapPost("/api/checkouts", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CheckoutRequest checkout) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
    IExternalPaymentService externalService = serviceProvider.GetService<IExternalPaymentService>();

    CheckoutResponse checkoutResponse = await OrderController.Build(dataRepository, externalService)
                                                            .ExecuteCheckoutAsync(checkout);

    return TypedResults.Ok(checkoutResponse);
});

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

await app.RunAsync();

static void ConfigureLog(WebApplicationBuilder builder)
{
    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();

    builder.Services.AddSerilog();
}

static void ConfigureEnviroment(WebApplicationBuilder builder)
{
    var rootPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../.."));
    var envFilePath = Path.Combine(rootPath, ".env");

    if (File.Exists(envFilePath))
    {
        DotNetEnv.Env.Load(envFilePath); // Carregar o arquivo .env
        Console.WriteLine($"Arquivo .env carregado do caminho: {envFilePath}");
    }
    else
    {
        Console.WriteLine($"Arquivo .env não encontrado no caminho: {envFilePath}");
    }
}