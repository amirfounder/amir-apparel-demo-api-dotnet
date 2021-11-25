using Amir.Apparel.Demo.Api.Dotnet.Tests.Utilities;
using amir_apparel_demo_api_dotnet_5;
using amir_apparel_demo_api_dotnet_5.API;
using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using amir_apparel_demo_api_dotnet_5.HttpStatusExceptions;

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
                        services.AddDbContext<ApplicationContext>((options, context) =>
                        {
                            context.UseNpgsql("Host=localhost; Port=5432; Database=postgres_tests; UserName=postgres; Password=root");
                        });

                        var serviceProvider = services.BuildServiceProvider();

                        using (var scope = serviceProvider.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var context = scopedServices.GetRequiredService<ApplicationContext>();
                            var logger = scopedServices.GetRequiredService<ILogger<WebApplicationFactory<Startup>>>();

                            context.Database.EnsureCreated();

                            try
                            {
                                context.ReinitializeDatabaseForTests();
                            }
                            catch (Exception ex)
                            {
                                logger.LogError(ex, "An error occured seeding the database with the message: " + ex.Message);
                            }
                        }
                    });
                    builder.UseContentRoot(Directory.GetCurrentDirectory());
                });
            _client = _factory.CreateClient();
        }

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
            var response = await _client.GetAsync("/products?demographic=men");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<Page<ProductDTO>>();
            var products = content.Content;
            Assert.Empty(products.Where(x => x.Demographic.ToLower() != "men").ToList());
        }

        [Fact]
        public async Task GetProducts_GivenFilterOneAttributeMultipleValues_Returns200()
        {
            var response = await _client.GetAsync("/products?demographic=men,women");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProducts_GivenFilterMultipleAttributesOneValuePerAttribute_Returns200()
        {
            var response = await _client.GetAsync("/products?demographic=men&material=cotton");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProducts_GivenFilterMultipleAttributesMultipleValuePerAttribute_Returns200()
        {
            var response = await _client.GetAsync("/products?demographic=men,women&material=cotton,silk");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProducts_GivenFilterOneAttributeInvalidValue_Returns200()
        {
            var response = await _client.GetAsync("/products?demographic=foo");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
