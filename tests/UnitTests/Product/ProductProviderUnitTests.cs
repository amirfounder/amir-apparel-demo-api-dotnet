using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Data.Repositories;
using Amir.Apparel.Demo.Api.Dotnet.Data.Seed;
using Amir.Apparel.Demo.Api.Dotnet.Providers;
using Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Amir.Apparel.Demo.Api.Dotnet.Tests.UnitTests
{
    public class ProductProviderUnitTests
    {

        private IProductProvider _productProvider;
        private ProductFactory _productFactory;
        private Mock<IProductRepository> _mockRepository;

        private Product testProduct;

        public ProductProviderUnitTests()
        {
            _productFactory = new ProductFactory();
            testProduct = _productFactory.BuildRandomProduct(1);

            _mockRepository = new Mock<IProductRepository>();
            _mockRepository
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .ReturnsAsync(testProduct);

            _productProvider = new ProductProvider(_mockRepository.Object);
        }

        [Fact]
        public async Task GetProductById_GivenValidProductReturned_ReturnsProduct()
        {
            _mockRepository
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .ReturnsAsync(testProduct);

            _productProvider = new ProductProvider(_mockRepository.Object);

            var actual = await _productProvider.GetProductByIdAsync(1);
            var expected = testProduct;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetProductById_GivenNoProductReturned_ThrowsNotFoundException()
        {
            _mockRepository
                .Setup(repository => repository.Get(It.IsAny<int>()))
                .ReturnsAsync((Product)null);

            _productProvider = new ProductProvider(_mockRepository.Object);

            await Assert.ThrowsAsync<NotFoundException>(() => _productProvider.GetProductByIdAsync(1));
        }
    }
}
