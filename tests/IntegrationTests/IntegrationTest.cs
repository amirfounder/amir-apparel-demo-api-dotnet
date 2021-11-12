using amir_apparel_demo_api_dotnet_5.Data.Context;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;

namespace amir_apparel_demo_api_dotnet_5.tests.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient httpClient;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(ApplicationContext));
                        services.AddDbContext<ApplicationContext>(options =>
                        {
                            options.UseInMemoryDatabase("testdb");
                        });
                    });
                });
            httpClient = appFactory.CreateClient();
        }

    }
}
