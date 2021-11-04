using amir_apparel_demo_api_dotnet_5.Providers.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
