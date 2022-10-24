using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RLPortalBackend.Exeption;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RLPortalBackend
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            try
            {
                await _next(context);
            } 
            catch (HttpException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpException httpException)
        {
            var code = httpException.Code;
            var result = string.Empty;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = System.Text.Json.JsonSerializer.Serialize(new { error = httpException.Message });
            }

            return context.Response.WriteAsync(result);
        }

        // Extension method used to add the middleware to the HTTP request pipeline.
        
    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }


}
