using MediatR;

namespace TodoMediatorAPI;

public class TodoSearchQuery : SearchQuery, IRequest<PaginatedResult<TodoViewModel>>
{
}
