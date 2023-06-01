using System.Collections;
using System.Net;
using Domain.Contracts;
using Infrastructure.Context;
using Infrastructure.Extensions;
using Infrastructure.Repositories.Abstractions;
using Infrastructure.Shared.Wrapper;
using LoggerService.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories.Implementations;

public class RepositoryManager : IRepositoryManager
{
    private readonly DatabaseContext _dbContext;
    private readonly ILoggerManager _logger;
    private Hashtable _repositories;

    public RepositoryManager(DatabaseContext dbContext, ILoggerManager logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IRepositoryBase<T> Repository<T>() where T : class, IEntity
    {
        if (_repositories == null)
            _repositories = new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(RepositoryBase<>);

            var repositoryInstance =
                Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

            _repositories.Add(type, repositoryInstance);
        }

        return (IRepositoryBase<T>)_repositories[type];
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _dbContext.Database.BeginTransactionAsync();
    }

    public DatabaseContext DbContext()
    {
        return _dbContext;
    }

    public async Task<IResult> SaveAsync(string errorMessage = "Failed to perform save operation")
    {
        try
        {
            await _dbContext.SaveChangesAsync();
            return await Result.SuccessAsync();
        }
        catch (DbUpdateException ex)
        {
            var error = await ex.HandleException();
            if (error.StatusCode != HttpStatusCode.InternalServerError) return error;

            _logger.LogError($"{errorMessage} {ex.Message} {ex.InnerException?.Message}");
            throw;
        }
    }
    public IQueryable<TEntity> Entity<TEntity>() where TEntity : class, IEntity
    {
        return _dbContext.Set<TEntity>();
    }
}