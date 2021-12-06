using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions
{
    public class ServerErrorException : Exception, IHttpStatusException
    {
        public ServerErrorException(string errorMessage)
        {
            Value = new(500, "Server Error", errorMessage);
        }

        public HttpStatusExceptionValue Value { get; set; }
    }
}
