using Microsoft.AspNetCore.Mvc;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Infrastructure;

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

// Add services to the container.
ApplicationBootstrapper.Register(builder.Services);
InfrastructureBootstrapper.Register(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

// app.UseHttpsRedirection();

app.MapPost("/payment-request-status", async ([FromQuery] string id, [FromQuery] string topic) =>
{
    Console.WriteLine($"id: {id}, topic: {topic}");

    return TypedResults.Ok();
});

await app.RunAsync();