using Glucometer.Application.Repository;
using Glucometer.Application.Services;
using Glucometer.Persistence;
using Glucometer.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Glucometer;

public static class GlucometerModule
{
    public static IServiceCollection AddGlucometerModule(this IServiceCollection services)
    {
        services.AddTransient<IGlucometerRepository, GlucometerRepository>();
        services.AddTransient<GlucometerService>();

        services.AddDbContext<DataContext>(options =>
        {
        });

        return services;
    }
}
