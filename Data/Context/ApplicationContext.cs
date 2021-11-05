using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace amir_apparel_demo_api_dotnet_5.Data.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDatabase();
        }
    }
}
