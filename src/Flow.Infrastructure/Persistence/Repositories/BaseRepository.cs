using System.Linq.Expressions;

namespace Flow.Infrastructure.Persistence.Repositories;

internal abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : Entity
{
    private readonly FlowContext _context;
    protected readonly DbSet<TEntity> All;

    protected BaseRepository(FlowContext context)
    {
        _context = context;
        All = _context.Set<TEntity>();
    }

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return All.AsNoTracking().ToListAsync(cancellationToken);
    }

    public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return All.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }

    public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, string? includes = null,
        bool disableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = All;

        if (disableTracking)
            query = query.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(includes))
            query = query.Include(includes);

        if (predicate != null)
            query = query.Where(predicate);

        return orderBy != null
            ? orderBy(query).ToListAsync(cancellationToken)
            : query.ToListAsync(cancellationToken);
    }

    public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        List<Expression<Func<TEntity, object>>>? includes = null, bool disableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = All;

        if (disableTracking)
            query = query.AsNoTracking();

        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null)
            query = query.Where(predicate);

        return orderBy != null
            ? orderBy(query).ToListAsync(cancellationToken)
            : query.ToListAsync(cancellationToken);
    }

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return All.FindAsync(new object?[] { id }, cancellationToken).AsTask();
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
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        All.Remove(entity);
    }

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return All.AnyAsync(predicate, cancellationToken);
    }
}