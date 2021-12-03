﻿using System;

namespace Amir.Apparel.Demo.Api.Dotnet.UtilitiesHttpStatusExceptions
{
    public class ServiceUnavailableException : Exception, IHttpStatusException
    {
        public ServiceUnavailableException(string errorMessage)
        {
            Value = new(503, "Internal Server Error", errorMessage);
        }
        public HttpStatusExceptionValue Value { get; set; }
    }
}
