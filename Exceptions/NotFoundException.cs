using System;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class NotFoundException : Exception, IHttpStatusException
    {
        public NotFoundException(string errorMessage)
        {
            ErrorObject = new(404, "Not Found", errorMessage);
        }

        public HttpStatusExceptionErrorObject ErrorObject { get; set; }
    }
}
