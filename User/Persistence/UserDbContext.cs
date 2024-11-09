using Microsoft.EntityFrameworkCore;
using User.Persistence.Config;

namespace User.Persistence;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    public DbSet<Domain.User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Domain.User>(new UserConfig());
    }
}
