using MediatR;

namespace TodoMediatorAPI;

public class TodoGetByIdQuery : IRequest<TodoViewModel>
{
    public Guid Id { get; set; }
}
