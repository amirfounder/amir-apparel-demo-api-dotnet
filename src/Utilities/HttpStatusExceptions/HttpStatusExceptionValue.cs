using System;

namespace Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions
{
    public class HttpStatusExceptionValue
    {
        public HttpStatusExceptionValue() { Timestamp = DateTime.UtcNow; }
        public HttpStatusExceptionValue(int status, string error, string message)
        {
            Timestamp = DateTime.UtcNow;
            Status = status;
            Error = error;
            ErrorMessage = message.EndsWith(".") ? message : $"{message}.";
        }
        public DateTime Timestamp { get; set; }
        public int Status { get; set; }
        public string Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}
