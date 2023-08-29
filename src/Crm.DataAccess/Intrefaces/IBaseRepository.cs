namespace Crm.DataAccess;

public interface IBaseRepository<T>
{
    T Create(T entity);
    T? Get(int id);
    List<T> GetAll();
    bool Delete(int id);
}