using System.Net;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Api.Middlewares
{
    public static class ExceptionMapper
    {
        public static (Error, HttpStatusCode) MapException(Exception ex)
        {
            switch (ex)
            {
                case KeyNotFoundException knf:
                    return (Error.NotFound("NOT_FOUND", knf.Message), HttpStatusCode.NotFound);

                case UnauthorizedAccessException ua:
                    return (Error.AccessUnAuthorized("UNAUTHORIZED", ua.Message), HttpStatusCode.Unauthorized);

                case ForbiddenAccessException fa:
                    return (Error.AccessForbidden("FORBIDDEN", fa.Message), HttpStatusCode.Forbidden);

                default:
                    return (Error.Failure("UNEXPECTED_ERROR", "An unexpected error occurred."), HttpStatusCode.InternalServerError);
            }
        }
    }
    public class ForbiddenAccessException : Exception
    {
        public ForbiddenAccessException(string message) : base(message) { }
    }
}
