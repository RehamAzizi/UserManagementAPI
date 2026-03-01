using TaskOne.Domain.Entities;
using TaskOne.Domain.ResultPattern;

namespace TaskOne.Application.Abstraction
{
    public interface IUserRepository
    {
        Task<ResultT<IEnumerable<UserEntity>>> GetAllUserAsync();
        Task<UserEntity> GetByIdAsync(Guid userId);
        UserEntity GetByEmail(string Email);
        Task<ResultT<UserEntity>>CreateUserAsync(UserEntity user);
        Task DeleteUserAsync(UserEntity user);
    }
}