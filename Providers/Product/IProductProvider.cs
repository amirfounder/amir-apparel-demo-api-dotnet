using amir_apparel_demo_api_dotnet_5.API.QueryParams;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public interface IProductProvider
    {
        Task<IEnumerable<T>> GetProductsAsync(PaginationQueryParams productParameters);
        Task<T> getProductByIdAsync(int id);
    }
}
