using amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
            var query = _context
                .Set<TEntity>()
                .ApplySorting(paginationOptions.Sort, _model);

            Page<TEntity> page = new(paginationOptions);

            page.TotalElements = await query.CountAsync();
            page.Content = await query
                .Skip(page.Number * page.Size)
                .Take(page.Size)
                .ToListAsync();

            return page;
        }

        public async Task<Page<TEntity>> GetAll(IPaginationOptions paginationOptions, IFilterable<TEntity> filterable)
        {
            var query = _context
                .Set<TEntity>()
                .ApplyFiltering(filterable)
                .ApplySorting(paginationOptions.Sort, _model);

            Page<TEntity> page = new(paginationOptions);

            page.TotalElements = await query.CountAsync();
            page.Content = await query
                .Skip(page.Number * page.Size)
                .Take(page.Size)
                .ToListAsync();

            return page;
        }

        public async Task<IEnumerable> GetDistinct(string property)
        {
            var query = _context
                .Set<TEntity>()
                .AsQueryable();

            var returnType = typeof(TEntity)
                .GetRuntimeProperties()
                .Where(x => x.Name.ToUpper() == property.ToUpper())
                .ElementAt(0)
                .PropertyType;

            /// TODO: Refactor using Linq Expressions

            if (returnType == typeof(bool))
            {
                return await query.ApplySelection<TEntity, bool>(property).Distinct().ToListAsync();
            }
            else if (returnType == typeof(decimal))
            {
                return await query.ApplySelection<TEntity, decimal>(property).Distinct().ToListAsync();
            }
            else if (returnType == typeof(int))
            {
                return await query.ApplySelection<TEntity, int>(property).Distinct().ToListAsync();
            }

            return await query.ApplySelection<TEntity, object>(property).Distinct().ToListAsync();
        }
    }
}
