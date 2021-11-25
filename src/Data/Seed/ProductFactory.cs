using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Utilities;
using System;
using System.Collections.Generic;

namespace amir_apparel_demo_api_dotnet_5.Data.Seed
{
    public class ProductFactory
    {

        private readonly Random rand = new();

        private readonly string[] Materials = new string[] { "Cotton", "Polyesters", "Silk", "Leather" };
        private readonly string[] Types = new string[] { "Gloves", "Shorts", "Pants", "Shoes", "Socks", "Boxers" };
        private readonly string[] Demographics = new string[] { "Men", "Women", "Kids" };
        private readonly string[] HexCodes = new string[] { "b0160b", "16f7d2", "870bb0", "0b81b0" };


        public List<Product> BuildRandomProducts(int count)
        {
            var products = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                products.Add(BuildRandomProduct(i + 1));
            }

            return products;
        }
        public Product BuildRandomProduct(int id)
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

        private string GetRandomMaterial()
        {
            return Materials.Random();
        }

        private string BuildRandomType()
        {
            return Types.Random();
        }

        private string BuildRandomDemographic()
        {
            return Demographics.Random();
        }

        private DateTime BuildRandomLaunchDate()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }

        private string BuildRandomHexCode()
        {
            return HexCodes.Random();
        }

        private decimal BuildRandomPrice()
        {
            var min = 10;
            var max = 100;
            var randomDouble = rand.NextDouble();
            var price = (decimal)(min + (randomDouble * (max - min)));
            return decimal.Round(price, 2);
        }

        private int BuildRandomQuantity()
        {
            var min = 100;
            var max = 500;
            return rand.Next(min, max);
        }

        private bool BuildRandomStatus()
        {
            return rand.NextDouble() >= 0.5;
        }

        private string BuildColor(string hexCode) => hexCode switch
        {
            "b0160b" => "Dark Red",
            "16f7d2" => "Purple",
            "870bb0" => "Turquoise",
            "0b81b0" => "Blue",
            _ => "Unkown"
        };

        private static string BuildName(string material, string type)
        {
            return material + " " + type;
        }

        private static string BuildDescription(string name)
        {
            return "These are some awesome " + name + "! These guys are definitely a steal!";
        }

    }
}
