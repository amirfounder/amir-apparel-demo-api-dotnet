using System.Collections.Generic;

namespace Amir.Apparel.Demo.Api.Dotnet.API.DTOs
{
    public class PurchaseResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<LineItemResponseDTO> LineItems { get; set; }
        public AddressResponseDTO ShippingAddress { get; set; }
        public AddressResponseDTO BillingAddress { get; set; }
        public CreditCardResponseDTO CreditCard { get; set; }
    }
}
