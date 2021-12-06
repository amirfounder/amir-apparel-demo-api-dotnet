using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public interface ILineItemValidation
    {
        Task<IEnumerable<string>> ValidateLineItems(IEnumerable<LineItem> lineItems);
    }
}
