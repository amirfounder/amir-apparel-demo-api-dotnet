using amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using System.Collections;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public interface IProductProvider
    {
        Task<Page<Product>> GetProductsAsync(IPaginationOptions paginationOptions);
        Task<Product> GetProductByIdAsync(int id);
        Task<Page<Product>> GetProductsWithFilterAsync(PaginationOptions paginationOptions, ProductFilter productFilter);
        Task<IEnumerable> GetDistinctAsync(string property);
    }
}
