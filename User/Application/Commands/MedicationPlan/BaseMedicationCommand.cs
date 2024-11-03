using Common.Application.Command;

namespace User.Application.Commands.MedicationPlan;

public class BaseMedicationCommand : ICommandRequest
{
    public Guid MedicationPlanId { get; set; } = Guid.Empty;
    public virtual bool Validate()
    {
        if (MedicationPlanId == Guid.Empty) return false;
        return true;
    }
}
