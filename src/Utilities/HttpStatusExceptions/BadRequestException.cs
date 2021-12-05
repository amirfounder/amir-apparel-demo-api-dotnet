using System;

namespace Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions
{
    public class BadRequestException : Exception, IHttpStatusException
    {
        public BadRequestException(string errorMessage)
        {
            Value = new(400, "Bad Request", errorMessage);
        }

        public HttpStatusExceptionValue Value { get; set; }
    }
}
