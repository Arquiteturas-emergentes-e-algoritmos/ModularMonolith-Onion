using Common.Application.Command;

namespace MedicationPlan.Application.Command;

public class BaseMedicationCommand : ICommandRequest
{
    public Guid UserId { get; set; } = Guid.Empty;
    public virtual bool Validate()
    {
        if (UserId == Guid.Empty) return false;
        return true;
    }
}
