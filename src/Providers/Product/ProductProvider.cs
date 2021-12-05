using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Data.Repositories;
using Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions;
using System.Collections;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _repository;

        public ProductProvider(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product product;

            product = await _repository.Get(id);

            if (product == default)
            {
                throw new NotFoundException("Could not find product with id: " + id);
            }

            return product;
        }

        public async Task<IPage<Product>> GetProductsAsync(IPaginationOptions paginationOptions)
        {
            return await _repository.GetAll(paginationOptions);
        }

        public async Task<IPage<Product>> GetProductsWithFilterAsync(PaginationOptions paginationOptions, ProductFilter productFilter)
        {
            return await _repository.GetAll(paginationOptions, productFilter);
        }

        public async Task<IEnumerable> GetDistinctAsync(string property)
        {
            return await _repository.GetDistinct(property);
        }
    }
}
