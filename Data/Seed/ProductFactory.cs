using amir_apparel_demo_api_dotnet_5.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Data.Seed
{
    public class ProductFactory
    {

        private Random rand = new Random();

        private int getRandomIndex(int maxBound)
        {
            return rand.Next(0, maxBound);
        }

        private readonly string[] Materials = new string[] { "Cotton", "Polyesters", "Silk", "Leather" };
        private readonly string[] Types = new string[] { "Gloves", "Shorts", "Pants", "Shoes", "Socks", "Boxers" };


        public List<Product> BuildRandomProducts(int count)
        {
            var products = new List<Product>();

            for (int i = 0; i < count; i ++)
            {
                products.Add(BuildRandomProduct(i + 1));
            }

            return products;
        }
        private Product BuildRandomProduct(int id)
        {
            var material = GetRandomMaterial();
            var type = BuildRandomType();
            var name = BuildName(material, type);

            return new Product {
                Id = id,
                Name = name,
                Type = type,
                Description = BuildDescription(name),
                Material = material,
                Price = BuildRandomPrice(),
                AvailableQuantity = BuildRandomQuantity(),
                Status = BuildRandomStatus()
            };
        }
        
        private string GetRandomMaterial()
        {
            int randomIndex = getRandomIndex(Materials.Length);
            return Materials[randomIndex];
        }

        private string BuildRandomType()
        {
            int randomIndex = getRandomIndex(Types.Length);
            return Types[randomIndex];
        }

        private string BuildName(string material, string type)
        {
            return material + " " + type;
        }

        private string BuildDescription(string name)
        {
            return "These are some awesome " + name + "! These guys are definitely a steal!";
        }

        private decimal BuildRandomPrice()
        {
            var min = 10;
            var max = 100;
            var randomDouble = rand.NextDouble();
            return (decimal)(min + (randomDouble * (max - min)));
        }

        private int BuildRandomQuantity()
        {
            var min = 10;
            var max = 100;
            return rand.Next(min, max);
        }

        private bool BuildRandomStatus()
        {
            return rand.NextDouble() >= 0.5;
        }

    }
}
