using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOne.Domain.Entities;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid userId) : IRequest<ResultT<UserEntity>>;
}