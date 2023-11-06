namespace Crm.DataAccess;

public interface IBaseRepository<T>
{
    T Create(T entity);
    T? Get(int id);
    List<T> GetAll();
    bool Delete(int id);

    Task<T> CreateAsync(T entity, CancellationToken token = default);
    Task<T>? GetAsync(int id, CancellationToken token = default);
    Task<List<T>> GetAllAsync(CancellationToken token = default);
    ValueTask<bool> DeleteAsync(int id, CancellationToken token = default);
}