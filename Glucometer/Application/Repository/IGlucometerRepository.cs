using Common.Application.Repositories;

namespace Glucometer.Application.Repository;

public interface IGlucometerRepository : IBaseRepository<Domain.Glucometer>
{
    Domain.Glucometer CreateGlucometer(Guid UserId);
}
