using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Soat10.TechChallenge.Application.ProductApplication.UseCases;
using Soat10.TechChallenge.Application.ProductApplication.UseCases.InterfacesUseCases;
using Soat10.TechChallenge.Application.ProductApplication.Validations;
using Soat10.TechChallenge.Application.UseCases.Checkout;
using Soat10.TechChallenge.Application.UseCases.CustomerUseCases;
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

            services.AddTransient<ICustomerUseCase, CustomerUseCase>();

            #region Denpendency Injection Products use cases. 
            services.AddTransient<ICreateProductAsync, CreateProductAsync>();
            services.AddTransient<IGetAllProductAsync, GetAllProductAsync>();
            services.AddTransient<IGetByCategoryProductsAsync, GetByCategoryProductsAsync>();
            services.AddTransient<IGetByIdProductsAsync, GetByIdProductsAsync>();
            services.AddTransient<IUpdateProductAsync, UpdateProductAsync>();
            services.AddTransient<IMakeUnavailableAsync, MakeUnavailableAsync>();
            services.AddTransient<IMakeAvailableAsync, MakeAvailableAsync>();
            services.AddTransient<IGetAvailableProductsAsync, GetAvailableProductsAsync>();
            services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
            #endregion

        }
    }
}
