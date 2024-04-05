using MediatR;

namespace TodoMediatorAPI;

public class CategoryGetAllQuery: IRequest<IEnumerable<CategoryViewModel>>
{
}