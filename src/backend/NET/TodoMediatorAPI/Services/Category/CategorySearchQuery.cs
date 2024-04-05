using MediatR;

namespace TodoMediatorAPI;

public class CategorySearchQuery : SearchQuery, IRequest<PaginatedResult<CategoryViewModel>>
{
}
