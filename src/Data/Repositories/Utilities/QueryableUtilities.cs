using Amir.Apparel.Demo.Api.Dotnet.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories.Utilities
{
    public static class QueryableUtilities
    {
        public static IQueryable<T> WherePropertyEquals<T>(this IQueryable<T> query, string property, string value)
        {
            var propertyType = typeof(T).GetPropertyType(property);

            if (propertyType == null)
            {
                return query;
            }

            return query;
        }
        public static IQueryable<TResult> SelectByProperty<T, TResult>(this IQueryable<T> query, string property)
        {
            var parameterExp = Expression.Parameter(typeof(T), "e");
            var propertyExp = Expression.Property(parameterExp, property);
            var lambdaExp = Expression.Lambda(propertyExp, parameterExp);

            return query.ApplyCustomSelect<T, TResult>(lambdaExp);
        }

        public static IQueryable<T> OrderByProperty<T>(this IQueryable<T> query, string property, bool isAscending, bool isFirstOrdering)
        {
            var model = Expression.Parameter(typeof(T), "e");
            var prop = Expression.Property(model, property);
            var expression = Expression.Lambda(prop, model);

            return query.ApplyCustomOrder(expression, isFirstOrdering, isAscending);
        }

        public static IQueryable<T> ApplyCustomOrder<T>(this IQueryable<T> query, LambdaExpression expression, bool isFirstOrdering, bool isAscending)
        {
            var method = isFirstOrdering
                ? (isAscending) ? "OrderBy" : "OrderByDescending"
                : (isAscending) ? "ThenBy" : "ThenByDescending";

            var types = new Type[] { query.ElementType, expression.Body.Type };
            var call = Expression.Call(
                typeof(Queryable),
                method,
                types,
                query.Expression,
                expression);

            return query.Provider.CreateQuery<T>(call);
        }

        public static IQueryable<T> ApplyCustomWhere<T>(this IQueryable<T> query, LambdaExpression expression)
        {
            var method = "Where";
            var types = new Type[] { query.ElementType };

            var call = Expression.Call(
                typeof(Queryable),
                method,
                types,
                query.Expression,
                expression);

            return query.Provider.CreateQuery<T>(call);
        }

        public static IQueryable<TResult> ApplyCustomSelect<T, TResult>(this IQueryable query, LambdaExpression expression)
        {
            var method = "Select";
            var types = new Type[] { query.ElementType, expression.Body.Type };

            var call = Expression.Call(
                typeof(Queryable),
                method,
                types,
                query.Expression,
                expression);

            return query.Provider.CreateQuery<TResult>(call);
        }
    }
}
