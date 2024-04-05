namespace TodoAPI;

public class UnitOfWork: IUnitOfWork
{
    private readonly TodoDbContext _context;

    private IGenericRepository<Todo>? _todoRepository;
    
    private IGenericRepository<Category>? _categoryRepository;

    public UnitOfWork(TodoDbContext context)
    {
        _context = context;
    }

    public TodoDbContext Context => _context;

    public IGenericRepository<Todo> TodoRepository => _todoRepository ??= new GenericRepository<Todo>(_context);

    public IGenericRepository<Category> CategoryRepository => _categoryRepository ??= new GenericRepository<Category>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public IGenericRepository<T> GenericRepository<T>() where T : EntityBase
    {
        return new GenericRepository<T>(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
