using Microsoft.EntityFrameworkCore;
using UserPlatform.Domain.Entities;

namespace UserPlatform.Persistence.DBStorage
{
    public class PlatformDBContex : DbContext
    {
        public PlatformDBContex(DbContextOptions<PlatformDBContex> options) : base(options)
        {
        }

        public DbSet<UserDetails> Users { get; set; }
        public DbSet<ChangePassword> ChangePassword { get; set; }
    }
}