namespace TodoMediatorAPI;

public class EntityBase: IEntityBase
{
    public Guid Id { get; set; }

    public DateTime InsertedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; } = false;
}
