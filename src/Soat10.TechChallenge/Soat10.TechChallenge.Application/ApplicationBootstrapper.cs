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
            services.AddTransient<IIdentifyUseCase, IdentifyUseCase>();

            #region Denpendency Injection Products use cases. 
            services.AddTransient<ICreateProductUseCase, CreateProductUseCase>();
            services.AddTransient<IGetAllProductUseCase, GetAllProductUseCase>();
            services.AddTransient<IGetByCategoryProductsUseCase, GetByCategoryProductsUseCase>();
            services.AddTransient<IGetByIdProductsUseCase, GetByIdProductsUseCase>();
            services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
            services.AddTransient<IMakeUnavailableUseCase, MakeUnavailableUseCase>();
            services.AddTransient<IMakeAvailableUseCase, MakeAvailableUseCase>();
            services.AddTransient<IGetAvailableProductsUseCase, GetAvailableProductsUseCase>();
            #endregion

        }
    }
}
