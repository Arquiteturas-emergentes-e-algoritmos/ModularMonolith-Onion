using Common.Application.Repositories;

namespace MedicationPlan.Application.Repository;

public interface IMedicationPlanRepository : IBaseRepository<Domain.MedicationPlan>
{
    Domain.MedicationPlan CreateMedicationPlan(Guid UserId);

}
