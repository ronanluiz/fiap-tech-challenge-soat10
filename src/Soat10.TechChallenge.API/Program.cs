using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.API.Middlewares;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Application.Controllers;
using Soat10.TechChallenge.Application.Dtos;
using Soat10.TechChallenge.Application.Interfaces;
using Soat10.TechChallenge.Application.Services;
using Soat10.TechChallenge.Application.Validators;
using Soat10.TechChallenge.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

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

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();


//builder.Services.AddControllers(); // Mantém os controladores registrados
builder.Services.AddFluentValidationAutoValidation(); // Adiciona validação automática com FluentValidation
builder.Services.AddFluentValidationClientsideAdapters(); // (opcional) Adiciona validação no cliente


// Registra todos os validadores encontrados no assembly do projeto Application
builder.Services.AddValidatorsFromAssemblyContaining<OrderValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( config =>
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

//app.UseAuthorization();

//app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapPost("/api/checkouts", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CheckoutDto checkout) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
    IExternalService externalService = serviceProvider.GetService<IExternalService>();

    var controller = new Soat10.TechChallenge.Application.Controllers.OrderController(dataRepository, externalService);

    await controller.ExecuteOrderCheckoutAsync(checkout);

    return TypedResults.Ok();
});

app.MapGet("/api/orders", async ([FromServices] IServiceProvider serviceProvider) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
    IExternalService externalService = serviceProvider.GetService<IExternalService>();

    var controller = new OrderController(dataRepository, externalService);

    IJsonPresenter jsonPresenter = await controller.GetAllOrders();

    return TypedResults.Ok(jsonPresenter.GetPresenter());
});

app.MapPost("/api/customers", async ([FromServices] IServiceProvider serviceProvider, [FromBody] CustomerDto customerDto) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();

    var controller = new CustomerController(dataRepository);

    await controller.CreateCustomer(customerDto);

    return TypedResults.Created();
});

await app.RunAsync();
