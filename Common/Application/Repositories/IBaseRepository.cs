namespace Common.Application.Repositories;
public interface IBaseRepository<T>
{
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    List<T> GetAll();
    T GetById(Guid id);
}