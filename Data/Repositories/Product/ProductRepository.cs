using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Models;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories
{
    public class ProductRepository : EFBaseRepository<Product, ApplicationContext>, IProductRepository<Product>
    {
        public ProductRepository(ApplicationContext context) : base(typeof(Product), context)
        { }
    }
}
