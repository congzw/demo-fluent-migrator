using Microsoft.EntityFrameworkCore;

namespace DemoApp.DataAccess
{
    public class UserDbContext : MainDbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
    }
}