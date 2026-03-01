using MediatR;
using System.Threading;
using TaskOne.Api.Extensions;
using TaskOne.Application.Features.Users.Commands.DeleteUser;

namespace TaskOne.Api.EndPoints
{
    public static class DeleteUserEndpoint
    {
        public static IEndpointRouteBuilder MapDeleteUserEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/users/DeleteUser/{id:guid}",
                async(Guid id, ISender sender, CancellationToken cancellationToken) =>
                {
                    var query = new DeleteUserCommand(id);
                    var result = await sender.Send(query, cancellationToken);
                    return result.ToIResult();
                }
            ).RequireAuthorization();

            return app;
        }
    }
}