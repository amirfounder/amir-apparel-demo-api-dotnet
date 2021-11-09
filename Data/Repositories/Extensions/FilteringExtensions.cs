using amir_apparel_demo_api_dotnet_5.API.CustomRequestQueries;
using System.Linq;
using System.Linq.Expressions;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories.Extensions
{
    public static class FilteringExtensions
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

            var model = Expression.Parameter(typeof(T), "e");

            var property = Expression.Property(model, firstFilterProperty);
            var valuesFilter = property.BuildOrPredicateFilter(firstFilterValues);

            var body = valuesFilter;
            
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

                    property = Expression.Property(model, filterProperty);
                    valuesFilter = property.BuildOrPredicateFilter(filterValues);

                    body = Expression.And(body, valuesFilter);
                    // todo --> should this be an "AND"? AND i love reyna
                }
            }           

            var expression = Expression.Lambda(body, model);

            return query.ApplyCustomWhere(expression);
        }

        public static Expression BuildOrPredicateFilter(this Expression property, string[] values)
        {
            var constant = Expression.Constant(values[0]);
            var equals = Expression.Equal(property, constant);
            var expression = equals;

            for (int i = 0; i < values.Length; i ++)
            {
                if (i == 0)
                {
                    continue;
                }

                constant = Expression.Constant(values[i], typeof(string));
                equals = Expression.Equal(property, constant);

                expression = Expression.Or(expression, equals);
            }

            return expression;
        }

        public static IQueryable<TResult> ApplySelection<T, TResult>(this IQueryable<T> query, string propertyName)
        {
            var parameterExp = Expression.Parameter(typeof(T), "e");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            var lambdaExp = Expression.Lambda(propertyExp, parameterExp);

            return query.ApplyCustomSelect<T, TResult>(lambdaExp);
        }
    }
}
