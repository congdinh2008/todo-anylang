using System.Linq.Expressions;

namespace TodoMediatorAPI;

public interface IServiceBase<T> where T : EntityBase
{
    /// <summary>
    /// Add new entity
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <returns></returns>
    int Add(T entity);

    /// <summary>
    /// Add new entity
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <returns></returns>
    Task<int> AddAsync(T entity);

    /// <summary>
    /// Add new entities
    /// </summary>
    /// <param name="entities">Entities to add</param>
    /// <returns></returns>
    int AddRange(IEnumerable<T> entities);

    /// <summary>
    /// Add new entities
    /// </summary>
    /// <param name="entities">Entities to add</param>
    /// <returns></returns>
    Task<int> AddRangeAsync(IEnumerable<T> entities);

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <returns></returns>
    bool Update(T entity);

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <returns></returns>
    Task<bool> UpdateAsync(T entity);

    /// <summary>
    /// Delete entity by id
    /// </summary>
    /// <param name="id">Id of entity to delete</param>
    /// <returns></returns>
    bool Delete(Guid id, bool isHardDelete = false);

    /// <summary>
    /// Delete entity by id
    /// </summary>
    /// <param name="id">Id of entity to delete</param>
    /// <returns></returns>
    Task<bool> DeleteAsync(Guid id, bool isHardDelete = false);

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    /// <returns></returns>
    bool Delete(T entity, bool isHardDelete = false);

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    /// <returns></returns>
    Task<bool> DeleteAsync(T entity, bool isHardDelete = false);

    /// <summary>
    /// Get entity by id
    /// </summary>
    /// <param name="id">Id of entity</param>
    /// <returns></returns>
    T? GetById(Guid id);

    /// <summary>
    /// Get entity by id
    /// </summary>
    /// <param name="id">Id of entity</param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(Guid id);

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <param name="isIncludeDeleted">Is include deleted entity</param>
    /// <returns></returns>
    IEnumerable<T> GetAll(bool isIncludeDeleted = false);

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <param name="isIncludeDeleted">Is include deleted entity</param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync(bool isIncludeDeleted = false);

    /// <summary>
    /// Get entities with paging, filtering, ordering
    /// </summary>
    /// <param name="filter">Filter condition</param>
    /// <param name="orderBy">Order by property</param>
    /// <param name="includeProperties">Include properties</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <returns></returns>
    Task<PaginatedResult<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string includeProperties = "", int pageIndex = 1, int pageSize = 10);
}
