using Microsoft.EntityFrameworkCore;

namespace DemoApp.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Org> Orgs { get; set; }
        public DbSet<Site> Sites { get; set; }
    }

    public class Org
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
