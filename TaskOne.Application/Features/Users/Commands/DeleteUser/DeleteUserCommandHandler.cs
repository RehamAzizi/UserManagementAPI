using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOne.Application.Abstraction;
using TaskOne.Domain.Entities;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultT<UserEntity>>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResultT<UserEntity>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.userId);
            if (user is null)
                return Error.NotFound("User.NotFound", "User Not Found");
            await _userRepository.DeleteUserAsync(user);
            return user;
        }
    }
}