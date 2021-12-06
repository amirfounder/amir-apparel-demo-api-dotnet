using Google.Apis.Auth;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public class GoogleAuthenticator : IGoogleAuthenticator
    {
        public async Task<bool> Authenticate(string jwt, string email)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(jwt);
            return payload.Email == email;
        }
    }
}
