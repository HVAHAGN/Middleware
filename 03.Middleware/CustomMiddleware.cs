using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string method = context.Request.Method;
            if (method=="GET")
            {
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Request method is GET!");

            }
            else
            {
               await _next.Invoke(context);
            }

        }
    }
}
