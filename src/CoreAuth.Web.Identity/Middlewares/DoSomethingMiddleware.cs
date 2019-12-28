using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CoreAuth.Web.Identity.Middlewares
{
    public class DoSomethingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<DoSomethingMiddleware> _logger;

        public DoSomethingMiddleware(RequestDelegate next, ILogger<DoSomethingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            _logger.LogCritical($"DoSomething er middleware called...");
            _logger.LogCritical($"cookie value :{httpContext.Request.Cookies["identity-cookie"]}");
            await _next(httpContext);
            _logger.LogCritical($"DoSomething lt middleware called...");
        }
    }
    public static class RegisterMiddlewareExtentions
    {        
        public static IApplicationBuilder UseDoSomething(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DoSomethingMiddleware>();
        }
        public static void Anything(IApplicationBuilder app)
        {
            app.Run(async (context)=> {
                await context.Response.WriteAsync("done Anythings get called...");
            });
        }
    }
}
