using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public class LineItemProvider : ILineItemProvider
    {
        public IEnumerable<LineItem> MergeLineItemsWithSameProductId(IEnumerable<LineItem> lineItems)
        {
            var lineItemProductIds = new List<int>();
            var lineItemsClean = new List<LineItem>();

            foreach (var lineItem in lineItems)
            {
                var productId = lineItem.ProductId;
                var productIdIsDuplicate = lineItemProductIds.Contains(productId);

                if (productIdIsDuplicate)
                {
                    var lineItemCleaned = lineItems.Where(x => x.ProductId == productId).First();
                    var index = lineItemsClean.IndexOf(lineItemCleaned);
                    lineItemsClean[index].Quantity += lineItem.Quantity;
                }
                else
                {
                    lineItemsClean.Add(lineItem);
                    lineItemProductIds.Add(productId);
                }
            }

            return lineItemsClean;
        }
    }
}
