using Microsoft.Extensions.DependencyInjection;

namespace amir_apparel_demo_api_dotnet_5.Providers
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
