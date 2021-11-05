using System;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class ServiceUnavailableException : Exception, IHttpResponseException
    {
        public ServiceUnavailableException(string errorMessage)
        {
            ErrorObject = new()
            {
                Status = 503,
                Error = "Service Unavailable",
                ErrorMessage = errorMessage,
                Timestamp = DateTime.UtcNow
            };
        }
        public HttpStatusExceptionErrorObject ErrorObject { get; set; }
    }
}
