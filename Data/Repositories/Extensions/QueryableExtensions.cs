using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Data.Repositories.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyCustomOrderExpression<T>(
            this IQueryable<T> query,
            LambdaExpression expression,
            bool isFirstOrdering,
            bool isAscending
        )
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
                expression
            );
            
            return query.Provider.CreateQuery<T>(call);
        }

        public static IQueryable<T> ApplyCustomWhereExpression<T>(
            this IQueryable<T> query,
            LambdaExpression expression
        )
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

        public static IQueryable<T> ApplyCustomSelectExpression<T>(
            this IQueryable<T> query,
            LambdaExpression expression
        )
        {
            var method = "Select";
            var types = new Type[] { query.ElementType, expression.Body.Type };
            var args = new[] { query.Expression, Expression.Quote(expression) };

            var call = Expression.Call(
                typeof(Queryable),
                method,
                types,
                args
                //expression
            );


            return query.Provider.CreateQuery<T>(call);
        }
    }
}
