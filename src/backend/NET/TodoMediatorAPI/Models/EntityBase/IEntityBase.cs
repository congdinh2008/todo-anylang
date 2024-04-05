namespace TodoMediatorAPI;

public interface IEntityBase
{
    Guid Id { get; set; }

    DateTime InsertedAt { get; set; }

    DateTime UpdatedAt { get; set; }

    bool IsDeleted { get; set; }
}