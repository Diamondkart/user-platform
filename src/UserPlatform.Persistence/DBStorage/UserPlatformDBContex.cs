using Microsoft.EntityFrameworkCore;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Persistence.DBStorage
{
    public class UserPlatformDBContex : DbContext
    {
        public UserPlatformDBContex(DbContextOptions<UserPlatformDBContex> options) : base(options)
        {
        }

        public DbSet<UserDetails> Users { get; set; }
        public DbSet<ChangePassword> ChangePassword { get; set; }
    }
}