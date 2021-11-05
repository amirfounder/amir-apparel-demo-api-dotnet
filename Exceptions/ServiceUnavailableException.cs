using System;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class ServiceUnavailableException : Exception, IHttpStatusException
    {
        public ServiceUnavailableException(string errorMessage)
        {
            ErrorObject = new(503, "Internal Server Error", errorMessage);            
        }
        public HttpStatusExceptionErrorObject ErrorObject { get; set; }
    }
}
