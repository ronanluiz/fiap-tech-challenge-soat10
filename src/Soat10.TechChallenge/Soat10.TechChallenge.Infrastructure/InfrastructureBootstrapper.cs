using Microsoft.Extensions.DependencyInjection;
using Soat10.TechChallenge.Application.Services;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Infrastructure.ExternalServices;
using Soat10.TechChallenge.Infrastructure.Persistence.Repositories;

namespace Soat10.TechChallenge.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentService, MercadoPagoPaymentService>();
        }
    }
}
