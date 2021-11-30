using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace amir_apparel_demo_api_dotnet_5
{
    public class Programs
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(options =>
                    {
                        int port;
                        var parsed = Int32.TryParse(System.Environment.GetEnvironmentVariable("PORT"), out port);
                        options.ListenAnyIP(parsed ? port : 8085);
                    });
                });
    }
}
