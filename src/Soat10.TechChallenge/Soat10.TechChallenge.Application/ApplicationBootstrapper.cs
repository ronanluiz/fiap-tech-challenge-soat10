using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Soat10.TechChallenge.Application.UseCases.Checkout;
using Soat10.TechChallenge.Application.Validators;
using Soat10.TechChallenge.Domain.Validators;

namespace Soat10.TechChallenge.Application
{
    public static class ApplicationBootstrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ICheckoutUseCase, CheckoutUseCase>();
            services.AddValidatorsFromAssemblyContaining<CheckoutRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<OrderValidator>();
        }
    }
}
