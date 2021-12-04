using Microsoft.AspNetCore.Hosting;
using System;

namespace Amir.Apparel.Demo.Api.Dotnet
{
    public static class ProgramConfigurations
    {
        public static IWebHostBuilder ConfigureKestrel(this IWebHostBuilder builder)
        {
            var environmentPort = Environment.GetEnvironmentVariable("PORT");
            var port = environmentPort != null ? int.Parse(environmentPort) : 5000;

            builder.UseKestrel(options =>
            {
                options.ListenAnyIP(port);
            });

            return builder;
        }
    }
}
