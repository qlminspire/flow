using Flow.Domain.Common;

using System.Linq.Expressions;

namespace Flow.Application.Contracts.Persistence.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                 string? includes = null,
                                 bool disableTracking = true,
                                 CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                 List<Expression<Func<TEntity, object>>>? includes = null,
                                 bool disableTracking = true,
                                 CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Create(TEntity entity);

    void CreateMany(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}