using System;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Providers
{
    public interface IPurchaseController
    {
        Task<Purchase> CreatePurchaseAsync(Purchase purchase);
    }
}
