using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Soat10.TechChallenge.Application.Services;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Infrastructure.ExternalServices;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;
using Soat10.TechChallenge.Infrastructure.Persistence.Repositories;

namespace Soat10.TechChallenge.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentService, MercadoPagoPaymentService>();
            services.AddTransient<IProductRepository, ProductRepository>();

            //Para realização de testes rápido em product
            //services.AddTransient<IProductRepository>(provider => new ProductRepositoryTemp("products.json"));

            ConfigureDatabase(services, configuration);
        }

        private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            string host = configuration["DbConnection:Host"];
            string database = configuration["DbConnection:Database"];
            string user = configuration["DbConnection:User"];
            string password = configuration["DbConnection:Password"];

            var connectionString = $"Host={host};Port=5432;Pooling=true;Database={database};User Id={user};Password={password};";

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);
                }));
        }
    }
}
