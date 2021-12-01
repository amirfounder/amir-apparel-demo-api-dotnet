using amir_apparel_demo_api_dotnet_5.API;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using amir_apparel_demo_api_dotnet_5.HttpStatusExceptions;

namespace Amir.Apparel.Demo.Api.Dotnet.Tests.IntegrationTests
{
    public class ProductIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task GetProducts_Returns200WithExpectedPageValues()
        {
            var response = await _client.GetAsync("/products/filter");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<Page<ProductDTO>>();
            Assert.Equal(25, content.Content.Count());
            Assert.False(content.Empty);
            Assert.Equal(25, content.Size);
            Assert.Equal(25, content.NumberOfElements);
            Assert.Equal(0, content.Number);
            Assert.Equal(250, content.TotalElements);
            Assert.Equal(10, content.TotalPages);
        }

        [Fact]
        public async Task GetProductById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/products/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<ProductDTO>();
            Assert.Equal(1, content.Id);
        }

        [Fact]
        public async Task GetProductById_GivenNonExistantId_Returns404()
        {
            var response = await _client.GetAsync("/products/9999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            var content = await response.Content.ReadAsAsync<HttpStatusExceptionValue>();
            Assert.Equal(404, content.Status);
            Assert.Equal("Not Found", content.Error);
            Assert.Equal("Could not find product with id: 9999", content.ErrorMessage);
        }

        [Fact]
        public async Task GetProducts_GivenFilterOneAttributeOneValue_Returns200()
        {
            var response = await _client.GetAsync("/products/filter?demographic=men");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<Page<ProductDTO>>();
            Assert.Empty(content.Content.Where(x => x.Demographic != "Men").ToList());
        }

        [Fact]
        public async Task GetProducts_GivenFilterOneAttributeMultipleValues_Returns200()
        {
            var response = await _client.GetAsync("/products/filter?demographic=men,women");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<Page<ProductDTO>>();
            Assert.Empty(content.Content.Where(x => x.Demographic != "Men" & x.Demographic != "Women").ToList());
        }

        [Fact]
        public async Task GetProducts_GivenFilterMultipleAttributesOneValuePerAttribute_Returns200()
        {
            var response = await _client.GetAsync("/products/filter?demographic=men&material=cotton");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<Page<ProductDTO>>();
            Assert.Empty(content.Content.Where(x => x.Demographic != "Men").ToList());
            Assert.Empty(content.Content.Where(x => x.Material != "Cotton").ToList());
        }

        [Fact]
        public async Task GetProducts_GivenFilterMultipleAttributesMultipleValuePerAttribute_Returns200()
        {
            var response = await _client.GetAsync("/products/filter?demographic=men,women&material=cotton,silk");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<Page<ProductDTO>>();
            Assert.Empty(content.Content.Where(x => x.Demographic != "Men" & x.Demographic != "Women").ToList());
            Assert.Empty(content.Content.Where(x => x.Material != "Cotton" & x.Material != "Silk").ToList());
        }

        [Fact]
        public async Task GetProducts_GivenFilterOneAttributeInvalidValue_Returns200()
        {
            var response = await _client.GetAsync("/products/filter?demographic=foo");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<Page<ProductDTO>>();
            Assert.Equal(0, content.TotalElements);
            Assert.True(content.Empty);
            Assert.Empty(content.Content);
        }
    }
}
