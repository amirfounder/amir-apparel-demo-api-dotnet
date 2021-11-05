using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class ExceptionResponse
    {
        public ExceptionResponse()
        {
        }
        public HttpStatusCode statusCode { get; set; }
        public string errorMessage { get; set; }
    }
}
