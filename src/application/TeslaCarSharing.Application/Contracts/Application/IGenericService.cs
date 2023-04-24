namespace TeslaCarSharing.Application.Contracts.Application;

public interface IGenericService<T>
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<bool> Exists(int id);
}
