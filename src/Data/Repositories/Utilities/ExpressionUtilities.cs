using System;
using System.Linq.Expressions;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Repositories.Utilities
{
    public static class ExpressionUtilities
    {
        public static Expression BuildOrPredicateFilter(this Expression propertyExp, string[] values)
        {
            var toUpperMethod = typeof(string).GetMethod("ToUpper", Array.Empty<Type>());

            var constant = Expression.Constant(values[0]);

            var left = Expression.Call(propertyExp, toUpperMethod);
            var right = Expression.Call(constant, toUpperMethod);

            var expression = Expression.Equal(left, right);

            for (int i = 0; i < values.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                constant = Expression.Constant(values[i], typeof(string));
                right = Expression.Call(constant, toUpperMethod);

                expression = Expression.Or(expression, Expression.Equal(left, right));
            }

            return expression;
        }
    }
}
