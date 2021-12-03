using Amir.Apparel.Demo.Api.Dotnet.UtilitiesHttpStatusExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Amir.Apparel.Demo.Api.Dotnet.API.Filters
{
    public class HttpStatusExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is IHttpStatusException exception)
            {
                context.Result = new ObjectResult(exception.Value)
                {
                    StatusCode = exception.Value.Status
                };
                context.ExceptionHandled = true;
            }
        }

    }
}
