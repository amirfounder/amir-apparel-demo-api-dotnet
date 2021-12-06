using Amir.Apparel.Demo.Api.Dotnet.Data.Context;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories
{
    public class ApplicationUserRepository : EntityFrameworkBaseRepository<ApplicationUser, ApplicationContext>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationContext context) : base(context) { }
    }
}
