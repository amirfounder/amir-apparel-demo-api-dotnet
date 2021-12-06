using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public interface IGoogleAuthenticator
    {
        Task<bool> Authenticate(string jwt, string email);
    }
}
