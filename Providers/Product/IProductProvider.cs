using amir_apparel_demo_api_dotnet_5.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Providers
{
    public interface IProductProvider
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
