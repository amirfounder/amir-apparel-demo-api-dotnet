using Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions;
using Google.Apis.Auth;
using System;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public class GoogleAuthenticator : IGoogleAuthenticator
    {
        public async Task<bool> Authenticate(string jwt, string email)
        {
            GoogleJsonWebSignature.Payload payload;

            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(jwt);
            }
            catch (InvalidJwtException e)
            {
                throw new UnauthorizedException(e.Message);
            }
            catch (FormatException)
            {
                throw new UnauthorizedException("There was an error reading the JWT token");
            }

            return payload.Email == email;
        }
    }
}
