using amir_apparel_demo_api_dotnet_5.API.CustomQueries;
using amir_apparel_demo_api_dotnet_5.Data.Models;
using amir_apparel_demo_api_dotnet_5.Data.Models.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories.Extensions
{
    public static class DbSetExtensions
    {
        public static IQueryable<T> BuildSortedQuery<T>(
            this DbSet<T> set,
            IPaginationOptions paginationOptions,
            Type model
        )
            where T : class, IEntity
        {
            IOrderedQueryable<T> query;
            var sortables = FilterInvalidPaginationSortables(paginationOptions, model);

            // Potential solution: https://stackoverflow.com/questions/31955025/generate-ef-orderby-expression-by-string
            if (sortables.Count == 0)
            {
                query = set.OrderBy(x => EF.Property<T>(x, "Id"));
            }
            else
            {
                var firstSortable = sortables[0];
                
                var firstSortableProperty = firstSortable[0];
                var firstSortableDirection = firstSortable[1];

                query = (firstSortableDirection == "asc")
                    ? set.OrderBy(x => EF.Property<T>(x, x.GetProperty(firstSortableProperty).Name))
                    : set.OrderByDescending(x => EF.Property<T>(x, x.GetProperty(firstSortableProperty).Name);

                if (sortables.Count > 1)
                {
                    foreach (var sortable in sortables)
                    {
                        var sortableProperty = sortable[0];
                        var sortableDirection = sortable[1];

                        query = (sortable[1] == "asc")
                            ? query.ThenBy(x => EF.Property<T>(x, x.GetProperty(firstSortableProperty).Name))
                            : query.ThenByDescending(x => EF.Property<T>(x, x.GetProperty(firstSortableProperty).Name));
                    }
                }
            }

            return query;
        }

        private static List<string[]> FilterInvalidPaginationSortables(IPaginationOptions paginationOptions, Type model)
        {
            var filteredSortables = new List<string[]>();
            var modelProperties = model
                .GetProperties()
                .Select(x => x.Name.ToUpper())
                .ToList();

            foreach (string sortable in paginationOptions.Sort)
            {
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
