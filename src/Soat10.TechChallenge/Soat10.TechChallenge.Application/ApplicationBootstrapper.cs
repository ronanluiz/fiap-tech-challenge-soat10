using Microsoft.Extensions.DependencyInjection;
using Soat10.TechChallenge.Application.UseCases.CreateNewCustomer;

namespace Soat10.TechChallenge.Application
{
    public static class ApplicationBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ICreateNewCustomerUseCase, CreateNewCustomerUseCase>();
        }
    }
}
