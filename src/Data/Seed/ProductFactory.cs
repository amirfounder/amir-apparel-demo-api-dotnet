using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Utilities;
using System;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Seed
{
    public class ProductFactory : EntityFactory<Product>
    {
        private readonly string[] Materials = new string[] { "Cotton", "Polyesters", "Silk", "Leather" };
        private readonly string[] Types = new string[] { "Gloves", "Shorts", "Pants", "Shoes", "Socks", "Boxers" };
        private readonly string[] Demographics = new string[] { "Men", "Women", "Kids" };
        private readonly string[] HexCodes = new string[] { "b0160b", "16f7d2", "870bb0", "0b81b0" };

        public override Product BuildEntity(int id)
        {
            var material = GetRandomMaterial();
            var type = BuildRandomType();
            var name = BuildName(material, type);
            var hexCode = BuildRandomHexCode();

            return new Product
            {
                Id = id,
                Name = name,
                Type = type,
                Description = BuildDescription(name),
                LaunchDate = BuildRandomLaunchDate(),
                HexCode = hexCode,
                Color = BuildColor(hexCode),
                Demographic = BuildRandomDemographic(),
                Material = material,
                Price = BuildRandomPrice(),
                AvailableQuantity = BuildRandomQuantity(),
                Status = BuildRandomStatus()
            };
        }

        private string GetRandomMaterial() => Materials.Random();
        private string BuildRandomType() => Types.Random();
        private string BuildRandomDemographic() => Demographics.Random();
        private string BuildRandomHexCode() => HexCodes.Random();

        private decimal BuildRandomPrice()
        {
            var min = 10;
            var max = 100;
            var randomDouble = _rand.NextDouble();
            var price = (decimal)(min + (randomDouble * (max - min)));
            return decimal.Round(price, 2);
        }

        private DateTime BuildRandomLaunchDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(_rand.Next(range));
        }

        private int BuildRandomQuantity() => _rand.Next(100, 500);
        private bool BuildRandomStatus() => _rand.NextDouble() >= 0.5;
        private static string BuildName(string material, string type) => material + " " + type;
        private static string BuildDescription(string name) => "These are some awesome " + name + "! These guys are definitely a steal!";
        private static string BuildColor(string hexCode) => hexCode switch
        {
            "b0160b" => "Dark Red",
            "16f7d2" => "Purple",
            "870bb0" => "Turquoise",
            "0b81b0" => "Blue",
            _ => "Unkown"
        };
    }
}
