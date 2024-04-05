namespace TodoMediatorAPI;

public interface IUnitOfWork: IDisposable
{
    TodoDbContext Context { get; }

    IGenericRepository<Todo> TodoRepository { get; }

    IGenericRepository<Category> CategoryRepository { get; }
    
    Task<int> SaveChangesAsync();
    
    int SaveChanges();

    IGenericRepository<T> GenericRepository<T>() where T : EntityBase;
}
