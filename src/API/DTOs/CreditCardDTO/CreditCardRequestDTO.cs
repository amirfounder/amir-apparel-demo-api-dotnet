namespace Amir.Apparel.Demo.Api.Dotnet.API.DTOs
{
    public class CreditCardRequestDTO
    {
        public string CardholderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}
