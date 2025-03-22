using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Serilog;
using Soat10.TechChallenge.API.Endpoints;
using Soat10.TechChallenge.API.Middlewares;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Application.Validators;
using Soat10.TechChallenge.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigureEnviroment();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();

ConfigureLog(builder);

builder.Services.AddFluentValidationAutoValidation(); // Adiciona valida��o automática com FluentValidation
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
        Description = "Api Fast Food de um sistema de autoatendimento de fast food projetado para gerenciar clientes, produtos e pedidos, além de facilitar o processo de checkout e acompanhamento dos pedidos"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath);
});

builder.Services.AddFluentValidationRulesToSwagger(); // Integra��o com Swagger

ApplicationBootstrapper.Register(builder.Services);
InfrastructureBootstrapper.Register(builder.Services, builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/api/hc");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapCustomerEndpoints();
app.MapOrderEndpoints();
app.MapCartEndpoints();
app.MapProductEndpoints();

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
