using System;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class ExceptionResponse : Exception
    {
        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
}
