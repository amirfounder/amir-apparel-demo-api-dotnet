using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace amir_apparel_demo_api_dotnet_5.Data
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql("Host=localhost; Port=5432; Database=postgres; UserName=postgres; Password=root"));

            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());
            services.AddScoped<IProductRepository<T>, ProductRepository>();

            return services;
        }
    }
}
