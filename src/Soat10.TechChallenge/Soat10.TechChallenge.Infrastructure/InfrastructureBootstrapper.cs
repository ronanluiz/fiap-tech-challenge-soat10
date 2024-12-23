using Microsoft.Extensions.DependencyInjection;
using Soat10.TechChallenge.Domain.Interfaces;
using Soat10.TechChallenge.Infrastructure.Persistence.Repositories;

namespace Soat10.TechChallenge.Infrastructure
{
    public static class InfrastructureBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
