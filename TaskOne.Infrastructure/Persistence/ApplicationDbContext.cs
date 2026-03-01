using Microsoft.EntityFrameworkCore;
using TaskOne.Domain.Entities;

namespace TaskOne.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<UserEntity> Users { get; set; }
    }
}