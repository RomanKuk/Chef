using System;
using System.Threading.Tasks;
using Chef.BLL.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Chef.API.Middleware
{
    public class GenericExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GenericExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                NotFoundException _ => 404,
                ArgumentNullException _ => 400,
                NullDtoException _ => 400,
                _ => 500
            };

            return context.Response.WriteAsync(exception.Message);
        }
    }
}
