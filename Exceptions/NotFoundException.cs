using System;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class NotFoundException : Exception, IHttpResponseException
    {
        public NotFoundException(string errorMessage)
        {
            ErrorObject = new(status: 404, error: "Not Found", errorMessage: errorMessage);
        }

        public HttpStatusExceptionErrorObject ErrorObject { get; set; }
    }
}
