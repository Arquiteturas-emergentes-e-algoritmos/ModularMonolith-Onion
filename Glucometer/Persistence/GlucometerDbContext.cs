using Glucometer.Persistence.Config;
using Microsoft.EntityFrameworkCore;

namespace Glucometer.Persistence;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Domain.Glucometer> Glucometers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Domain.Glucometer>(new GlucometerConfig());
    }
}