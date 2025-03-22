using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Soat10.TechChallenge.Application
{
    public static class ApplicationBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            //services.AddValidatorsFromAssemblyContaining<CheckoutRequestValidator>();
            //services.AddTransient<IIdentifyUseCase, IdentifyUseCase>();
        }
    }
}
