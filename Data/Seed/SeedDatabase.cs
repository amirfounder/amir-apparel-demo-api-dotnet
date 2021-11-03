using amir_apparel_demo_api_dotnet_5.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Data.Seed
{
    public static class Extensions
    {
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            var productFactory = new ProductFactory();

            var products = productFactory.BuildRandomProducts(500);

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
