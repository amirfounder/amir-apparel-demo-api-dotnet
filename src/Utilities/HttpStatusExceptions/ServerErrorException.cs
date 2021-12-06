using System;

namespace Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions
{
    public class ServerErrorException : Exception, IHttpStatusException
    {
        public ServerErrorException(string errorMessage)
        {
            Value = new(500, "Server Error", errorMessage);
        }

        public HttpStatusExceptionValue Value { get; set; }
    }
}
