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

        public List<Product> BuildRandomProducts(int count)
        {
            var products = new List<Product>();

            for (int i = 0; i < count; i ++)
            {
                products.Add(BuildRandomProduct(i + 1));
            }

            return products;
        }
        public Product BuildRandomProduct(int id)
        {
            return new Product {
                Id=id,
                Name="Random Name",
                Type="Random Type",
                Description="Description",
                Material="Random Material",
                Price=12.11m,
                AvailableQuantity=10,
                Status=true
            };
        }
    }
}
