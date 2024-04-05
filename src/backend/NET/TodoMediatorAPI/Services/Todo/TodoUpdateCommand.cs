namespace TodoMediatorAPI;
using MediatR;

public class TodoUpdateCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public bool IsCompleted { get; set; }

    public Guid CategoryId { get; set; }
}
