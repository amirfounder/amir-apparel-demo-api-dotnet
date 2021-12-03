using System;

namespace Amir.Apparel.Demo.Api.Dotnet.UtilitiesHttpStatusExceptions
{
    public class NotFoundException : Exception, IHttpStatusException
    {
        public NotFoundException(string errorMessage)
        {
            Value = new(404, "Not Found", errorMessage);
        }

        public HttpStatusExceptionValue Value { get; set; }
    }
}
