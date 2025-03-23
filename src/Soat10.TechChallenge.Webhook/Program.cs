using Microsoft.AspNetCore.Mvc;
using Serilog;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Common.Requests;
using Soat10.TechChallenge.Application.Controllers;
using Soat10.TechChallenge.Infrastructure;
using Soat10.TechChallenge.Webhook.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureEnviroment();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();

ConfigureLog(builder);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Soat 10 Tech Challenge - Webhook",
        Version = "v1",
        Description = "Webhook responsável por receber triggers externas relacionadas às integraçãoes do sistema de autoatendimento de fast food"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

ApplicationBootstrapper.Register(builder.Services);
InfrastructureBootstrapper.Register(builder.Services, builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/webhook/hc");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapPost("/webhook/payment-notifications", async (
    [FromServices] IServiceProvider serviceProvider,
    [FromBody] PaymentNotificationRequest paymentNotificationRequest) =>
{
    IDataRepository dataRepository = serviceProvider.GetService<IDataRepository>();
    IExternalPaymentService externalService = serviceProvider.GetService<IExternalPaymentService>();

    await PaymentController.Build(dataRepository, externalService)
                           .ProcessPaymentNotifications(paymentNotificationRequest);

    return TypedResults.Ok();
});

await app.RunAsync();

static void ConfigureEnviroment()
{
#if DEBUG
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
#endif
}

static void ConfigureLog(WebApplicationBuilder builder)
{
    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();

    builder.Services.AddSerilog();
}