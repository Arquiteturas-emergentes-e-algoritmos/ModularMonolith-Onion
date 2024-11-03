using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicationPlan.Persistence.Config;

public class MedicationPlanConfig : IEntityTypeConfiguration<Domain.MedicationPlan>
{
    public void Configure(EntityTypeBuilder<Domain.MedicationPlan> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsMany(u => u.Medications);
    }
}
