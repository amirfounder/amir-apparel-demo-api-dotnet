using Amir.Apparel.Demo.Api.Dotnet.API.CustomQueries;
using System;
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

            var parameterExp = Expression.Parameter(typeof(T), "e");

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

        public static Expression BuildOrPredicateFilter(this Expression propertyExp, string[] values)
        {
            var upperCaseMethod = typeof(string).GetMethod("ToUpper", Array.Empty<Type>());

            var constant = Expression.Constant(values[0]);

            var left = Expression.Call(propertyExp, upperCaseMethod);
            var right = Expression.Call(constant, upperCaseMethod);

            var expression = Expression.Equal(left, right);

            for (int i = 0; i < values.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                constant = Expression.Constant(values[i], typeof(string));
                right = Expression.Call(constant, upperCaseMethod);

                expression = Expression.Or(expression, Expression.Equal(left, right));
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
