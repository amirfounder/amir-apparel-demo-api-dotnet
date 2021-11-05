using System;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class ServiceUnavailableException : Exception, IHttpResponseException
    {
        public ServiceUnavailableException(string errorMessage)
        {
            Status = 503;
            ObjectData = new HttpResponseExceptionObject()
            {
                Status = 503,
                Error = "Internal Server Error",
                ErrorMessage = errorMessage,
                Timestamp = DateTime.UtcNow,
            };
        }

        public int Status { get; }
        public object ObjectData { get; set; }
    }
}
