using MediatR;
using TaskOne.Api.Extensions;
using TaskOne.Application.Features.Users.Queries.GetUserById;

namespace TaskOne.Api.EndPoints
{
    public static class GetUserByIdEndpoint
    {
        public static IEndpointRouteBuilder MapGetUserByIdEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/users/GetUserById/{id:guid}",
                async(Guid id, ISender sender, CancellationToken cancellationToken) =>
                {
                var query = new GetUserByIdQuery(id);
                var result = await sender.Send(query, cancellationToken);
                return result.ToIResult();
                }
            ).RequireAuthorization();

            return app;
        }
    }
}