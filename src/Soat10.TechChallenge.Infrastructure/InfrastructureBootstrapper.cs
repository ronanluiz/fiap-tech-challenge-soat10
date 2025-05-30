﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Soat10.TechChallenge.Application.Common.Interfaces;
using Soat10.TechChallenge.Infrastructure.ExternalServices;
using Soat10.TechChallenge.Infrastructure.Persistence.Context;
using Soat10.TechChallenge.Infrastructure.Persistence.Repositories;

namespace Soat10.TechChallenge.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IExternalPaymentService, ExternalPaymentService>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<PaymentRepository>();
            services.AddScoped<CartRepository>();
            services.AddScoped<ProductRepository>();
            services.AddTransient<AuthenticationHeaderMercadoPagoHandler>();

            services
                .AddRefitClient<IMercadoPagoApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration["PaymentService:BaseUrl"]))
                .AddHttpMessageHandler<AuthenticationHeaderMercadoPagoHandler>();

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
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);
                });
            });
        }
    }
}
