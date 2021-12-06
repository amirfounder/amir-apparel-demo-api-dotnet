using System;

namespace Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions
{
    public class UnauthorizedException : Exception, IHttpStatusException
    {
        public UnauthorizedException(string errorMessage)
        {
            Value = new(401, "Unauthorized", errorMessage);
        }
        public HttpStatusExceptionValue Value { get; set; }
    }
}
