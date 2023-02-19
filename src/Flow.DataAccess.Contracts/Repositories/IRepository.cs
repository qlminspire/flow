using System.Linq.Expressions;

namespace Flow.DataAccess.Contracts.Repositories;

public interface IRepository<TEntity>
{
    IQueryable<TEntity> GetAll(bool trackChanges = false);

    IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false);

    void Create(TEntity entity);

    void CreateMany(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void Delete(TEntity entity);

}