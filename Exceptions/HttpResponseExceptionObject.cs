using System;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class HttpExceptionResponseObject
    {
        public DateTime Timestamp { get; set; }
        public int Status { get; set; }
        public string Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}
