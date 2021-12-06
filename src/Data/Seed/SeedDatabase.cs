﻿using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Seed
{
    public static class Extensions
    {
        public static ModelBuilder SeedDatabase(this ModelBuilder modelBuilder)
        {
            var productFactory = new ProductFactory();
            var products = productFactory.BuildEntities(500);

            modelBuilder.Entity<Product>().HasData(products);

            return modelBuilder;
        }
    }
}
