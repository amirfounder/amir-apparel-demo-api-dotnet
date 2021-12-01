using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Seed;

namespace Amir.Apparel.Demo.Api.Dotnet.Tests.Utilities
{
    public static class DatabaseSetupExtensions
    {
        public static void InitializeDatabaseForTests(this ApplicationContext context)
        {
            var productFactory = new ProductFactory();
            var products = productFactory.BuildRandomProducts(250);

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        public static void ReinitializeDatabaseForTests(this ApplicationContext context)
        {
            context.Products.RemoveRange(context.Products);
            context.InitializeDatabaseForTests();
        }
    }
}
