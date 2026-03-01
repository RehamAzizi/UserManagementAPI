using MediatR;
using System.Reflection;
using System.Threading.Tasks;
using TaskOne.Api.Extensions;
using TaskOne.Application.Features.Authentication.Queries;

namespace TaskOne.Api.EndPoints
{
    public static class LogInEndpoint
    {
        public static IEndpointRouteBuilder MapLoginEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/auth/login",
                async (LoginQuery request, ISender sender, CancellationToken cancellationToken) =>
                {
                    var result = await sender.Send(request, cancellationToken);
                    return result.ToIResult();
                }
            );

            return app;
        }
    }
}