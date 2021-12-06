using Amir.Apparel.Demo.Api.Dotnet.Data.Context;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories
{
    public class ApplicationUserRepository : EntityFrameworkBaseRepository<ApplicationUser, ApplicationContext>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationContext context) : base(context) { }
    }
}
