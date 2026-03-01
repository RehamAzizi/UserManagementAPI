using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOne.Domain.Entities;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Application.Features.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<ResultT<IEnumerable<UserEntity>>>;
}
