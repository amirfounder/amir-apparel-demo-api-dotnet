using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace amir_apparel_demo_api_dotnet_5.Data
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(config.GetConnectionString("AmirApparel")));

            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
