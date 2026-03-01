using TaskOne.Infrastructure.Persistence;
using TaskOne.Domain.ResultPattern;
using TaskOne.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TaskOne.Application.Abstraction;

namespace TaskOne.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultT<IEnumerable<UserEntity>>> GetAllUserAsync()
            => await _context.Users.ToListAsync();

        public async Task<UserEntity> GetByIdAsync(Guid userId)
            => await _context.Users.FindAsync(userId);
        public UserEntity GetByEmail(string Email)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == Email);
            return user;
        }
        public async Task<ResultT<UserEntity>> CreateUserAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteUserAsync(UserEntity user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}