using amir_apparel_demo_api_dotnet_5.API.QueryParams;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories
{
    public abstract class EFBaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext context;

        public EFBaseRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<Page<TEntity>> GetAll(PaginationOptions paginationOptions)
        {
            Page<TEntity> page = new()
            {
                Number = paginationOptions.Page,
                Size = paginationOptions.Size,
                NumberOfElements = paginationOptions.Size
            };

            page.TotalElements = await context.Set<TEntity>().CountAsync();
            page.TotalPages = (int) Math.Ceiling(page.TotalElements / (double) page.Size);
            
            int offset = page.Number * page.Size;

            page.Content = await context.Set<TEntity>()
                .OrderBy(x => x.Id)
                .Skip(offset)
                .Take(page.Size)
                .ToListAsync();

            page.Empty = !page.Content.Any();

            return page;
        }
    }
}
