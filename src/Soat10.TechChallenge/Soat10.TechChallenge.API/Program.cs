using Soat10.TechChallenge.API.Middlewares;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Infrastructure;

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

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ApplicationBootstrapper.Register(builder.Services);
InfrastructureBootstrapper.Register(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

await app.RunAsync();
