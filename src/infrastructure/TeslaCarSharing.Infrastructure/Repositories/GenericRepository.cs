﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaCarSharing.Application.Contracts.Infrastructure;

namespace TeslaCarSharing.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly TeslaCarSharingDbContext _dbContext;

    public GenericRepository(TeslaCarSharingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> Add(T entity)
    {
        await _dbContext.AddAsync(entity);
        return entity;
    }

    public virtual async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public virtual async Task<bool> Exists(int id)
    {
        var entity = await Get(id);
        return entity != null;
    }

    public virtual async Task<T> Get(int id)
    {
        var entity = await _dbContext.FindAsync<T>(id);
        return entity;
    }

    public virtual async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}
