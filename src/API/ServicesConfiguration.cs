using Amir.Apparel.Demo.Api.Dotnet.API.Filters;
using Amir.Apparel.Demo.Api.Dotnet.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mime;

namespace Amir.Apparel.Demo.Api.Dotnet.API
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

        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new HttpStatusExceptionFilter());
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new BadRequestObjectResult(context.ModelState);
                    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                    result.ContentTypes.Add(MediaTypeNames.Application.Xml);
                    return result;
                };
            });
            return services;
        }

    }
}
