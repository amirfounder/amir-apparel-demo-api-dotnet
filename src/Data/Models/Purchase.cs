using System.Collections.Generic;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public class Purchase : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<LineItem> LineItems {get; set;}
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
    }
}
