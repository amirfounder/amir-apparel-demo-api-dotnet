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

            var firstProperty = Expression.Property(model, firstFilterProperty);
            var firstValuesFilters = firstProperty.BuildValuesFilters(firstFilterValues);

            var lambdaExpression = firstValuesFilters;
            
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

                    firstProperty = Expression.Property(model, filterProperty);
                    firstValuesFilters = firstProperty.BuildValuesFilters(filterValues);

                    lambdaExpression = Expression.Or(lambdaExpression, firstValuesFilters);
                }
            }           

            var expression = Expression.Lambda(lambdaExpression, model);

            return query.ApplyCustomWhereExpression(expression);
        }

        public static Expression BuildValuesFilters(this Expression property, string[] values)
        {
            var firstConstant = Expression.Constant(values[0], typeof(string));
            var expression = Expression.Equal(property, firstConstant);

            for (int i = 0; i < values.Length; i ++)
            {
                if (i == 0)
                {
                    continue;
                }

                var constant = Expression.Constant(values[i], typeof(string));
                expression = Expression.Or(property, constant);
            }

            return expression;
        }

        public static IQueryable<T> ApplyDistinctSelection<T>(this IQueryable<T> query, string propertyName)
        {
            //var properties = typeof(T)
            //    .GetType()
            //    .GetProperties(Binding...);

            var model = Expression.Parameter(typeof(T), "e");
            var property = Expression.Property(model, propertyName);
            var lambdaExpression = Expression.Lambda(property, model);

            return query.ApplyCustomSelectExpression(lambdaExpression);
        }

    }
}
