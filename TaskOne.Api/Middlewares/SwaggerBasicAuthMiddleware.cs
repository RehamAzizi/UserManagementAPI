using System.Net;
using System.Text;
using TaskOne.Api.Constants;

namespace TaskOne.Api.Middlewares
{
    public class SwaggerBasicAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public SwaggerBasicAuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic "))
                {
                    var encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
                    var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));

                    var username = decodedUsernamePassword.Split(':', 2)[0];
                    var password = decodedUsernamePassword.Split(':', 2)[1];

                    if (IsAuthorized(username, password))
                    {
                        context.Request.Headers.Remove("Authorization");

                        context.Response.GetTypedHeaders().CacheControl =
                            new Microsoft.Net.Http.Headers.CacheControlHeaderValue
                            {
                                Public = false,
                                MaxAge = TimeSpan.Zero,
                                NoCache = true,
                                NoStore = true,
                                MustRevalidate = true
                            };

                        await _next(context);
                        return;
                    }
                }
                context.Response.Headers["WWW-Authenticate"] = "Basic";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
            else
            {
                await _next(context);
            }
        }
        public bool IsAuthorized(string username, string password)
        {
            var _userName = _configuration[SettingConstant.SwaggerSetting_UserName];
            var _password = _configuration[SettingConstant.SwaggerSetting_Password];
            return username.Equals(_userName, StringComparison.InvariantCultureIgnoreCase) && password.Equals(_password);
        }
    }
}