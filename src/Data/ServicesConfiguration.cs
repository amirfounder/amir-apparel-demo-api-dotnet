using Amir.Apparel.Demo.Api.Dotnet.Data.Context;
using Amir.Apparel.Demo.Api.Dotnet.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Amir.Apparel.Demo.Api.Dotnet.Data
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql("Host=localhost; Port=5432; Database=postgres; UserName=postgres; Password=root"));

            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
