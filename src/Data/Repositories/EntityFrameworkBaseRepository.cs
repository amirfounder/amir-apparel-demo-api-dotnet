using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using Amir.Apparel.Demo.Api.Dotnet.Data.Repositories.Utilities;
using Amir.Apparel.Demo.Api.Dotnet.Utilities;
using Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories
{
    public abstract class EntityFrameworkBaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EntityFrameworkBaseRepository(TContext context)
        {
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

        public async Task<IPage<TEntity>> GetAll(IPaginationOptions paginationOptions)
        {
            var query = _context
                .Set<TEntity>()
                .ApplySorting(paginationOptions.Sort);

            Page<TEntity> page = new(paginationOptions);

            page.TotalElements = await query.CountAsync();
            page.Content = await query
                .Skip(page.Number * page.Size)
                .Take(page.Size)
                .ToListAsync();

            return page;
        }

        public async Task<IPage<TEntity>> GetAll(IPaginationOptions paginationOptions, IFilterable<TEntity> filterable)
        {
            var query = _context
                .Set<TEntity>()
                .ApplyFiltering(filterable)
                .ApplySorting(paginationOptions.Sort);

            Page<TEntity> page = new(paginationOptions);

            page.TotalElements = await query.CountAsync();
            page.Content = await query
                .Skip(page.Number * page.Size)
                .Take(page.Size)
                .ToListAsync();

            return page;
        }

        public async Task<TEntity> GetByProperty(string property, string value)
        {
            var properProperty = typeof(TEntity).GetPropertyName(property);

            if (properProperty == null)
            {
                return null;
            }

            var toUpperMethod = typeof(string).GetMethod("ToUpper", Array.Empty<Type>());
            var paramExp = Expression.Parameter(typeof(TEntity));
            var propExp = Expression.Property(paramExp, property);
            var constExp = Expression.Constant(value, typeof(string));
            var rightExp = Expression.Call(propExp, toUpperMethod);
            var leftExp = Expression.Call(constExp, toUpperMethod);
            var equalExp = Expression.Equal(leftExp, rightExp);
            var lambdaExp = Expression.Lambda(equalExp, paramExp);

            var query = _context
                .Set<TEntity>()
                .ApplyCustomWhere(lambdaExp);

            var entities = await query.ToListAsync();

            if (entities.Count == 0)
            {
                return null;
            }

            if (entities.Count > 1)
            {
                throw new ServerErrorException($"Something went wrong when accessing database to find entity by {property}");
            }

            return entities[0];
        }

        public async Task<IEnumerable> GetDistinct(string property)
        {
            var query = _context
                .Set<TEntity>()
                .AsQueryable();

            var propertyType = typeof(TEntity)
                .GetPropertyType(property)
                ?.Name
                ?.ToLower();

            return propertyType switch
            {
                "bool" => await query.SelectByProperty<TEntity, bool>(property).Distinct().ToListAsync(),
                "byte" => await query.SelectByProperty<TEntity, byte>(property).Distinct().ToListAsync(),
                "char" => await query.SelectByProperty<TEntity, char>(property).Distinct().ToListAsync(),
                "decimal" => await query.SelectByProperty<TEntity, decimal>(property).Distinct().ToListAsync(),
                "double" => await query.SelectByProperty<TEntity, double>(property).Distinct().ToListAsync(),
                "single" => await query.SelectByProperty<TEntity, float>(property).Distinct().ToListAsync(),
                "int16" => await query.SelectByProperty<TEntity, short>(property).Distinct().ToListAsync(),
                "int32" => await query.SelectByProperty<TEntity, int>(property).Distinct().ToListAsync(),
                "uint16" => await query.SelectByProperty<TEntity, ushort>(property).Distinct().ToListAsync(),
                "uint32" => await query.SelectByProperty<TEntity, uint>(property).Distinct().ToListAsync(),
                "string" => await query.SelectByProperty<TEntity, string>(property).Distinct().ToListAsync(),
                _ => null
            };

        }
        public async Task<bool> ExistsById(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity != null;
        }

        public async Task<TEntity> Save(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
