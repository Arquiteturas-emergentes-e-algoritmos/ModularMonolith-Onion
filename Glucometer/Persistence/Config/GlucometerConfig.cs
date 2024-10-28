using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Glucometer.Persistence.Config;

public class GlucometerConfig : IEntityTypeConfiguration<Domain.Glucometer>
{
    public void Configure(EntityTypeBuilder<Domain.Glucometer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsMany(u => u.GlucoseTests);
    }
}