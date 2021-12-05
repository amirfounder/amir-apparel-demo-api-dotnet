using System.Collections.Generic;

namespace Amir.Apparel.Demo.Api.Dotnet.API.DTOs
{
    public class PurchaseRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<LineItemRequestDTO> LineItems { get; set; }
        public AddressRequestDTO ShippingAddress { get; set; }
        public AddressRequestDTO BillingAddress { get; set; }
        public CreditCardRequestDTO CreditCard { get; set; }
    }
}
