using amir_apparel_demo_api_dotnet_5.API.QueryParams;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using amir_apparel_demo_api_dotnet_5.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository<T> _repository;

        public ProductProvider(IProductRepository<T> repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<T>> GetProductsAsync(PaginationQueryParams productParameters)
        {
            return await _repository.GetAll(productParameters);
        }

        public async Task<T> getProductByIdAsync(int id)
        {
            T product;

            product = await _repository.Get(id);

            if (product == null)
            {
                throw new NotFoundException("Could not find product with id: " + id);
            }

            return product;
        }
    }
}
