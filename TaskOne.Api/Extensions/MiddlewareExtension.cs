using TaskOne.Api.Middlewares;

namespace TaskOne.Api.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication UseCustomMiddlewares(
            this WebApplication app)
        {
            app.UseMiddleware<SwaggerBasicAuthMiddleware>();
            app.UseMiddleware<XssSanitizerMiddleware>();
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<ResultUnauthorizedMiddleware>();

            return app;
        }
    }
}