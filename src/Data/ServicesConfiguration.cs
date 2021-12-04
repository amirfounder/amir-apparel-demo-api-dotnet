﻿using Amir.Apparel.Demo.Api.Dotnet.Data.Context;
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
            services.AddDbContext<ApplicationContext>(options =>
            {
                if (env.IsProduction())
                {
                    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
                    var databaseUri = new Uri(databaseUrl);
                    var connectionString = databaseUri.BuildHerokuConnectionString();

                    options.UseNpgsql(connectionString);
                }
                else if (env.IsDevelopment())
                {
                    options.UseNpgsql(config.GetConnectionString("Local"));
                }
            });

            services.AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>());
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
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
