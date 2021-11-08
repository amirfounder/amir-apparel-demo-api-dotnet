using amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using amir_apparel_demo_api_dotnet_5.HttpStatusExceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository<Product> _repository;

        public ProductProvider(IProductRepository<Product> repository)
        {
            _repository = repository;
        }


        public async Task<Page<Product>> GetProductsAsync(IPaginationOptions paginationOptions)
        {
            var page = await _repository.GetAll(paginationOptions);
            return page;
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            Product product;

            product = await _repository.Get(id);

            if (product == null)
            {
                throw new NotFoundException("Could not find product with id: " + id);
            }

            return product;
        }

        public async Task<Page<Product>> GetProductsWithFilterAsync(PaginationOptions paginationOptions, ProductFilter productFilter)
        {
            var page = await _repository.GetAll(paginationOptions, productFilter);
            return page;
        }

        public async Task<IEnumerable<object>> GetDistinctAsync(string property)
        {
            var distinct = await _repository.GetDistinct(property);
            return distinct;
        }
    }
}
