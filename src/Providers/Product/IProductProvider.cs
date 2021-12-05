using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System.Collections;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public interface IProductProvider
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IPage<Product>> GetProductsAsync(IPaginationOptions paginationOptions);
        Task<IPage<Product>> GetProductsWithFilterAsync(PaginationOptions paginationOptions, ProductFilter productFilter);
        Task<IEnumerable> GetDistinctAsync(string property);
    }
}
