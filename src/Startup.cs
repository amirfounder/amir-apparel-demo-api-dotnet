using amir_apparel_demo_api_dotnet_5.Controllers;
using amir_apparel_demo_api_dotnet_5.Data;
using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.DTOs.MapperProfiles;
using amir_apparel_demo_api_dotnet_5.Providers;
using amir_apparel_demo_api_dotnet_5.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace amir_apparel_demo_api_dotnet_5
{
    public class Startup
    {

        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddCorsServices();
            services.AddCustomControllers();

            services.AddProviderServices();
            services.AddDataServices(Configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "amir_apparel_demo_api_dotnet_5", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "amir_apparel_demo_api_dotnet_5 v1"));
            }

            context.Database.EnsureCreated();

            app.UseRouting();

            app.UseCors(Constants.AmirApparelCorsPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
