using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }
    
    public DbSet<Todo> Todos { get; set; }

    public DbSet<Category> Categories { get; set; }

    public override int SaveChanges()
    {
        BeforeSaveChanges();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        BeforeSaveChanges();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void BeforeSaveChanges()
    {
        var entities = this.ChangeTracker.Entries();
        foreach (var entry in entities)
        {
            if (entry.Entity is IEntityBase entityBase)
            {
                var now = DateTime.Now;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entityBase.UpdatedAt = now;
                        break;

                    case EntityState.Added:
                        entityBase.InsertedAt = now;
                        entityBase.UpdatedAt = now;
                        break;
                }
            }
        }
    }
}
