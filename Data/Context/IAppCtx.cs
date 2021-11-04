using amir_apparel_demo_api_dotnet_5.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace amir_apparel_demo_api_dotnet_5.Data.Context
{
    public interface IAppCtx
    {
        DbSet<Product> Products { get; set; }
    }
}
