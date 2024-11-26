using Common.Application.Command;
using MedicationPlan.Application.Command;
using MedicationPlan.Application.Repository;
using MedicationPlan.Domain;

namespace MedicationPlan.Application.Services;

public class MedicationPlanService(IMedicationPlanRepository medicationPlanRepository)
{
    private readonly IMedicationPlanRepository _medicationPlanRepository = medicationPlanRepository;

    public ICommandResponse Handle(AddMedicationCommand command)
    {
        Medication medication = new(command.Name, command.TakeAt);
        var MedicationPlan = _medicationPlanRepository.GetById(command.UserId);
        MedicationPlan ??= _medicationPlanRepository.CreateMedicationPlan(command.UserId);
        MedicationPlan.AddMedication(medication);
        _medicationPlanRepository.Update(MedicationPlan);
        return new CommandResponse(null, 200);
    }

    public ICommandResponse Handle(GetMedicationPlanCommand command)
        => new CommandResponse(_medicationPlanRepository.GetById(command.UserId), 200);
    public ICommandResponse Handle(UpdateMedicationCommand command)
    {
        var MedicationPlan = _medicationPlanRepository.GetById(command.UserId);
        MedicationPlan.UpdateMedication(command.Medication);
        _medicationPlanRepository.Update(MedicationPlan);
        return new CommandResponse(null, 200);
    }
    public ICommandResponse Handle(DeleteMedicationCommand command)
    {
        var MedicationPlan = _medicationPlanRepository.GetById(command.UserId);
        MedicationPlan.RemoveMedication(command.MedicationId);
        _medicationPlanRepository.Update(MedicationPlan);
        return new CommandResponse(null, 200);
    }
}
