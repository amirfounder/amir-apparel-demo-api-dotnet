using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amir_apparel_demo_api_dotnet_5.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace amir_apparel_demo_api_dotnet_5.Data
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<AppCtx>(options =>
                options.UseNpgsql("Host=localhost; Port=5432; Database=postgres; UserName=postgres; Password=root"));

            services.AddScoped<IAppCtx>(provider => provider.GetService<AppCtx>());

            return services;
        }
    }
}
