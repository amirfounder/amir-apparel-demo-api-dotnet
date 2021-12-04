using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
    }
}
