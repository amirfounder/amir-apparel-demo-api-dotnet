﻿using System;

namespace Amir.Apparel.Demo.Api.Dotnet.Utilities.HttpStatusExceptions
{
    public class HttpStatusExceptionValue
    {
        public HttpStatusExceptionValue() { Timestamp = DateTime.UtcNow; }
        public HttpStatusExceptionValue(int status, string error, string errorMessage)
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
