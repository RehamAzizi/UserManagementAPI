using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOne.Application.DTOs;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Application.Features.Authentication.Commands
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
        ) : IRequest<ResultT<AuthenticationResponse>>;
}
