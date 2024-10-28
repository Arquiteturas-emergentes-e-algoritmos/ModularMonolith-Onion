using Common.Domain;

namespace MedicationPlan.Domain;

public class Medication : Entity
{
    public Medication() { }

    public Medication(string name, DateTime takeAt)
    {
        Name = name;
        TakeAt = takeAt;
    }

    public string Name { get; set; } = string.Empty;
    public DateTime TakeAt { get; set; } = DateTime.MaxValue;
}
