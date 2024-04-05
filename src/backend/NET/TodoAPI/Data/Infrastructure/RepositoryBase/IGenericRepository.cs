using System.Linq.Expressions;

namespace TodoAPI;

public interface IGenericRepository<T> where T : class, IEntityBase
{
    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Get IQueryable entities
    /// </summary>
    /// <returns></returns>
    IQueryable<T> GetQuery();


    /// <summary>
    /// Get entities by condition
    /// </summary>
    /// <param name="condition">Condition to get entities</param>
    /// <param name="size">Number of entity to return for each page</param>
    /// <param name="page">Page index</param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetByPageAsync(Expression<Func<T, bool>> condition, int size, int page);

    /// <summary>
    /// Get Queryable entities with filter, order by, include properties and can load deleted
    /// </summary>
    /// <param name="filter">Fiter</param>
    /// <param name="orderBy">Order</param>
    /// <param name="includeProperties">Include Properties</param>
    /// <param name="canLoadDeleted">Can load delete or not</param>
    /// <returns></returns>
    IQueryable<T> Get(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "", bool canLoadDeleted = false);

    /// <summary>
    /// Get entities by condition
    /// </summary>
    /// <param name="where">Condition to get entities</param>
    /// <returns></returns>
    IQueryable<T> GetQuery(Expression<Func<T, bool>> where);

    /// <summary>
    /// Get entity by id
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <returns></returns>
    T? GetById(Guid id);

    /// <summary>
    /// Get entity by id asynchronously
    /// </summary>
    /// <param name="id">Id of the entity</param>
    /// <returns></returns>
    Task<T?> GetByIdAsync(Guid id);

    /// <summary>
    /// Add entity
    /// </summary>
    /// <param name="entity">Entity object to add</param>
    void Add(T entity);

    /// <summary>
    /// Add entities
    /// </summary>
    /// <param name="entities">List of entity to add</param>
    void Add(IEnumerable<T> entities);

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    void Update(T entity);

    /// <summary>
    /// Update entities
    /// </summary>
    /// <param name="entities">List of entity</param>
    void Update(IEnumerable<T> entities);

    /// <summary>
    /// Delete entity by id
    /// </summary>
    /// <param name="id">Id of the entity</param>
    void Delete(Guid id, bool isHardDelete = false);

    /// <summary>
    /// Delete entity
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    /// <param name="isHardDelete">Hard delete or sort delete</param>
    void Delete(T entity, bool isHardDelete = false);

    /// <summary>
    /// Delete entities
    /// </summary>
    /// <param name="entities">List of entity to delete</param>
    /// <param name="isHardDelete">Hard delete or sort delete</param>
    void Delete(IEnumerable<T> entities, bool isHardDelete = false);

    /// <summary>
    /// Delete entities by condition
    /// </summary>
    /// <param name="where">Condition to delete</param>
    /// <param name="isHardDelete">Hard delete or sort delete</param>
    void Delete(Expression<Func<T, bool>> where, bool isHardDelete = false);
}
