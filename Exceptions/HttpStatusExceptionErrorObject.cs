using System;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class HttpStatusExceptionErrorObject
    {
        public HttpStatusExceptionErrorObject() { Timestamp = DateTime.UtcNow; }
        public HttpStatusExceptionErrorObject(int status, string error, string errorMessage)
        {
            Timestamp = DateTime.UtcNow;
            Status = status;
            Error = error;
            ErrorMessage = errorMessage;
        }
        public DateTime Timestamp { get; set; }
        public int Status { get; set; }
        public string Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}
