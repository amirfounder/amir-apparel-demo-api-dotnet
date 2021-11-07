using amir_apparel_demo_api_dotnet_5.HttpStatusExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace amir_apparel_demo_api_dotnet_5.API.Filters
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
