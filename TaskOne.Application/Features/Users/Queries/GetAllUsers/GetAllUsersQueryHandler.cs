using MediatR;
using TaskOne.Domain.Entities;
using TaskOne.Domain.ResultPattern;
using TaskOne.Application.Abstraction;
using TaskOne.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQuery, ResultT<IEnumerable<UserEntity>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultT<IEnumerable<UserEntity>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllUserAsync();
    }
}