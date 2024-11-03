using Common.Application.Repositories;

namespace User.Application.Repository;

public interface IUserRepository : IBaseRepository<Domain.User>
{
}
