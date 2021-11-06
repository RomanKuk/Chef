using System;
using System.Net;

namespace Chef.API.Extensions
{
    public static class ExceptionFilterExtensions
    {
        public static (HttpStatusCode statusCode, ErrorCode errorCode) ParseException(this Exception exception)
        {
            return exception switch
            {
                //NotFoundException _ => (HttpStatusCode.NotFound, ErrorCode.NotFound),
                ArgumentException _ => (HttpStatusCode.BadRequest, ErrorCode.Argument),
                _ => (HttpStatusCode.InternalServerError, ErrorCode.General),
            };
        }
    }
    public enum ErrorCode
    {
        General = 1,
        NotFound,
        Argument
    }
}
