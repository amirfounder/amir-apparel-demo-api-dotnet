using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Data.Repositories;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public class PurchaseProvider : IPurchaseProvider
    {
        private readonly IPurchaseRepository _repository;

        public PurchaseProvider(IPurchaseRepository repository)
        {
            _repository = repository;
        }
        public async Task<Purchase> CreatePurchaseAsync(Purchase purchase)
        {
            return await _repository.Save(purchase);
        }

        public async Task<Page<Purchase>> GetPurchasesByEmailAsync(IPaginationOptions paginationOptions, string email)
        {
            return await _repository.GetAllByProperty(paginationOptions, "email", email);
        }
    }
}
