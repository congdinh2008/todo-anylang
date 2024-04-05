namespace TodoMediatorAPI;
using MediatR;

public class CategoryCreateCommand : IRequest<bool>
{
    public Guid? Id { get; set; }

    public required string Name { get; set; }
}
