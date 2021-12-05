using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using System.Linq;
using System.Linq.Expressions;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories.Utilities
{
    public static class FilteringUtilities
    {
        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> query, IFilterable<T> filterable)
            where T : class
        {
            var filters = filterable.GetFilters();

            if (filters.Count == 0)
            {
                return query;
            }

            var firstFilter = filters.First();

            var firstFilterProperty = firstFilter.Key;
            var firstFilterValues = firstFilter.Value;

            var parameterExp = Expression.Parameter(typeof(T));

            var propertyExp = Expression.Property(parameterExp, firstFilterProperty);
            var orPredicateExp = propertyExp.BuildOrPredicateFilter(firstFilterValues);

            var bodyExp = orPredicateExp;

            if (filters.Count > 1)
            {
                foreach (var filter in filters)
                {
                    var filterProperty = filter.Key;
                    var filterValues = filter.Value;

                    if (firstFilterProperty == filterProperty || filterValues.Length == 0)
                    {
                        continue;
                    }

                    propertyExp = Expression.Property(parameterExp, filterProperty);
                    orPredicateExp = propertyExp.BuildOrPredicateFilter(filterValues);

                    bodyExp = Expression.And(bodyExp, orPredicateExp);
                }
            }

            var lambdaExp = Expression.Lambda(bodyExp, parameterExp);

            return query.ApplyCustomWhere(lambdaExp);
        }
    }
}
