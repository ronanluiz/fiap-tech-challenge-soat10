using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Application.Common.Dtos;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Application.Controllers;
using Soat10.TechChallenge.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureEnviroment(builder);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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


static void ConfigureEnviroment(WebApplicationBuilder builder)
{
    if (builder.Environment.IsDevelopment())
    {
        builder.Configuration.AddUserSecrets<Program>();
    }
}