using MediatR;
using TaskOne.Api.Extensions;
using TaskOne.Application.Features.Users.Queries.GetAllUsers;

namespace TaskOne.Api.EndPoints
{
    public static class GetAllUsersEndpoint
    {
        public static IEndpointRouteBuilder MapGetAllUsersEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/users/GetAllUsers",
                async (ISender sender, CancellationToken cancellationToken) =>
                {
                    var result = await sender.Send(new GetAllUsersQuery(), cancellationToken);
                    return result.ToIResult();
                }
            ).RequireAuthorization();

            return app;
        }
    }
}