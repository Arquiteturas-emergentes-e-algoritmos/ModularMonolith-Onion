using User.Application.Repository;

namespace User.Persistence.Repository;

public class UserRepository : IUserRepository
{
    public void Add(Domain.User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Domain.User entity)
    {
        throw new NotImplementedException();
    }

    public List<Domain.User> GetAll()
    {
        throw new NotImplementedException();
    }

    public Domain.User GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Domain.User entity)
    {
        throw new NotImplementedException();
    }
}
