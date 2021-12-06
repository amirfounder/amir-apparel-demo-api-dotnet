using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public interface IApplicationUserProvider
    {
        Task<ApplicationUser> SaveUserAsync(ApplicationUser user, string bearerToken);
        Task<ApplicationUser> GetUserByEmailAsync(string email, string bearerToken);
    }
}
