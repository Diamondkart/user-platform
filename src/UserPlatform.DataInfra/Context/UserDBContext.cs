using Microsoft.EntityFrameworkCore;
using UserPlatform.Model;

namespace UserPlatform.DataModel
{
    public class UserDBContext:DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options):base(options)
        {
            
        }
        public DbSet<UserDetails> Users{ get; set; }
    }
}
