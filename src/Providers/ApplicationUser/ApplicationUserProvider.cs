using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Data.Repositories;
using Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public class ApplicationUserProvider : IApplicationUserProvider
    {
        private readonly IApplicationUserRepository _repository;
        private readonly IGoogleAuthenticator _googleAuthenticator;
        
        public ApplicationUserProvider(IApplicationUserRepository repository, IGoogleAuthenticator googleAuthenticator)
        {
            _repository = repository;
            _googleAuthenticator = googleAuthenticator;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email, string bearerToken)
        {
            if (email == default)
            {
                throw new BadRequestException("User email cannot be empty");
            }

            var jwt = bearerToken.ParseJwt();

            if (jwt == null)
            {
                throw new UnauthorizedException("Could not parse JWT from header");
            }

            var authenticated = await _googleAuthenticator.Authenticate(jwt, email);

            if (!authenticated)
            {
                throw new UnauthorizedException("Could not authenticate request");
            }

            var user = await _repository.GetByProperty("email", email);

            if (user == null)
            {
                throw new NotFoundException($"Could not find user with email: {email}");
            }

            return user;
        }

        public async Task<ApplicationUser> SaveUserAsync(ApplicationUser user, string bearerToken)
        {
            var email = user.Email;

            if (email == default)
            {
                throw new BadRequestException("User email cannot be empty");
            }

            var jwt = bearerToken.ParseJwt();

            if (jwt == null)
            {
                throw new UnauthorizedException("Could not parse JWT from header");
            }

            var authenticated = await _googleAuthenticator.Authenticate(jwt, email);

            if (!authenticated)
            {
                throw new UnauthorizedException("Could not authenticate request");
            }

            return await _repository.Save(user);
        }
    }
}
