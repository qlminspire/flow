using Flow.Domain.Common;

using System.Linq.Expressions;

namespace Flow.Application.Contracts.Persistence.Repositories;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> GetAll(bool trackChanges = false);

    IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false);

    IQueryable<TEntity> GetById(Guid id);

    void Create(TEntity entity);

    void CreateMany(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void Delete(TEntity entity);

}