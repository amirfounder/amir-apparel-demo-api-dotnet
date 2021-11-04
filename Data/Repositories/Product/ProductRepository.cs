using amir_apparel_demo_api_dotnet_5.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IAppCtx _ctx;

        public ProductRepository(IAppCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _ctx.Products.ToListAsync();
        }
    }
}
