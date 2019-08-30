using System;
using System.Net;

namespace Tt.App.WebMvc.Exceptions
{
    [Serializable]
    internal class HttpRequestFailedException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpRequestFailedException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpRequestFailedException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpRequestFailedException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}