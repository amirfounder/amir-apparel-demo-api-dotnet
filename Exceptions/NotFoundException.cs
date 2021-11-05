using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amir_apparel_demo_api_dotnet_5.Exceptions
{
    public class NotFoundException : Exception, IHttpResponseException
    {
        public NotFoundException(string errorMessage)
        {
            Status = 404;
            ObjectData = new HttpExceptionResponseObject()
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
