using Amir.Apparel.Demo.Api.Dotnet.API.Mapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public class Purchase : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<LineItem> LineItems { get; set; }

        public string ShippingAddressStreet { get; set; }
        public string ShippingAddressStreetOptional { get; set; }
        public string ShippingAddressCity { get; set; }
        public string ShippingAddressState { get; set; }
        public string ShippingAddressZipCode { get; set; }

        public string BillingAddressStreet { get; set; }
        public string BillingAddressStreetOptional { get; set; }
        public string BillingAddressCity { get; set; }
        public string BillingAddressState { get; set; }
        public string BillingAddressZipCode { get; set; }

        public string CreditCardCardholderName { get; set; }
        public string CreditCardCardNumber { get; set; }
        public string CreditCardExpirationDate { get; set; }
        public string CreditCardCvv { get; set; }

        [NotMapped]
        public Address ShippingAddress
        {
            get => this.BuildShippingAddress();
            set
            {
                ShippingAddressStreet = value?.Street;
                ShippingAddressStreetOptional = value?.StreetOptional;
                ShippingAddressCity = value?.City;
                ShippingAddressState = value?.State;
                ShippingAddressZipCode = value?.ZipCode;
            }
        }
        [NotMapped]
        public Address BillingAddress
        {
            get => this.BuildBillingAddress();
            set
            {
                BillingAddressStreet = value?.Street;
                BillingAddressStreetOptional = value?.StreetOptional;
                BillingAddressCity = value?.City;
                BillingAddressState = value?.State;
                BillingAddressZipCode = value?.ZipCode;
            }
        }
        [NotMapped]
        public CreditCard CreditCard
        {
            get => this.BuildCreditCard();
            set
            {
                CreditCardCardholderName = value?.CardholderName;
                CreditCardCardNumber = value?.CardNumber;
                CreditCardExpirationDate = value?.ExpirationDate;
                CreditCardCvv = value?.Cvv;
            }
        }
    }
}
