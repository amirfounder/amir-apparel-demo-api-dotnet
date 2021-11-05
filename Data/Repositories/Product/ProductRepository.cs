using amir_apparel_demo_api_dotnet_5.Data.Context;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _ctx.Products.FindAsync(id);
            }

            // How come we don't just catch all 500 / 503 exception in our filter? SRP?

            catch (Exception e)
            {
                if (e.InnerException is NpgsqlException)
                {
                    throw new ServiceUnavailableException(e.Message);
                }
                if (e is DbUpdateException)
                {
                    throw new ServiceUnavailableException("Could not save changes to the databse");
                }
                throw;
            }
        }
    }
}
