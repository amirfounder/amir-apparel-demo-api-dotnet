using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public interface IGoogleAuthenticator
    {
        Task<bool> Authenticate(string jwt, string email);
    }
}
