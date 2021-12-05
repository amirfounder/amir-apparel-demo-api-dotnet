using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System.Collections.Generic;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public interface ILineItemProvider
    {
        IEnumerable<LineItem> MergeLineItemsWithSameProductId(IEnumerable<LineItem> lineItems);
    }
}
