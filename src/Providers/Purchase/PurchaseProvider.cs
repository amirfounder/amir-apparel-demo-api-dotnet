using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Data.Repositories;
using Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions;
using System.Linq;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public class PurchaseProvider : IPurchaseProvider
    {
        private readonly IPurchaseRepository _repository;
        private readonly ILineItemProvider _lineItemProvider;
        private readonly ILineItemValidation _lineItemValidation;

        public PurchaseProvider(
            IPurchaseRepository repository,
            ILineItemProvider lineItemProvider,
            ILineItemValidation lineItemValidation
        )
        {
            _repository = repository;
            _lineItemProvider = lineItemProvider;
            _lineItemValidation = lineItemValidation;
        }
        public async Task<Purchase> CreatePurchaseAsync(Purchase purchase)
        {
            var lineItems = purchase.LineItems;

            var uniqueLineItems = _lineItemProvider.MergeLineItemsWithSameProductId(lineItems);
            var lineItemErrors = await _lineItemValidation.ValidateLineItems(uniqueLineItems);

            if (lineItemErrors.Any())
            {
                var errorMessage = string.Join(" ", lineItemErrors);
                throw new BadRequestException(errorMessage);
            }

            return await _repository.Save(purchase);
        }
    }
}
