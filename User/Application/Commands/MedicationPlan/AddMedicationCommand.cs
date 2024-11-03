namespace User.Application.Commands.MedicationPlan;
public class AddMedicationCommand : BaseMedicationCommand
{
    public string Name { get; set; } = string.Empty;
    public DateTime TakeAt { get; set; } = DateTime.MinValue;

    public override bool Validate()
    {
        if (string.IsNullOrEmpty(Name) || TakeAt == DateTime.MinValue || !base.Validate()) return false;
        return true;
    }
}