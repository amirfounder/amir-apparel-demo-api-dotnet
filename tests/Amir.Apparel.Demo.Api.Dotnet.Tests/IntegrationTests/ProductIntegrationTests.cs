using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using amir_apparel_demo_api_dotnet_5;
using amir_apparel_demo_api_dotnet_5.API;
using amir_apparel_demo_api_dotnet_5.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Amir.Apparel.Demo.Api.Dotnet.Tests.IntegrationTests
{
    public class ProductIntegrationTests
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Startup> _factory;

        public ProductIntegrationTests()
        {
            _factory = new WebApplicationFactory<Startup>()
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
                    builder.UseContentRoot(Directory.GetCurrentDirectory());
                });
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetProducts_Returns200WithCollection()
        {
            var response = await _client.GetAsync("/products");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<List<ProductDTO>>();
        }
    }
}
