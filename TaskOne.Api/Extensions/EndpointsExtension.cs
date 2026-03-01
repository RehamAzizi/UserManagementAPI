using TaskOne.Api.EndPoints;

namespace TaskOne.Api.Extensions
{
    public static class EndpointsExtension
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            app.MapGetAllUsersEndpoint();
            app.MapGetUserByIdEndpoint();
            app.MapRegisterEndpoint();
            app.MapLoginEndpoint();
            app.MapDeleteUserEndpoint();
            
            return app;
        }
    }
}