using Microsoft.AspNetCore.Mvc;
using MultishopOnion.Application.Exceptions.Base;

namespace MultishopOnion.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (BaseException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.StatusCode;
                var obj = new {statusCode =  ex.StatusCode, message = ex.Message};
                await context.Response.WriteAsJsonAsync(obj);
                
            }
        }
    }
}
