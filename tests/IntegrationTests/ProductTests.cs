using amir_apparel_demo_api_dotnet_5.API;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace amir_apparel_demo_api_dotnet_5.tests.IntegrationTests
{
    public class ProductTest
    {
        private readonly HttpClient _client;
        public ProductTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact]
        public async Task GetAll_NoPaginationNoFiltering_ReturnsAllProducts()
        {
            var response = await _client.GetAsync("/products");
            var content = await response.Content.ReadAsAsync<List<ProductDTO>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            content.Should().BeEmpty();
        }
    }
}
