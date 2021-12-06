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
            services.AddScoped<ILineItemValidation, LineItemValidation>();
            services.AddScoped<IGoogleAuthenticator, GoogleAuthenticator>();

            return services;
        }
    }
}
