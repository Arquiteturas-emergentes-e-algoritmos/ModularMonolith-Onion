using MedicationPlan.Application.Repository;
using MedicationPlan.Application.Services;
using MedicationPlan.Persistence;
using MedicationPlan.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationPlan;

public static class MedicationPlanModule
{
    public static IServiceCollection AddMedicationPlanModule(this IServiceCollection services)
    {
        services.AddTransient<IMedicationPlanRepository, MedicationPlanRepository>();
        services.AddTransient<MedicationPlanService>();

        services.AddDbContext<MedicationPlanDbContext>(options =>
        {
        });

        return services;
    }
}
