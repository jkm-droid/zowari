using Domain.Contracts;
using Infrastructure.Context;
using Infrastructure.Shared.Wrapper;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories.Abstractions;

public interface IRepositoryManager
{
    IRepositoryBase<T> Repository<T>() where T : class, IEntity;

    Task<IDbContextTransaction> BeginTransactionAsync();

    DatabaseContext DbContext();

    Task<IResult> SaveAsync(string errorMessage = "Failed to perform save operation");

    IQueryable<TEntity> Entity<TEntity>() where TEntity : class, IEntity;
}