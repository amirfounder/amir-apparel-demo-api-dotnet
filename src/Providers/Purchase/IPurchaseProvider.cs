using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public interface IPurchaseProvider
    {
        Task<Purchase> CreatePurchaseAsync(Purchase purchase);
    }
}
