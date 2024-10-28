using Common.Domain;

namespace User.Domain;

public class User : Entity, IObserver
{
    public Guid MedicationPlanId { get; set; } = Guid.Empty;
    public Guid GlucometerId { get; set; } = Guid.Empty;
    public void Update()
    {
    }
}
