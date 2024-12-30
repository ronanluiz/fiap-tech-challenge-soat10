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

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("TechChallengeDb");
                options.UseNpgsql(connectionString);
            });
        }
    }
}
