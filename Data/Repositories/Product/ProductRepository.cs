using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Models;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories
{
    public class ProductRepository : EntityFrameworkBaseRepository<Product, ApplicationContext>
    {
        public ProductRepository(ApplicationContext context) : base(context)
        { }
    }
}
