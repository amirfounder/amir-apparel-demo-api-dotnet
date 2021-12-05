using Amir.Apparel.Demo.Api.Dotnet.Data.Context;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories
{
    public class LineItemRepository : EntityFrameworkBaseRepository<LineItem, ApplicationContext>, ILineItemRepository
    {
        public LineItemRepository(ApplicationContext context) : base(context)
        { }
    }
}
