using System;

namespace amir_apparel_demo_api_dotnet_5.HttpStatusExceptions
{
    public class ServiceUnavailableException : Exception, IHttpStatusException
    {
        public ServiceUnavailableException(string errorMessage)
        {
            Value = new(503, "Internal Server Error", errorMessage);
        }
        public HttpStatusExceptionValue Value { get; set; }
    }
}
