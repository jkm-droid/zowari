using System.Linq.Expressions;
using Domain.Contracts;
using Infrastructure.Abstractions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
{
    private readonly DatabaseContext _dbContext;

    public RepositoryBase(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<T> Entities => _dbContext.Set<T>();

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges ? _dbContext.Set<T>().AsNoTracking() : _dbContext.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges
            ? _dbContext.Set<T>().Where(expression).AsNoTracking()
            : _dbContext.Set<T>().Where(expression);
    }

    public void Create(T entity)
    {
        _dbContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }
}