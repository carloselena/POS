using Blocks.Application.Exceptions;
using Blocks.Domain.Abstractions;
using Blocks.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Blocks.EntityFramework;

public static class RepositoryExtensions
{
    public static async Task<TEntity> FindByIdOrThrowAsync<TEntity, TContext>(
        this GenericRepository<TEntity, TContext> repository, Guid id, string propertyName)
        where TContext : DbContext
        where TEntity : class, IAggregateRoot
    {
        var entity = await repository.FindByIdAsync(id);
        return entity ?? throw new NotFoundException($"Recurso {propertyName} no encontrado");
    }
    
    public static async Task<TEntity> FindByIdOrThrowAsync<TEntity>(this DbSet<TEntity> dbSet, Guid id, string propertyName)
        where TEntity : class, IAggregateRoot
    {
        var entity = await dbSet.FindAsync(id);
        return entity ?? throw new NotFoundException($"Recurso {propertyName} no encontrado");
    }
    
    public static async Task<TEntity> GetByIdOrThrowAsync<TEntity, TContext>(
        this GenericRepository<TEntity, TContext> repository, Guid id, string propertyName)
        where TContext : DbContext
        where TEntity : class, IAggregateRoot
    {
        var entity = await repository.GetByIdAsync(id);
        return entity ?? throw new NotFoundException($"Recurso {propertyName} no encontrado");
    }
}