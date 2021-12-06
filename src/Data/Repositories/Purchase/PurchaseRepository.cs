using Amir.Apparel.Demo.Api.Dotnet.Data.Context;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories
{
    public class PurchaseRepository : EntityFrameworkBaseRepository<Purchase, ApplicationContext>, IPurchaseRepository
    {
        public PurchaseRepository(ApplicationContext context) : base(context) { }
    }
}
