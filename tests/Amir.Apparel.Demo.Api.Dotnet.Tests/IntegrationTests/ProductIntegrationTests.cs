﻿using System.Collections.Generic;
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
        }
        
        [Fact]
        public async Task GetProductById_GivenNonExistantId_Returns404()
        {
            var respnose = await _client.GetAsync("/products/9999");
            Assert.Equal(HttpStatusCode.NotFound, respnose.StatusCode);
        }
        [Fact]
        public async Task GetProductById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/products/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetProducts_GivenFilterOneAttributeOneValue_Returns200()
        {
            var response = await _client.GetAsync("/products?demographic=men");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
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
