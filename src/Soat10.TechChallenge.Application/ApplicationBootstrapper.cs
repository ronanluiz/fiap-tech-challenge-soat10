using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Soat10.TechChallenge.Application.UseCases.Checkout;
using Soat10.TechChallenge.Application.UseCases.Identify;

namespace Soat10.TechChallenge.Application
{
    public static class ApplicationBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CheckoutRequestValidator>();
            //services.AddTransient<IIdentifyUseCase, IdentifyUseCase>();
        }
    }
}
