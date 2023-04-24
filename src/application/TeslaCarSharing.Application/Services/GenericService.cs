
using TeslaCarSharing.Application.Contracts.Application;
using TeslaCarSharing.Application.Contracts.Infrastructure;

namespace TeslaCarSharing.Application.Services;

public class GenericService<T> : IGenericService<T> where T : class
{
    private readonly IGenericRepository<T> _repository;

    public GenericService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public virtual async Task<T> Get(int id)
    {
        return await _repository.Get(id);
    }

    public virtual async Task<IReadOnlyList<T>> GetAll()
    { 
        return await _repository.GetAll();
    }

    public virtual async Task<T> Add(T entity)
    {
        await _repository.Add(entity);
        return entity;
    }

    public virtual async Task Update(T entity)
    {
        await _repository.Update(entity);
    }

    public virtual async Task Delete(T entity)
    {
        await _repository.Delete(entity);
    }

    public virtual async Task<bool> Exists(int id)
    {
        return await _repository.Exists(id);
    }
}
