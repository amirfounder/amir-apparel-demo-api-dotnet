using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Data.Context
{
    public class AppCtx : DbContext, IAppCtx
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDatabase();
        }
    }
}
