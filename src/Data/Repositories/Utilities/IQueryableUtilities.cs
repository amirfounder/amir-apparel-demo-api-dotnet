using System;
using System.Linq;
using System.Linq.Expressions;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories.Utilities
{
    public static class IQueryableUtilities
    {
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
