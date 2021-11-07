using System;

namespace amir_apparel_demo_api_dotnet_5.HttpStatusExceptions
{
    public class NotFoundException : Exception, IHttpStatusException
    {
        public NotFoundException(string errorMessage)
        {
            Value = new(404, "Not Found", errorMessage);
        }

        public HttpStatusExceptionErrorValue Value { get; set; }
    }
}
