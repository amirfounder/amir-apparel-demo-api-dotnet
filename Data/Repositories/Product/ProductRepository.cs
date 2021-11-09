using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories
{
    public class ProductRepository : EFBaseRepository<Product, ApplicationContext>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(typeof(Product), context)
        { }
    }
}
