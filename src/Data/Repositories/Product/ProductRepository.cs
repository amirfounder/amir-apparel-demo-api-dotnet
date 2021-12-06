using Amir.Apparel.Demo.Api.Dotnet.Data.Context;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories
{
    public class ProductRepository : EntityFrameworkBaseRepository<Product, ApplicationContext>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        { }
    }
}
