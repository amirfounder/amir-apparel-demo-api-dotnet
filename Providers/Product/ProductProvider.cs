using amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using amir_apparel_demo_api_dotnet_5.HttpStatusExceptions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _repository;

        public ProductProvider(IProductRepository repository)
        {
            _repository = repository;
        }


        public async Task<Page<Product>> GetProductsAsync(IPaginationOptions paginationOptions)
        {
            return await _repository.GetAll(paginationOptions);
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            Product product;

            product = await _repository.Get(id);

            if (product == default)
            {
                throw new NotFoundException("Could not find product with id: " + id);
            }

            return product;
        }

        public async Task<Page<Product>> GetProductsWithFilterAsync(PaginationOptions paginationOptions, ProductFilter productFilter)
        {
            return await _repository.GetAll(paginationOptions, productFilter);
        }

        public async Task<IEnumerable> GetDistinctAsync(string property)
        {
            return await _repository.GetDistinct(property);
        }
    }
}
