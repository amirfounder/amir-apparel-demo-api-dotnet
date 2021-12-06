using Microsoft.Extensions.DependencyInjection;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddProviderServices(this IServiceCollection services)
        {
            services.AddScoped<IProductProvider, ProductProvider>();
            services.AddScoped<IPurchaseProvider, PurchaseProvider>();
            services.AddScoped<ILineItemProvider, LineItemProvider>();
            services.AddScoped<IApplicationUserProvider, ApplicationUserProvider>();

            services.AddScoped<IGoogleAuthenticator, GoogleAuthenticator>();

            services.AddScoped<ILineItemValidation, LineItemValidation>();
            
            return services;
        }
    }
}
