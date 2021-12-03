using Microsoft.Extensions.DependencyInjection;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddProviderServices(this IServiceCollection services)
        {
            services.AddScoped<IProductProvider, ProductProvider>();

            return services;
        }
    }
}
