using MediatR;

namespace TodoMediatorAPI;

public class TodoGetAllQuery: IRequest<IEnumerable<TodoViewModel>>
{
}