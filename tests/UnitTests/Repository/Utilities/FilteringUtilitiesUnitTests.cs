using amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries;
using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories.Utilities;
using amir_apparel_demo_api_dotnet_5.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Amir.Apparel.Demo.Api.Dotnet.Tests.UnitTests.Repository.Utilities
{
    public class FilteringUtilitiesUnitTests
    {
        private ProductFactory _productFactory;
        private ICollection<Product> _products;

        private Mock<DbSet<Product>> _mockSet;
        private Mock<IApplicationContext> _mockContext;

        public FilteringUtilitiesUnitTests()
        {
            _productFactory = new();
            _products = _productFactory.BuildRandomProducts(500);
            _mockSet = new();
            _mockContext = new();
        }

        private void ResetMocks()
        {
            _mockSet.Invocations.Clear();
            _mockContext.Invocations.Clear();
        }

        [Fact]
        public void ApplyFilteringTest()
        {
            _mockSet.LoadMockDbSetWithData(_products);
            _mockContext.Setup(x => x.Products).Returns(_mockSet.Object);

            IQueryable<Product> actualQuery = _mockContext.Object.Products.AsQueryable<Product>();
            IQueryable<Product> expectedQuery = _mockContext.Object.Products.AsQueryable<Product>();

            ProductFilter filterable = new();
            filterable.Material = "leather";
            filterable.Demographic = "Men";

            var actual = actualQuery
                .ApplyFiltering(filterable)
                .ToList();

            var expected = expectedQuery
                .Where(x => x.Demographic == "Men" & x.Material == "Leather")
                .ToList();

            Assert.Equal(expected, actual);

            ResetMocks();
        }

    }
}
