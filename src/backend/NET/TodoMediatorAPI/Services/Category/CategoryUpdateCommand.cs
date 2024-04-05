namespace TodoMediatorAPI;
using MediatR;

public class CategoryUpdateCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
}
