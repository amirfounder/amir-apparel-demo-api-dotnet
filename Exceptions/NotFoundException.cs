using System;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class NotFoundException : Exception, IHttpResponseException
    {
        public NotFoundException(string errorMessage)
        {
            Status = 404;
            ObjectData = new HttpResponseExceptionObject()
            {
                Status = 404,
                Error = "Not Found",
                ErrorMessage = errorMessage,
                Timestamp = DateTime.UtcNow,
            };
        }
        public int Status { get; }
        public object ObjectData { get; set; }
    }
}
