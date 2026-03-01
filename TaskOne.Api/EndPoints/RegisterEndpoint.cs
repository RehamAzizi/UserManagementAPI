using MediatR;
using System.Reflection.Metadata.Ecma335;
using TaskOne.Api.Extensions;
using TaskOne.Application.DTOs;
using TaskOne.Application.Features.Authentication.Commands;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Api.EndPoints
{
    public static class RegisterEndpoint
    {
        public static IEndpointRouteBuilder MapRegisterEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/auth/register",
                async (RegisterCommand command, ISender sender, CancellationToken cancellationToken) =>
                {
                    var result = await sender.Send(command, cancellationToken);
                    return result.ToIResult();
                }
            );

            return app;
        }
    }
}