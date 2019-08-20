using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Tt.App.WebApi.Infrastructure.Middleware
{
    public class LastRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public LastRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //TODO:

            await _next(context);
        }
    }
}
