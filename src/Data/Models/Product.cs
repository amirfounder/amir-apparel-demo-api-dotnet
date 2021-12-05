using System;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Models
{
    public class Product : Entity, IEntity
    {
        public Product() : base() { }

        public string Name { get; set; }

        public string HexCode { get; set; }

        public string Color { get; set; }

        public string Demographic { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime LaunchDate { get; set; }

        public string Material { get; set; }

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }

        public bool Status { get; set; }
    }
}
