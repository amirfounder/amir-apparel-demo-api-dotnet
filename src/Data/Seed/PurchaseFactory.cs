using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Utilities;
using System.Collections.Generic;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Seed
{
    public class PurchaseFactory : EntityFactory<Purchase>
    {
        private IEnumerable<Product> _products;

        public PurchaseFactory(IEnumerable<Product> products) : base()
        {
            _products = products;
        }

        public override Purchase BuildEntity(int id)
        {
            return new Purchase
            {
                Id = id,
                Email = BuildRandomEmail()
            };
        }

        private string BuildRandomEmail() => $"{_alphabet.Random()}@{_alphabet.Random()}.{_alphabet.Random()}";
    }
}
