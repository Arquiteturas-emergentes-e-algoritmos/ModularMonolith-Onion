using MedicationPlan.Domain;

namespace MedicationPlan.Tests.Domain;

[TestClass]
public class DomainTests
{
    [DataTestMethod]
    [DataRow("2023-01-01T10:00:00", "2023-01-01T09:00:00")]
    [DataRow("2023-01-01T08:00:00", "2023-01-01T11:00:00")]
    public void AddMedication_ShouldAddAndSortMedicationsByTakeAt(string takeAt1, string takeAt2)
    {
        var medicationPlan = new MedicationPlan.Domain.MedicationPlan();
        var medication1 = new Medication { Id = Guid.NewGuid(), TakeAt = DateTime.Parse(takeAt1) };
        var medication2 = new Medication { Id = Guid.NewGuid(), TakeAt = DateTime.Parse(takeAt2) };

        medicationPlan.AddMedication(medication1);
        medicationPlan.AddMedication(medication2);

        Assert.AreEqual(2, medicationPlan.Medications.Count);
    }

    [DataTestMethod]
    [DataRow("2023-01-01T10:00:00")]
    [DataRow("2023-01-01T08:00:00")]
    public void RemoveMedication_ShouldRemoveMedicationById(string takeAt)
    {
        var medicationPlan = new MedicationPlan.Domain.MedicationPlan();
        var medicationId = Guid.NewGuid();
        var medication = new Medication { Id = medicationId, TakeAt = DateTime.Parse(takeAt) };
        medicationPlan.AddMedication(medication);

        medicationPlan.RemoveMedication(medicationId);

        Assert.AreEqual(0, medicationPlan.Medications.Count);
    }

    [DataTestMethod]
    [DataRow("2023-01-01T10:00:00", "2023-01-01T12:00:00")]
    [DataRow("2023-01-01T09:00:00", "2023-01-01T10:30:00")]
    public void UpdateMedication_ShouldUpdateExistingMedicationAndSortByTakeAt(string oldTakeAt, string newTakeAt)
    {
        var medicationPlan = new MedicationPlan.Domain.MedicationPlan();
        var medicationId = Guid.NewGuid();
        var oldMedication = new Medication { Id = medicationId, TakeAt = DateTime.Parse(oldTakeAt) };
        medicationPlan.AddMedication(oldMedication);

        var updatedMedication = new Medication { Id = medicationId, TakeAt = DateTime.Parse(newTakeAt) };
        medicationPlan.UpdateMedication(updatedMedication);

        Assert.AreEqual(1, medicationPlan.Medications.Count);
        Assert.AreEqual(updatedMedication.TakeAt, medicationPlan.Medications[0].TakeAt);
    }
}
