using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.API.MapperProfiles
{
    public static class MapperExtensions
    {
        public static Address BuildShippingAddress(this Purchase purchase)
        {
            return new Address
            {
                Street = purchase.ShippingAddressStreet,
                StreetOptional = purchase.ShippingAddressStreetOptional,
                City = purchase.ShippingAddressCity,
                State = purchase.ShippingAddressState,
                ZipCode = purchase.ShippingAddressZipCode
            };
        }

        public static Address BuildBillingAddress(this Purchase purchase)
        {
            return new Address
            {
                Street = purchase.BillingAddressStreet,
                StreetOptional = purchase.BillingAddressStreetOptional,
                City = purchase.BillingAddressCity,
                State = purchase.BillingAddressState,
                ZipCode = purchase.BillingAddressZipCode
            };
        }
    }
}
