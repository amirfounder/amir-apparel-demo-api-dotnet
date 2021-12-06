using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public static class AuthenticationExtensions
    {
        public static string ParseJwt(this string bearerToken)
        {
            return bearerToken != default && bearerToken.StartsWith("Bearer ") ? bearerToken[7..] : null;
        }
    }
}
