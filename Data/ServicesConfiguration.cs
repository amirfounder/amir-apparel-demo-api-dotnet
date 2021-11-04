using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace amir_apparel_demo_api_dotnet_5.Data
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<AppCtx>(options =>
                options.UseNpgsql("Host=localhost; Port=5432; Database=postgres; UserName=postgres; Password=root"));

            services.AddScoped<IAppCtx>(provider => provider.GetService<AppCtx>());
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
