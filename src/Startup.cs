using Amir.Apparel.Demo.Api.Dotnet.API;
using Amir.Apparel.Demo.Api.Dotnet.API.MapperProfiles;
using Amir.Apparel.Demo.Api.Dotnet.Data;
using Amir.Apparel.Demo.Api.Dotnet.Providers;
using Amir.Apparel.Demo.Api.Dotnet.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Amir.Apparel.Demo.Api.Dotnet
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile));

            services.AddCorsServices();
            services.AddCustomControllers();

            services.AddProviderServices();
            services.AddDataServices(Environment);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Amir.Apparel.Demo.Api.Dotnet", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Amir.Apparel.Demo.Api.Dotnet v1"));
            }

            app.UseHttpsRedirection();

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
