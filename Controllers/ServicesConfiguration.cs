using amir_apparel_demo_api_dotnet_5.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace amir_apparel_demo_api_dotnet_5.Controllers
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(Constants.AmirApparelCorsPolicy, builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
