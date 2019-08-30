using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Tt.App.WebMvc.Exceptions;

namespace Tt.App.WebMvc.Infrastructure.Middleware
{
    public class HttpRequestFailedExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<HttpRequestFailedExceptionMiddleware> logger;

        public HttpRequestFailedExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            logger = loggerFactory?.CreateLogger<HttpRequestFailedExceptionMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (HttpRequestFailedException ex)
            {
                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                {
                    logger.LogError(ex, ex.Message);
                    context.Response.Redirect("/");
                    return;
                }

                throw;
            }
        }
    }
}
