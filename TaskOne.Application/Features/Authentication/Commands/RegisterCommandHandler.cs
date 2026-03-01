using MediatR;
using TaskOne.Application.Abstraction;
using TaskOne.Application.DTOs;
using TaskOne.Domain.Entities;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Application.Features.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResultT<AuthenticationResponse>>
    {
        private readonly IUserRepository _userService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public RegisterCommandHandler(IUserRepository userService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ResultT<AuthenticationResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if(_userService.GetByEmail(request.Email) is not null)
                return Error.Conflict("User.AlreadyExists","A user with this email already exists");
            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };
            _userService.CreateUserAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
            return new AuthenticationResponse(user.Id, user.FirstName, user.LastName, user.Email, token);
        }
    }
}