using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Flow.Application.Persistence.Repositories;
using Flow.Domain.Common;

namespace Flow.Infrastructure.Persistence.Repositories;

internal abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<Guid>
{
    protected readonly FlowContext Context;
    protected readonly DbSet<TEntity> All;

    protected BaseRepository(FlowContext context)
    {
        Context = context;
        All = Context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll(bool trackChanges = false)
    {
        return trackChanges ? All : All.AsNoTracking();
    }

    public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false)
    {
        return GetAll(trackChanges).Where(expression);
    }

    public IQueryable<TEntity> GetById(Guid id)
    {
        return GetByCondition(x => x.Id == id, true);
    }

    public void Create(TEntity entity)
    {
        All.Add(entity);
    }

    public void CreateMany(IEnumerable<TEntity> entities)
    {
        All.AddRange(entities);
    }

    public void Update(TEntity entity)
    {

    }

    public void Delete(TEntity entity)
    {
        All.Remove(entity);
    }


}
