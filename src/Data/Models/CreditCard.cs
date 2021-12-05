namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public class CreditCard : Entity
    {
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}
