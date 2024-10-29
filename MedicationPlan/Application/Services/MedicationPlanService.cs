using MedicationPlan.Application.Repository;

namespace MedicationPlan.Application.Services;

public class MedicationPlanService(IMedicationPlanRepository medicationPlanRepository)
{
    private readonly IMedicationPlanRepository _medicationPlanRepository = medicationPlanRepository;



}
