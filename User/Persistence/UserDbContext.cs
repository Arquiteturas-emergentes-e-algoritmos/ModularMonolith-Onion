using Microsoft.EntityFrameworkCore;

namespace User.Persistence;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    public DbSet<Domain.User> MedicationPlans { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Domain.User>(new MedicationPlanConfig());
    }
}
