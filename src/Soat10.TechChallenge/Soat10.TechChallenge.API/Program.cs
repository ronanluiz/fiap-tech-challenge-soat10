using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Soat10.TechChallenge.API.Middlewares;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Application.ProductApplication.Validations;
using Soat10.TechChallenge.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var rootPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../.."));
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


builder.Services.AddControllers(); // Mantém os controladores registrados
builder.Services.AddFluentValidationAutoValidation(); // Adiciona validação automática com FluentValidation
builder.Services.AddFluentValidationClientsideAdapters(); // (opcional) Adiciona validação no cliente


// Registra todos os validadores encontrados no assembly do projeto Application
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();

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

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

await app.RunAsync();
