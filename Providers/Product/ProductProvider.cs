using amir_apparel_demo_api_dotnet_5.API.Controllers;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using amir_apparel_demo_api_dotnet_5.Exceptions;
using System.Collections.Generic;
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


        public async Task<IEnumerable<Product>> GetProductsAsync(ProductParameters productParameters)
        {
            return await _repository.GetProductsAsync(productParameters);
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            Product product;

            product = await _repository.GetProductByIdAsync(id);

            if (product == null)
            {
                throw new NotFoundException("Could not find product with id: " + id);
            }

            return product;
        }
    }
}
