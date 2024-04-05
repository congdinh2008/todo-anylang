using Microsoft.EntityFrameworkCore;

namespace TodoAPI;

public class TodoDbContext: DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options): base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Category> Categories { get; set; }
}
