using amir_apparel_demo_api_dotnet_5.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(int id);
    }
}
