using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public class LineItemValidation : ILineItemValidation
    {
        private readonly IProductRepository _productRepository;

        public LineItemValidation(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<string>> ValidateLineItems(IEnumerable<LineItem> lineItems)
        {
            var errors = new List<string>();

            foreach (var lineItem in lineItems)
            {
                var quantityError = GetLineItemQuantityError(lineItem.Quantity);
                if (quantityError != null)
                {
                    if (!errors.Contains(quantityError))
                    {
                        errors.Add(quantityError);
                    }
                    continue;
                }

                var noProductIdError = GetLineItemNoProductIdError(lineItem.ProductId);
                if (noProductIdError != null)
                {
                    if (!errors.Contains(noProductIdError))
                    {
                        errors.Add(noProductIdError);
                    }
                    continue;
                }

                var nonExistentProductError = await GetLineItemNonExistentProductError(lineItem.ProductId);
                if (nonExistentProductError != null)
                {
                    errors.Add(nonExistentProductError);
                    continue;
                }
            }

            return errors;
        }

        private string GetLineItemQuantityError(int quantity) => quantity < 1
            ? "Purchase contains lineitem with a quantity less than 1."
            : null;
        private string GetLineItemNoProductIdError(int productId) => productId == default
            ? "Purchase contains lineitem with productId that is 0 or not defined."
            : null;
        private async Task<string> GetLineItemNonExistentProductError(int productId) => !await _productRepository.ExistsById(productId)
            ? $"Lineitem cannot contain a reference to a product that does not exist in the database (productId: {productId})."
            : null;
    }
}
