using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityBase
{
    #region Protected Fields

    protected readonly TodoDbContext _context;
    private readonly DbSet<T> _dbSet;

    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryBase{T, TDbContext}"/> class.
    /// </summary>
    /// <param name="context">The data context.</param>
    public GenericRepository(TodoDbContext context)
    {
        _context = context;

        // Find Property with typeof(T) on dataContext
        var typeOfDbSet = typeof(DbSet<T>);

        foreach (var prop in context.GetType().GetProperties())
        {
            if (typeOfDbSet == prop.PropertyType)
            {
                var value = prop.GetValue(context, null) as DbSet<T>;
                if (value != null)
                {
                    _dbSet = value;
                }
                break;
            }
        }

        if (_dbSet == null)
        {
            _dbSet = context.Set<T>();
        }
    }

    #region Public Methods

    #region Create, Update, Delete
    public virtual void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Add(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Update(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public virtual void Delete(Guid id, bool isHardDelete = false)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            if (isHardDelete)
            {
                _dbSet.Remove(entity);
            }
            else
            {
                entity.IsDeleted = true;
                _dbSet.Update(entity);
            }
        }
    }

    public virtual void Delete(T entity, bool isHardDelete = false)
    {
        if (isHardDelete)
        {
            _dbSet.Remove(entity);
        }
        else
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }
    }

    public virtual void Delete(IEnumerable<T> entities, bool isHardDelete = false)
    {
        if (isHardDelete)
        {
            _dbSet.RemoveRange(entities);
        }
        else
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                _dbSet.Update(entity);
            }
        }
    }

    public virtual void Delete(Expression<Func<T, bool>> where, bool isHardDelete = false)
    {
        var entities = _dbSet.Where(where).ToList();
        Delete(entities, isHardDelete);
    }

    #endregion

    #region Get and Search

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual T? GetById(Guid id)
    {
        
        return _dbSet.Find(id);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<T> GetQuery()
    {
        return _dbSet.AsQueryable();
    }

    public virtual IQueryable<T> GetQuery(Expression<Func<T, bool>> condition)
    {
        IQueryable<T> query = _dbSet;

        if (condition != null)
        {
            query = query.Where(condition);
        }

        return query;
    }

    public virtual async Task<IEnumerable<T>> GetByPageAsync(Expression<Func<T, bool>> condition, int size, int page)
    {
        return await _dbSet.Where(condition).Skip(size * (page - 1)).Take(size).ToListAsync();
    }

    public virtual IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", bool canLoadDeleted = false)
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (canLoadDeleted == false)
        {
            query = query.Where(x => x.IsDeleted == canLoadDeleted);
        }

        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        return orderBy != null ? orderBy(query) : query;
    }

    #endregion

    #endregion
}
