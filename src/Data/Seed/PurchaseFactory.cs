using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Utilities;
using System.Collections.Generic;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Seed
{
    public class PurchaseFactory : EntityFactory<Purchase>
    {
        private IEnumerable<Product> _products;
        private IEnumerable<string> _firstNames = new string[] { "Amir", "Jack", "Morgan", "Jon", "Tyler", "Alex", "Alexis" };
        private IEnumerable<string> _lastNames = new string[] { "Sharapov", "Smith", "Doe", "Johnson", "Brown", "Williams", "Miller" };
        private IEnumerable<string> _streets = new string[] { "24th", "Main", "Ogden", "Park", "Fourth", "Oak", "Elm" };
        private IEnumerable<string> _emailDomains = new string[] { "gmail.com", "yahoo.com", "aol.com", "outlook.com" };
        private IEnumerable<string> _streetTypes = new string[] { "Ave", "Dr", "Ct", "Ln" };
        private IEnumerable<string> _cities = new string[] { "Chicago", "Denver", "Detroit", "New York City" };
        private IEnumerable<string> _states = Constants.States;

        public PurchaseFactory(IEnumerable<Product> products) : base()
        {
            _products = products;
        }

        public override Purchase BuildEntity(int id)
        {
            var firstName = BuildRandomFirstName();
            var lastName = BuildRandomLastName();
            var address = BuildRandomAddress();

            return new Purchase
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = BuildEmail(firstName, lastName),
                CreditCard = BuildRandomCreditCard(firstName, lastName),
                BillingAddress = address,
                ShippingAddress = address
            };
        }

        public CreditCard BuildRandomCreditCard(string firstName, string lastName) => new()
        {
            CardholderName = BuildCardholderName(firstName, lastName),
            CardNumber = BuildRandomCardNumber(),
            ExpirationDate = BuildRandomExpirationDate(),
            Cvv = BuildRandomCvv()
        };

        public Address BuildRandomAddress() => new()
        {
            Street = BuildRandomStreet(),
            StreetOptional = BuildRandomStreetOptional(),
            City = BuildRandomCity(),
            State = BuildRandomState(),
            ZipCode = BuildRandomZipCode()
        };

        private string BuildRandomFirstName() => _firstNames.Random();
        private string BuildRandomLastName() => _lastNames.Random();
        private string BuildEmail(string firstName, string lastName) => $"{firstName.ToLower()}{lastName.ToLower()}@{_emailDomains.Random()}";

        private string BuildRandomStreet() => $"{string.Concat(_numbers.BuildRandomSequence(4))} {_streets.Random()} {_streetTypes.Random()}";
        private string BuildRandomStreetOptional() => $"Suite #{string.Concat(_numbers.BuildRandomSequence(3))}";
        private string BuildRandomCity() => _cities.Random();
        private string BuildRandomState() => _states.Random();
        private string BuildRandomZipCode() => string.Concat(_numbers.BuildRandomSequence(5));
        
        private string BuildCardholderName(string firstName, string lastName) => $"{firstName} {lastName}";
        private string BuildRandomCardNumber() => string.Concat(_numbers.BuildRandomSequence(16));
        private string BuildRandomCvv() => string.Concat(_numbers.BuildRandomSequence(3));
        private string BuildRandomExpirationDate() => $"{_rand.Next(1, 13):00}/{_rand.Next(1, 28):00}";
    }
}
