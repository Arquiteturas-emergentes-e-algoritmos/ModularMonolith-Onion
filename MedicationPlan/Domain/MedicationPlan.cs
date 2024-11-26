﻿using Common.Domain;

namespace MedicationPlan.Domain;
public class MedicationPlan : Entity
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public List<Medication> Medications { get; set; } = [];
    public DateTime BeginAt { get; set; } = DateTime.UtcNow;
    public DateTime FinishAt { get; set; } = DateTime.MaxValue;

    public void AddMedication(Medication m)
    {
        Medications.Add(m);
        _ = Medications.OrderBy(m => m.TakeAt.TimeOfDay - DateTime.UtcNow.TimeOfDay);
    }

    public void RemoveMedication(Guid Id) => Medications.RemoveAll(m => m.Id == Id);

    public void UpdateMedication(Medication m)
    {
        var medicationFound = Medications.Find(x => x.Id == m.Id);
        if (medicationFound == null) return;
        Medications.Remove(medicationFound);
        Medications.Add(m);
        _ = Medications.OrderBy(t => t.TakeAt.TimeOfDay);
    }
}