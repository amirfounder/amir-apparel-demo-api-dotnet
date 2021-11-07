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
        public static IQueryable<T> BuildSortedQuery<T>(this DbSet<T> set, IPaginationOptions paginationOptions, Type model)
            where T : class, IEntity
        {
            var sortables = FilterInvalidPaginationSortables(paginationOptions, model);
            var query = ApplyOrderingUsingSortables<T>(set, sortables);

            return query;
        }

        private static IQueryable<T> OrderByField<T>(this IQueryable<T> query, string field, bool ascending, bool firstOrdering)
        {
            var param = Expression.Parameter(typeof(T), "entity");
            var property = Expression.Property(param, field);
            var expression = Expression.Lambda(property, param);

            string method = firstOrdering
                ? (ascending) ? "OrderBy" : "OrderByDescending"
                : (ascending) ? "ThenBy" : "ThenByDescending";

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

        private static IQueryable<T> ApplyOrderingUsingSortables<T>(DbSet<T> set, List<string[]> sortables) where T : class, IEntity
        {
            IQueryable<T> query;

            if (sortables.Count == 0)
            {
                query = set.OrderBy(x => x.Id);
            }
            else
            {
                var sortable = sortables[0];
                var sortableProp = sortable[0];
                var isAscending = sortable[1] == "asc";

                query = set.OrderByField(sortableProp, isAscending, true);

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

        private static List<string[]> FilterInvalidPaginationSortables(IPaginationOptions paginationOptions, Type model)
        {
            var filteredSortables = new List<string[]>();

            if (paginationOptions.Sort == default)
            {
                return filteredSortables;
            }

            var modelProperties = model
                .GetProperties()
                .Select(x => x.Name.ToUpper())
                .ToList();

            foreach (string sortable in paginationOptions.Sort)
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
                    if (item[0] != "asc" || item[0] != "desc")
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
