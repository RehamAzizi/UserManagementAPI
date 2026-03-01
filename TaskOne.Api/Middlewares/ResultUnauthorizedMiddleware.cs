using TaskOne.Domain.ResultPattern;

public class ResultUnauthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public ResultUnauthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
        {
            context.Response.ContentType = "application/json";

            var result = Error.AccessUnAuthorized(
                code: "401",
                description: "You must be logged in to access this resource."
            );
            await context.Response.WriteAsJsonAsync(result);
        }

        if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
        {
            context.Response.ContentType = "application/json";

            var result = Error.AccessForbidden("Forbidden", "User is not authorized");
            await context.Response.WriteAsJsonAsync(result);
        }
    }
}