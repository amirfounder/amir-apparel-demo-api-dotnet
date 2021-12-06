using Amir.Apparel.Demo.Api.Dotnet.Data.Context;
using Amir.Apparel.Demo.Api.Dotnet.Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;

namespace Amir.Apparel.Demo.Api.Dotnet.Data
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddDbContext<ApplicationContext>(options => options.ConfigureNpgsql(config, env));

            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<ILineItemRepository, LineItemRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            return services;
        }

        public static DbContextOptionsBuilder ConfigureNpgsql(this DbContextOptionsBuilder options, IConfiguration config, IWebHostEnvironment env)
        {
            string connectionString = "";

            if (env.IsDevelopment())
            {
                connectionString = config.GetConnectionString("Local");
            }
            else if (env.IsProduction())
            {
                var url = Environment.GetEnvironmentVariable("DATABASE_URL");
                var uri = new Uri(url);
                connectionString = uri.BuildHerokuConnectionString();
            }

            options.UseNpgsql(connectionString);
            return options;
        }

        private static string BuildHerokuConnectionString(this Uri uri)
        {
            var userInfo = uri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = uri.Host,
                Port = uri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = uri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };

            return builder.ToString();
        }
    }
}
