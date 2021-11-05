using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _repository;

        public ProductProvider(IProductRepository repository)
        {
            _repository = repository;
        }

        
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repository.GetProductsAsync();
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            Product product;

            try
            {
                product = await _repository.GetProductByIdAsync(id);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;
        }
    }
}
