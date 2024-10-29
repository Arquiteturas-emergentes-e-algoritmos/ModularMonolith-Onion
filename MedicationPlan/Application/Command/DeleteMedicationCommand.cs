namespace MedicationPlan.Application.Command;

public class DeleteMedicationCommand : BaseMedicationCommand
{
    public Guid MedicationId { get; set; } = Guid.Empty;

    public override bool Validate()
    {
        return base.Validate() && MedicationId != Guid.Empty;
    }
}
