using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Soat10.TechChallenge.API.Middlewares;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Controllers;
using Soat10.TechChallenge.Application.Validators;
using Soat10.TechChallenge.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureEnviroment();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();

ConfigureLog(builder);

builder.Services.AddFluentValidationAutoValidation(); // Adiciona validação automática com FluentValidation
builder.Services.AddFluentValidationClientsideAdapters(); // (opcional) Adiciona validação no cliente

// Registra todos os validadores encontrados no assembly do projeto Application
builder.Services.AddValidatorsFromAssemblyContaining<OrderValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Soat 10 Tech Challenge - Api Fast Food",
        Version = "v1",
        Description = "Api Fast Food é um sistema de autoatendimento de fast food projetado para gerenciar clientes, produtos e pedidos, além de facilitar o processo de checkout e acompanhamento dos pedidos"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

builder.Services.AddFluentValidationRulesToSwagger(); // Integração com Swagger

ApplicationBootstrapper.Register(builder.Services);
InfrastructureBootstrapper.Register(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapPost("/api/checkouts", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CheckoutDto checkout) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
    IExternalPaymentService externalService = serviceProvider.GetService<IExternalPaymentService>();

    var controller = OrderController.Build(dataRepository, externalService);

    await controller.ExecuteOrderCheckoutAsync(checkout);

    return TypedResults.Ok();
});

app.MapGet("/api/orders", async ([FromServices] IServiceProvider serviceProvider) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
    IExternalPaymentService externalService = serviceProvider.GetService<IExternalPaymentService>();

    var controller = OrderController.Build(dataRepository, externalService);

    IEnumerable<OrderDto> orders = await controller.GetAllOrders();

    return TypedResults.Ok(orders);
});

app.MapPost("/api/customers", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CustomerDto customerDto) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();

    var controller = CustomerController.Build(dataRepository);

    await controller.CreateCustomer(customerDto);

    return TypedResults.Created();
});

app.MapPost("/api/carts/items", async ([FromServices] IServiceProvider serviceProvider, [FromBody] List<AddingItemCartRequest> addingItemsCart) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();

    var controller = CartController.Build(dataRepository);

    AddingItemCartResponse addingItemCartResponse = await controller.AddItemsCartAsync(addingItemsCart);

    return TypedResults.Ok(addingItemCartResponse);
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

static void ConfigureEnviroment()
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