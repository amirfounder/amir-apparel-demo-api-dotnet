using amir_apparel_demo_api_dotnet_5.API.CustomQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public interface IProductProvider
    {
        Task<Page<Product>> GetProductsAsync(IPaginationOptions paginationOptions);
        Task<Product> getProductByIdAsync(int id);
    }
}
