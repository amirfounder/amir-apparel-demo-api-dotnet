using amir_apparel_demo_api_dotnet_5.API.CustomQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories.Extensions
{
    public static class PaginationExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string[] paginationSortables, Type model)
            where T : class, IEntity
        {
            
            var sortables = FilterInvalidPaginationSortables(paginationSortables, model);

            if (sortables.Count == 0)
            {
                query = query.OrderBy(x => x.Id);
            }
            else
            {
                var sortable = sortables[0];
                var sortableProp = sortable[0];
                var isAscending = sortable[1] == "asc";

                query = query.OrderByField(sortableProp, isAscending, true);

                for (int i = 0; i < sortables.Count; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }

                    sortable = sortables[i];
                    sortableProp = sortable[0];
                    isAscending = sortable[1] == "asc";

                    query = query.OrderByField(sortableProp, isAscending, false);
                }
            }

            return query;
        }

        private static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string field, bool isAscending, bool isFirstOrdering)
        {
            var param = Expression.Parameter(typeof(T), "entity");
            var property = Expression.Property(param, field);
            var expression = Expression.Lambda(property, param);

            string method = isFirstOrdering
                ? (isAscending) ? "OrderBy" : "OrderByDescending"
                : (isAscending) ? "ThenBy" : "ThenByDescending";

            Type[] types = new Type[] { query.ElementType, expression.Body.Type };
            var call = Expression.Call(
                typeof(Queryable),
                method,
                types,
                query.Expression,
                expression
            );

            return query.Provider.CreateQuery<T>(call);
        }

        private static List<string[]> FilterInvalidPaginationSortables(string[] paginationSortables, Type model)
        {
            var filteredSortables = new List<string[]>();

            if (paginationSortables == default)
            {
                return filteredSortables;
            }

            var modelProperties = model
                .GetProperties()
                .Select(x => x.Name.ToUpper())
                .ToList();

            foreach (string sortable in paginationSortables)
            {
                if (sortable == null)
                {
                    continue;
                }

                string[] item = sortable.Split(",");

                if (item.Length != 2 || !modelProperties.Contains(item[0].ToUpper()))
                {
                    continue;
                }
                else
                {
                    if (item[0] != "asc" && item[0] != "desc")
                    {
                        item[1] = "asc";
                    }
                    filteredSortables.Add(item);
                }
            }

            return filteredSortables;
        }
    }
}
