namespace User.Application.Commands.MedicationPlan;

public class UpdateMedicationCommand : BaseMedicationCommand
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime TakeAt { get; set; } = DateTime.MinValue;
    public override bool Validate()
    {
        if (string.IsNullOrEmpty(Name) || (TakeAt == DateTime.MinValue) || Id == Guid.Empty || !base.Validate()) return false;
        return true;
    }

}
