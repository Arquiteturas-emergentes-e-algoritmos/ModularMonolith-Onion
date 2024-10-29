using Common.Application.Command;

namespace MedicationPlan.Application.Command;

public class BaseMedicationCommand : ICommandRequest
{
    public Guid MedicationPlanId { get; set; } = Guid.Empty;
    public virtual bool Validate()
    {
        if (MedicationPlanId == Guid.Empty) return false;
        return true;
    }
}
