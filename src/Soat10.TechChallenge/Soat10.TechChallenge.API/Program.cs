using Soat10.TechChallenge.API.Middlewares;
using Soat10.TechChallenge.Application;
using Soat10.TechChallenge.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

ApplicationBootstrapper.Register(builder.Services);
InfrastructureBootstrapper.Register(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

await app.RunAsync();
