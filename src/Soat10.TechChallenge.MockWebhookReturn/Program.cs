using Microsoft.AspNetCore.Mvc;
using Refit;
using Serilog;
using Soat10.TechChallenge.MockWebhookReturn;

var builder = WebApplication.CreateBuilder(args);

ConfigureEnviroment();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();

ConfigureLog(builder);

// Add services to the container.
builder.Services.AddRefitClient<IWebhookService>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["BaseWebhookUrl"]));

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/mock/hc");

// Configure the HTTP request pipeline.

app.MapPost("/mock/payment-notifications", async (
    [FromServices] IWebhookService webhookService,
    [FromBody] PaymentNotificationDto paymentNotification) =>
{
    try
    {
        await webhookService.SendPaymentNotification(paymentNotification);
    }
    catch (ApiException ex)
    {
        Log.Logger.Error(ex, "Erro na integração com webhook");
        throw;
    }
    

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
