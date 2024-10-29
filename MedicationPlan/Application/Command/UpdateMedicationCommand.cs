using MedicationPlan.Domain;

namespace MedicationPlan.Application.Command;

public class UpdateMedicationCommand : BaseMedicationCommand
{
    public Medication Medication { get; set; } = new();

    public override bool Validate()
    {
        if (string.IsNullOrEmpty(Medication.Name) || (Medication.TakeAt == DateTime.MinValue) || !base.Validate()) return false;
        return true;
    }

}
