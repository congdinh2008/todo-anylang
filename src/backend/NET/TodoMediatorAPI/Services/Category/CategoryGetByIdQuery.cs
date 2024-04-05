using MediatR;

namespace TodoMediatorAPI;

public class CategoryGetByIdQuery : IRequest<CategoryViewModel>
{
    public Guid Id { get; set; }
}
