using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOne.Application.Abstraction;
using TaskOne.Application.DTOs;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Application.Features.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ResultT<AuthenticationResponse>>
    {
        private readonly IUserRepository _userService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ResultT<AuthenticationResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = _userService.GetByEmail(request.Email);
            if (user is null)
                return Error.NotFound("User.NotFound", "User not found");

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);

            return new AuthenticationResponse(user.Id, user.FirstName, user.LastName, user.Email, token);
        }
    }
}
