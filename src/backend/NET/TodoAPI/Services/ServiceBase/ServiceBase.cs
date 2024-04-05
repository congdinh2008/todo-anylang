using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TodoAPI;

public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
{
    protected readonly IUnitOfWork _unitOfWork;   

    public ServiceBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public virtual int Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Add(entity);
        return _unitOfWork.SaveChanges();
    }

    public virtual async Task<int> AddAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Add(entity);
        return await _unitOfWork.SaveChangesAsync();
    }

    public virtual int AddRange(IEnumerable<T> entities)
    {
         foreach (var item in entities)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _unitOfWork.GenericRepository<T>().Add(item);
        }
        return _unitOfWork.SaveChanges();
    }

    public virtual async Task<int> AddRangeAsync(IEnumerable<T> entities)
    {
        foreach (var item in entities)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _unitOfWork.GenericRepository<T>().Add(item);
        }
        return await _unitOfWork.SaveChangesAsync();
    }

    public virtual bool Delete(Guid id, bool isHardDelete = false)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }

        _unitOfWork.GenericRepository<T>().Delete(id, isHardDelete);
        return _unitOfWork.SaveChanges() > 0;
    }

    public virtual bool Delete(T entity, bool isHardDelete = false)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Delete(entity, isHardDelete);
        return _unitOfWork.SaveChanges() > 0;
    }

    public virtual async Task<bool> DeleteAsync(Guid id, bool isHardDelete = false)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }

        _unitOfWork.GenericRepository<T>().Delete(id, isHardDelete);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(T entity, bool isHardDelete = false)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Delete(entity, isHardDelete);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public virtual IEnumerable<T> GetAll(bool isIncludeDeleted = false)
    {
        if (!isIncludeDeleted)
        {
            return _unitOfWork.GenericRepository<T>().GetQuery(x=> x.IsDeleted == isIncludeDeleted).ToList();
        }

        return _unitOfWork.GenericRepository<T>().GetQuery().ToList();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(bool isIncludeDeleted = false)
    {
        if (!isIncludeDeleted)
        {
            return await _unitOfWork.GenericRepository<T>().GetQuery(x=> x.IsDeleted == isIncludeDeleted).ToListAsync();
        }

        return await _unitOfWork.GenericRepository<T>().GetQuery().ToListAsync();
    }

    public virtual async Task<PaginatedResult<T>> GetAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "", int pageIndex = 1, int pageSize = 10)
    {
        var query = _unitOfWork.GenericRepository<T>().Get(filter, orderBy, includeProperties);

        return await PaginatedResult<T>.CreateAsync(query, pageIndex, pageSize);
    }

    public virtual T? GetById(Guid id)
    {
        return _unitOfWork.GenericRepository<T>().GetById(id);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _unitOfWork.GenericRepository<T>().GetByIdAsync(id);
    }

    public virtual bool Update(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Update(entity);
        return _unitOfWork.SaveChanges() > 0;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        _unitOfWork.GenericRepository<T>().Update(entity);
        return await _unitOfWork.SaveChangesAsync() > 0;   
    }
}
