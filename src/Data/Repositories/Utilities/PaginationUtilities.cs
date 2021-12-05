using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories.Utilities
{
    public static class PaginationUtilities
    {
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, Page<T> page) => query.Skip(page.Number * page.Size).Take(page.Size);
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string[] paginationSortables)
            where T : class, IEntity
        {
            var sortables = CleanPaginationSortables<T>(paginationSortables);

            if (sortables.Count == 0)
            {
                query = query.OrderBy(x => x.Id);
            }
            else
            {
                var sortable = sortables[0];
                var sortableProp = sortable[0];
                var isAscending = sortable[1] == "asc";
                query = query.OrderByProperty(sortableProp, isAscending, true);

                for (int i = 0; i < sortables.Count; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }

                    sortable = sortables[i];
                    sortableProp = sortable[0];
                    isAscending = sortable[1] == "asc";

                    query = query.OrderByProperty(sortableProp, isAscending, false);
                }
            }

            return query;
        }

        private static List<string[]> CleanPaginationSortables<T>(string[] paginationSortables)
        {
            var model = typeof(T);
            var filteredSortables = new List<string[]>();

            if (paginationSortables == default)
            {
                return filteredSortables;
            }

            var properties = model
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

                if (item.Length != 2 || !properties.Contains(item[0].ToUpper()))
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
