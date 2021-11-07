using amir_apparel_demo_api_dotnet_5.API.CustomQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories.Extensions;
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
        private readonly TContext _context;
        private readonly Type _model;

        public EFBaseRepository(Type model, TContext context)
        {
            _model = model;
            _context = context;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<Page<TEntity>> GetAll(IPaginationOptions paginationOptions)
        {
            Page<TEntity> page = new()
            {
                Number = paginationOptions.Page,
                Size = paginationOptions.Size,
                NumberOfElements = paginationOptions.Size
            };

            page.TotalElements = await _context.Set<TEntity>().CountAsync();
            page.TotalPages = (int)Math.Ceiling(page.TotalElements / (double)page.Size);

            var query = _context
                .Set<TEntity>()
                .AsQueryable<TEntity>();

            query.ApplySorting(paginationOptions, _model);

            page.Content = await query
                .Skip(page.Number * page.Size)
                .Take(page.Size)
                .ToListAsync();

            page.Empty = !page.Content.Any();

            return page;
        }
    }
}
