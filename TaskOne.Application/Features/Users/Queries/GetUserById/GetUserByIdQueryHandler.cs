using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOne.Application.Abstraction;
using TaskOne.Domain.Entities;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultT<UserEntity>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResultT<UserEntity>> Handle(GetUserByIdQuery requset, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(requset.userId);
            if (user is null)
                return Error.NotFound("User.NotFound", "User Not Found");
            return user;
        }
    }   
}